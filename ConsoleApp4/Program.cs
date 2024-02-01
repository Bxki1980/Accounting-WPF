using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting_DataLayer;
using Accounting_DataLayer.Repositories;
using Accounting_DataLayer.Services;
using Accounting_DataLayer.Context;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork db = new UnitOfWork();

            var list = db.CustomerRepository.GetAllCustomers();
        }
    }
}
