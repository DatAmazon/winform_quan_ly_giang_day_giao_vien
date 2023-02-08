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
    public partial class FrmGV : Form
    {
        public FrmGV()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=QLLDGV;Integrated Security=True";
        private void btnThem_Click(object sender, EventArgs e)
        {
            layDSGV();
        }
        private void layDSGV()
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("Select * from Giangvien", Cnn))
                {
                    Cmd.CommandType = CommandType.Text;
                    Cnn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvGV.DataSource = dt;
                    }
                    Cnn.Close();
                }
            }
        }
        private void dgvGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmGV_Load(object sender, EventArgs e)
        {
            layDSGV();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("ThemGV", Cnn))
                {
                    //(sMagv, sTengv, sGioitinh, dNgaysinh, sDiachi, sSdt, sChucvu)
                    //values(@MAGV, @TenGV, @GT, @NS, @DC, @SDT, @ChucVu)
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@MAGV", txtMagv.Text);
                    Cmd.Parameters.AddWithValue("@TenGV", txtTengv.Text);
                    Cmd.Parameters.AddWithValue("@NS", dtpNS.Value);
                    Cmd.Parameters.AddWithValue("@DC", txtDiachi.Text);
                    Cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    Cmd.Parameters.AddWithValue("@ChucVu", txtChucVu.Text);
                    Cmd.Parameters.AddWithValue("@GT", txtGT.Text);

                    Cnn.Open();
                    int i = Cmd.ExecuteNonQuery();
                    Cnn.Close();
                    layDSGV();
                }
            }
        }

        private void dgvGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGT.Text = dgvGV.CurrentRow.Cells["sGioitinh"].Value.ToString();
            txtMagv.Text = dgvGV.CurrentRow.Cells["sMagv"].Value.ToString();
            txtTengv.Text = dgvGV.CurrentRow.Cells["sTengv"].Value.ToString();
            dtpNS.Text = dgvGV.CurrentRow.Cells["dNgaysinh"].Value.ToString();
            txtDiachi.Text = dgvGV.CurrentRow.Cells["sDiachi"].Value.ToString();
            txtSDT.Text = dgvGV.CurrentRow.Cells["sSdt"].Value.ToString();
            txtChucVu.Text = dgvGV.CurrentRow.Cells["sChucvu"].Value.ToString();
        }
        private void xoaContent()
        {
            txtMagv.Clear();
            txtTengv.Clear();
            dtpNS.Value = DateTime.Now;
            txtDiachi.Clear();
            txtSDT.Clear();
            txtChucVu.Clear();
            txtGT.Clear();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            xoaContent();
        }

   

        private void btnSua_Click(object sender, EventArgs e)
        {//sTengv = @TenGV, sGioitinh=@GT, dNgaysinh= @NS, sDiachi = @DC, sSdt= @SDT, sChucvu = @ChucVu
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("CapNhatGV", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Magv", txtMagv.Text);
                    Cmd.Parameters.AddWithValue("@TenGV", txtTengv.Text);

                    Cmd.Parameters.AddWithValue("@NS", dtpNS.Value);
                    Cmd.Parameters.AddWithValue("@DC", txtDiachi.Text);
                    Cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    Cmd.Parameters.AddWithValue("@ChucVu", txtChucVu.Text);
                    Cmd.Parameters.AddWithValue("@GT", txtGT.Text);
                    Cnn.Open();
                    int i = Cmd.ExecuteNonQuery();
                    Cnn.Close();
                    layDSGV();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("deleteGV", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@MAGV", txtMagv.Text);
                    Cnn.Open();
                    int i = Cmd.ExecuteNonQuery();
                    Cnn.Close();
                    layDSGV();
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            RptGVF rLD = new RptGVF();
            this.Hide();
            rLD.ShowDialog();
            this.Show();
        }
    }
}
