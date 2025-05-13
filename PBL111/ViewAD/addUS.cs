using PBL111.BLL;
using PBL111.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PBL111.ViewAD
{
    public partial class addUS : Form
    {
        private readonly UserBLL _userBLL;
        public addUS()
        {
            InitializeComponent();
            _userBLL = new UserBLL();
            LoadComboBoxStatus();
        }
        private void LoadComboBoxStatus()
        {
            List<string> statusList = new List<string>
            {
                "Hoạt động",
                "Khóa"
            };
            cbBTT.DataSource = statusList;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            MainAD mainAD = new MainAD();
            this.Hide();
            mainAD.ShowDialog();

            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFN.Text) ||
                    string.IsNullOrEmpty(txtUS.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text) ||
                    string.IsNullOrEmpty(txtMK.Text) ||
                    cbBTT.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }
                user newUser = new user
                {
                    username = txtUS.Text,
                    Fullname = txtFN.Text,
                    Email = txtEmail.Text,
                    password = txtMK.Text,
                    IsActive = cbBTT.SelectedItem.ToString() == "Hoạt động"
                };
                bool success = _userBLL.Register(newUser, txtMK.Text);
                if (success)
                {
                    MessageBox.Show("Đăng ký thành công.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên người dùng đã tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
