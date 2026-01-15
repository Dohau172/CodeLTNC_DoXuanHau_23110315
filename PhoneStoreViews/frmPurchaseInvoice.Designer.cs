namespace PhoneStoreViews
{
    partial class frmPurchaseInvoice
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
            textBox1 = new TextBox();
            label6 = new Label();
            cboEmployee = new ComboBox();
            label5 = new Label();
            cboSupplier = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            dtpCreatedAt = new DateTimePicker();
            txtCode = new TextBox();
            label2 = new Label();
            txtPurchaseInvoiceId = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvPurchaseDetails = new DataGridView();
            BtnClearDetail = new Button();
            btnRemoveDetail = new Button();
            btnAddDetail = new Button();
            numsQuantity = new NumericUpDown();
            label9 = new Label();
            numQuantity = new NumericUpDown();
            label8 = new Label();
            cboProductVariant = new ComboBox();
            label7 = new Label();
            txtTotalMoney = new TextBox();
            label10 = new Label();
            btnCreateNew = new Button();
            btnSave = new Button();
            btnDeleteInvoice = new Button();
            btnPrint = new Button();
            numCost = new NumericUpDown();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numsQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cboEmployee);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cboSupplier);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpCreatedAt);
            groupBox1.Controls.Add(txtCode);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPurchaseInvoiceId);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(23, 17);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(328, 373);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin cơ bản";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(137, 318);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(185, 30);
            textBox1.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 321);
            label6.Name = "label6";
            label6.Size = new Size(62, 22);
            label6.TabIndex = 10;
            label6.Text = "Notes:";
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
            // cboSupplier
            // 
            cboSupplier.FormattingEnabled = true;
            cboSupplier.Location = new Point(137, 205);
            cboSupplier.Name = "cboSupplier";
            cboSupplier.Size = new Size(185, 30);
            cboSupplier.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 208);
            label4.Name = "label4";
            label4.Size = new Size(127, 22);
            label4.TabIndex = 6;
            label4.Text = "Nhà cung cấp: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 146);
            label3.Name = "label3";
            label3.Size = new Size(132, 22);
            label3.TabIndex = 5;
            label3.Text = "Ngày được tạo:";
            // 
            // dtpCreatedAt
            // 
            dtpCreatedAt.Location = new Point(137, 140);
            dtpCreatedAt.Name = "dtpCreatedAt";
            dtpCreatedAt.Size = new Size(185, 30);
            dtpCreatedAt.TabIndex = 4;
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
            // txtPurchaseInvoiceId
            // 
            txtPurchaseInvoiceId.Location = new Point(137, 33);
            txtPurchaseInvoiceId.Name = "txtPurchaseInvoiceId";
            txtPurchaseInvoiceId.Size = new Size(185, 30);
            txtPurchaseInvoiceId.TabIndex = 1;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(numCost);
            groupBox2.Controls.Add(dgvPurchaseDetails);
            groupBox2.Controls.Add(BtnClearDetail);
            groupBox2.Controls.Add(btnRemoveDetail);
            groupBox2.Controls.Add(btnAddDetail);
            groupBox2.Controls.Add(numsQuantity);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(numQuantity);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(cboProductVariant);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(391, 17);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(697, 369);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chi tiết";
            // 
            // dgvPurchaseDetails
            // 
            dgvPurchaseDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchaseDetails.Location = new Point(6, 111);
            dgvPurchaseDetails.Name = "dgvPurchaseDetails";
            dgvPurchaseDetails.RowHeadersWidth = 51;
            dgvPurchaseDetails.Size = new Size(545, 246);
            dgvPurchaseDetails.TabIndex = 10;
            // 
            // BtnClearDetail
            // 
            BtnClearDetail.Location = new Point(576, 186);
            BtnClearDetail.Name = "BtnClearDetail";
            BtnClearDetail.Size = new Size(94, 29);
            BtnClearDetail.TabIndex = 9;
            BtnClearDetail.Text = "Clear";
            BtnClearDetail.UseVisualStyleBackColor = true;
            BtnClearDetail.Click += BtnClearDetail_Click;
            // 
            // btnRemoveDetail
            // 
            btnRemoveDetail.Location = new Point(576, 121);
            btnRemoveDetail.Name = "btnRemoveDetail";
            btnRemoveDetail.Size = new Size(94, 29);
            btnRemoveDetail.TabIndex = 8;
            btnRemoveDetail.Text = "Xóa";
            btnRemoveDetail.UseVisualStyleBackColor = true;
            btnRemoveDetail.Click += btnRemoveDetail_Click;
            // 
            // btnAddDetail
            // 
            btnAddDetail.Location = new Point(576, 56);
            btnAddDetail.Name = "btnAddDetail";
            btnAddDetail.Size = new Size(94, 29);
            btnAddDetail.TabIndex = 7;
            btnAddDetail.Text = "Thêm";
            btnAddDetail.UseVisualStyleBackColor = true;
            btnAddDetail.Click += btnAddDetail_Click;
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
            label9.Size = new Size(52, 22);
            label9.TabIndex = 4;
            label9.Text = "Price";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(32339, 455);
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
            // cboProductVariant
            // 
            cboProductVariant.FormattingEnabled = true;
            cboProductVariant.Location = new Point(6, 51);
            cboProductVariant.Name = "cboProductVariant";
            cboProductVariant.Size = new Size(151, 30);
            cboProductVariant.TabIndex = 1;
            cboProductVariant.SelectedIndexChanged += cboProductVariant_SelectedIndexChanged ;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 26);
            label7.Name = "label7";
            label7.Size = new Size(110, 22);
            label7.TabIndex = 0;
            label7.Text = "Pro.Variant: ";
            // 
            // txtTotalMoney
            // 
            txtTotalMoney.Location = new Point(160, 414);
            txtTotalMoney.Multiline = true;
            txtTotalMoney.Name = "txtTotalMoney";
            txtTotalMoney.Size = new Size(185, 30);
            txtTotalMoney.TabIndex = 13;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(29, 417);
            label10.Name = "label10";
            label10.Size = new Size(116, 22);
            label10.TabIndex = 12;
            label10.Text = "Total Money:";
            // 
            // btnCreateNew
            // 
            btnCreateNew.Location = new Point(391, 414);
            btnCreateNew.Name = "btnCreateNew";
            btnCreateNew.Size = new Size(94, 29);
            btnCreateNew.TabIndex = 14;
            btnCreateNew.Text = "Tạo mới";
            btnCreateNew.UseVisualStyleBackColor = true;
            btnCreateNew.Click += btnCreateNew_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(550, 414);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 15;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDeleteInvoice
            // 
            btnDeleteInvoice.Location = new Point(743, 414);
            btnDeleteInvoice.Name = "btnDeleteInvoice";
            btnDeleteInvoice.Size = new Size(94, 29);
            btnDeleteInvoice.TabIndex = 16;
            btnDeleteInvoice.Text = "Xóa";
            btnDeleteInvoice.UseVisualStyleBackColor = true;
            btnDeleteInvoice.Click += btnDeleteInvoice_Click;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(967, 415);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(94, 29);
            btnPrint.TabIndex = 17;
            btnPrint.Text = "In";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // numCost
            // 
            numCost.Location = new Point(374, 51);
            numCost.Maximum = new decimal(new int[] { -1486618625, 232830643, 0, 0 });
            numCost.Name = "numCost";
            numCost.Size = new Size(121, 30);
            numCost.TabIndex = 11;
            // 
            // frmPurchaseInvoice
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
            Name = "frmPurchaseInvoice";
            Text = "Hóa đơn nhập";
            Load += frmPurchaseInvoice_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchaseDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)numsQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void CboProductVariant_Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cboEmployee;
        private Label label5;
        private ComboBox cboSupplier;
        private Label label4;
        private Label label3;
        private DateTimePicker dtpCreatedAt;
        private TextBox txtCode;
        private Label label2;
        private TextBox txtPurchaseInvoiceId;
        private Label label1;
        private TextBox textBox1;
        private Label label6;
        private GroupBox groupBox2;
        private Label label9;
        private NumericUpDown numQuantity;
        private Label label8;
        private ComboBox cboProductVariant;
        private Label label7;
        private DataGridView dgvPurchaseDetails;
        private Button BtnClearDetail;
        private Button btnRemoveDetail;
        private Button btnAddDetail;
        private NumericUpDown numsQuantity;
        private TextBox txtTotalMoney;
        private Label label10;
        private Button btnCreateNew;
        private Button btnSave;
        private Button btnDeleteInvoice;
        private Button btnPrint;
        private NumericUpDown numCost;
    }
}