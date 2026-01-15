using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;
using static PhoneStoreDAL.Entities.Enums;

namespace PhoneStoreViews
{
    public partial class frmSalesInvoice : Form
    {
        // Giỏ tạm (RAM): IMEI + Price
        private readonly List<(string Imei, decimal Price)> items = new List<(string Imei, decimal Price)>();

        public frmSalesInvoice()
        {
            InitializeComponent();

            // đảm bảo Load chạy (phòng trường hợp Designer chưa gán)
            this.Load += frmSalesInvoice_Load;
            this.FormClosed += frmSalesInvoice_FormClosed;

            // (khuyến nghị) gán event nếu designer chưa gán
            this.txtImeiScan.KeyDown += txtImeiScan_KeyDown;
            this.txtImeiScan.TextChanged += txtImeiScan_TextChanged;
        }

        private void frmSalesInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            // không giữ DbContext global ở form này nên không cần Dispose
        }

        private async void frmSalesInvoice_Load(object sender, EventArgs e)
        {
            await LoadCombosAsync();
            ClearAll();
            RefreshGrid();

            // ✅ mở form lên tự load hóa đơn mới nhất (nếu có)
            await LoadLatestInvoiceAsync();
        }

        // =========================
        // A) Load Combos
        // =========================
        private async Task LoadCombosAsync()
        {
            using (var db = new PhoneStoreDBContext())
            {
                cboCustomer.DataSource = await db.Customers.AsNoTracking()
                    .OrderBy(x => x.FullName).ToListAsync();
                cboCustomer.DisplayMember = "FullName";
                cboCustomer.ValueMember = "CustomerId";
                cboCustomer.SelectedIndex = -1;

                cboEmployee.DataSource = await db.Employees.AsNoTracking()
                    .OrderBy(x => x.FullName).ToListAsync();
                cboEmployee.DisplayMember = "FullName";
                cboEmployee.ValueMember = "EmployeeId";
                cboEmployee.SelectedIndex = -1;

                cboPaymentMethod.DataSource = Enum.GetValues(typeof(PaymentMethod));
                cboPaymentMethod.SelectedIndex = 0;
            }
        }

        // =========================
        // B) Clear / Grid (RAM)
        // =========================
        private void ClearAll()
        {
            txtSalesInvoiceId.Text = "";
            txtCode.Text = "";
            dtpSoldAt.Value = DateTime.Now;

            cboCustomer.SelectedIndex = -1;
            cboEmployee.SelectedIndex = -1;
            cboPaymentMethod.SelectedIndex = 0;

            txtImeiScan.Text = "";
            txtTotalMoney.Text = "0";
            
            numCost.Value = 0;

            items.Clear();
        }

        private void RefreshGrid()
        {
            dgvSalesDetails.AutoGenerateColumns = true;
            dgvSalesDetails.DataSource = null;

            // Projecting to a list for the DataGridView
            var displayList = items.Select(x => new {
                x.Imei,
                Price = x.Price,
                Quantity = 1, // IMEI is always 1 unit
                SubTotal = x.Price * 1
            }).ToList();

            dgvSalesDetails.DataSource = displayList;
            dgvSalesDetails.ClearSelection();

            // Calculate sum of (Price * Quantity)
            decimal total = items.Sum(x => x.Price);
            txtTotalMoney.Text = total.ToString("N0");
        }

        private void SetNumericUpDownSafe(NumericUpDown nud, decimal value)
        {
            if (value < nud.Minimum) value = nud.Minimum;
            if (value > nud.Maximum) value = nud.Maximum;
            nud.Value = value;
        }

        // =========================
        // C) Fill cost by IMEI while typing
        // =========================
        private async Task FillCostByImeiAsync(string imei)
        {
            imei = (imei ?? "").Trim();
            if (imei.Length == 0)
            {
                numCost.Value = 0;
                return;
            }

            using (var db = new PhoneStoreDBContext())
            {
                var unit = await db.ImeiUnits.AsNoTracking()
                    .Include(x => x.ProductVariant)
                    .FirstOrDefaultAsync(x => x.Imei == imei);

                if (unit == null || unit.ProductVariant == null)
                {
                    numCost.Value = 0;
                    return;
                }

                SetNumericUpDownSafe(numCost, unit.ProductVariant.SalePrice);
            }
        }

        private async void txtImeiScan_TextChanged(object sender, EventArgs e)
        {
            string imei = (txtImeiScan.Text ?? "").Trim();
            if (imei.Length < 5)
            {
                numCost.Value = 0;
                return;
            }

            await FillCostByImeiAsync(imei);
        }

        // =========================
        // D) Add IMEI vào GIỎ (RAM)
        //    ✅ CHỈ CHECK, KHÔNG TRỪ KHO Ở ĐÂY
        // =========================
        private async Task AddImeiFromTextbox()
        {
            string imei = (txtImeiScan.Text ?? "").Trim();
            if (imei.Length == 0) return;

            if (items.Any(x => x.Imei.Equals(imei, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("IMEI đã có trong danh sách!");
                return;
            }

            using (var db = new PhoneStoreDBContext())
            {
                var unit = await db.ImeiUnits.AsNoTracking()
                    .Include(x => x.ProductVariant)
                    .FirstOrDefaultAsync(x => x.Imei == imei);

                if (unit == null)
                {
                    MessageBox.Show("IMEI không tồn tại: " + imei);
                    return;
                }

                if (unit.Status != ImeiStatus.InStock)
                {
                    MessageBox.Show("IMEI không ở trạng thái InStock: " + imei);
                    return;
                }

                if (unit.ProductVariant == null)
                {
                    MessageBox.Show("IMEI thiếu ProductVariant: " + imei);
                    return;
                }

                // ✅ check tồn kho
                if (unit.ProductVariant.QuantityInStock <= 0)
                {
                    MessageBox.Show("Sản phẩm đã hết hàng!");
                    return;
                }

                decimal price = unit.ProductVariant.SalePrice;

                SetNumericUpDownSafe(numCost, price);
                items.Add((imei, price));

                txtImeiScan.Text = "";
                RefreshGrid();
            }
        }

        private async void txtImeiScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await AddImeiFromTextbox();
            }
        }

        private async void btnAddDeatail_Click(object sender, EventArgs e)
        {
            await AddImeiFromTextbox();
        }

        // =========================
        // E) Remove / Clear GIỎ (RAM)
        //    ✅ Không đụng DB vì chưa Save
        // =========================
        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (dgvSalesDetails.CurrentRow == null) return;

            string imei = dgvSalesDetails.CurrentRow.Cells["Imei"].Value?.ToString() ?? "";
            items.RemoveAll(x => x.Imei.Equals(imei, StringComparison.OrdinalIgnoreCase));

            RefreshGrid();
        }

        private void btnClearDetails_Click(object sender, EventArgs e)
        {
            items.Clear();
            RefreshGrid();
        }

        // =========================
        // F) SAVE (Transaction)
        //    ✅ Trừ kho ở đây
        // =========================
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Nhập Code!");
                return;
            }

            if (cboCustomer.SelectedValue == null || cboEmployee.SelectedValue == null)
            {
                MessageBox.Show("Chọn Customer và Employee!");
                return;
            }

            if (items.Count == 0)
            {
                MessageBox.Show("Thêm ít nhất 1 IMEI!");
                return;
            }

            using (var db = new PhoneStoreDBContext())
            using (var tx = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    // (tuỳ chọn) chặn trùng code
                    bool codeExists = await db.SalesInvoices.AnyAsync(x => x.Code == txtCode.Text.Trim());
                    if (codeExists)
                    {
                        MessageBox.Show("Code đã tồn tại!");
                        return;
                    }

                    var invoice = new SalesInvoice
                    {
                        Code = txtCode.Text.Trim(),
                        SoldAt = dtpSoldAt.Value,
                        CustomerId = (int)cboCustomer.SelectedValue,
                        EmployeeId = (int)cboEmployee.SelectedValue,
                        PaymentMethod = (PaymentMethod)cboPaymentMethod.SelectedItem,
                        Discount = 0,
                        Tax = 0
                    };

                    db.SalesInvoices.Add(invoice);
                    await db.SaveChangesAsync(); // lấy SalesInvoiceId

                    decimal sub = 0;

                    foreach (var it in items)
                    {
                        string imei = it.Imei;

                        // ✅ LẤY TRACKING (không AsNoTracking)
                        var unit = await db.ImeiUnits
                            .Include(x => x.ProductVariant)
                            .FirstOrDefaultAsync(x => x.Imei == imei);

                        if (unit == null) throw new Exception("IMEI không tồn tại: " + imei);
                        if (unit.Status != ImeiStatus.InStock) throw new Exception("IMEI không ở trạng thái InStock: " + imei);
                        if (unit.ProductVariant == null) throw new Exception("IMEI thiếu ProductVariant: " + imei);

                        // ✅ check tồn kho trước khi trừ
                        if (unit.ProductVariant.QuantityInStock <= 0)
                            throw new Exception("Hết hàng (kho = 0) cho IMEI: " + imei);

                        decimal price = unit.ProductVariant.SalePrice;

                        db.SalesInvoiceDetails.Add(new SalesInvoiceDetail
                        {
                            SalesInvoiceId = invoice.SalesInvoiceId,
                            Imei = imei,
                            SalePrice = price
                        });

                        // ✅ update trạng thái IMEI + trừ kho
                        unit.Status = ImeiStatus.Sold;
                        unit.SoldAt = dtpSoldAt.Value;

                        unit.ProductVariant.QuantityInStock -= 1;

                        // ✅ chặn âm (an toàn)
                        if (unit.ProductVariant.QuantityInStock < 0)
                            unit.ProductVariant.QuantityInStock = 0;

                        sub += price;
                    }

                    invoice.SubTotal = sub;
                    invoice.TotalAmount = sub - invoice.Discount + invoice.Tax;

                    await db.SaveChangesAsync();
                    await tx.CommitAsync();

                    // ✅ load lại từ DB để thoát ra vẫn còn
                    items.Clear();
                    await LoadInvoiceByIdAsync(invoice.SalesInvoiceId);

                    // ✅ refresh kho ở frmProductVariant nếu đang mở
                    await RefreshProductVariantIfOpen();

                    MessageBox.Show("Lưu hóa đơn bán thành công (Transaction)!");
                }
                catch (Exception ex)
                {
                    await tx.RollbackAsync();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // =========================
        // G) LOAD Invoice từ DB (theo ID / mới nhất)
        // =========================
        private async Task LoadInvoiceByIdAsync(int id)
        {
            using (var db = new PhoneStoreDBContext())
            {
                var invoice = await db.SalesInvoices.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.SalesInvoiceId == id);

                if (invoice == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!");
                    return;
                }

                // header
                txtSalesInvoiceId.Text = invoice.SalesInvoiceId.ToString();
                txtCode.Text = invoice.Code ?? "";
                dtpSoldAt.Value = invoice.SoldAt;

                cboCustomer.SelectedValue = invoice.CustomerId;
                cboEmployee.SelectedValue = invoice.EmployeeId;
                cboPaymentMethod.SelectedItem = invoice.PaymentMethod;

                // details
                var dbDetails = await db.SalesInvoiceDetails.AsNoTracking()
                    .Where(x => x.SalesInvoiceId == id)
                    .Select(x => new
                    {
                        Imei = x.Imei,
                        Price = x.SalePrice
                    })
                    .ToListAsync();

                dgvSalesDetails.AutoGenerateColumns = true;
                dgvSalesDetails.DataSource = null;
                dgvSalesDetails.DataSource = dbDetails;
                dgvSalesDetails.ClearSelection();

                txtTotalMoney.Text = dbDetails.Sum(x => x.Price).ToString("0.##");
            }
        }

        private async Task LoadLatestInvoiceAsync()
        {
            using (var db = new PhoneStoreDBContext())
            {
                int? latestId = await db.SalesInvoices.AsNoTracking()
                    .OrderByDescending(x => x.SalesInvoiceId)
                    .Select(x => (int?)x.SalesInvoiceId)
                    .FirstOrDefaultAsync();

                if (latestId.HasValue)
                {
                    await LoadInvoiceByIdAsync(latestId.Value);
                }
            }
        }

        private async void btnLoadInvoice_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtSalesInvoiceId.Text, out id) || id <= 0)
            {
                MessageBox.Show("Nhập SalesInvoiceId hợp lệ!");
                return;
            }

            await LoadInvoiceByIdAsync(id);
        }

        // =========================
        // H) New / Delete
        // =========================
        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            ClearAll();
            RefreshGrid();
        }

        private async void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtSalesInvoiceId.Text, out id) || id <= 0)
            {
                MessageBox.Show("Nhập/Chọn SalesInvoiceId hợp lệ!");
                return;
            }

            if (MessageBox.Show("Xóa hóa đơn này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (var db = new PhoneStoreDBContext())
            using (var tx = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    var detailRows = await db.SalesInvoiceDetails
                        .Where(x => x.SalesInvoiceId == id)
                        .ToListAsync();

                    foreach (var d in detailRows)
                    {
                        var unit = await db.ImeiUnits
                            .Include(x => x.ProductVariant)
                            .FirstOrDefaultAsync(x => x.Imei == d.Imei);

                        if (unit != null)
                        {
                            unit.Status = ImeiStatus.InStock;
                            unit.SoldAt = null;

                            if (unit.ProductVariant != null)
                            {
                                unit.ProductVariant.QuantityInStock += 1;
                            }
                        }

                        db.SalesInvoiceDetails.Remove(d);
                    }

                    var invoice = await db.SalesInvoices.FirstOrDefaultAsync(x => x.SalesInvoiceId == id);
                    if (invoice == null)
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn!");
                        return;
                    }

                    db.SalesInvoices.Remove(invoice);

                    await db.SaveChangesAsync();
                    await tx.CommitAsync();

                    MessageBox.Show("Xóa hóa đơn thành công!");
                    ClearAll();
                    RefreshGrid();

                    await LoadLatestInvoiceAsync();
                    await RefreshProductVariantIfOpen();
                }
                catch (Exception ex)
                {
                    await tx.RollbackAsync();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // để sau
        }

        // =========================
        // I) Refresh frmProductVariant nếu đang mở
        // =========================
        private async Task RefreshProductVariantIfOpen()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmProductVariant)
                {
                    // cần public method bên frmProductVariant
                    frmProductVariant pv = (frmProductVariant)f;
                    await pv.ReloadGridFromOutsideAsync();
                    break;
                }
            }
        }
    }
}
