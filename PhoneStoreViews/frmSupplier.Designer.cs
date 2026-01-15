namespace PhoneStoreViews
{
    partial class frmSupplier
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
            dgvSupplier = new DataGridView();
            groupBox3 = new GroupBox();
            btnExit = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            groupBox2 = new GroupBox();
            txtSupplierId = new TextBox();
            label6 = new Label();
            txtAddress = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            txtKeyWord = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSupplier
            // 
            dgvSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSupplier.Location = new Point(408, 189);
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.RowHeadersWidth = 51;
            dgvSupplier.Size = new Size(685, 264);
            dgvSupplier.TabIndex = 7;
            dgvSupplier.CellContentClick += dgvSupplier_CellContentClick;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnExit);
            groupBox3.Controls.Add(btnDelete);
            groupBox3.Controls.Add(btnUpdate);
            groupBox3.Controls.Add(btnAdd);
            groupBox3.Location = new Point(9, 307);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(361, 101);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Hoạt động";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(261, 64);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 3;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(6, 64);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(261, 29);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(6, 29);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSupplierId);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtAddress);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(txtPhone);
            groupBox2.Controls.Add(txtName);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(8, 43);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(359, 258);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin nhà cung cấp";
            // 
            // txtSupplierId
            // 
            txtSupplierId.Location = new Point(108, 34);
            txtSupplierId.Name = "txtSupplierId";
            txtSupplierId.Size = new Size(230, 30);
            txtSupplierId.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 34);
            label6.Name = "label6";
            label6.Size = new Size(36, 22);
            label6.TabIndex = 8;
            label6.Text = "ID:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(108, 213);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(230, 30);
            txtAddress.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(108, 172);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 30);
            txtEmail.TabIndex = 6;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(108, 125);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(230, 30);
            txtPhone.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(108, 81);
            txtName.Name = "txtName";
            txtName.Size = new Size(230, 30);
            txtName.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(0, 221);
            label5.Name = "label5";
            label5.Size = new Size(74, 22);
            label5.TabIndex = 3;
            label5.Text = "Địa chỉ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(0, 180);
            label4.Name = "label4";
            label4.Size = new Size(68, 22);
            label4.TabIndex = 2;
            label4.Text = "Email: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 128);
            label3.Name = "label3";
            label3.Size = new Size(52, 22);
            label3.TabIndex = 1;
            label3.Text = "SĐT:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 81);
            label2.Name = "label2";
            label2.Size = new Size(46, 22);
            label2.TabIndex = 0;
            label2.Text = "Tên:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtKeyWord);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(749, 42);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(335, 118);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm nhà cung cấp";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(159, 83);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtKeyWord
            // 
            txtKeyWord.Location = new Point(98, 32);
            txtKeyWord.Name = "txtKeyWord";
            txtKeyWord.Size = new Size(231, 30);
            txtKeyWord.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(86, 22);
            label1.TabIndex = 0;
            label1.Text = "Nhập tên:";
            // 
            // frmSupplier
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 495);
            Controls.Add(dgvSupplier);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmSupplier";
            Text = "Nhà cung cấp";
            Load += frmSupplier_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSupplier;
        private GroupBox groupBox3;
        private Button btnExit;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private GroupBox groupBox2;
        private TextBox txtSupplierId;
        private Label label6;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox groupBox1;
        private Button btnSearch;
        private TextBox txtKeyWord;
        private Label label1;
    }
}