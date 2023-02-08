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
    public partial class FrmThoiGian : Form
    {
        public FrmThoiGian()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=QLLDGV;Integrated Security=True";
        private void FrmThoiGian_Load(object sender, EventArgs e)
        {
            LayDSTG();
            dtpNgayDay.Enabled = false;
            txtCaDay.Enabled = false;
            txtGhiChu.Enabled = false;

            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void LayDSTG()
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("select * from THOIGIAN", Cnn))
                {
                    Cmd.CommandType = CommandType.Text;
                    Cnn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvThoiGian.DataSource = dt;
                    }
                    Cnn.Close();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LayDSTG();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTim.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            dtpNgayDay.Enabled = true;
            txtCaDay.Enabled = true;
            txtGhiChu.Enabled = true;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {//text
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                string insertStr = "insert into THOIGIAN values('" + dtpNgayDay.Value + "','" + txtCaDay.Text + "','" + txtGhiChu.Text + "')";
                using (SqlCommand Cmd = new SqlCommand(insertStr, Cnn))
                {
                    Cnn.Open();
                    Cmd.CommandType = CommandType.Text;
                    int i = Cmd.ExecuteNonQuery();
                    if (i == 0)
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Cnn.Close();
                    LayDSTG();
                    xoaTextBox();
                }
            }
        }
        private void xoaTextBox()
        {
            dtpNgayDay.Value = DateTime.Now;
            txtCaDay.Clear();
            txtGhiChu.Clear();
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            xoaTextBox();
            btnThem.Enabled = true;
            btnTim.Enabled = true;
            btnLuu.Enabled = false;
            dtpNgayDay.Enabled = false;
            txtCaDay.Enabled = false;
            txtGhiChu.Enabled = false;
        }
        private void dgvThoiGian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvThoiGian.CurrentRow.Index;
            dtpNgayDay.Text = dgvThoiGian.Rows[i].Cells[0].Value.ToString();
            txtCaDay.Text = dgvThoiGian.Rows[i].Cells[1].Value.ToString();
            txtGhiChu.Text = dgvThoiGian.Rows[i].Cells[2].Value.ToString();

            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnTim.Enabled = true;

            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            dtpNgayDay.Enabled = true;
            txtCaDay.Enabled = true;
            txtGhiChu.Enabled = true;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {// procedure
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("updateTG", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cnn.Open();
                    Cmd.Parameters.AddWithValue("@Caday", txtCaDay.Text);
                    Cmd.Parameters.AddWithValue("@Ghichu", txtGhiChu.Text);
                    Cmd.Parameters.AddWithValue("@Ngayday", dtpNgayDay.Text.ToString());
                    int i = Cmd.ExecuteNonQuery();
                    if (i == 0)
                    {
                        MessageBox.Show("Cập nhật thất bại");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thành công");
                    }
                    Cnn.Close();
                    LayDSTG();
                    xoaTextBox();
                    btnThem.Enabled = true;
                    btnXoa.Enabled = false;
                    btnTim.Enabled = false;
                    btnSua.Enabled = false;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn nuốn xóa không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                try
                {
                    string deleteStr = "Delete THOIGIAN where dNgayday = '" + dtpNgayDay.Value.ToString() + "'";
                    using (SqlConnection Cnn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand Cmd = new SqlCommand(deleteStr, Cnn))
                        {
                            Cmd.CommandType = CommandType.Text;
                            Cnn.Open();
                            int i = Cmd.ExecuteNonQuery();
                            Cnn.Close();
                            LayDSTG();
                            xoaTextBox();
                            btnThem.Enabled = true;
                            btnXoa.Enabled = false;
                            btnTim.Enabled = false;
                            btnSua.Enabled = false;
                        }
                    }

                }
                catch (System.Data.SqlClient.SqlException er)
                {
                    MessageBox.Show("Dữ liệu đang được tham chiếu tới bảng khác", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("timAllByCaDay", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Caday", txtCaDay.Text);
                    Cnn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvThoiGian.DataSource = dt;
                    }
                    Cnn.Close();

                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            RptThoiGianF rLD = new RptThoiGianF();
            this.Hide();
            rLD.ShowDialog();
            this.Show();
        }
    }
}
