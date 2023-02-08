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
    public partial class FrmSignUp : Form
    {
        public FrmSignUp()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProvider1.SetError(txtName, "Bạn chưa nhập tên");
            }
            else
            {
                errorProvider1.SetError(txtName, "");
            }
        }

        private void txtAge_Validating(object sender, CancelEventArgs e)
        {
            if (txtAge.Text == "")
            {
                errorProvider1.SetError(txtAge, "Bạn chưa nhập tuổi");
            }
            else { }
            try
            {
                if (int.Parse(txtAge.Text) < 15)
                {
                    errorProvider1.SetError(txtAge, "Tuổi phải lớn hơn 15");
                }

                else
                {
                    errorProvider1.SetError(txtAge, "");
                }
            }
            catch
            {
                errorProvider1.SetError(txtAge, "Tuổi phải là số");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void maskDateLogin_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (maskDateLogin.Text == string.Empty)
                {
                    errorProvider1.SetError(maskDateLogin, "Bạn chưa nhập ngày nhập");
                }
            }
            catch { errorProvider1.SetError(maskDateLogin, "Bạn phải nhập đúng định dạng"); }
            
        }
    }
}

