using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting_DataLayer.Services;
using Accounting_DataLayer.Repositories;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository Customer = new CustomerRepository();

           


            var list = Customer.GetAllCustomers();
        }
    }
}
