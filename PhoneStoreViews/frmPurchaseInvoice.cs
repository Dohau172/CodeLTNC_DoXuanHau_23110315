using Microsoft.EntityFrameworkCore;
using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneStoreViews
{
    public partial class frmPurchaseInvoice : Form
    {
        // Giỏ tạm (RAM) để add detail trước khi Save
        private readonly List<PurchaseInvoiceDetail> details = new List<PurchaseInvoiceDetail>();

        public frmPurchaseInvoice()
        {
            InitializeComponent();

            // đảm bảo event Load chạy (phòng trường hợp Designer chưa gán)
            this.Load += frmPurchaseInvoice_Load;
        }

        private async void frmPurchaseInvoice_Load(object sender, EventArgs e)
        {
            await LoadCombosAsync();

            ClearAll();
            RefreshDetailGrid();

            // ✅ Mở form lên sẽ auto load hóa đơn nhập mới nhất (nếu có)
            await LoadLatestInvoiceAsync();
        }

        // =========================
        // A) Load Combos
        // =========================
        private async Task LoadCombosAsync()
        {
            using var db = new PhoneStoreDBContext();

            cboEmployee.DataSource = await db.Employees.AsNoTracking()
                .OrderBy(x => x.FullName).ToListAsync();
            cboEmployee.DisplayMember = "FullName";
            cboEmployee.ValueMember = "EmployeeId";
            cboEmployee.SelectedIndex = -1;

            cboSupplier.DataSource = await db.Suppliers.AsNoTracking()
                .OrderBy(x => x.Name).ToListAsync();
            cboSupplier.DisplayMember = "Name";
            cboSupplier.ValueMember = "SupplierId";
            cboSupplier.SelectedIndex = -1;

            var pvList = await db.ProductVariants.AsNoTracking()
                .OrderBy(x => x.Sku).ToListAsync();

            cboProductVariant.DataSource = pvList;
            cboProductVariant.DisplayMember = "Sku";
            cboProductVariant.ValueMember = "ProductVariantId";
            cboProductVariant.SelectedIndex = -1;
        }

        // =========================
        // B) Clear / Grid (RAM)
        // =========================
        private void ClearAll()
        {
            txtPurchaseInvoiceId.Text = "";
            txtCode.Text = "";
            dtpCreatedAt.Value = DateTime.Now;

            cboEmployee.SelectedIndex = -1;
            cboSupplier.SelectedIndex = -1;
            cboProductVariant.SelectedIndex = -1;

            numQuantity.Value = 1;
            numsQuantity.Value = 1;
            numCost.Value = 0;

            txtTotalMoney.Text = "0";
            textBox1.Text = ""; // designer có, không map entity

            details.Clear();
        }

        private int GetQty()
        {
            if (numsQuantity != null && numsQuantity.Focused)
                return (int)numsQuantity.Value;

            if (numQuantity != null && numQuantity.Focused)
                return (int)numQuantity.Value;

            // nếu không focus cái nào thì ưu tiên numsQuantity (thường là cái bạn dùng)
            if (numsQuantity != null && numsQuantity.Visible && numsQuantity.Enabled)
                return (int)numsQuantity.Value;

            if (numQuantity != null && numQuantity.Visible && numQuantity.Enabled)
                return (int)numQuantity.Value;

            return 1;
        }



        private void RefreshDetailGrid()
        {
            var view = details.Select(d => new
            {
                d.ProductVariantId,
                d.Quantity,
                d.UnitCost,
                LineTotal = d.Quantity * d.UnitCost
            }).ToList();

            dgvPurchaseDetails.AutoGenerateColumns = true;
            dgvPurchaseDetails.DataSource = null;
            dgvPurchaseDetails.DataSource = view;
            dgvPurchaseDetails.ClearSelection();

            txtTotalMoney.Text = details.Sum(d => d.Quantity * d.UnitCost).ToString("0.##");
        }

        private void SetNumericUpDownSafe(NumericUpDown nud, decimal value)
        {
            if (value < nud.Minimum) value = nud.Minimum;
            if (value > nud.Maximum) value = nud.Maximum;
            nud.Value = value;
        }

        // =========================
        // C) Auto fill cost by ProductVariant
        // =========================
        private void cboProductVariant_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = cboProductVariant.SelectedValue;
            if (val == null) return;

            int variantId;
            if (!int.TryParse(val.ToString(), out variantId)) return;
            if (variantId <= 0) return;

            var list = cboProductVariant.DataSource as List<ProductVariant>;
            if (list == null) return;

            var pv = list.FirstOrDefault(x => x.ProductVariantId == variantId);
            if (pv == null) return;

            // dùng SalePrice làm mặc định (bạn có thể đổi thành PurchaseCost nếu bạn có)
            SetNumericUpDownSafe(numCost, pv.SalePrice);
        }

        // =========================
        // D) Add/Remove/Clear detail (RAM)
        // =========================
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (cboProductVariant.SelectedValue == null)
            {
                MessageBox.Show("Chọn ProductVariant!");
                return;
            }

            int variantId = (int)cboProductVariant.SelectedValue;
            int qty = GetQty();
            decimal cost = numCost.Value;

            if (qty <= 0) { MessageBox.Show("Quantity phải > 0"); return; }
            if (cost < 0) { MessageBox.Show("Cost phải >= 0"); return; }

            var exist = details.FirstOrDefault(x => x.ProductVariantId == variantId);
            if (exist != null)
            {
                exist.Quantity += qty;
                exist.UnitCost = (int)cost; // giữ theo entity của bạn (UnitCost đang là int)
            }
            else
            {
                details.Add(new PurchaseInvoiceDetail
                {
                    ProductVariantId = variantId,
                    Quantity = qty,
                    UnitCost = (int)cost
                });
            }

            RefreshDetailGrid();
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseDetails.CurrentRow == null) return;
            if (dgvPurchaseDetails.CurrentRow.Cells["ProductVariantId"]?.Value == null) return;

            int variantId = Convert.ToInt32(dgvPurchaseDetails.CurrentRow.Cells["ProductVariantId"].Value);
            details.RemoveAll(x => x.ProductVariantId == variantId);

            RefreshDetailGrid();
        }

        private void BtnClearDetail_Click(object sender, EventArgs e)
        {
            details.Clear();
            RefreshDetailGrid();
        }

        // =========================
        // E) SAVE (Transaction) + Load lại từ DB
        // =========================
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Nhập Code!");
                return;
            }
            if (cboSupplier.SelectedValue == null || cboEmployee.SelectedValue == null)
            {
                MessageBox.Show("Chọn Supplier và Employee!");
                return;
            }
            if (details.Count == 0)
            {
                MessageBox.Show("Thêm ít nhất 1 detail!");
                return;
            }

            using var db = new PhoneStoreDBContext();
            using var tx = await db.Database.BeginTransactionAsync();

            try
            {
                var invoice = new PurchaseInvoice
                {
                    Code = txtCode.Text.Trim(),
                    CreatedAt = dtpCreatedAt.Value,
                    SupplierId = (int)cboSupplier.SelectedValue,
                    EmployeeId = (int)cboEmployee.SelectedValue
                };

                db.PurchaseInvoices.Add(invoice);
                await db.SaveChangesAsync(); // lấy PurchaseInvoiceId

                decimal total = 0;

                foreach (var d in details)
                {
                    db.PurchaseInvoiceDetails.Add(new PurchaseInvoiceDetail
                    {
                        PurchaseInvoiceId = invoice.PurchaseInvoiceId,
                        ProductVariantId = d.ProductVariantId,
                        Quantity = d.Quantity,
                        UnitCost = d.UnitCost
                    });

                    // tăng tồn
                    var variant = await db.ProductVariants.FirstAsync(x => x.ProductVariantId == d.ProductVariantId);
                    variant.QuantityInStock += d.Quantity;

                    total += d.Quantity * d.UnitCost;
                }

                invoice.TotalCost = total;

                await db.SaveChangesAsync();
                await tx.CommitAsync();

                txtPurchaseInvoiceId.Text = invoice.PurchaseInvoiceId.ToString();
                txtTotalMoney.Text = invoice.TotalCost.ToString("0.##");

                // ✅ Quan trọng: load lại từ DB để mở lại vẫn còn
                details.Clear();
                await LoadInvoiceByIdAsync(invoice.PurchaseInvoiceId);

                MessageBox.Show("Lưu hóa đơn nhập thành công (Transaction)!");
            }
            catch (Exception ex)
            {
                await tx.RollbackAsync();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // =========================
        // F) LOAD Invoice (từ DB) theo ID / mới nhất
        // =========================
        private async Task LoadInvoiceByIdAsync(int id)
        {
            using var db = new PhoneStoreDBContext();

            var invoice = await db.PurchaseInvoices.AsNoTracking()
                .FirstOrDefaultAsync(x => x.PurchaseInvoiceId == id);

            if (invoice == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!");
                return;
            }

            // đổ header
            txtPurchaseInvoiceId.Text = invoice.PurchaseInvoiceId.ToString();
            txtCode.Text = invoice.Code ?? "";
            dtpCreatedAt.Value = invoice.CreatedAt;

            cboSupplier.SelectedValue = invoice.SupplierId;
            cboEmployee.SelectedValue = invoice.EmployeeId;

            // đổ details
            var dbDetails = await db.PurchaseInvoiceDetails.AsNoTracking()
                .Where(x => x.PurchaseInvoiceId == id)
                .Select(x => new
                {
                    x.ProductVariantId,
                    x.Quantity,
                    x.UnitCost,
                    LineTotal = x.Quantity * x.UnitCost
                })
                .ToListAsync();

            dgvPurchaseDetails.AutoGenerateColumns = true;
            dgvPurchaseDetails.DataSource = null;
            dgvPurchaseDetails.DataSource = dbDetails;
            dgvPurchaseDetails.ClearSelection();

            txtTotalMoney.Text = dbDetails.Sum(x => x.LineTotal).ToString("0.##");
        }

        private async Task LoadLatestInvoiceAsync()
        {
            using var db = new PhoneStoreDBContext();

            var latestId = await db.PurchaseInvoices.AsNoTracking()
                .OrderByDescending(x => x.PurchaseInvoiceId)
                .Select(x => (int?)x.PurchaseInvoiceId)
                .FirstOrDefaultAsync();

            if (latestId.HasValue)
            {
                await LoadInvoiceByIdAsync(latestId.Value);
            }
        }

        // ✅ Bạn có thể dùng ngay hàm này: nhập ID vào txtPurchaseInvoiceId rồi bấm nút (nếu có)
        private async void btnLoadInvoice_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtPurchaseInvoiceId.Text, out id) || id <= 0)
            {
                MessageBox.Show("Nhập PurchaseInvoiceId hợp lệ!");
                return;
            }

            await LoadInvoiceByIdAsync(id);
        }

        // =========================
        // G) New / Delete (Transaction)
        // =========================
        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            ClearAll();
            RefreshDetailGrid();
        }

        private async void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtPurchaseInvoiceId.Text, out id) || id <= 0)
            {
                MessageBox.Show("Nhập/Chọn PurchaseInvoiceId hợp lệ!");
                return;
            }

            if (MessageBox.Show("Xóa hóa đơn này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using var db = new PhoneStoreDBContext();
            using var tx = await db.Database.BeginTransactionAsync();

            try
            {
                var ds = await db.PurchaseInvoiceDetails
                    .Where(x => x.PurchaseInvoiceId == id)
                    .ToListAsync();

                foreach (var d in ds)
                {
                    // rollback tồn
                    var variant = await db.ProductVariants.FirstAsync(x => x.ProductVariantId == d.ProductVariantId);
                    variant.QuantityInStock -= d.Quantity;

                    db.PurchaseInvoiceDetails.Remove(d);
                }

                var invoice = await db.PurchaseInvoices.FirstOrDefaultAsync(x => x.PurchaseInvoiceId == id);
                if (invoice == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!");
                    return;
                }

                db.PurchaseInvoices.Remove(invoice);

                await db.SaveChangesAsync();
                await tx.CommitAsync();

                MessageBox.Show("Xóa hóa đơn thành công!");
                ClearAll();
                RefreshDetailGrid();

                // load invoice mới nhất còn lại (nếu có)
                await LoadLatestInvoiceAsync();
            }
            catch (Exception ex)
            {
                await tx.RollbackAsync();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // để sau
        }
    }
}
