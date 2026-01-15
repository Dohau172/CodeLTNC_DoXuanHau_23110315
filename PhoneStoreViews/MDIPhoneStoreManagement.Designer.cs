namespace PhoneStoreViews
{
    partial class MDIPhoneStoreManagement
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
            menuStrip1 = new MenuStrip();
            mnuCatalog = new ToolStripMenuItem();
            mnuCustomer = new ToolStripMenuItem();
            mnuEmployee = new ToolStripMenuItem();
            mnuSupplier = new ToolStripMenuItem();
            mnuManufacturer = new ToolStripMenuItem();
            mnuProductLine = new ToolStripMenuItem();
            mnuProductVariant = new ToolStripMenuItem();
            mnuImeiUnits = new ToolStripMenuItem();
            mnuBusiness = new ToolStripMenuItem();
            mnuPurchaseInvoice = new ToolStripMenuItem();
            mnuSalesInvoice = new ToolStripMenuItem();
            mnuWarrantyTickets = new ToolStripMenuItem();
            mnuWindow = new ToolStripMenuItem();
            mnuCascade = new ToolStripMenuItem();
            mnuTileH = new ToolStripMenuItem();
            mnuTileV = new ToolStripMenuItem();
            mnuCloseAll = new ToolStripMenuItem();
            mnuSystem = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuCatalog, mnuBusiness, mnuWindow, mnuSystem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1100, 43);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuCatalog
            // 
            mnuCatalog.BackColor = SystemColors.ActiveCaption;
            mnuCatalog.DropDownItems.AddRange(new ToolStripItem[] { mnuCustomer, mnuEmployee, mnuSupplier, mnuManufacturer, mnuProductLine, mnuProductVariant, mnuImeiUnits });
            mnuCatalog.ImageTransparentColor = Color.White;
            mnuCatalog.Name = "mnuCatalog";
            mnuCatalog.Size = new Size(158, 39);
            mnuCatalog.Text = "Danh mục";
            // 
            // mnuCustomer
            // 
            mnuCustomer.Name = "mnuCustomer";
            mnuCustomer.Size = new Size(338, 40);
            mnuCustomer.Text = "Khách hàng";
            mnuCustomer.Click += Menu_Click;
            // 
            // mnuEmployee
            // 
            mnuEmployee.Name = "mnuEmployee";
            mnuEmployee.Size = new Size(338, 40);
            mnuEmployee.Text = "Nhân viên";
            mnuEmployee.Click += Menu_Click;
            // 
            // mnuSupplier
            // 
            mnuSupplier.Name = "mnuSupplier";
            mnuSupplier.Size = new Size(338, 40);
            mnuSupplier.Text = "Nhà cung cấp";
            mnuSupplier.Click += Menu_Click;
            // 
            // mnuManufacturer
            // 
            mnuManufacturer.Name = "mnuManufacturer";
            mnuManufacturer.Size = new Size(338, 40);
            mnuManufacturer.Text = "Hãng";
            mnuManufacturer.Click += Menu_Click;
            // 
            // mnuProductLine
            // 
            mnuProductLine.Name = "mnuProductLine";
            mnuProductLine.Size = new Size(338, 40);
            mnuProductLine.Text = "Dòng sản phẩm";
            mnuProductLine.Click += Menu_Click;
            // 
            // mnuProductVariant
            // 
            mnuProductVariant.Name = "mnuProductVariant";
            mnuProductVariant.Size = new Size(338, 40);
            mnuProductVariant.Text = "Biến thể sản phẩm";
            mnuProductVariant.Click += Menu_Click;
            // 
            // mnuImeiUnits
            // 
            mnuImeiUnits.Name = "mnuImeiUnits";
            mnuImeiUnits.Size = new Size(338, 40);
            mnuImeiUnits.Text = "IMEI";
            mnuImeiUnits.Click += Menu_Click;
            // 
            // mnuBusiness
            // 
            mnuBusiness.BackColor = SystemColors.Control;
            mnuBusiness.DropDownItems.AddRange(new ToolStripItem[] { mnuPurchaseInvoice, mnuSalesInvoice, mnuWarrantyTickets });
            mnuBusiness.Name = "mnuBusiness";
            mnuBusiness.Size = new Size(158, 39);
            mnuBusiness.Text = "Nghiệp vụ";
            // 
            // mnuPurchaseInvoice
            // 
            mnuPurchaseInvoice.Name = "mnuPurchaseInvoice";
            mnuPurchaseInvoice.Size = new Size(243, 40);
            mnuPurchaseInvoice.Text = "Nhập hàng";
            mnuPurchaseInvoice.Click += Menu_Click;
            // 
            // mnuSalesInvoice
            // 
            mnuSalesInvoice.Name = "mnuSalesInvoice";
            mnuSalesInvoice.Size = new Size(243, 40);
            mnuSalesInvoice.Text = "Bán hàng";
            mnuSalesInvoice.Click += Menu_Click;
            // 
            // mnuWarrantyTickets
            // 
            mnuWarrantyTickets.Name = "mnuWarrantyTickets";
            mnuWarrantyTickets.Size = new Size(243, 40);
            mnuWarrantyTickets.Text = "Bảo hành";
            mnuWarrantyTickets.Click += Menu_Click;
            // 
            // mnuWindow
            // 
            mnuWindow.BackColor = SystemColors.ActiveCaption;
            mnuWindow.DropDownItems.AddRange(new ToolStripItem[] { mnuCascade, mnuTileH, mnuTileV, mnuCloseAll });
            mnuWindow.Name = "mnuWindow";
            mnuWindow.Size = new Size(118, 39);
            mnuWindow.Text = "Cửa sổ";
            // 
            // mnuCascade
            // 
            mnuCascade.Name = "mnuCascade";
            mnuCascade.Size = new Size(293, 40);
            mnuCascade.Text = "Cascade";
            mnuCascade.Click += Menu_Click;
            // 
            // mnuTileH
            // 
            mnuTileH.Name = "mnuTileH";
            mnuTileH.Size = new Size(293, 40);
            mnuTileH.Text = "Tile Horizontal";
            mnuTileH.Click += Menu_Click;
            // 
            // mnuTileV
            // 
            mnuTileV.Name = "mnuTileV";
            mnuTileV.Size = new Size(293, 40);
            mnuTileV.Text = "Tile Vertical";
            mnuTileV.Click += Menu_Click;
            // 
            // mnuCloseAll
            // 
            mnuCloseAll.Name = "mnuCloseAll";
            mnuCloseAll.Size = new Size(293, 40);
            mnuCloseAll.Text = "Close All";
            mnuCloseAll.Click += Menu_Click;
            // 
            // mnuSystem
            // 
            mnuSystem.DropDownItems.AddRange(new ToolStripItem[] { mnuExit });
            mnuSystem.Name = "mnuSystem";
            mnuSystem.Size = new Size(145, 39);
            mnuSystem.Text = "Hệ thống";
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(180, 40);
            mnuExit.Text = "Thoát";
            mnuExit.Click += Menu_Click;
            // 
            // MDIPhoneStoreManagement
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 495);
            Controls.Add(menuStrip1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MDIPhoneStoreManagement";
            Text = "Quản lý Của hàng điện thoại";
            WindowState = FormWindowState.Minimized;
            Load += MDIPhoneStoreManagement_Load;
            Click += Menu_Click;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuCatalog;
        private ToolStripMenuItem mnuCustomer;
        private ToolStripMenuItem mnuEmployee;
        private ToolStripMenuItem mnuSupplier;
        private ToolStripMenuItem mnuManufacturer;
        private ToolStripMenuItem mnuProductLine;
        private ToolStripMenuItem mnuProductVariant;
        private ToolStripMenuItem mnuImeiUnits;
        private ToolStripMenuItem mnuBusiness;
        private ToolStripMenuItem mnuWindow;
        private ToolStripMenuItem mnuSystem;
        private ToolStripMenuItem mnuPurchaseInvoice;
        private ToolStripMenuItem mnuSalesInvoice;
        private ToolStripMenuItem mnuWarrantyTickets;
        private ToolStripMenuItem mnuCascade;
        private ToolStripMenuItem mnuTileH;
        private ToolStripMenuItem mnuTileV;
        private ToolStripMenuItem mnuCloseAll;
        private ToolStripMenuItem mnuExit;
    }
}