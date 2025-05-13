using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL111.BLL;
using PBL111.DTO;
using System.Windows.Forms;
using PBL111.DAL;

namespace PBL111.ViewAD
{
    public partial class EditTL : Form
    {
        private Theloai _theloai;
        private readonly TheloaiDAL _TheloaiDAL = new TheloaiDAL();
        private readonly int _currentUserId;
        public EditTL(Theloai theloai, int currentUserId)
        {
            InitializeComponent();
            _theloai = theloai;
            _currentUserId = currentUserId;
            txtTL.Text = _theloai.nameTL;
            txtMT.Text = _theloai.description;
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            string tenTL = txtTL.Text.Trim();
            string moTa = txtMT.Text.Trim();
            if (string.IsNullOrEmpty(tenTL))
            {
                MessageBox.Show("Vui lòng nhập tên thể loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _theloai.nameTL = tenTL;
            _theloai.description = moTa;

            bool result = _TheloaiDAL.UpdateTheloai(_theloai, _currentUserId);
            if (result)
            {
                MessageBox.Show("Cập nhật thể loại thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thể loại thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
