using PBL111.BLL;
using PBL111.DAL;
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
using static PBL111.View.Login;

namespace PBL111.View
{
    public partial class EditGD : Form
    {
        private readonly TheloaiDAL _TheloaiDAL = new TheloaiDAL();
        private readonly ChiphiBLL _chiphiBLL = new ChiphiBLL();
        private readonly Giaodich _giaodich;

        public EditGD(Giaodich giaodich)
        {
            InitializeComponent();
            _giaodich = giaodich;
            LoadTheloai();
            LoadGiaoDichData();
        }

        private void LoadTheloai()
        {
            var theloaiList = _TheloaiDAL.GetAllTheloai();
            if (theloaiList == null || theloaiList.Count == 0)
            {
                MessageBox.Show("Không có loại giao dịch nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtloai.DataSource = theloaiList;
            txtloai.DisplayMember = "nameTL";
            txtloai.ValueMember = "theloaiID";
        }

        private void LoadGiaoDichData()
        {
            txtST.Text = _giaodich.soluong.ToString();
            dTP.Value = _giaodich.ngayGD;
            txtND.Text = _giaodich.Description;
            txtDD.Text = _giaodich.diachi;
            txtloai.SelectedValue = _giaodich.theloaiID;
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal soluong)) return;

            _giaodich.soluong = soluong;
            _giaodich.ngayGD = dTP.Value;
            _giaodich.Description = txtND.Text.Trim();
            _giaodich.diachi = txtDD.Text.Trim();
            _giaodich.theloaiID = Convert.ToInt32(txtloai.SelectedValue);

            if (_chiphiBLL.updateGD(_giaodich, Session.CurrentUserId))
            {
                MessageBox.Show("Cập nhật giao dịch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Cập nhật giao dịch thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput(out decimal soluong)
        {
            soluong = 0;

            if (string.IsNullOrWhiteSpace(txtST.Text) || !decimal.TryParse(txtST.Text, out soluong))
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtND.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung mô tả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDD.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtloai.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại giao dịch.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
