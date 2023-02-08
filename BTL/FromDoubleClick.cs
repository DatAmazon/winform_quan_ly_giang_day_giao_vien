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
    public partial class FromDoubleClick : Form
    {
        static string MA;
        public FromDoubleClick(string malo)
        {
            InitializeComponent();
            MA = malo;
        }
    }
}
