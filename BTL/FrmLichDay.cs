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

namespace BTL
{
    public partial class FrmLichDay : Form
    {
        public FrmLichDay()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=QLLDGV;Integrated Security=True";
        //install-package System.Data.SqlClient
        private void btnThem_Click(object sender, EventArgs e)
        {
            layDSLD();
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;

            txtMaGV.Enabled = true;
            txtGhiChu.Enabled = true;
            dtpNgayDay.Enabled = true;
            txtMaL.Enabled = true;
            txtMaM.Enabled = true;
            txtMaP.Enabled = true;
            txtTrangThai.Enabled = true;
        }

        public void layDSLD()
        {
            //Lấy dl có nhiều cách 1 Datatable           
            try
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("select * from LichDay ", Cnn))
                    {
                        Cmd.CommandType = CommandType.Text;
                        Cnn.Open();
                        using (SqlDataAdapter ad = new SqlDataAdapter(Cmd))
                        {
                            DataTable tb = new DataTable();
                            ad.Fill(tb);
                            dgvLichDay.DataSource = tb;
                        }
                        Cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

        private void layDSLD2()
        {
            //2 Dataset
            try
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("select * from LichDay", Cnn))
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dgvLichDay.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
        private void layDSLD3()
        {
            //3 DataReader
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("select * from LichDay", Cnn))
                {
                    Cmd.CommandType = CommandType.Text;
                    Cnn.Open();
                    using (SqlDataReader dr = Cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dgvLichDay.DataSource = dt;
                        dr.Close();
                    }
                    Cnn.Close();
                    Console.ReadLine();
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        { // dNgayday = @ngayday, sMagv = @magv,sMamon = @mamon,sMalop= @malop,sMap = @map,sTrangthai= @trangthai,sGhichu = @ghichu
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("updateLD", Cnn))
                {
                    int res = dgvLichDay.CurrentRow.Index;
                    String STT = dgvLichDay.Rows[res].Cells[7].Value.ToString();
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Ngayday", dtpNgayDay.Text.ToString());
                    Cmd.Parameters.AddWithValue("@magv", txtMaGV.Text);
                    Cmd.Parameters.AddWithValue("@mamon", txtMaM.Text);
                    Cmd.Parameters.AddWithValue("@malop", txtMaL.Text);
                    Cmd.Parameters.AddWithValue("@map", txtMaP.Text);
                    Cmd.Parameters.AddWithValue("@trangthai", txtTrangThai.Text);
                    Cmd.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
                    Cmd.Parameters.AddWithValue("@STT", STT);
                    Cnn.Open();
                    int i = Cmd.ExecuteNonQuery();
                    if(i == 0)
                    {
                        MessageBox.Show("Cập nhật thất bại");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thành công");
                    }
                    Cnn.Close();
                    layDSLD();
                    xoaTextBox();
                }
            }
        }
        private void xoaTextBox()
        {
            dtpNgayDay.Value = DateTime.Now;
            txtMaGV.Clear();
            txtMaL.Clear();
            txtMaM.Clear();
            txtMaP.Clear();
            txtTrangThai.Clear();
            txtGhiChu.Clear();
        }
        private void FrmLichDay_Load(object sender, EventArgs e)
        {
            layDSLD3();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTim.Enabled = false;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;

            txtMaGV.Enabled = false;
            txtGhiChu.Enabled = false;
            dtpNgayDay.Enabled = false;
            txtMaL.Enabled = false;
            txtMaM.Enabled = false;
            txtMaP.Enabled = false;
            txtTrangThai.Enabled = false;
        }

        private void dtpNgayDay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvLichDay_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string malop  = AAS lay tu textbox 
            string malop = "AAS";
            FromDoubleClick frm = new FromDoubleClick(malop);

            frm.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //DateTime ngayday = DateTime.Parse(txtNgayDay.Text);
            //string maGV = txtMaGV.Text;
            //string maMon = txtMaM.Text;
            //string maLop = txtMaL.Text;
            //string maP = txtMaP.Text;
            //string trangThai = txtTrangThai.Text;
            //string ghiChu = txtGhiChu.Text;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand())
                {
                    //Cnn.Open?
                    Cmd.Connection = Cnn;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "insLichDay";//Custom format: yyyy-MM-dd hh:mm:ss (SSS: milisecond)
                    //Formar: custom
                    Cmd.Parameters.AddWithValue("@Ngayday", dtpNgayDay.Value);//key used trigger
                    Cmd.Parameters.AddWithValue("@Magv", txtMaGV.Text);
                    Cmd.Parameters.AddWithValue("@Mamon", txtMaM.Text);
                    Cmd.Parameters.AddWithValue("@Malop", txtMaL.Text);
                    Cmd.Parameters.AddWithValue("@Map", txtMaP.Text);
                    Cmd.Parameters.AddWithValue("@Trangthai", txtTrangThai.Text);
                    Cmd.Parameters.AddWithValue("@Ghichu", txtGhiChu.Text);
                    Cnn.Open();
                    int i = Cmd.ExecuteNonQuery();
                    if (i == 0)
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    layDSLD();
                    btnThem.Enabled = true;
                    btnTim.Enabled = true;
                    btnLuu.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnTim.Enabled = false;
                    btnBoQua.Enabled = false;
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            xoaTextBox();
            btnThem.Enabled = true;
            btnTim.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTim.Enabled = false;
            btnBoQua.Enabled = false;

            txtMaGV.Enabled = false;
            txtGhiChu.Enabled = false;
            dtpNgayDay.Enabled = false;
            txtMaL.Enabled = false;
            txtMaM.Enabled = false;
            txtMaP.Enabled = false;
            txtTrangThai.Enabled = false;
        }

        private void dgvLichDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //(dNgayday, sMagv, sMamon, sMalop, sMap, sTrangthai, sGhichu)
            int i = dgvLichDay.CurrentRow.Index;
            dtpNgayDay.Text = dgvLichDay.Rows[i].Cells[0].Value.ToString();
            txtMaGV.Text = dgvLichDay.Rows[i].Cells[1].Value.ToString();
            txtMaM.Text = dgvLichDay.Rows[i].Cells[2].Value.ToString();
            txtMaL.Text = dgvLichDay.Rows[i].Cells[3].Value.ToString();
            txtMaP.Text = dgvLichDay.Rows[i].Cells[4].Value.ToString();
            txtTrangThai.Text = dgvLichDay.Rows[i].Cells[5].Value.ToString();
            txtGhiChu.Text = dgvLichDay.Rows[i].Cells[6].Value.ToString();

            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnTim.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            txtMaGV.Enabled = true;
            txtGhiChu.Enabled = true;
            dtpNgayDay.Enabled = true;
            txtMaL.Enabled = true;
            txtMaM.Enabled = true;
            txtMaP.Enabled = true;
            txtTrangThai.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn nuốn xóa không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("deleteLD", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        int res = dgvLichDay.CurrentRow.Index;
                        String STT = dgvLichDay.Rows[res].Cells[7].Value.ToString();
                        Cmd.Parameters.AddWithValue("@STT", STT);
                        Cnn.Open();
                        int i = Cmd.ExecuteNonQuery();
                        Cnn.Close();
                        layDSLD();
                        xoaTextBox();
                    }
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("timLDByTrangThai", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Trangthai", txtTrangThai.Text);
                    Cnn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLichDay.DataSource = dt;
                    }
                    Cnn.Close();
                    btnThem.Enabled = true;
                }

            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            RptLichDayF rLD = new RptLichDayF();
            this.Hide();
            rLD.ShowDialog();
            this.Show();
        }

        private void dgvLichDay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
