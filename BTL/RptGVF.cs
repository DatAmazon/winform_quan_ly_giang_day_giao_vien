using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Data;
namespace BTL
{
    public partial class RptGVF : Form
    {
        public RptGVF()
        {
            InitializeComponent();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }
        string connectionString = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=QLLDGV;Integrated Security=True";
        private void RptGVF_Load(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"F:\LTHSK\Finish_BTL_LTHSK_QuanLyLichDayGiangVien\BTL\RptGV.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //lệnh truy vấn
            String chucVu = txtChucVu.Text;
            string search = "{GIANGVIEN.schucvu}  LIKE '*" + chucVu + "*'";
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"F:\LTHSK\BTL\BTL\RptGV.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            cryRpt.RecordSelectionFormula = search;
            cryRpt.DataDefinition.GroupSelectionFormula = search;

            crystalReportViewer1.Refresh();
        }
        //hiện ng sinh tháng 4
        private void btnSL_Click(object sender, EventArgs e)
        {
            //Hiện thị số lượng giảng viên theo chức vụ
            String chucVu = txtChucVu.Text;
            string search = "{GIANGVIEN.schucvu}  LIKE '*" + chucVu + "*'";
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"F:\LTHSK\BTL\BTL\RptGV.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            cryRpt.RecordSelectionFormula = search;
            cryRpt.DataDefinition.GroupSelectionFormula = search;

            crystalReportViewer1.Refresh();
        }
        //gom nhóm gtri = nhau ở gần nhau , chuột trái , field , group, insert
        // tạo reportt : vào form tạo button, textbox, path đúng
        //ddkien rep RptGiangVienF
    }
  
    
}
