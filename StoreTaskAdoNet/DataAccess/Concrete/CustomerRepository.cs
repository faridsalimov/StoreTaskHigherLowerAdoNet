using StoreTaskAdoNet.DataAccess.Abstractions;
using StoreTaskAdoNet.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTaskAdoNet.DataAccess.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreDBDataContext _context;
        public CustomerRepository()
        {
            _context = new StoreDBDataContext();
        }

        public void AddData(Customer data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Customer data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Customer> GetAll()
        {
            var result = from c in _context.Customers
                         orderby c.Username
                         select c;
            return new ObservableCollection<Customer>(result);
        }

        public Customer GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Customer data)
        {
            throw new NotImplementedException();
        }
    }
}
