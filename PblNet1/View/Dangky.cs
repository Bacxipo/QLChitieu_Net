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
using PblNet1.BLL;
using PblNet1.DTO;

namespace PblNet1.View
{
    public partial class Dangky : Form
    {
        private readonly UserBLL userBLL;
        public Dangky()
        {
            InitializeComponent();
            userBLL = new UserBLL();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            try {
                if(string.IsNullOrEmpty(txtUsername.Text)||
                    string.IsNullOrEmpty(txtName.Text)||
                    string.IsNullOrEmpty(txtEmail.Text)||
                    string.IsNullOrEmpty(txtPW.Text)||
                    string.IsNullOrEmpty(txtPW1.Text))
                    {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                    }
                if (txtPW.Text != txtPW1.Text)
                {
                    MessageBox.Show("Mật khẩu không khớp.");
                    return;
                }
                user newUser = new user
                {
                    username = txtUsername.Text,
                    Fullname = txtName.Text,
                    Email = txtEmail.Text,
                    password = txtPW.Text
                };
                bool success = userBLL.Register(newUser, txtPW.Text);
                if (success)
                {
                    MessageBox.Show("Đăng ký thành công.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên người dùng đã tồn tại.");
                }
            } catch (Exception ex){
                  MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
    }
}
