using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            frmCustomers S1 = new frmCustomers();
            S1.ShowDialog();          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmNewTransition NewTransition = new frmNewTransition();
            NewTransition.ShowDialog();
        }

        private void btnReportCost_Click(object sender, EventArgs e)
        {
            frmReport report = new frmReport();
            report.TypeID = 2;
            report.ShowDialog();
        }

        private void btnReportIncome_Click(object sender, EventArgs e)
        {
            frmReport report = new frmReport();
            report.TypeID = 1;
            report.ShowDialog();
        }
    }
}
