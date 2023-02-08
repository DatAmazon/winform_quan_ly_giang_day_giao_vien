using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class FrmLogin1 : Form
    {
        public FrmLogin1()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            try
            {
                string tk = txtTK.Text;
                int mk = int.Parse(txtMK.Text);
                if (tk == "1" && mk == 1 || tk == "t" && mk == 5)
                {
                    FrmCha frm = new FrmCha();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bạn đã nhập sai tên đăng nhập hoặc mật khẩu, vui lòng nhập lại!");
                    txtMK.Clear();
                    txtTK.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi", ex.Message);
                txtMK.Clear();
                txtTK.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTK_Validating(object sender, CancelEventArgs e)
        {
            //if (txtTK.Text.Trim() == "")
            //{
            //    errorProvider1.SetError(txtTK, "Bạn chưa điền mật khẩu");
            //}
            //else
            //{
            //    errorProvider1.SetError(txtTK, "");
            //}

        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMK_Validating(object sender, CancelEventArgs e)
        {
            //if (txtMK.Text.Trim() == "")
            //{
            //    errorProvider1.SetError(txtMK, "Bạn chưa điền mật khẩu");
            //}
            //else
            //{
            //    errorProvider1.SetError(txtMK, "");
            //}
        }

        private void FrmLogin1_Load(object sender, EventArgs e)
        {

        }
    }
}
