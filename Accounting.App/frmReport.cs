using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting_DataLayer.Context;

namespace Accounting.App
{
    public partial class frmReport : Form
    {
        public int TypeID = 0;
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (TypeID == 1)
            {
                this.Text = "Income Reporting";
            }
            else
            {
                this.Text = "Cost Reporting";
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }

        void filter()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var Filter = db.accountingRepository.Get(c => c.TypeID == TypeID);
                dgvReport.AutoGenerateColumns = false;
                dgvReport.DataSource = Filter;
            }
        }
    }
}
