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
    public partial class FrmCha : Form
    {
        public FrmCha()
        {
            InitializeComponent();
        }

        private void mnuItemLichDay_Click(object sender, EventArgs e)
        {
            FrmLichDay frm = new FrmLichDay();
            //frm.MdiParent = this;
            frm.ShowDialog();
            //frm.Show();
        }

        private void mnuItemLogin_Click(object sender, EventArgs e)
        {
            FrmLogin1 frm = new FrmLogin1();
            //frm.MdiParent = this;
            //frm.Show();
            frm.ShowDialog();
        }

        private void mnuItemMon_Click(object sender, EventArgs e)
        {
            FrmMon frm = new FrmMon();
            //frm.MdiParent = this;
            //frm.Show();
            frm.ShowDialog();
        }
        private void mnuItemThoiGian_Click(object sender, EventArgs e)
        {
            FrmThoiGian frm = new FrmThoiGian();
            frm.ShowDialog();
        }

        private void mnuItemExit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn nuốn thoát không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                Close();
            }
        }

        private void FrmCha_Load(object sender, EventArgs e)
        {
   
        }
        private void nte()
        {
            int i = 0;
            DialogResult kq = MessageBox.Show("Bạn nuốn thoát không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                Close();
            }
            if (i == 0)
            {
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            using (SqlConnection Cnn = new SqlConnection("connectionString"))
            {
                using (SqlCommand Cmd = new SqlCommand("Select * from Giangvien", Cnn))
                {
                    Cmd.CommandType = CommandType.Text;
                    Cnn.Open();

                    Cnn.Close();
                }
            }

        }

        private void mnuItemGiangVien_Click(object sender, EventArgs e)
        {
            FrmGiangVien frm = new FrmGiangVien();
            frm.ShowDialog();
        }

        private void mnuQuanLy_Click(object sender, EventArgs e)
        {

        }
    }
}
