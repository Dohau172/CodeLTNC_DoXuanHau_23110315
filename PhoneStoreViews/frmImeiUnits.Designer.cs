namespace PhoneStoreViews
{
    partial class frmImeiUnits
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
            groupBox3 = new GroupBox();
            btnExit = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            groupBox2 = new GroupBox();
            txtReceivedPurchaseInvoiceId = new TextBox();
            label7 = new Label();
            numWarrantyMonths = new NumericUpDown();
            label6 = new Label();
            dtpWarrantyStart = new DateTimePicker();
            cboProductVariant = new ComboBox();
            txtStatus = new TextBox();
            label5 = new Label();
            txtImei = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            txtKeyWord = new TextBox();
            label1 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dgvImei = new DataGridView();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numWarrantyMonths).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImei).BeginInit();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnExit);
            groupBox3.Controls.Add(btnUpdate);
            groupBox3.Controls.Add(btnDelete);
            groupBox3.Controls.Add(btnAdd);
            groupBox3.Location = new Point(423, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(302, 123);
            groupBox3.TabIndex = 10;
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
            groupBox2.Controls.Add(txtReceivedPurchaseInvoiceId);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(numWarrantyMonths);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(dtpWarrantyStart);
            groupBox2.Controls.Add(cboProductVariant);
            groupBox2.Controls.Add(txtStatus);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtImei);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(14, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(323, 382);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin các dòng sản phẩm";
            // 
            // txtReceivedPurchaseInvoiceId
            // 
            txtReceivedPurchaseInvoiceId.Location = new Point(118, 326);
            txtReceivedPurchaseInvoiceId.Name = "txtReceivedPurchaseInvoiceId";
            txtReceivedPurchaseInvoiceId.Size = new Size(185, 30);
            txtReceivedPurchaseInvoiceId.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 334);
            label7.Name = "label7";
            label7.Size = new Size(115, 22);
            label7.TabIndex = 13;
            label7.Text = "Mã hóa đơn: ";
            // 
            // numWarrantyMonths
            // 
            numWarrantyMonths.Location = new Point(171, 277);
            numWarrantyMonths.Name = "numWarrantyMonths";
            numWarrantyMonths.Size = new Size(132, 30);
            numWarrantyMonths.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 279);
            label6.Name = "label6";
            label6.Size = new Size(163, 22);
            label6.TabIndex = 11;
            label6.Text = "Số tháng bảo hành: ";
            // 
            // dtpWarrantyStart
            // 
            dtpWarrantyStart.Location = new Point(146, 223);
            dtpWarrantyStart.Name = "dtpWarrantyStart";
            dtpWarrantyStart.Size = new Size(157, 30);
            dtpWarrantyStart.TabIndex = 10;
            // 
            // cboProductVariant
            // 
            cboProductVariant.DisplayMember = "Name";
            cboProductVariant.FormattingEnabled = true;
            cboProductVariant.Location = new Point(171, 95);
            cboProductVariant.Name = "cboProductVariant";
            cboProductVariant.Size = new Size(132, 30);
            cboProductVariant.TabIndex = 9;
            cboProductVariant.ValueMember = "ManufacturerId";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(116, 162);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(185, 30);
            txtStatus.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 228);
            label5.Name = "label5";
            label5.Size = new Size(134, 22);
            label5.TabIndex = 6;
            label5.Text = "Warranty Start: ";
            // 
            // txtImei
            // 
            txtImei.Location = new Point(116, 34);
            txtImei.Name = "txtImei";
            txtImei.Size = new Size(187, 30);
            txtImei.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 165);
            label4.Name = "label4";
            label4.Size = new Size(68, 22);
            label4.TabIndex = 2;
            label4.Text = "Status: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 98);
            label3.Name = "label3";
            label3.Size = new Size(143, 22);
            label3.TabIndex = 1;
            label3.Text = "Product Variant: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 37);
            label2.Name = "label2";
            label2.Size = new Size(51, 22);
            label2.TabIndex = 0;
            label2.Text = "IMEI";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtKeyWord);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(784, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 110);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm theo IMEI/SKU";
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
            txtKeyWord.Location = new Point(135, 23);
            txtKeyWord.Name = "txtKeyWord";
            txtKeyWord.Size = new Size(163, 30);
            txtKeyWord.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 26);
            label1.Name = "label1";
            label1.Size = new Size(101, 22);
            label1.TabIndex = 0;
            label1.Text = "IMEI/SKU:";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dgvImei
            // 
            dgvImei.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvImei.Location = new Point(384, 166);
            dgvImei.Name = "dgvImei";
            dgvImei.RowHeadersWidth = 51;
            dgvImei.Size = new Size(708, 308);
            dgvImei.TabIndex = 11;
            dgvImei.CellContentClick += dgvImei_CellContentClick;
            // 
            // frmImeiUnits
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 495);
            Controls.Add(dgvImei);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmImeiUnits";
            Text = "Kho IMEI";
            Load += frmImeiUnits_Load;
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numWarrantyMonths).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImei).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox3;
        private Button btnExit;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private GroupBox groupBox2;
        private TextBox txtStatus;
        private Label label5;
        private TextBox txtName;
        private TextBox txtImei;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox groupBox1;
        private Button btnSearch;
        private TextBox txtKeyWord;
        private Label label1;
        private NumericUpDown numWarrantyMonths;
        private Label label6;
        private DateTimePicker dtpWarrantyStart;
        private ComboBox cboProductVariant;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private TextBox txtReceivedPurchaseInvoiceId;
        private Label label7;
        private DataGridView dgvImei;
    }
}