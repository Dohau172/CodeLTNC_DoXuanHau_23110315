namespace PhoneStoreViews
{
    partial class frmProductLine
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
            dgvProductLines = new DataGridView();
            groupBox3 = new GroupBox();
            btnExit = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            groupBox2 = new GroupBox();
            txtProductLinesId = new TextBox();
            label2 = new Label();
            txtDescription = new TextBox();
            cboManufacturer = new ComboBox();
            label5 = new Label();
            txtName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            txtKeyWord = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductLines).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProductLines
            // 
            dgvProductLines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductLines.Location = new Point(356, 170);
            dgvProductLines.Name = "dgvProductLines";
            dgvProductLines.RowHeadersWidth = 51;
            dgvProductLines.Size = new Size(725, 313);
            dgvProductLines.TabIndex = 7;
            dgvProductLines.CellContentClick += dgvProductLines_CellContentClick;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnExit);
            groupBox3.Controls.Add(btnUpdate);
            groupBox3.Controls.Add(btnDelete);
            groupBox3.Controls.Add(btnAdd);
            groupBox3.Location = new Point(12, 285);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(302, 123);
            groupBox3.TabIndex = 6;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(txtProductLinesId);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtDescription);
            groupBox2.Controls.Add(cboManufacturer);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtName);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(13, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(323, 264);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin các dòng sản phẩm";
            // 
            // txtProductLinesId
            // 
            txtProductLinesId.Location = new Point(116, 29);
            txtProductLinesId.Name = "txtProductLinesId";
            txtProductLinesId.Size = new Size(187, 30);
            txtProductLinesId.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 32);
            label2.Name = "label2";
            label2.Size = new Size(36, 22);
            label2.TabIndex = 9;
            label2.Text = "ID:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(116, 217);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(185, 30);
            txtDescription.TabIndex = 8;
            // 
            // cboManufacturer
            // 
            cboManufacturer.DisplayMember = "Name";
            cboManufacturer.FormattingEnabled = true;
            cboManufacturer.Location = new Point(116, 84);
            cboManufacturer.Name = "cboManufacturer";
            cboManufacturer.Size = new Size(185, 30);
            cboManufacturer.TabIndex = 7;
            cboManufacturer.ValueMember = "ManufacturerId";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 87);
            label5.Name = "label5";
            label5.Size = new Size(103, 22);
            label5.TabIndex = 6;
            label5.Text = "Nhãn hàng: ";
            // 
            // txtName
            // 
            txtName.Location = new Point(116, 150);
            txtName.Name = "txtName";
            txtName.Size = new Size(187, 30);
            txtName.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 220);
            label4.Name = "label4";
            label4.Size = new Size(114, 22);
            label4.TabIndex = 2;
            label4.Text = "Description: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 153);
            label3.Name = "label3";
            label3.Size = new Size(46, 22);
            label3.TabIndex = 1;
            label3.Text = "Tên:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtKeyWord);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(783, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 110);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm dòng sản phẩm";
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
            // frmProductLine
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 495);
            Controls.Add(dgvProductLines);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmProductLine";
            Text = "Quản lý dòng sản phẩm";
            Load += frmProductLine_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductLines).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProductLines;
        private GroupBox groupBox3;
        private Button btnExit;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private GroupBox groupBox2;
        private TextBox txtRole;
        private TextBox txtName;
        private Label label4;
        private Label label3;
        private GroupBox groupBox1;
        private Button btnSearch;
        private TextBox txtKeyWord;
        private Label label1;
        private ComboBox cboManufacturer;
        private Label label5;
        private TextBox txtDescription;
        private TextBox txtProductLinesId;
        private Label label2;
    }
}