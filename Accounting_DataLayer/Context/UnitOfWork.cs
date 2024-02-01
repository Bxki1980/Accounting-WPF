using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting_DataLayer.Repositories;
using Accounting_DataLayer.Services;

namespace Accounting_DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        Accounting_DBEntities db = new Accounting_DBEntities();

        private ICustomerRepository _customerRipository;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRipository == null)
                {
                    _customerRipository = new CustomerRepository(db);
                }
                return _customerRipository;
            }
        }

        private GenericRepository<Accounting> _accountingRepository;
        public GenericRepository<Accounting> accountingRepository
        {
            get
            {
                if (_accountingRepository == null)
                {
                    _accountingRepository = new GenericRepository<Accounting>(db);
                }

                return _accountingRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
