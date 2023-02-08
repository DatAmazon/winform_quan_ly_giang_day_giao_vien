using CrystalDecisions.CrystalReports.Engine;
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
    public partial class RptGiangVienF : Form
    {
        public RptGiangVienF()
        {
            InitializeComponent();
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"F:\LTHSK\BTL\BTL\Report\rptGiangVien.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string chucvu = textBox1.Text;
            if(chucvu.Length > 0)
            {
                //Tìm kiếm and
                string searchs = "{GIANGVIEN.sChucvu}  LIKE '*" + chucvu + "*' OR {GIANGVIEN.sChucvu}  LIKE '*" + chucvu + "*'";
                //tìm kiếm giảng viên theo chức vụ
                string search = "{GIANGVIEN.sChucvu}  LIKE '*" + chucvu + "*'" ;
                //   string search = "DateValue({GIANGVIEN.dNgaysinh}) > DateValue('" + ngaybatdau + "')" + 
                //       "AND DateValue({tbl_HoaDon.dNgayTra}) < DateValue('" + ngayketthuc + "')";
                //hiện thị ngày  sinh lớn hơn 24/8/1985
                DateTime ngaybatdau = new DateTime(1985, 8, 24);
                string search2 = "DateValue({GIANGVIEN.dNgaysinh}) > DateValue('" + ngaybatdau + "')";
                //hiện tuổi lớn hơn 35
                int gia = 35;
                string search3 = " {@Age} > ToNumber('" + gia + "')";
                //    {@dNgayTra} < Date (2021, 01, 01)

                string searchs1 = "Month ({GIANGVIEN.dNgaysinh}) = 4";

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@"F:\LTHSK\BTL\BTL\Report\rptGiangVien.rpt");
                crystalReportViewer1.ReportSource = cryRpt;
                //cryRpt.RecordSelectionFormula = search;
                //cryRpt.DataDefinition.GroupSelectionFormula = search;
                cryRpt.RecordSelectionFormula = search3;
                cryRpt.DataDefinition.GroupSelectionFormula = search3;

                crystalReportViewer1.Refresh();
            }
        }

        private void FrmGiangVien_Load(object sender, EventArgs e)
        {

        }
    }
}
