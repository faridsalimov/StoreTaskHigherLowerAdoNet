using StoreTaskAdoNet.DataAccess.Abstractions;
using StoreTaskAdoNet.DataAccess.Concrete;
using StoreTaskAdoNet.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTaskAdoNet.Domain.Services
{
    public class CustomerService
    {
        private IRepository<Customer> _repository;
        public CustomerService()
        {
            _repository = new CustomerRepository();
        }

        public Customer GetCustomerByUsername(string username)
        {
            var customers = _repository.GetAll();
            var customer = customers.FirstOrDefault(c => c.Username == username);
            return customer;
        }
    }
}
