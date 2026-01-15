using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;

namespace PhoneStoreViews
{
    public partial class frmSupplier : Form
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        private int selectedSupplierID = 0;
        public frmSupplier()
        {
            InitializeComponent();
        }
        private async void frmSupplier_Load(object sender, EventArgs e)
        {
            await LoadGridAsync();
            ClearUI();
        }

        private async Task LoadGridAsync()
        {
            var data = await context.Suppliers.AsNoTracking()
                .OrderByDescending(x => x.SupplierId)
                .Select(x => new
                {
                    x.SupplierId,
                    x.Name,
                    x.Phone,
                    x.Email,
                    x.Address,
                    PurchaseInvoiceCount = x.PurchaseInvoices.Count()
                })
                .ToListAsync();

            dgvSupplier.AutoGenerateColumns = true;
            dgvSupplier.DataSource = data;
            dgvSupplier.ClearSelection();
        }


        private void ClearUI()
        {
            selectedSupplierID = 0;
            txtSupplierId.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!");
                txtName.Focus();
                return false;
            }
            return true;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = (txtKeyWord.Text ?? "").Trim();

            var q = context.Suppliers.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(kw))
                q = q.Where(x => (x.Name ?? "").Contains(kw)
                              || (x.Phone ?? "").Contains(kw)
                              || (x.Email ?? "").Contains(kw));

            var data = await q.OrderByDescending(x => x.SupplierId)
                .Select(x => new
                {
                    x.SupplierId,
                    x.Name,
                    x.Phone,
                    x.Email,
                    x.Address,
                    PurchaseInvoiceCount = x.PurchaseInvoices.Count()
                })
                .ToListAsync();

            dgvSupplier.AutoGenerateColumns = true;
            dgvSupplier.DataSource = data;
            dgvSupplier.ClearSelection();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var s = new Supplier
            {
                Name = (txtName.Text ?? "").Trim(),
                Phone = (txtPhone.Text ?? "").Trim(),
                Email = (txtEmail.Text ?? "").Trim(),
                Address = (txtAddress.Text ?? "").Trim()
            };

            context.Suppliers.Add(s);
            await context.SaveChangesAsync();

            MessageBox.Show("Thêm thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedSupplierID <= 0) { MessageBox.Show("Chọn nhà cung cấp trong bảng trước!"); return; }
            if (!ValidateInput()) return;

            var s = await context.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == selectedSupplierID);
            if (s == null) { MessageBox.Show("Không tìm thấy supplier!"); return; }

            s.Name = (txtName.Text ?? "").Trim();
            s.Phone = (txtPhone.Text ?? "").Trim();
            s.Email = (txtEmail.Text ?? "").Trim();
            s.Address = (txtAddress.Text ?? "").Trim();

            await context.SaveChangesAsync();

            MessageBox.Show("Sửa thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSupplierID <= 0) { MessageBox.Show("Chọn nhà cung cấp trong bảng trước!"); return; }

            if (MessageBox.Show("Xóa nhà cung cấp này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var s = await context.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == selectedSupplierID);
            if (s == null) { MessageBox.Show("Không tìm thấy supplier!"); return; }

            context.Suppliers.Remove(s);
            await context.SaveChangesAsync();

            MessageBox.Show("Xóa thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private async void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSupplier.CurrentRow == null) return;

            selectedSupplierID = Convert.ToInt32(dgvSupplier.CurrentRow.Cells["SupplierId"].Value);
            txtSupplierId.Text = selectedSupplierID.ToString();

            txtName.Text = dgvSupplier.CurrentRow.Cells["Name"].Value?.ToString() ?? "";
            txtPhone.Text = dgvSupplier.CurrentRow.Cells["Phone"].Value?.ToString() ?? "";
            txtEmail.Text = dgvSupplier.CurrentRow.Cells["Email"].Value?.ToString() ?? "";
            txtAddress.Text = dgvSupplier.CurrentRow.Cells["Address"].Value?.ToString() ?? "";


        }

        private async void btnExit_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
