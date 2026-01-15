using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;

namespace PhoneStoreViews
{
    public partial class frmProductVariant : Form
    {
        private int selectedProductVariantID = 0;

        public frmProductVariant()
        {
            InitializeComponent();

            // đảm bảo event chạy
            this.Load += frmProductVariant_Load;
            this.FormClosed += frmProductVariant_FormClosed;

           
        }

        public async Task ReloadGridFromOutsideAsync()
        {
            await LoadGridAsync();
        }

        private void frmProductVariant_FormClosed(object sender, FormClosedEventArgs e)
        {
            // không giữ DbContext nên không cần Dispose context ở đây
        }

        private async void frmProductVariant_Load(object sender, EventArgs e)
        {
            await LoadProductLineComboAsync();
            await LoadGridAsync();
            ClearUI();
        }

        private async Task LoadProductLineComboAsync()
        {
            using (var db = new PhoneStoreDBContext())
            {
                var data = await db.ProductLines.AsNoTracking()
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                cboProductLine.DataSource = data;
                cboProductLine.DisplayMember = "Name";
                cboProductLine.ValueMember = "ProductLineId";
                cboProductLine.SelectedIndex = -1;
            }
        }

        private async Task LoadGridAsync()
        {
            using (var db = new PhoneStoreDBContext())
            {
                var data = await db.ProductVariants.AsNoTracking()
                    .Include(x => x.ProductLine)
                    .Select(x => new
                    {
                        x.ProductVariantId,
                        x.ProductLineId,
                        ProductLineName = x.ProductLine != null ? x.ProductLine.Name : "",

                        x.Sku,
                        x.Color,
                        x.StorageGb,
                        x.SalePrice,

                        // ✅ clamp hiển thị: âm -> 0
                        QuantityInStock = x.QuantityInStock < 0 ? 0 : x.QuantityInStock,

                        StockStatus = (x.QuantityInStock < 0 ? 0 : x.QuantityInStock) <= 0
                            ? "Hết hàng"
                            : "Còn hàng"
                    })
                    .OrderByDescending(x => x.ProductVariantId)
                    .ToListAsync();

                dgvProductVariant.AutoGenerateColumns = true;
                dgvProductVariant.DataSource = null;
                dgvProductVariant.DataSource = data;
                dgvProductVariant.ClearSelection();
            }
        }

        private void ClearUI()
        {
            selectedProductVariantID = 0;
            txtProductLinesId.Text = "";
            txtSku.Text = "";
            txtColor.Text = "";
            numStorageGb.Value = 1;
            numSalePrice.Value = 0;
            cboProductLine.SelectedIndex = -1;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtSku.Text))
            {
                MessageBox.Show("SKU không được để trống!");
                txtSku.Focus();
                return false;
            }
            if (cboProductLine.SelectedValue == null)
            {
                MessageBox.Show("Chọn ProductLine!");
                cboProductLine.Focus();
                return false;
            }
            if (numStorageGb.Value <= 0)
            {
                MessageBox.Show("StorageGb phải > 0!");
                return false;
            }
            if (numSalePrice.Value < 0)
            {
                MessageBox.Show("SalePrice phải >= 0!");
                return false;
            }
            return true;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = (txtKeyWord.Text ?? "").Trim();

            using (var db = new PhoneStoreDBContext())
            {
                var q = db.ProductVariants.AsNoTracking()
                    .Include(x => x.ProductLine)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(kw))
                {
                    q = q.Where(x =>
                        (x.Sku ?? "").Contains(kw) ||
                        (x.Color ?? "").Contains(kw) ||
                        (x.ProductLine != null && (x.ProductLine.Name ?? "").Contains(kw)));
                }

                var data = await q
                    .OrderByDescending(x => x.ProductVariantId)
                    .Select(x => new
                    {
                        x.ProductVariantId,
                        x.ProductLineId,
                        ProductLineName = x.ProductLine != null ? x.ProductLine.Name : "",

                        x.Sku,
                        x.Color,
                        x.StorageGb,
                        x.SalePrice,

                        QuantityInStock = x.QuantityInStock < 0 ? 0 : x.QuantityInStock,
                        StockStatus = (x.QuantityInStock < 0 ? 0 : x.QuantityInStock) <= 0 ? "Hết hàng" : "Còn hàng"
                    })
                    .ToListAsync();

                dgvProductVariant.DataSource = null;
                dgvProductVariant.DataSource = data;
                dgvProductVariant.ClearSelection();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            using (var db = new PhoneStoreDBContext())
            {
                var v = new ProductVariant
                {
                    ProductLineId = (int)cboProductLine.SelectedValue,
                    Sku = (txtSku.Text ?? "").Trim(),
                    Color = (txtColor.Text ?? "").Trim(),
                    StorageGb = (int)numStorageGb.Value,
                    SalePrice = numSalePrice.Value,

                    // ✅ mặc định tồn kho khi tạo mới là 0 (để nhập hàng qua PurchaseInvoice)
                    QuantityInStock = 0
                };

                db.ProductVariants.Add(v);
                await db.SaveChangesAsync();
            }

            MessageBox.Show("Thêm thành công!");
            await LoadGridAsync();
            ClearUI();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProductVariantID <= 0)
            {
                MessageBox.Show("Chọn Variant trong bảng trước!");
                return;
            }
            if (!ValidateInput()) return;

            using (var db = new PhoneStoreDBContext())
            {
                var v = await db.ProductVariants.FirstOrDefaultAsync(x => x.ProductVariantId == selectedProductVariantID);
                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy Variant!");
                    return;
                }

                v.ProductLineId = (int)cboProductLine.SelectedValue;
                v.Sku = (txtSku.Text ?? "").Trim();
                v.Color = (txtColor.Text ?? "").Trim();
                v.StorageGb = (int)numStorageGb.Value;
                v.SalePrice = numSalePrice.Value;

                // ✅ đảm bảo tồn kho không âm trong DB (nếu bị âm do nghiệp vụ)
                if (v.QuantityInStock < 0) v.QuantityInStock = 0;

                await db.SaveChangesAsync();
            }

            MessageBox.Show("Sửa thành công!");
            await LoadGridAsync();
            ClearUI();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductVariantID <= 0)
            {
                MessageBox.Show("Chọn Variant trong bảng trước!");
                return;
            }

            if (MessageBox.Show("Xóa Variant này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (var db = new PhoneStoreDBContext())
            {
                var v = await db.ProductVariants.FirstOrDefaultAsync(x => x.ProductVariantId == selectedProductVariantID);
                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy Variant!");
                    return;
                }

                db.ProductVariants.Remove(v);
                await db.SaveChangesAsync();
            }

            MessageBox.Show("Xóa thành công!");
            await LoadGridAsync();
            ClearUI();
        }

        // ✅ Đổi sang CellClick
        private void dgvProductVariant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductVariant.CurrentRow == null) return;

            selectedProductVariantID = Convert.ToInt32(dgvProductVariant.CurrentRow.Cells["ProductVariantId"].Value);
            txtProductLinesId.Text = selectedProductVariantID.ToString();

            txtSku.Text = dgvProductVariant.CurrentRow.Cells["Sku"].Value?.ToString() ?? "";
            txtColor.Text = dgvProductVariant.CurrentRow.Cells["Color"].Value?.ToString() ?? "";

            if (dgvProductVariant.CurrentRow.Cells["StorageGb"]?.Value != null)
                numStorageGb.Value = Convert.ToDecimal(dgvProductVariant.CurrentRow.Cells["StorageGb"].Value);

            if (dgvProductVariant.CurrentRow.Cells["SalePrice"]?.Value != null)
                numSalePrice.Value = Convert.ToDecimal(dgvProductVariant.CurrentRow.Cells["SalePrice"].Value);

            if (dgvProductVariant.CurrentRow.Cells["ProductLineId"]?.Value != null)
                cboProductLine.SelectedValue = Convert.ToInt32(dgvProductVariant.CurrentRow.Cells["ProductLineId"].Value);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // (khuyến nghị) nếu bạn có nút Reload thì gọi cái này:
        private async void btnReload_Click(object sender, EventArgs e)
        {
            await LoadGridAsync();
            ClearUI();
        }
    }
}
