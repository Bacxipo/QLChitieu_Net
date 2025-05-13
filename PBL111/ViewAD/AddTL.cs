using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL111.BLL;
using PBL111.DAL;
using PBL111.DTO;

namespace PBL111.ViewAD
{
    public partial class AddTL : Form
    {
        private readonly TheloaiDAL theloai;
        private readonly int currentUserid;

        public AddTL()
        {
            InitializeComponent();
            theloai = new TheloaiDAL();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string tenTL = txtTL.Text.Trim().Trim();
            string moTa = txtMT.Text.Trim();
            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Vui lòng nhập tên thể loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var TheloaiDAL = new Theloai
            {
                nameTL= tenTL,
                description = moTa,
            };

            var bll = new TheloaiDAL();
            bool result = bll.AddTheloai(TheloaiDAL,  currentUserid);

            if (result)
            {
                MessageBox.Show("Thêm thể loại thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm thể loại thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
