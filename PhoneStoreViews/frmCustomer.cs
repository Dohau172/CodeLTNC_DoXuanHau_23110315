using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;

namespace PhoneStoreViews
{
    public partial class frmCustomer : Form
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        private int selectedCustomerId = 0;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void frmCustomer_Load(object sender, EventArgs e)
        {
            await LoadGridAsync();

            ClearUI();
        }
        private async Task LoadGridAsync()
        {
            var data = await context.Customers.AsNoTracking()
                .Select(c => new
                {
                    c.CustomerId,
                    c.FullName,
                    c.Phone,
                    c.Email,
                    c.Address,
                    SalesInvoiceCount = c.SalesInvoices.Count()
                })
                .OrderByDescending(x => x.CustomerId)
                .ToListAsync();

            dgvCustomers.AutoGenerateColumns = true;
            dgvCustomers.DataSource = data;
            dgvCustomers.ClearSelection();
        }

        private void ClearUI()
        {
            selectedCustomerId = 0;
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";

        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!");
                txtName.Focus();
                return false;
            }
            return true;
        }

        
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = (txtKeyWord.Text ?? "").Trim();

            var q = context.Customers.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(kw))
            {
                q = q.Where(x =>
                    (x.FullName ?? "").Contains(kw) ||
                    (x.Phone ?? "").Contains(kw) ||
                    (x.Email ?? "").Contains(kw)
                );
            }

            var data = await q
                .Select(c => new
                {
                    c.CustomerId,
                    c.FullName,
                    c.Phone,
                    c.Email,
                    c.Address,
                    SalesInvoiceCount = c.SalesInvoices.Count()
                })
                .OrderByDescending(x => x.CustomerId)
                .ToListAsync();

            dgvCustomers.DataSource = data;
            dgvCustomers.ClearSelection();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var c = new Customer
            {
                FullName = (txtName.Text ?? "").Trim(),
                Phone = (txtPhone.Text ?? "").Trim(),
                Email = (txtEmail.Text ?? "").Trim(),
                Address = (txtAddress.Text ?? "").Trim()
            };

            context.Customers.Add(c);
            await context.SaveChangesAsync();

            MessageBox.Show("Thêm thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Chọn khách hàng trong bảng trước!");
                return;
            }
            if (!ValidateInput()) return;

            var c = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == selectedCustomerId);
            if (c == null)
            {
                MessageBox.Show("Không tìm thấy customer!");
                return;
            }

            c.FullName = (txtName.Text ?? "").Trim();
            c.Phone = (txtPhone.Text ?? "").Trim();
            c.Email = (txtEmail.Text ?? "").Trim();
            c.Address = (txtAddress.Text ?? "").Trim();

            await context.SaveChangesAsync();

            MessageBox.Show("Sửa thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Chọn khách hàng trong bảng trước!");
                return;
            }

            if (MessageBox.Show("Xóa khách hàng này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var c = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == selectedCustomerId);
            if (c == null)
            {
                MessageBox.Show("Không tìm thấy customer!");
                return;
            }

            context.Customers.Remove(c);
            await context.SaveChangesAsync();

            MessageBox.Show("Xóa thành công!");
            await LoadGridAsync();
            ClearUI();

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

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;

            selectedCustomerId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["CustomerId"].Value);
            txtName.Text = dgvCustomers.CurrentRow.Cells["FullName"].Value?.ToString() ?? "";
            txtPhone.Text = dgvCustomers.CurrentRow.Cells["Phone"].Value?.ToString() ?? "";
            txtEmail.Text = dgvCustomers.CurrentRow.Cells["Email"].Value?.ToString() ?? "";
            txtAddress.Text = dgvCustomers.CurrentRow.Cells["Address"].Value?.ToString() ?? "";

        }
    }
}
