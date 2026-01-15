using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;

namespace PhoneStoreViews
{
    public partial class frmManufacturer : Form
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        private int selectedManufacturerId = 0;
        public frmManufacturer()
        {
            InitializeComponent();
        }
        private async void frmManufacturer_Load(object sender, EventArgs e)
        {
            await LoadGridAsync();
            ClearUI();
        }

        private async Task LoadGridAsync()
        {
            var data = await context.Manufacturers.AsNoTracking()
                .Include(x => x.ProductLines)
                .OrderByDescending(x => x.ManufacturerId)
                .ToListAsync();

            var view = data.Select(x => new
            {
                x.ManufacturerId,
                x.Name,
                ProductLines = string.Join(", ", x.ProductLines.Select(pl => pl.Name))
            }).ToList();

            dgvManufacturerId.AutoGenerateColumns = true;
            dgvManufacturerId.DataSource = view;
            dgvManufacturerId.ClearSelection();
        }


        private void ClearUI()
        {
            selectedManufacturerId = 0;
            txtManufacturerId.Text = "";
            txtName.Text = "";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên hãng không được để trống!");
                txtName.Focus();
                return false;
            }
            return true;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = (txtKeyWord.Text ?? "").Trim();

            var q = context.Manufacturers.AsNoTracking()
                .Include(x => x.ProductLines)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(kw))
                q = q.Where(x => (x.Name ?? "").Contains(kw));

            var data = await q.OrderByDescending(x => x.ManufacturerId).ToListAsync();

            var view = data.Select(x => new
            {
                x.ManufacturerId,
                x.Name,
                ProductLines = string.Join(", ", x.ProductLines.Select(pl => pl.Name))
            }).ToList();

            dgvManufacturerId.AutoGenerateColumns = true;
            dgvManufacturerId.DataSource = view;
            dgvManufacturerId.ClearSelection();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            context.Manufacturers.Add(new Manufacturer { Name = (txtName.Text ?? "").Trim() });
            await context.SaveChangesAsync();

            MessageBox.Show("Thêm thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedManufacturerId <= 0) { MessageBox.Show("Chọn hãng trong bảng trước!"); return; }
            if (!ValidateInput()) return;

            var m = await context.Manufacturers.FirstOrDefaultAsync(x => x.ManufacturerId == selectedManufacturerId);
            if (m == null) { MessageBox.Show("Không tìm thấy hãng!"); return; }

            m.Name = (txtName.Text ?? "").Trim();
            await context.SaveChangesAsync();

            MessageBox.Show("Sửa thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedManufacturerId <= 0) { MessageBox.Show("Chọn hãng trong bảng trước!"); return; }

            if (MessageBox.Show("Xóa hãng này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var m = await context.Manufacturers.FirstOrDefaultAsync(x => x.ManufacturerId == selectedManufacturerId);
            if (m == null) { MessageBox.Show("Không tìm thấy hãng!"); return; }

            context.Manufacturers.Remove(m);
            await context.SaveChangesAsync();

            MessageBox.Show("Xóa thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private async void dgvManufacturerId_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvManufacturerId.CurrentRow == null) return;

            selectedManufacturerId = Convert.ToInt32(dgvManufacturerId.CurrentRow.Cells["ManufacturerId"].Value);
            txtManufacturerId.Text = selectedManufacturerId.ToString();

            txtName.Text = dgvManufacturerId.CurrentRow.Cells["Name"].Value?.ToString() ?? "";

        }

        private async void btnExit_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            

        }
    }
}
