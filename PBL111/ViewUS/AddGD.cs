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
    public partial class AddGD : Form
    {
        private readonly TheloaiDAL _TheloaiDAL = new TheloaiDAL();
        private readonly ChiphiBLL _chiphiBLL = new ChiphiBLL();

        public AddGD()
        {
            InitializeComponent();
            LoadTheloai();
            lbnameUS.Text = Session.CurrentFullName;
            lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void LoadTheloai()
        {
            var theloaiList = _TheloaiDAL.GetAllTheloai();
            if (theloaiList == null || theloaiList.Count == 0)
            {
                MessageBox.Show("Không có loại giao dịch nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cbTheLoai.DataSource = theloaiList;
            cbTheLoai.DisplayMember = "nameTL";
            cbTheLoai.ValueMember = "theloaiID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal soluong)) return;

            var giaodich = new Giaodich
            {
                soluong = soluong,
                ngayGD = dtpNGD.Value,
                Description = txtND.Text.Trim(),
                diachi = txtDD.Text.Trim(),
                theloaiID = Convert.ToInt32(cbTheLoai.SelectedValue),
                userID = Session.CurrentUserId
            };

            if (_chiphiBLL.AddGD(giaodich, Session.CurrentUserId))
            {
                MessageBox.Show("Thêm giao dịch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Thêm giao dịch thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (cbTheLoai.SelectedValue == null)
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
