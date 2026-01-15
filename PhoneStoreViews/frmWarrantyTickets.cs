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
    public partial class frmWarrantyTickets : Form
    {
        private int selectedWarrantyTicketId = 0;

        public frmWarrantyTickets()
        {
            InitializeComponent();

            // phòng trường hợp Designer chưa gán
            this.Load += frmWarrantyTickets_Load;
        }

        private async void frmWarrantyTickets_Load(object sender, EventArgs e)
        {
            await LoadCombosAsync();
            ClearUI();
            await LoadLatestTicketAsync();
        }

        // =========================
        // Combos (DB riêng)
        // =========================
        private async Task LoadCombosAsync()
        {
            using (var db = new PhoneStoreDBContext())
            {
                cboImei.DataSource = await db.ImeiUnits.AsNoTracking()
                    .OrderBy(x => x.Imei)
                    .Select(x => x.Imei)
                    .ToListAsync();
            }
            cboImei.SelectedIndex = -1;

            using (var db = new PhoneStoreDBContext())
            {
                cboTechnician.DataSource = await db.Employees.AsNoTracking()
                    .OrderBy(x => x.FullName)
                    .ToListAsync();
            }
            cboTechnician.DisplayMember = "FullName";
            cboTechnician.ValueMember = "EmployeeId";
            cboTechnician.SelectedIndex = -1;

            cboCurrentStatus.DataSource = Enum.GetValues(typeof(WarrantyStatus));
            cboCurrentStatus.SelectedIndex = 0;

            cboStatus.DataSource = Enum.GetValues(typeof(WarrantyStatus));
            cboStatus.SelectedIndex = 0;
        }

        private void ClearUI()
        {
            selectedWarrantyTicketId = 0;

            txtWarrantyTicketId.Text = "";
            txtCode.Text = "";
            txtKeyWord.Text = "";
            txtNote.Text = "";
            textBox1.Text = ""; // IssueDescription

            dtpCreatedAt.Value = DateTime.Now;

            cboImei.SelectedIndex = -1;
            cboTechnician.SelectedIndex = -1;
            cboCurrentStatus.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;

            dgvStatusLogs.DataSource = null;
        }

        // =========================
        // Load Ticket + Logs (DB riêng)
        // =========================
        private async Task LoadTicketByIdAsync(int ticketId)
        {
            if (ticketId <= 0) return;

            WarrantyTicket t;
            using (var db = new PhoneStoreDBContext())
            {
                t = await db.WarrantyTickets.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.WarrantyTicketId == ticketId);
            }

            if (t == null)
            {
                MessageBox.Show("Không tìm thấy ticket!");
                return;
            }

            FillTicket(t);
            await LoadLogsAsync(ticketId);
        }

        private async Task LoadLatestTicketAsync()
        {
            int? latestId;
            using (var db = new PhoneStoreDBContext())
            {
                latestId = await db.WarrantyTickets.AsNoTracking()
                    .OrderByDescending(x => x.WarrantyTicketId)
                    .Select(x => (int?)x.WarrantyTicketId)
                    .FirstOrDefaultAsync();
            }

            if (latestId.HasValue)
                await LoadTicketByIdAsync(latestId.Value);
            else
                await LoadLogsAsync(0);
        }

        private async Task LoadLogsAsync(int ticketId)
        {
            if (ticketId <= 0)
            {
                dgvStatusLogs.AutoGenerateColumns = true;
                dgvStatusLogs.DataSource = null;
                return;
            }

            using (var db = new PhoneStoreDBContext())
            {
                var logs = await db.WarrantyStatusLogs.AsNoTracking()
                    .Where(x => x.WarrantyTicketId == ticketId)
                    .OrderByDescending(x => x.ChangedAt)
                    .Select(x => new
                    {
                        x.WarrantyStatusLogId,
                        x.WarrantyTicketId,
                        x.Status,
                        x.ChangedAt,
                        x.ChangedByEmployeeId,
                        x.Note
                    })
                    .ToListAsync();

                dgvStatusLogs.AutoGenerateColumns = true;
                dgvStatusLogs.DataSource = logs;
                dgvStatusLogs.ClearSelection();
            }
        }

        private void FillTicket(WarrantyTicket t)
        {
            selectedWarrantyTicketId = t.WarrantyTicketId;

            txtWarrantyTicketId.Text = t.WarrantyTicketId.ToString();
            txtCode.Text = t.Code ?? "";

            if (!string.IsNullOrWhiteSpace(t.Imei))
                cboImei.SelectedItem = t.Imei;
            else
                cboImei.SelectedIndex = -1;

            if (t.TechnicianEmployeeId.HasValue)
                cboTechnician.SelectedValue = t.TechnicianEmployeeId.Value;
            else
                cboTechnician.SelectedIndex = -1;

            cboCurrentStatus.SelectedItem = t.CurrentStatus;
            dtpCreatedAt.Value = t.ReceivedAt;

            textBox1.Text = t.IssueDescription ?? "";
        }

        // =========================
        // Buttons
        // =========================
        private async void btnReload_Click(object sender, EventArgs e)
        {
            await LoadCombosAsync();
            ClearUI();
            await LoadLatestTicketAsync();
        }

        private async void btnSeach_Click(object sender, EventArgs e)
        {
            string kw = (txtKeyWord.Text ?? "").Trim();
            if (kw.Length == 0)
            {
                MessageBox.Show("Nhập Code hoặc IMEI để tìm!");
                return;
            }

            WarrantyTicket t;
            using (var db = new PhoneStoreDBContext())
            {
                t = await db.WarrantyTickets.AsNoTracking()
                    .OrderByDescending(x => x.WarrantyTicketId)
                    .FirstOrDefaultAsync(x => x.Code == kw || x.Imei == kw);
            }

            if (t == null)
            {
                MessageBox.Show("Không tìm thấy ticket!");
                return;
            }

            FillTicket(t);
            await LoadLogsAsync(t.WarrantyTicketId);
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string code = (txtCode.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(code)) { MessageBox.Show("Nhập Code!"); return; }
            if (cboImei.SelectedItem == null) { MessageBox.Show("Chọn IMEI!"); return; }
            if (cboTechnician.SelectedValue == null) { MessageBox.Show("Chọn Technician!"); return; }

            int techId = (int)cboTechnician.SelectedValue;
            string imei = cboImei.SelectedItem.ToString() ?? "";

            using (var db = new PhoneStoreDBContext())
            using (var tx = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    bool codeExists = await db.WarrantyTickets.AnyAsync(x => x.Code == code);
                    if (codeExists)
                    {
                        MessageBox.Show("Code đã tồn tại!");
                        return;
                    }

                    var ticket = new WarrantyTicket
                    {
                        Code = code,
                        Imei = imei,
                        ReceivedAt = dtpCreatedAt.Value,
                        TechnicianEmployeeId = techId,
                        CurrentStatus = (WarrantyStatus)cboCurrentStatus.SelectedItem,
                        IssueDescription = (textBox1.Text ?? "").Trim(),
                        Accessories = null
                    };

                    db.WarrantyTickets.Add(ticket);
                    await db.SaveChangesAsync();

                    db.WarrantyStatusLogs.Add(new WarrantyStatusLog
                    {
                        WarrantyTicketId = ticket.WarrantyTicketId,
                        Status = ticket.CurrentStatus,
                        ChangedAt = DateTime.Now,
                        ChangedByEmployeeId = techId,
                        Note = "Tạo ticket"
                    });

                    await db.SaveChangesAsync();
                    await tx.CommitAsync();

                    MessageBox.Show("Thêm ticket thành công!");
                    await LoadTicketByIdAsync(ticket.WarrantyTicketId);
                }
                catch (Exception ex)
                {
                    await tx.RollbackAsync();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedWarrantyTicketId <= 0) { MessageBox.Show("Tìm/Chọn ticket trước!"); return; }
            if (cboImei.SelectedItem == null) { MessageBox.Show("Chọn IMEI!"); return; }

            string code = (txtCode.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(code)) { MessageBox.Show("Nhập Code!"); return; }

            int? techId = cboTechnician.SelectedValue == null ? null : (int?)cboTechnician.SelectedValue;
            string imei = cboImei.SelectedItem.ToString() ?? "";

            using (var db = new PhoneStoreDBContext())
            {
                var ticket = await db.WarrantyTickets.FirstOrDefaultAsync(x => x.WarrantyTicketId == selectedWarrantyTicketId);
                if (ticket == null) { MessageBox.Show("Không tìm thấy ticket!"); return; }

                bool codeExistsOther = await db.WarrantyTickets.AnyAsync(x =>
                    x.Code == code && x.WarrantyTicketId != selectedWarrantyTicketId);

                if (codeExistsOther) { MessageBox.Show("Code đã tồn tại ở ticket khác!"); return; }

                ticket.Code = code;
                ticket.Imei = imei;
                ticket.ReceivedAt = dtpCreatedAt.Value;
                ticket.TechnicianEmployeeId = techId;
                ticket.CurrentStatus = (WarrantyStatus)cboCurrentStatus.SelectedItem;
                ticket.IssueDescription = (textBox1.Text ?? "").Trim();

                await db.SaveChangesAsync();
            }

            MessageBox.Show("Sửa ticket thành công!");
            await LoadTicketByIdAsync(selectedWarrantyTicketId);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedWarrantyTicketId <= 0) { MessageBox.Show("Tìm/Chọn ticket trước!"); return; }

            if (MessageBox.Show("Xóa ticket này? (xóa logs trước)", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (var db = new PhoneStoreDBContext())
            using (var tx = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    var logs = await db.WarrantyStatusLogs
                        .Where(x => x.WarrantyTicketId == selectedWarrantyTicketId)
                        .ToListAsync();
                    db.WarrantyStatusLogs.RemoveRange(logs);

                    var ticket = await db.WarrantyTickets
                        .FirstOrDefaultAsync(x => x.WarrantyTicketId == selectedWarrantyTicketId);
                    if (ticket == null) { MessageBox.Show("Không tìm thấy ticket!"); return; }

                    db.WarrantyTickets.Remove(ticket);

                    await db.SaveChangesAsync();
                    await tx.CommitAsync();

                    MessageBox.Show("Xóa ticket thành công!");
                    ClearUI();
                    await LoadLatestTicketAsync();
                }
                catch (Exception ex)
                {
                    await tx.RollbackAsync();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private async void btnAddLogs_Click(object sender, EventArgs e)
        {
            if (selectedWarrantyTicketId <= 0) { MessageBox.Show("Tìm/Chọn ticket trước!"); return; }
            if (cboTechnician.SelectedValue == null) { MessageBox.Show("Chọn Technician (ChangedBy)!"); return; }

            var newStatus = (WarrantyStatus)cboStatus.SelectedItem;
            int changedBy = (int)cboTechnician.SelectedValue;
            string note = (txtNote.Text ?? "").Trim();

            using (var db = new PhoneStoreDBContext())
            using (var tx = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    var ticket = await db.WarrantyTickets.FirstOrDefaultAsync(x => x.WarrantyTicketId == selectedWarrantyTicketId);
                    if (ticket == null) { MessageBox.Show("Không tìm thấy ticket!"); return; }

                    ticket.CurrentStatus = newStatus;

                    db.WarrantyStatusLogs.Add(new WarrantyStatusLog
                    {
                        WarrantyTicketId = selectedWarrantyTicketId,
                        Status = newStatus,
                        ChangedAt = DateTime.Now,
                        ChangedByEmployeeId = changedBy,
                        Note = note
                    });

                    await db.SaveChangesAsync();
                    await tx.CommitAsync();

                    MessageBox.Show("Cập nhật status + thêm log thành công!");
                    await LoadTicketByIdAsync(selectedWarrantyTicketId);
                }
                catch (Exception ex)
                {
                    await tx.RollbackAsync();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
