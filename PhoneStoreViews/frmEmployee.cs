using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;

namespace PhoneStoreViews
{
    public partial class frmEmployee : Form
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        private int selectedEmployeeID = 0;
        public frmEmployee()
        {
            InitializeComponent();
        }
        private async void frmEmployee_Load(object sender, EventArgs e)
        {
            await LoadGridAsync();
            ClearUI();
        }

        private async Task LoadGridAsync()
        {
            var data = await context.Employees.AsNoTracking()
        .OrderByDescending(x => x.EmployeeId)
        .Select(x => new
        {
            x.EmployeeId,
            x.FullName,
            x.Role,

            PurchaseInvoiceCount = x.PurchaseInvoices.Count(),
            SalesInvoiceCount = x.SalesInvoices.Count(),
            WarrantyTicketCount = x.WarrantyTicketsAssigned.Count(),
            WarrantyLogCount = x.WarrantyLogsChanged.Count()
        })
        .ToListAsync();

            dgvEmployees.AutoGenerateColumns = true;
            dgvEmployees.DataSource = data;
            dgvEmployees.ClearSelection();
        }

        private void ClearUI()
        {
            selectedEmployeeID = 0;
            txtEmployeeId.Text = "";
            txtName.Text = "";
            txtRole.Text = "";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống!");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtRole.Text))
            {
                MessageBox.Show("Role không được để trống!");
                txtRole.Focus();
                return false;
            }
            return true;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = (txtKeyWord.Text ?? "").Trim();

            var q = context.Employees.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(kw))
                q = q.Where(x => (x.FullName ?? "").Contains(kw) || (x.Role ?? "").Contains(kw));

            var data = await q.OrderByDescending(x => x.EmployeeId)
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FullName,
                    x.Role,

                    PurchaseInvoiceCount = x.PurchaseInvoices.Count(),
                    SalesInvoiceCount = x.SalesInvoices.Count(),
                    WarrantyTicketCount = x.WarrantyTicketsAssigned.Count(),
                    WarrantyLogCount = x.WarrantyLogsChanged.Count()
                })
                .ToListAsync();

            dgvEmployees.DataSource = data;
            dgvEmployees.ClearSelection();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var emp = new Employee
            {
                FullName = (txtName.Text ?? "").Trim(),
                Role = (txtRole.Text ?? "").Trim()
            };

            context.Employees.Add(emp);
            await context.SaveChangesAsync();

            MessageBox.Show("Thêm thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeID <= 0) { MessageBox.Show("Chọn nhân viên trong bảng trước!"); return; }
            if (!ValidateInput()) return;

            var emp = await context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == selectedEmployeeID);
            if (emp == null) { MessageBox.Show("Không tìm thấy employee!"); return; }

            emp.FullName = (txtName.Text ?? "").Trim();
            emp.Role = (txtRole.Text ?? "").Trim();

            await context.SaveChangesAsync();

            MessageBox.Show("Sửa thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeID <= 0) { MessageBox.Show("Chọn nhân viên trong bảng trước!"); return; }

            if (MessageBox.Show("Xóa nhân viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var emp = await context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == selectedEmployeeID);
            if (emp == null) { MessageBox.Show("Không tìm thấy employee!"); return; }

            context.Employees.Remove(emp);
            await context.SaveChangesAsync();

            MessageBox.Show("Xóa thành công!");
            await LoadGridAsync();
            ClearUI();

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

        private async void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployees.CurrentRow == null) return;

            selectedEmployeeID = Convert.ToInt32(dgvEmployees.CurrentRow.Cells["EmployeeId"].Value);
            txtEmployeeId.Text = selectedEmployeeID.ToString();

            txtName.Text = dgvEmployees.CurrentRow.Cells["FullName"].Value?.ToString() ?? "";
            txtRole.Text = dgvEmployees.CurrentRow.Cells["Role"].Value?.ToString() ?? "";

        }
    }
}
