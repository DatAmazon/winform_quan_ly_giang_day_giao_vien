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
namespace BTL
{
    public partial class RptThoiGianF : Form
    {
        public RptThoiGianF()
        {
            InitializeComponent();
        }

        private void RptThoiGianF_Load(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"F:\LTHSK\Finish_BTL_LTHSK_QuanLyLichDayGiangVien\BTL\RptThoiGian.rpt");
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
