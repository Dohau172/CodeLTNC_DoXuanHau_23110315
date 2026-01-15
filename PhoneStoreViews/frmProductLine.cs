using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;

namespace PhoneStoreViews
{
    public partial class frmProductLine : Form
    {
        PhoneStoreDBContext context = new PhoneStoreDBContext();
        private int selectedProductLineID = 0;
        public frmProductLine()
        {
            InitializeComponent();
        }

        private async void frmProductLine_Load(object sender, EventArgs e)
        {
            await LoadManufacturerComboAsync();
            await LoadGridAsync();
            ClearUI();

        }
        private async Task LoadManufacturerComboAsync()
        {
            var data = await context.Manufacturers.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
            cboManufacturer.DataSource = data;
            cboManufacturer.DisplayMember = "Name";
            cboManufacturer.ValueMember = "ManufacturerId";
            cboManufacturer.SelectedIndex = -1;
        }

        private async Task LoadGridAsync()
        {
            var data = await context.ProductLines.AsNoTracking()
                .Include(x => x.Manufacturer)
                .OrderByDescending(x => x.ProductLineId)
                .Select(x => new
                {
                    x.ProductLineId,
                    x.Name,
                    x.Description,
                    x.ManufacturerId,
                    ManufacturerName = x.Manufacturer != null ? x.Manufacturer.Name : ""
                })
                .ToListAsync();

            dgvProductLines.AutoGenerateColumns = true;
            dgvProductLines.DataSource = data;
            dgvProductLines.ClearSelection();
        }

        private void ClearUI()
        {
            selectedProductLineID = 0;
            txtProductLinesId.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
            cboManufacturer.SelectedIndex = -1;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên ProductLine không được để trống!");
                txtName.Focus();
                return false;
            }
            if (cboManufacturer.SelectedValue == null)
            {
                MessageBox.Show("Chọn Manufacturer!");
                cboManufacturer.Focus();
                return false;
            }
            return true;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = (txtKeyWord.Text ?? "").Trim();

            var q = context.ProductLines.AsNoTracking().Include(x => x.Manufacturer).AsQueryable();
            if (!string.IsNullOrWhiteSpace(kw))
                q = q.Where(x => (x.Name ?? "").Contains(kw) || (x.Description ?? "").Contains(kw));

            dgvProductLines.DataSource = await q
                .OrderByDescending(x => x.ProductLineId)
                .Select(x => new
                {
                    x.ProductLineId,
                    x.Name,
                    x.Description,
                    x.ManufacturerId,
                    ManufacturerName = x.Manufacturer != null ? x.Manufacturer.Name : ""
                })
                .ToListAsync();

            dgvProductLines.ClearSelection();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var pl = new ProductLine
            {
                Name = (txtName.Text ?? "").Trim(),
                Description = (txtDescription.Text ?? "").Trim(),
                ManufacturerId = (int)cboManufacturer.SelectedValue
            };

            context.ProductLines.Add(pl);
            await context.SaveChangesAsync();

            MessageBox.Show("Thêm thành công!");
            await LoadGridAsync();
            ClearUI();


        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProductLineID <= 0) { MessageBox.Show("Chọn ProductLine trong bảng trước!"); return; }
            if (!ValidateInput()) return;

            var pl = await context.ProductLines.FirstOrDefaultAsync(x => x.ProductLineId == selectedProductLineID);
            if (pl == null) { MessageBox.Show("Không tìm thấy ProductLine!"); return; }

            pl.Name = (txtName.Text ?? "").Trim();
            pl.Description = (txtDescription.Text ?? "").Trim();
            pl.ManufacturerId = (int)cboManufacturer.SelectedValue;

            await context.SaveChangesAsync();

            MessageBox.Show("Sửa thành công!");
            await LoadGridAsync();
            ClearUI();


        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductLineID <= 0) { MessageBox.Show("Chọn ProductLine trong bảng trước!"); return; }

            if (MessageBox.Show("Xóa ProductLine này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var pl = await context.ProductLines.FirstOrDefaultAsync(x => x.ProductLineId == selectedProductLineID);
            if (pl == null) { MessageBox.Show("Không tìm thấy ProductLine!"); return; }

            context.ProductLines.Remove(pl);
            await context.SaveChangesAsync();

            MessageBox.Show("Xóa thành công!");
            await LoadGridAsync();
            ClearUI();

        }

        private void dgvProductLines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductLines.CurrentRow == null) return;

            selectedProductLineID = Convert.ToInt32(dgvProductLines.CurrentRow.Cells["ProductLineId"].Value);
            txtProductLinesId.Text = selectedProductLineID.ToString();

            txtName.Text = dgvProductLines.CurrentRow.Cells["Name"].Value?.ToString() ?? "";
            txtDescription.Text = dgvProductLines.CurrentRow.Cells["Description"].Value?.ToString() ?? "";

            if (dgvProductLines.CurrentRow.Cells["ManufacturerId"]?.Value != null)
                cboManufacturer.SelectedValue = Convert.ToInt32(dgvProductLines.CurrentRow.Cells["ManufacturerId"].Value);

        }

        private void btnExit_Click(object sender, EventArgs e)
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
