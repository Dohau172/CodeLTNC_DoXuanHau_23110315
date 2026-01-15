using Microsoft.EntityFrameworkCore;
using PhoneStoreDAL.Contexts;
using PhoneStoreDAL.Entities;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PhoneStoreDAL.Entities.Enums;

namespace PhoneStoreViews
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public static void SeedDefaultAdmin()
        {
            using var db = new PhoneStoreDBContext();

            // Nếu đã có user admin thì thôi
            if (db.UserAccounts.Any(x => x.Username == "admin"))
                return;

            db.UserAccounts.Add(new UserAccount
            {
                Username = "admin",
                PasswordHash = HashPassword("123"),
                Role = UserRole.Admin,      // nếu enum bạn là Admin/Staff
                IsActive = true,
                CreatedAt = DateTime.Now,
                EmployeeId = null
            });

            db.SaveChanges();
        }

        private static string HashPassword(string raw)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(raw);
                byte[] hash = sha.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                    sb.Append(hash[i].ToString("x2"));

                return sb.ToString();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            SeedDefaultAdmin();
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string u = (txtUsername.Text ?? "").Trim();
            string p = (txtPassword.Text ?? "").Trim();
            if (u.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Username!");
                txtUsername.Focus();
                return;
            }

            if (p.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Password!");
                txtPassword.Focus();
                return;
            }
            btnLogin.Enabled = false;
            try
            {
                bool ok = await CheckLoginAsync(u, p);
                if (!ok)
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                    return;
                }

                // ✅ Login OK → mở form chính
                // Bạn đổi tên form chính của bạn ở đây
                this.Hide();
                MDIPhoneStoreManagement main = new MDIPhoneStoreManagement();
                main.FormClosed += Main_FormClosed;
                main.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
            finally
            {
                btnLogin.Enabled = true;
            }

        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            // đóng main thì thoát app
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Thoát chương trình?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
                Application.Exit();

        }
        private async Task<bool> CheckLoginAsync(string username, string password)
        {
            using var db = new PhoneStoreDBContext();

            string hash = HashPassword(password);

            var acc = await db.UserAccounts.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Username == username && x.IsActive);

            if (acc == null) return false;

            return string.Equals(acc.PasswordHash, hash, StringComparison.Ordinal);
        }
        


    }
}
