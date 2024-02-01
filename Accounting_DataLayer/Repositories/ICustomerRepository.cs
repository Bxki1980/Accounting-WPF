using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.ViewModels.Customers;

namespace Accounting_DataLayer.Repositories
{
    public interface ICustomerRepository
    {
        bool DeleteCustomer(Customers Customer);
        bool DeleteCustomer(int CustomerId);
        List<ListCustomerViewModels> GetCustomerName(String Filter =" ");
        IEnumerable<Customers> GetCustomersByfiter(string parameter);
        List<Customers> GetAllCustomers();
        Customers GetCustomersById(int customerId);
        bool InsertCusomer(Customers Customer);
        bool UpdateCustomer(Customers Customer);

    }
}
