using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;
using static PhoneStoreDAL.Entities.Enums;

namespace PhoneStoreViews
{
    public partial class frmImeiUnits : Form
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        private string selectedImei = "";
        public frmImeiUnits()
        {
            InitializeComponent();
        }

        private async void frmImeiUnits_Load(object sender, EventArgs e)
        {
            await LoadVariantComboAsync();
            await LoadGridAsync();
            ClearUI();

        }
        private async Task LoadVariantComboAsync()
        {
            var data = await context.ProductVariants.AsNoTracking()
                .OrderBy(x => x.Sku)
                .Select(x => new { x.ProductVariantId, x.Sku })
                .ToListAsync();

            cboProductVariant.DataSource = data;
            cboProductVariant.DisplayMember = "Sku";
            cboProductVariant.ValueMember = "ProductVariantId";
            cboProductVariant.SelectedIndex = -1;
        }

        private async Task LoadGridAsync()
        {
            var data = await context.ImeiUnits.AsNoTracking()
                .Include(x => x.ProductVariant)
                .OrderByDescending(x => x.WarrantyStartDate)
                .Select(x => new
                {
                    x.Imei,
                    x.ProductVariantId,
                    Sku = x.ProductVariant != null ? x.ProductVariant.Sku : "",
                    x.Status,
                    x.WarrantyStartDate,
                    x.WarrantyMonths,
                    x.ReceivedInPurchaseInvoiceId
                })
                .ToListAsync();

            dgvImei.AutoGenerateColumns = true;
            dgvImei.DataSource = data;
            dgvImei.ClearSelection();
        }

        private void ClearUI()
        {
            selectedImei = "";
            txtImei.Text = "";
            txtStatus.Text = ""; // designer có, không map entity (bạn dùng mô tả riêng nếu muốn)
           
            txtKeyWord.Text = "";
            txtReceivedPurchaseInvoiceId.Text = "";

            numWarrantyMonths.Value = 12;
            dtpWarrantyStart.Value = DateTime.Now;

            cboProductVariant.SelectedIndex = -1;
        }

        private bool ValidateInputForAdd()
        {
            if (string.IsNullOrWhiteSpace(txtImei.Text))
            {
                MessageBox.Show("IMEI không được để trống!");
                txtImei.Focus();
                return false;
            }
            if (cboProductVariant.SelectedValue == null)
            {
                MessageBox.Show("Chọn ProductVariant!");
                cboProductVariant.Focus();
                return false;
            }
            return true;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = (txtKeyWord.Text ?? "").Trim();

            var q = context.ImeiUnits.AsNoTracking().Include(x => x.ProductVariant).AsQueryable();
            if (!string.IsNullOrWhiteSpace(kw))
            {
                q = q.Where(x =>
                    (x.Imei ?? "").Contains(kw) ||
                    (x.ProductVariant != null && (x.ProductVariant.Sku ?? "").Contains(kw)));
            }

            dgvImei.DataSource = await q
                .OrderByDescending(x => x.WarrantyStartDate)
                .Select(x => new
                {
                    x.Imei,
                    x.ProductVariantId,
                    Sku = x.ProductVariant != null ? x.ProductVariant.Sku : "",
                    x.Status,
                    x.WarrantyStartDate,
                    x.WarrantyMonths,
                    x.ReceivedInPurchaseInvoiceId
                })
                .ToListAsync();

            dgvImei.ClearSelection();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var imei = (txtImei.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(imei))
            {
                MessageBox.Show("Nhập IMEI!");
                return;
            }

            var val = cboProductVariant.SelectedValue;
            if (val == null || !int.TryParse(val.ToString(), out var variantId) || variantId <= 0)
            {
                MessageBox.Show("Chọn ProductVariant hợp lệ!");
                return;
            }

            if (!await context.ProductVariants.AnyAsync(x => x.ProductVariantId == variantId))
            {
                MessageBox.Show("ProductVariantId không tồn tại trong DB!");
                return;
            }

            if (!int.TryParse((txtStatus.Text ?? "").Trim(), out var st) || !Enum.IsDefined(typeof(ImeiStatus), st))
            {
                MessageBox.Show("Status không hợp lệ! Chỉ được: 0(InStock), 1(Sold), 2(InWarranty)");
                return;
            }

            var unit = new ImeiUnit
            {
                Imei = imei,
                ProductVariantId = variantId,
                Status = (ImeiStatus)st,
                WarrantyMonths = 12,
                ReceivedInPurchaseInvoiceId = null
            };

            try
            {
                context.ImeiUnits.Add(unit);
                await context.SaveChangesAsync();
                MessageBox.Show("Thêm thành công!");
                await LoadGridAsync();
                ClearUI();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedImei))
            {
                MessageBox.Show("Chọn IMEI trước!");
                return;
            }

            if (cboProductVariant.SelectedValue == null)
            {
                MessageBox.Show("Chọn ProductVariant!");
                return;
            }

            var unit = await context.ImeiUnits.FirstOrDefaultAsync(x => x.Imei == selectedImei);
            if (unit == null)
            {
                MessageBox.Show("Không tìm thấy IMEI trong DB!");
                return;
            }

            // ✅ lấy ProductVariantId an toàn
            var vVal = cboProductVariant.SelectedValue;
            if (vVal == null || !int.TryParse(vVal.ToString(), out var variantId) || variantId <= 0)
            {
                MessageBox.Show("ProductVariant không hợp lệ!");
                return;
            }

            // ✅ check tồn tại ProductVariantId (tránh FK fail)
            if (!await context.ProductVariants.AnyAsync(x => x.ProductVariantId == variantId))
            {
                MessageBox.Show("ProductVariantId không tồn tại trong DB!");
                return;
            }

            // ✅ đọc purchaseId (nullable) + check tồn tại nếu có nhập
            int? purchaseId = null;
            var txt = (txtReceivedPurchaseInvoiceId.Text ?? "").Trim();
            if (!string.IsNullOrWhiteSpace(txt))
            {
                if (!int.TryParse(txt, out var pid) || pid <= 0)
                {
                    MessageBox.Show("PurchaseInvoiceId không hợp lệ!");
                    return;
                }

                bool purchaseExists = await context.PurchaseInvoices.AnyAsync(x => x.PurchaseInvoiceId == pid);
                if (!purchaseExists)
                {
                    MessageBox.Show("PurchaseInvoiceId không tồn tại trong DB!");
                    return;
                }

                purchaseId = pid;
            }

            // ✅ gán sau khi đã validate hết
            unit.ProductVariantId = variantId;
            unit.WarrantyStartDate = dtpWarrantyStart.Value;
            unit.WarrantyMonths = (int)numWarrantyMonths.Value;
            unit.ReceivedInPurchaseInvoiceId = purchaseId;
            if (!int.TryParse((txtStatus.Text ?? "").Trim(), out var st) || !Enum.IsDefined(typeof(ImeiStatus), st))
            {
                MessageBox.Show("Status không hợp lệ! Chỉ được: 0(InStock), 1(Sold), 2(InWarranty)");
                return;
            }

            unit.Status = (ImeiStatus)st;   // hoặc = st nếu Status là int


            try
            {
                await context.SaveChangesAsync();
                MessageBox.Show("Sửa thành công!");
                await LoadGridAsync();
                ClearUI();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }


        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedImei))
            {
                MessageBox.Show("Chọn IMEI trong bảng trước!");
                return;
            }

            if (MessageBox.Show("Xóa IMEI này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var unit = await context.ImeiUnits.FirstOrDefaultAsync(x => x.Imei == selectedImei);
            if (unit == null) { MessageBox.Show("Không tìm thấy IMEI!"); return; }

            context.ImeiUnits.Remove(unit);
            await context.SaveChangesAsync();

            MessageBox.Show("Xóa thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private void dgvImei_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvImei.CurrentRow == null) return;

            selectedImei = dgvImei.CurrentRow.Cells["Imei"].Value?.ToString() ?? "";
            txtImei.Text = selectedImei;

            if (dgvImei.CurrentRow.Cells["ProductVariantId"]?.Value != null)
                cboProductVariant.SelectedValue = Convert.ToInt32(dgvImei.CurrentRow.Cells["ProductVariantId"].Value);

            if (dgvImei.CurrentRow.Cells["WarrantyMonths"]?.Value != null)
                numWarrantyMonths.Value = Convert.ToDecimal(dgvImei.CurrentRow.Cells["WarrantyMonths"].Value);

            if (DateTime.TryParse(dgvImei.CurrentRow.Cells["WarrantyStartDate"]?.Value?.ToString(), out var dt))
                dtpWarrantyStart.Value = dt;
            txtStatus.Text = dgvImei.CurrentRow.Cells["Status"]?.Value?.ToString() ?? "0";


            txtReceivedPurchaseInvoiceId.Text = dgvImei.CurrentRow.Cells["ReceivedInPurchaseInvoiceId"]?.Value?.ToString() ?? "";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
