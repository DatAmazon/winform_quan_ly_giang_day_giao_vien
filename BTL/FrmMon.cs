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
    public partial class FrmMon : Form
    {
        public FrmMon()
        {
            InitializeComponent();
        }

        private void FrmMon_Load(object sender, EventArgs e)
        {
            layDSMon();
            txtMaM.Enabled = false;
            txtSoTin.Enabled = false;
            txtTen.Enabled = false;

            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        string connectionString = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=QLLDGV;Integrated Security=True";
        public void layDSMon()
        {
            try
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("select * from Mon", Cnn))
                    {
                        Cmd.CommandType = CommandType.Text;
                        Cnn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvMon.DataSource = dt;
                        }
                        Cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnTim.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            txtMaM.Enabled = true;
            txtSoTin.Enabled = true;
            txtTen.Enabled = true;
            btnThem.Enabled = false;
            layDSMon();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand())
                    {
                        Cmd.Connection = Cnn;
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "THEMMON";
                        Cnn.Open();
                        Cmd.Parameters.AddWithValue("@Mamon", txtMaM.Text);
                        Cmd.Parameters.AddWithValue("@tenmon", txtTen.Text);
                        Cmd.Parameters.AddWithValue("@sotin", int.Parse(txtSoTin.Text));

                        int i = Cmd.ExecuteNonQuery();
                        if (txtMaM.Text.Equals(""))
                        {
                            MessageBox.Show("Mã môn không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (i == 0)
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                        else
                        {
                            MessageBox.Show("Thêm thành công");
                        }
                        Cnn.Close();
                        layDSMon();
                        xoaTextBox();
                    }
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("Bạn phải điền đủ các trường dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaM.Text = "";
            txtTen.Text = "";
            txtSoTin.Text = "";
            btnThem.Enabled = true;
            btnTim.Enabled = true;
            btnLuu.Enabled = false;
        }
        private void dgvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaM.Text = dgvMon.CurrentRow.Cells["sMamon"].Value.ToString();
            txtTen.Text = dgvMon.CurrentRow.Cells["sTenmon"].Value.ToString();
            txtSoTin.Text = dgvMon.CurrentRow.Cells["iSotin"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTim.Enabled = true;
            btnTim.Enabled = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("TimMonByTinChi", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cnn.Open();
                        Cmd.Parameters.AddWithValue("@Tinchi", int.Parse(txtSoTin.Text));
                        //int i = Cmd.ExecuteNonQuery();

                        SqlDataReader da = Cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(da);
                        dgvMon.DataSource = dt;
                        Cnn.Close();
                        da.Close();
                        btnThem.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("update Mon set sTenmon = N'" + txtTen.Text + "'," +
                        " iSotin = '" + int.Parse(txtSoTin.Text) + "' where sMamon = N'" + txtMaM.Text + "'", Cnn))

                    {
                        Cmd.CommandType = CommandType.Text;
                        Cnn.Open();
                        int i = Cmd.ExecuteNonQuery();
                        //if (txtMaM.Text == txtMaM.Text)
                        //{
                        //    MessageBox.Show("Không được thay đổi khóa");//txtbox.enable= false trong cellclick
                        //}
                        if (i == 0)
                        {
                            MessageBox.Show("Cập nhật thất bại");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thành công");
                        }
                        Cnn.Close();
                        layDSMon();
                        xoaTextBox();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnThem.Enabled = true;
        }
        private void xoaTextBox()
        {
            txtMaM.Clear();
            txtTen.Clear();
            txtSoTin.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("Bạn nuốn xóa không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (kq == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection Cnn = new SqlConnection(connectionString))
                        {
                            using (SqlCommand Cmd = new SqlCommand())
                            {
                                Cmd.Connection = Cnn;
                                Cmd.CommandType = CommandType.StoredProcedure;
                                Cmd.CommandText = "XoaMon";
                                Cnn.Open();
                                Cmd.Parameters.AddWithValue("@Mamon", txtMaM.Text);
                                Cmd.Parameters.AddWithValue("@tenmon", txtTen.Text);
                                Cmd.Parameters.AddWithValue("@sotin", int.Parse(txtSoTin.Text));
                                int i = Cmd.ExecuteNonQuery();
                                if (i == 0)
                                {
                                    Console.WriteLine("Insert success");
                                }
                                else
                                {
                                    Console.WriteLine("Insert fail");
                                }
                                Cnn.Close();
                                layDSMon();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Giá trị tham chiếu đến bản ghi khác", "Lỗi không xóa được");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi", "Bản ghi bị ràng buộc khóa");
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            RptMonF rLD = new RptMonF();
            this.Hide();
            rLD.ShowDialog();
            this.Show();
        }

        private void txtSoTin_Validating(object sender, CancelEventArgs e)
        {
            if (txtSoTin.Text.Trim() == "")
            {
                errorProvider1.SetError(txtSoTin, "Bạn chưa điền số tín");
            }
            else
            {
                errorProvider1.SetError(txtSoTin, "");
            }
        }

        private void dgvMon_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string mamon = dgvMon.CurrentRow.Cells["sMamon"].Value.ToString();
            string tenmon = dgvMon.CurrentRow.Cells["sTenmon"].Value.ToString();
            string sotin = dgvMon.CurrentRow.Cells["iSotin"].Value.ToString();

            string res = "Mã môn " + mamon + "\r\n";
            res += "Tên môn: " + tenmon + "\r\n";
            res += "Số tín: " + sotin;

            MessageBox.Show(res);
        }
    }
}
