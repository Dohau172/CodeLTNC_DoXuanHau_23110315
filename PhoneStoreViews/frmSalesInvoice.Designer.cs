namespace PhoneStoreViews
{
    partial class frmSalesInvoice
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
            btnPrint = new Button();
            btnDeleteInvoice = new Button();
            btnSave = new Button();
            btnCreateNew = new Button();
            txtTotalMoney = new TextBox();
            label10 = new Label();
            groupBox2 = new GroupBox();
            btnClearDetails = new Button();
            btnAddDeatail = new Button();
            txtImeiScan = new TextBox();
            dgvSalesDetails = new DataGridView();
            btnRemoveDetail = new Button();
            numCost = new NumericUpDown();
            numsQuantity = new NumericUpDown();
            label9 = new Label();
            numQuantity = new NumericUpDown();
            label8 = new Label();
            label7 = new Label();
            groupBox1 = new GroupBox();
            cboPaymentMethod = new ComboBox();
            label6 = new Label();
            cboEmployee = new ComboBox();
            label5 = new Label();
            cboCustomer = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            dtpSoldAt = new DateTimePicker();
            txtCode = new TextBox();
            label2 = new Label();
            txtSalesInvoiceId = new TextBox();
            label1 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numsQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(962, 432);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(94, 29);
            btnPrint.TabIndex = 25;
            btnPrint.Text = "In";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnDeleteInvoice
            // 
            btnDeleteInvoice.Location = new Point(738, 431);
            btnDeleteInvoice.Name = "btnDeleteInvoice";
            btnDeleteInvoice.Size = new Size(94, 29);
            btnDeleteInvoice.TabIndex = 24;
            btnDeleteInvoice.Text = "Xóa";
            btnDeleteInvoice.UseVisualStyleBackColor = true;
            btnDeleteInvoice.Click += btnDeleteInvoice_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(545, 431);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 23;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCreateNew
            // 
            btnCreateNew.Location = new Point(386, 431);
            btnCreateNew.Name = "btnCreateNew";
            btnCreateNew.Size = new Size(94, 29);
            btnCreateNew.TabIndex = 22;
            btnCreateNew.Text = "Tạo mới";
            btnCreateNew.UseVisualStyleBackColor = true;
            btnCreateNew.Click += btnCreateNew_Click;
            // 
            // txtTotalMoney
            // 
            txtTotalMoney.Location = new Point(155, 431);
            txtTotalMoney.Multiline = true;
            txtTotalMoney.Name = "txtTotalMoney";
            txtTotalMoney.Size = new Size(185, 30);
            txtTotalMoney.TabIndex = 21;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(24, 434);
            label10.Name = "label10";
            label10.Size = new Size(116, 22);
            label10.TabIndex = 20;
            label10.Text = "Total Money:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnClearDetails);
            groupBox2.Controls.Add(btnAddDeatail);
            groupBox2.Controls.Add(txtImeiScan);
            groupBox2.Controls.Add(dgvSalesDetails);
            groupBox2.Controls.Add(btnRemoveDetail);
            groupBox2.Controls.Add(numCost);
            groupBox2.Controls.Add(numsQuantity);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(numQuantity);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(386, 34);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(697, 369);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi tiết";
            // 
            // btnClearDetails
            // 
            btnClearDetails.Location = new Point(576, 182);
            btnClearDetails.Name = "btnClearDetails";
            btnClearDetails.Size = new Size(94, 29);
            btnClearDetails.TabIndex = 13;
            btnClearDetails.Text = "Clear";
            btnClearDetails.UseVisualStyleBackColor = true;
            btnClearDetails.Click += btnClearDetails_Click;
            // 
            // btnAddDeatail
            // 
            btnAddDeatail.Location = new Point(576, 71);
            btnAddDeatail.Name = "btnAddDeatail";
            btnAddDeatail.Size = new Size(94, 29);
            btnAddDeatail.TabIndex = 12;
            btnAddDeatail.Text = "Thêm";
            btnAddDeatail.UseVisualStyleBackColor = true;
            btnAddDeatail.Click += btnAddDeatail_Click;
            // 
            // txtImeiScan
            // 
            txtImeiScan.Location = new Point(6, 50);
            txtImeiScan.Name = "txtImeiScan";
            txtImeiScan.Size = new Size(148, 30);
            txtImeiScan.TabIndex = 11;
            txtImeiScan.TextChanged += txtImeiScan_TextChanged;
            // 
            // dgvSalesDetails
            // 
            dgvSalesDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesDetails.Location = new Point(14, 110);
            dgvSalesDetails.Name = "dgvSalesDetails";
            dgvSalesDetails.RowHeadersWidth = 51;
            dgvSalesDetails.Size = new Size(545, 247);
            dgvSalesDetails.TabIndex = 10;
            // 
            // btnRemoveDetail
            // 
            btnRemoveDetail.Location = new Point(576, 121);
            btnRemoveDetail.Name = "btnRemoveDetail";
            btnRemoveDetail.Size = new Size(94, 29);
            btnRemoveDetail.TabIndex = 8;
            btnRemoveDetail.Text = "Remove";
            btnRemoveDetail.UseVisualStyleBackColor = true;
            btnRemoveDetail.Click += btnRemoveDetail_Click;
            // 
            // numCost
            // 
            numCost.Location = new Point(370, 52);
            numCost.Maximum = new decimal(new int[] { 276447231, 23283, 0, 0 });
            numCost.Name = "numCost";
            numCost.Size = new Size(121, 30);
            numCost.TabIndex = 6;
            // 
            // numsQuantity
            // 
            numsQuantity.Location = new Point(211, 51);
            numsQuantity.Name = "numsQuantity";
            numsQuantity.Size = new Size(121, 30);
            numsQuantity.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(388, 26);
            label9.Name = "label9";
            label9.Size = new Size(46, 22);
            label9.TabIndex = 4;
            label9.Text = "Cost";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(32042, 455);
            numQuantity.Margin = new Padding(4763, 3, 4763, 3);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(65535, 30);
            numQuantity.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(233, 26);
            label8.Name = "label8";
            label8.Size = new Size(76, 22);
            label8.TabIndex = 2;
            label8.Text = "Quantity";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 26);
            label7.Name = "label7";
            label7.Size = new Size(94, 22);
            label7.TabIndex = 0;
            label7.Text = "IMEI Scan";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboPaymentMethod);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cboEmployee);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cboCustomer);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpSoldAt);
            groupBox1.Controls.Add(txtCode);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtSalesInvoiceId);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(18, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(328, 391);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin cơ bản";
            // 
            // cboPaymentMethod
            // 
            cboPaymentMethod.FormattingEnabled = true;
            cboPaymentMethod.Location = new Point(137, 343);
            cboPaymentMethod.Name = "cboPaymentMethod";
            cboPaymentMethod.Size = new Size(185, 30);
            cboPaymentMethod.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 309);
            label6.Name = "label6";
            label6.Size = new Size(193, 22);
            label6.TabIndex = 10;
            label6.Text = "Phương thức thanh toán";
            // 
            // cboEmployee
            // 
            cboEmployee.FormattingEnabled = true;
            cboEmployee.Location = new Point(137, 262);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(185, 30);
            cboEmployee.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 262);
            label5.Name = "label5";
            label5.Size = new Size(96, 22);
            label5.TabIndex = 8;
            label5.Text = "Nhân viên:";
            // 
            // cboCustomer
            // 
            cboCustomer.FormattingEnabled = true;
            cboCustomer.Location = new Point(137, 205);
            cboCustomer.Name = "cboCustomer";
            cboCustomer.Size = new Size(185, 30);
            cboCustomer.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 208);
            label4.Name = "label4";
            label4.Size = new Size(112, 22);
            label4.TabIndex = 6;
            label4.Text = "Khách hàng: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 146);
            label3.Name = "label3";
            label3.Size = new Size(94, 22);
            label3.TabIndex = 5;
            label3.Text = "Ngày mua:";
            // 
            // dtpSoldAt
            // 
            dtpSoldAt.Location = new Point(137, 140);
            dtpSoldAt.Name = "dtpSoldAt";
            dtpSoldAt.Size = new Size(185, 30);
            dtpSoldAt.TabIndex = 4;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(137, 81);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(185, 30);
            txtCode.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 89);
            label2.Name = "label2";
            label2.Size = new Size(58, 22);
            label2.TabIndex = 2;
            label2.Text = "Code:";
            // 
            // txtSalesInvoiceId
            // 
            txtSalesInvoiceId.Location = new Point(137, 33);
            txtSalesInvoiceId.Name = "txtSalesInvoiceId";
            txtSalesInvoiceId.Size = new Size(185, 30);
            txtSalesInvoiceId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 36);
            label1.Name = "label1";
            label1.Size = new Size(36, 22);
            label1.TabIndex = 0;
            label1.Text = "ID:";
            // 
            // frmSalesInvoice
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 495);
            Controls.Add(btnPrint);
            Controls.Add(btnDeleteInvoice);
            Controls.Add(btnSave);
            Controls.Add(btnCreateNew);
            Controls.Add(txtTotalMoney);
            Controls.Add(label10);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmSalesInvoice";
            Text = "Hóa đơn bán";
            Load += frmSalesInvoice_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)numsQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrint;
        private Button btnDeleteInvoice;
        private Button btnSave;
        private Button btnCreateNew;
        private TextBox txtTotalMoney;
        private Label label10;
        private GroupBox groupBox2;
        private DataGridView dgvPurchaseDetails;
        private Button BtnClearDetail;
        private Button btnRemoveDetail;
        private Button btnAddDetail;
        private NumericUpDown numCost;
        private NumericUpDown numsQuantity;
        private Label label9;
        private NumericUpDown numQuantity;
        private Label label8;
        private ComboBox cboProductVariant;
        private Label label7;
        private GroupBox groupBox1;
        private ComboBox cboPaymentMethod;
        private Label label6;
        private ComboBox cboEmployee;
        private Label label5;
        private ComboBox cboCustomer;
        private Label label4;
        private Label label3;
        private DateTimePicker dtpSoldAt;
        private TextBox txtCode;
        private Label label2;
        private TextBox txtSalesInvoiceId;
        private Label label1;
        private TextBox txtImeiScan;
        private DataGridView dgvSalesDetails;
        private Button button2;
        private Button btnAddDeatail;
        private Button btnClearDetails;
    }
}