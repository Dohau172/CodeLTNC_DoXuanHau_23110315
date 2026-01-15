namespace PhoneStoreViews
{
    partial class frmProductVariant
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
            txtProductLinesId = new TextBox();
            label2 = new Label();
            numSalePrice = new NumericUpDown();
            label7 = new Label();
            label6 = new Label();
            numStorageGb = new NumericUpDown();
            txtColor = new TextBox();
            txtSku = new TextBox();
            label5 = new Label();
            label4 = new Label();
            cboProductLine = new ComboBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            txtKeyWord = new TextBox();
            label1 = new Label();
            dgvProductVariant = new DataGridView();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStorageGb).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductVariant).BeginInit();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnExit);
            groupBox3.Controls.Add(btnUpdate);
            groupBox3.Controls.Add(btnDelete);
            groupBox3.Controls.Add(btnAdd);
            groupBox3.Location = new Point(13, 285);
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
            groupBox2.Controls.Add(txtProductLinesId);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(numSalePrice);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(numStorageGb);
            groupBox2.Controls.Add(txtColor);
            groupBox2.Controls.Add(txtSku);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(cboProductLine);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(14, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(323, 264);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin chi tiết sản phẩm";
            // 
            // txtProductLinesId
            // 
            txtProductLinesId.Location = new Point(106, 29);
            txtProductLinesId.Name = "txtProductLinesId";
            txtProductLinesId.Size = new Size(187, 30);
            txtProductLinesId.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(-4, 32);
            label2.Name = "label2";
            label2.Size = new Size(36, 22);
            label2.TabIndex = 14;
            label2.Text = "ID:";
            // 
            // numSalePrice
            // 
            numSalePrice.Location = new Point(227, 223);
            numSalePrice.Maximum = new decimal(new int[] { 1316134912, 2328, 0, 0 });
            numSalePrice.Name = "numSalePrice";
            numSalePrice.Size = new Size(58, 30);
            numSalePrice.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(144, 225);
            label7.Name = "label7";
            label7.Size = new Size(87, 22);
            label7.TabIndex = 12;
            label7.Text = "Giá sale: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-2, 225);
            label6.Name = "label6";
            label6.Size = new Size(43, 22);
            label6.TabIndex = 11;
            label6.Text = "GB:";
            // 
            // numStorageGb
            // 
            numStorageGb.Location = new Point(47, 223);
            numStorageGb.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numStorageGb.Name = "numStorageGb";
            numStorageGb.Size = new Size(58, 30);
            numStorageGb.TabIndex = 10;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(106, 170);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(187, 30);
            txtColor.TabIndex = 9;
            // 
            // txtSku
            // 
            txtSku.Location = new Point(108, 128);
            txtSku.Name = "txtSku";
            txtSku.Size = new Size(187, 30);
            txtSku.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(-2, 173);
            label5.Name = "label5";
            label5.Size = new Size(51, 22);
            label5.TabIndex = 7;
            label5.Text = "Màu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(-2, 131);
            label4.Name = "label4";
            label4.Size = new Size(48, 22);
            label4.TabIndex = 6;
            label4.Text = "SKU";
            // 
            // cboProductLine
            // 
            cboProductLine.FormattingEnabled = true;
            cboProductLine.Location = new Point(108, 80);
            cboProductLine.Name = "cboProductLine";
            cboProductLine.Size = new Size(187, 30);
            cboProductLine.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(-2, 80);
            label3.Name = "label3";
            label3.Size = new Size(95, 22);
            label3.TabIndex = 4;
            label3.Text = "Dòng máy:";
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
            groupBox1.Text = "Tìm kiếm sản phẩm";
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
            // dgvProductVariant
            // 
            dgvProductVariant.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductVariant.Location = new Point(383, 144);
            dgvProductVariant.Name = "dgvProductVariant";
            dgvProductVariant.RowHeadersWidth = 51;
            dgvProductVariant.Size = new Size(699, 256);
            dgvProductVariant.TabIndex = 11;
            dgvProductVariant.CellContentClick += dgvProductVariant_CellContentClick;
            // 
            // frmProductVariant
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 495);
            Controls.Add(dgvProductVariant);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmProductVariant";
            Text = "Chi tiết sản phẩm";
            Load += frmProductVariant_Load;
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStorageGb).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductVariant).EndInit();
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
        private NumericUpDown numStorageGb;
        private TextBox txtColor;
        private TextBox txtSku;
        private Label label5;
        private Label label4;
        private ComboBox cboProductLine;
        private Label label3;
        private GroupBox groupBox1;
        private Button btnSearch;
        private TextBox txtKeyWord;
        private Label label1;
        private NumericUpDown numSalePrice;
        private Label label7;
        private Label label6;
        private DataGridView dgvProductVariant;
        private TextBox txtProductLinesId;
        private Label label2;
    }
}