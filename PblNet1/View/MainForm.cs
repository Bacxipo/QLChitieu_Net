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
using static PblNet1.Login;
using System.Drawing.Text;

namespace PblNet1.View
{
    public partial class MainForm : Form
    {
        private readonly ChiphiBLL chiphiBLL;
        private readonly TheloaiBLL theloaiBLL;
        private readonly NgansachBLL ngansachBLL;

        public MainForm(DTO.user user)
        {
            InitializeComponent();
            chiphiBLL = new ChiphiBLL();
            theloaiBLL = new TheloaiBLL();
            ngansachBLL = new NgansachBLL();


        }
        private void ThietLapFrom()
        { //Ẩn các menu không cần thiết dựa trên quyền của người dùng
            adminToolStripMenuItem.Visible = Session.IsAdmin;
            reportsToolStripMenuItem.Visible = Session.IsManager || Session.IsAdmin;
            // Hiển thị tên người dùng trong label
            lalWecome.Text = $"Xin chào,   {Session.CurrentUserName}";
        }
        private void LoadLoaiGD()
        {
            var theloais = theloaiBLL.GetAllTheloai();
            cboLoai.DataSource = theloais;
            cboLoai.DisplayMember = "nameTL";
            cboLoai.ValueMember = "theloaiID";
        }
        private void LoadLoaiChi()
        {
            List<Giaodich> chiphis;
            if (Session.IsManager || Session.IsAdmin)
            {
                chiphis = chiphiBLL.GetAllExpenses(Session.CurrentUserId);

                dgvGD.Columns["User"].Visible = true;
            }
            else
            {
                chiphis = chiphiBLL.GetUserExpenses(Session.CurrentUserId);
                dgvGD.Columns["User"].Visible = false;
            }
            dgvGD.DataSource = chiphis;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Giaodich giaodich = new Giaodich
                {
                    userID = Session.CurrentUserId,
                    theloaiID = (int)cboLoai.SelectedValue,
                    soluong = int.Parse(txtSL.Text),
                    ngayGD = dtpNgayGD.Value,
                    Description = txtMT.Text,
                    diachi = txtLocation.Text
                };
                bool success = chiphiBLL.AddGD(giaodich, Session.CurrentUserId);
                if (success)
                {
                    MessageBox.Show("Thêm giao dịch thành công.", "success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    LoadLoaiChi();

                }
                else
                {
                    MessageBox.Show("Thêm giao dịch thất bại.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearForm()
        {
            txtSL.Text = "";
            txtMT.Text = "";
            txtLocation.Text = "";
            dtpNgayGD.Value = DateTime.Now;
            cboLoai.SelectedIndex = 0;
        }
    }
}
