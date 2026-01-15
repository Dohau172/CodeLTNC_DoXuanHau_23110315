namespace PhoneStoreViews
{
    partial class frmWarrantyTickets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnReload = new Button();
            btnSeach = new Button();
            cboStatus = new ComboBox();
            label2 = new Label();
            txtKeyWord = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtNote = new TextBox();
            label10 = new Label();
            textBox1 = new TextBox();
            label9 = new Label();
            dtpCreatedAt = new DateTimePicker();
            label8 = new Label();
            cboCurrentStatus = new ComboBox();
            label7 = new Label();
            cboTechnician = new ComboBox();
            label6 = new Label();
            cboImei = new ComboBox();
            label5 = new Label();
            txtCode = new TextBox();
            label4 = new Label();
            txtWarrantyTicketId = new TextBox();
            label3 = new Label();
            groupBox3 = new GroupBox();
            btnExit = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            btnAddLogs = new Button();
            dgvStatusLogs = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStatusLogs).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnReload);
            groupBox1.Controls.Add(btnSeach);
            groupBox1.Controls.Add(cboStatus);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtKeyWord);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(771, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(319, 166);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm theo Code / IMEI";
            // 
            // btnReload
            // 
            btnReload.Location = new Point(204, 116);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(94, 29);
            btnReload.TabIndex = 5;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // btnSeach
            // 
            btnSeach.Location = new Point(19, 116);
            btnSeach.Name = "btnSeach";
            btnSeach.Size = new Size(94, 29);
            btnSeach.TabIndex = 4;
            btnSeach.Text = "Search";
            btnSeach.UseVisualStyleBackColor = true;
            btnSeach.Click += btnSeach_Click;
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(87, 71);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(226, 30);
            cboStatus.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 79);
            label2.Name = "label2";
            label2.Size = new Size(63, 22);
            label2.TabIndex = 2;
            label2.Text = "Status:";
            // 
            // txtKeyWord
            // 
            txtKeyWord.Location = new Point(87, 28);
            txtKeyWord.Name = "txtKeyWord";
            txtKeyWord.Size = new Size(226, 30);
            txtKeyWord.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 36);
            label1.Name = "label1";
            label1.Size = new Size(63, 22);
            label1.TabIndex = 0;
            label1.Text = "Nhập: ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtNote);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(dtpCreatedAt);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(cboCurrentStatus);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(cboTechnician);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(cboImei);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtCode);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtWarrantyTicketId);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(-1, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(370, 352);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(71, 299);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(293, 30);
            txtNote.TabIndex = 15;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 307);
            label10.Name = "label10";
            label10.Size = new Size(59, 22);
            label10.TabIndex = 14;
            label10.Text = "Note: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(171, 252);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(193, 30);
            textBox1.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 260);
            label9.Name = "label9";
            label9.Size = new Size(159, 22);
            label9.TabIndex = 12;
            label9.Text = "Issue Description: ";
            // 
            // dtpCreatedAt
            // 
            dtpCreatedAt.Location = new Point(103, 203);
            dtpCreatedAt.Name = "dtpCreatedAt";
            dtpCreatedAt.Size = new Size(261, 30);
            dtpCreatedAt.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 209);
            label8.Name = "label8";
            label8.Size = new Size(91, 22);
            label8.TabIndex = 10;
            label8.Text = "Ngày tạo: ";
            // 
            // cboCurrentStatus
            // 
            cboCurrentStatus.FormattingEnabled = true;
            cboCurrentStatus.Location = new Point(144, 162);
            cboCurrentStatus.Name = "cboCurrentStatus";
            cboCurrentStatus.Size = new Size(220, 30);
            cboCurrentStatus.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 170);
            label7.Name = "label7";
            label7.Size = new Size(132, 22);
            label7.TabIndex = 8;
            label7.Text = "Current Status: ";
            // 
            // cboTechnician
            // 
            cboTechnician.FormattingEnabled = true;
            cboTechnician.Location = new Point(77, 126);
            cboTechnician.Name = "cboTechnician";
            cboTechnician.Size = new Size(287, 30);
            cboTechnician.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 134);
            label6.Name = "label6";
            label6.Size = new Size(76, 22);
            label6.TabIndex = 6;
            label6.Text = "E.Role: ";
            // 
            // cboImei
            // 
            cboImei.FormattingEnabled = true;
            cboImei.Location = new Point(77, 90);
            cboImei.Name = "cboImei";
            cboImei.Size = new Size(287, 30);
            cboImei.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 98);
            label5.Name = "label5";
            label5.Size = new Size(62, 22);
            label5.TabIndex = 4;
            label5.Text = "IMEI: ";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(77, 54);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(287, 30);
            txtCode.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 62);
            label4.Name = "label4";
            label4.Size = new Size(58, 22);
            label4.TabIndex = 2;
            label4.Text = "Code:";
            // 
            // txtWarrantyTicketId
            // 
            txtWarrantyTicketId.Location = new Point(77, 18);
            txtWarrantyTicketId.Name = "txtWarrantyTicketId";
            txtWarrantyTicketId.Size = new Size(287, 30);
            txtWarrantyTicketId.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 26);
            label3.Name = "label3";
            label3.Size = new Size(41, 22);
            label3.TabIndex = 0;
            label3.Text = "ID: ";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnExit);
            groupBox3.Controls.Add(btnUpdate);
            groupBox3.Controls.Add(btnDelete);
            groupBox3.Controls.Add(btnAdd);
            groupBox3.Location = new Point(422, 20);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(302, 123);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Hoạt động";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(200, 88);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 3;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(200, 29);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(6, 88);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(5, 29);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnAddLogs
            // 
            btnAddLogs.Location = new Point(695, 441);
            btnAddLogs.Name = "btnAddLogs";
            btnAddLogs.Size = new Size(94, 29);
            btnAddLogs.TabIndex = 4;
            btnAddLogs.Text = "Thêm";
            btnAddLogs.UseVisualStyleBackColor = true;
            btnAddLogs.Click += btnAddLogs_Click;
            // 
            // dgvStatusLogs
            // 
            dgvStatusLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStatusLogs.Location = new Point(401, 195);
            dgvStatusLogs.Name = "dgvStatusLogs";
            dgvStatusLogs.RowHeadersWidth = 51;
            dgvStatusLogs.Size = new Size(683, 192);
            dgvStatusLogs.TabIndex = 8;
            // 
            // frmWarrantyTickets
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 495);
            Controls.Add(dgvStatusLogs);
            Controls.Add(btnAddLogs);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmWarrantyTickets";
            Text = "Phiếu bảo hành";
            Load += frmWarrantyTickets_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStatusLogs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtKeyWord;
        private Label label1;
        private Button btnReload;
        private Button btnSeach;
        private ComboBox cboStatus;
        private Label label2;
        private GroupBox groupBox2;
        private ComboBox cboImei;
        private Label label5;
        private TextBox txtCode;
        private Label label4;
        private TextBox txtWarrantyTicketId;
        private Label label3;
        private TextBox txtNote;
        private Label label10;
        private TextBox textBox1;
        private Label label9;
        private DateTimePicker dtpCreatedAt;
        private Label label8;
        private ComboBox cboCurrentStatus;
        private Label label7;
        private ComboBox cboTechnician;
        private Label label6;
        private GroupBox groupBox3;
        private Button btnExit;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnAddLogs;
        private DataGridView dgvStatusLogs;
    }
}