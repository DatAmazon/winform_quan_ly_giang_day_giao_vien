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
//using CrystalDecisions.CrystalReports.Engine;

namespace BTL
{
    public partial class FrmGiangVien : Form
    {
        public FrmGiangVien()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=QLLDGV;Integrated Security=True";
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmGiangVien_Load(object sender, EventArgs e)
        {//auto load
            string sql = "select sMagv, sChucvu from GiangVien";
            cbbChucvu.DataSource = Database1.Singleton.LoadData(sql);
            cbbChucvu.DisplayMember = "sChucVu";
            cbbChucvu.ValueMember = "sMagv";

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
                        //dgvGV.DisplayMember = "schucvu";
                        //dgvgv.valuemember = "smagv";
                    }
                    Cnn.Close();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
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
                    Cmd.Parameters.AddWithValue("@ChucVu", cbbChucvu.Text);
                    if (rdNam.Checked == true)
                    {
                        Cmd.Parameters.AddWithValue("@GT", "Nam");
                    }
                    else
                    {
                        Cmd.Parameters.AddWithValue("@GT", "Nữ");
                    }
                    Cnn.Open();
                    int i = Cmd.ExecuteNonQuery();
                    Cnn.Close();
                    layDSGV();
                }
            }
        }

        private void dgvGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGV.CurrentRow.Cells["sGioitinh"].Value.ToString() == "Nam")
            {
                rdNam.Checked = true;
            }
            else
            {
                rdNu.Checked = true;
            }
            txtMagv.Text = dgvGV.CurrentRow.Cells["sMagv"].Value.ToString();
            txtTengv.Text = dgvGV.CurrentRow.Cells["sTengv"].Value.ToString();
            dtpNS.Text = dgvGV.CurrentRow.Cells["dNgaysinh"].Value.ToString();
            txtDiachi.Text = dgvGV.CurrentRow.Cells["sDiachi"].Value.ToString();
            txtSDT.Text = dgvGV.CurrentRow.Cells["sSdt"].Value.ToString();
            cbbChucvu.Text = dgvGV.CurrentRow.Cells["sChucvu"].Value.ToString();
        }
        private void xoaContent()
        {
            txtMagv.Clear();
            txtTengv.Clear();
            dtpNS.Value = DateTime.Now;
            txtDiachi.Clear();
            txtSDT.Clear();
            cbbChucvu.Text = "";
            if (rdNam.Checked == true)
            {
                rdNam.Checked = false;
            }
            else
            {
                rdNu.Checked = false;
            }
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            xoaContent();
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("timGVByChucVu", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Chucvu", cbbChucvu.Text);
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
                    Cmd.Parameters.AddWithValue("@ChucVu", cbbChucvu.Text);
                    if (rdNam.Checked == true)
                    {
                        Cmd.Parameters.AddWithValue("@GT", "Nam");
                    }
                    else
                    {
                        Cmd.Parameters.AddWithValue("@GT", "Nữ");
                    }
                    Cnn.Open();
                    int i = Cmd.ExecuteNonQuery();
                    Cnn.Close();
                    layDSGV();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void cbbChucvu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
