using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;
using Accounting_DataLayer.Context;
using Accounting_DataLayer;
using System.IO;

namespace Accounting.App
{
    public partial class frmAddOrEdit : Form
    {
        public int customerId = 0;
        public frmAddOrEdit()
        {
            InitializeComponent();
        }

        private void btnSelectPc_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                CustomerPc.ImageLocation = OpenFile.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {

                if (BaseValidator.IsFormValid(this.components))
                {
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(CustomerPc.ImageLocation);
                    string path = Application.StartupPath + "/Images/";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    CustomerPc.Image.Save(path + ImageName);

                    Customers customer = new Customers()
                    {
                        FullName = txtName.Text,
                        Mobile = txtMobile.Text,
                        Email = txtEmail.Text,
                        Adress = txtAddress.Text,
                        CustomerImage = "No Photo.jpg"
                    };

                    if (customerId == 0)
                    {
                        db.CustomerRepository.InsertCusomer(customer);
                    }
                    else 
                    {
                        customer.CustomerID = customerId;
                        db.CustomerRepository.UpdateCustomer(customer);
                    }
                    db.Save();
                    MessageBox.Show("Seccessful", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if(customerId!=0)
            {
                this.Text = "Edit Person";
                btnSave.Text = "Edit";

                using (UnitOfWork db = new UnitOfWork())
                {
                    var customer = db.CustomerRepository.GetCustomersById(customerId);
                    txtName.Text = customer.FullName;
                    txtEmail.Text = customer.Email;
                    txtMobile.Text = customer.Mobile;
                    txtAddress.Text = customer.Adress;
                    CustomerPc.ImageLocation = Application.StartupPath + "/Images/" + customer.CustomerImage;
                }
                

            }
        }
    }
}
