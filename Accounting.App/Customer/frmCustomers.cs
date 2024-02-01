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
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgCustomers.AutoGenerateColumns = false;
                dgCustomers.DataSource = db.CustomerRepository.GetAllCustomers();
            }

        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            BindGrid();
        }


        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgCustomers.DataSource = db.CustomerRepository.GetCustomersByfiter(txtFilter.Text);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtFilter.Text = " ";
            BindGrid();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgCustomers.CurrentRow != null)
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    string name = dgCustomers.CurrentRow.Cells[1].Value.ToString();

                    if (MessageBox.Show($"Are you sure u want to Delete {name}?!", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int customerid = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
                        db.CustomerRepository.DeleteCustomer(customerid);
                        db.Save();
                        BindGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Pls Chose a person!");
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmAddOrEdit Addnew = new frmAddOrEdit();
            if (Addnew.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            if (dgCustomers.CurrentRow != null)
            {
                int customerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());

                frmAddOrEdit Edit = new frmAddOrEdit();
                Edit.customerId = customerId;
                Edit.ShowDialog();

                if (Edit.DialogResult == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }
    }
}
