
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PBL111.BLL;
using PBL111.DTO;
using PBL111.ViewAD;


namespace PBL111.View
{
    public partial class Login : Form
    {
        private readonly UserBLL userBLL;
        public Login()
        {
            InitializeComponent();
            userBLL = new UserBLL();
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            Dangky dangky = new Dangky();
            dangky.Show();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUS.Text.Trim();
            string matKhau = txtPW.Text.Trim();
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.");
                return;
            }
            try
            {
                user user = userBLL.Authenticate(tenDangNhap, matKhau);
                if (user != null)
                {
                    if (user.IsActive.HasValue && !user.IsActive.Value)
                    {
                        MessageBox.Show("Tài khoản của bạn đã bị khóa. Vui lòng liên hệ admin để được hỗ trợ.", "Tài khoản bị khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lưu thông tin người dùng vào Session
                    Session.CurrentUserId = user.userID;
                    Session.CurrentUserName = user.username;
                    Session.CurrentFullName = user.Fullname;
                    Session.CurrentUserEmail = user.Email;
                    Session.IsAdmin = userBLL.HasPermission(user.userID, "Admin");

                    this.Hide();
                    if (Session.IsAdmin)
                    {
                        using (var mainAD = new MainAD())
                        {
                            mainAD.ShowDialog();
                        }
                    }
                    else
                    {
                        using (var mainUS = new mainUS())
                        {
                            mainUS.ShowDialog();
                        }
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static class Session
        {
            public static int CurrentUserId { get; set; }
            public static string CurrentFullName { get; set; }
            public static string CurrentUserName { get; set; }
            public static bool IsAdmin { get; set; }
            public static string CurrentUserEmail { get; internal set; }
        }
    }
}
