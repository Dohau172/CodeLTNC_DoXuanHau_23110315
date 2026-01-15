namespace PhoneStoreViews
{
    partial class frmEmployee
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
            btnSearch = new Button();
            txtKeyWord = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtRole = new TextBox();
            txtName = new TextBox();
            txtEmployeeId = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox3 = new GroupBox();
            btnExit = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            dgvEmployees = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtKeyWord);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(784, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 110);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm nhân viên";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(109, 72);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtKeyWord
            // 
            txtKeyWord.Location = new Point(77, 23);
            txtKeyWord.Name = "txtKeyWord";
            txtKeyWord.Size = new Size(221, 30);
            txtKeyWord.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 26);
            label1.Name = "label1";
            label1.Size = new Size(51, 22);
            label1.TabIndex = 0;
            label1.Text = "Tên: ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtRole);
            groupBox2.Controls.Add(txtName);
            groupBox2.Controls.Add(txtEmployeeId);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(14, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(301, 211);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin nhân viên";
            // 
            // txtRole
            // 
            txtRole.Location = new Point(108, 157);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(187, 30);
            txtRole.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(108, 90);
            txtName.Name = "txtName";
            txtName.Size = new Size(187, 30);
            txtName.TabIndex = 4;
            // 
            // txtEmployeeId
            // 
            txtEmployeeId.Location = new Point(108, 34);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.Size = new Size(187, 30);
            txtEmployeeId.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 165);
            label4.Name = "label4";
            label4.Size = new Size(87, 22);
            label4.TabIndex = 2;
            label4.Text = "Chức vụ: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 98);
            label3.Name = "label3";
            label3.Size = new Size(46, 22);
            label3.TabIndex = 1;
            label3.Text = "Tên:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 37);
            label2.Name = "label2";
            label2.Size = new Size(41, 22);
            label2.TabIndex = 0;
            label2.Text = "ID: ";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnExit);
            groupBox3.Controls.Add(btnUpdate);
            groupBox3.Controls.Add(btnDelete);
            groupBox3.Controls.Add(btnAdd);
            groupBox3.Location = new Point(15, 255);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(302, 123);
            groupBox3.TabIndex = 2;
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
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(357, 170);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(725, 313);
            dgvEmployees.TabIndex = 3;
            dgvEmployees.CellContentClick += dgvEmployees_CellClick;
            // 
            // frmEmployee
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 495);
            Controls.Add(dgvEmployees);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmEmployee";
            Text = "Quản lý nhân viên";
            Load += frmEmployee_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
        }

        //private void FrmEmployee_Load(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        private GroupBox groupBox1;
        private TextBox txtKeyWord;
        private Label label1;
        private Button btnSearch;
        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtRole;
        private TextBox txtName;
        private TextBox txtEmployeeId;
        private GroupBox groupBox3;
        private Button btnExit;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private DataGridView dgvEmployees;
    }
}