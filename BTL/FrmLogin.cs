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
using System.Data;
namespace BTL
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        string conStr = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=DangNhap;Integrated Security=True";
        private void btnOK_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                string tk = txtTK.Text;
                string mk = txtMK.Text;
                string sql = "select * from  NguoiDung where tk = '"+txtTK.Text+"' and mk ='"+ txtMK.Text +"'";
                SqlCommand Cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = Cmd.ExecuteReader();
                if(dta.Read() == true)
                {
                    
                    MessageBox.Show("Đăng nhập thành công");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(txtTK.Text == "")
            {
                errorProvider1.SetError(txtTK, "Bạn phải nhập tên");
            }
            else
            {
                errorProvider1.SetError(txtTK, "");
            }
        }

        private void btnLogOn_Click(object sender, EventArgs e)
        {
            FrmSignUp frm = new FrmSignUp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
