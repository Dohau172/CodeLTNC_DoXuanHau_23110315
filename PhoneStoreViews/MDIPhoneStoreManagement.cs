using System;
using System.Windows.Forms;

namespace PhoneStoreViews
{
    public partial class MDIPhoneStoreManagement : Form
    {
        public MDIPhoneStoreManagement()
        {
            InitializeComponent();
        }

        private void MDIPhoneStoreManagement_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

        }


        //// =========================
        //// 1) Event chung cho menu
        //// =========================
        private void Menu_Click(object sender, EventArgs e)
        {
            if (sender == null) return;

            string name = ((ToolStripMenuItem)sender).Name;

            switch (name)
            {
                // ===== Danh mục =====
                case "mnuCustomer":
                    OpenChild(new frmCustomer());
                    break;

                case "mnuEmployee":
                    OpenChild(new frmEmployee());
                    break;

                case "mnuSupplier":
                    OpenChild(new frmSupplier());
                    break;

                case "mnuManufacturer":
                    OpenChild(new frmManufacturer());
                    break;

                case "mnuProductLine":
                    OpenChild(new frmProductLine());
                    break;

                case "mnuProductVariant":
                    OpenChild(new frmProductVariant());
                    break;

                case "mnuImeiUnits":
                    OpenChild(new frmImeiUnits());
                    break;

                // ===== Nghiệp vụ =====
                case "mnuPurchaseInvoice":
                    OpenChild(new frmPurchaseInvoice());
                    break;

                case "mnuSalesInvoice":
                    OpenChild(new frmSalesInvoice());
                    break;

                case "mnuWarrantyTickets":
                    OpenChild(new frmWarrantyTickets());
                    break;

                // ===== Cửa sổ =====
                case "mnuCascade":
                    this.LayoutMdi(MdiLayout.Cascade);
                    break;

                case "mnuTileH":
                    this.LayoutMdi(MdiLayout.TileHorizontal);
                    break;

                case "mnuTileV":
                    this.LayoutMdi(MdiLayout.TileVertical);
                    break;

                case "mnuCloseAll":
                    CloseAllChildren();
                    break;

                // ===== Hệ thống =====
                case "mnuExit":
                    this.Close();
                    break;

                default:
                    MessageBox.Show("Menu chưa được xử lý: " + name);
                    break;
            }
        }

        // =========================
        // 2) OpenChild: tránh mở trùng
        // =========================
        private void OpenChild(Form child)
        {
            // Nếu form này đã mở rồi thì focus, không mở trùng
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == child.GetType())
                {
                    f.WindowState = FormWindowState.Normal;
                    f.Activate();
                    child.Dispose();
                    return;
                }
            }

            child.MdiParent = this;
            child.StartPosition = FormStartPosition.CenterScreen;
            child.WindowState = FormWindowState.Maximized;
            child.Show();
        }

        private void CloseAllChildren()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }


    }
}
