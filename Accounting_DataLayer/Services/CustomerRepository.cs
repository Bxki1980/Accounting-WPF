using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting_DataLayer.Repositories;
using System.Data.Entity;
using Accounting.ViewModels.Customers;

namespace Accounting_DataLayer.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private Accounting_DBEntities db;
        public CustomerRepository(Accounting_DBEntities Context)
        {
            db = Context;
        }

        public bool DeleteCustomer(Customers Customer)
        {
            try
            {
                db.Entry(Customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int CustomerId)
        {
            try
            {
                var customer = GetCustomersById(CustomerId);
                DeleteCustomer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Customers> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public List<ListCustomerViewModels> GetCustomerName(string Filter = " ")
        {
            if (Filter == " ")
            {
                return db.Customers.Select(c => new ListCustomerViewModels()
                {
                    CustomerID = c.CustomerID,
                    CustomerName = c.FullName
                }).ToList();
            }

            return db.Customers.Where(c => c.FullName.Contains(Filter)).Select(c => new ListCustomerViewModels()
            {
                CustomerID = c.CustomerID,
                CustomerName = c.FullName
            }).ToList();

        }

        public IEnumerable<Customers> GetCustomersByfiter(string parameter)
        {
            return db.Customers.Where(c => c.FullName.Contains(parameter) || c.Email.Contains(parameter) || c.Mobile.Contains(parameter)).ToList();
        }

        public Customers GetCustomersById(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public bool InsertCusomer(Customers Customer)
        {
            try
            {
                db.Customers.Add(Customer);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateCustomer(Customers Customer)
        {
            try
            {
                db.Entry(Customer).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
