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
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDBDataContext _context;
        public OrderRepository()
        {
            _context = new StoreDBDataContext();
        }

        public void AddData(Order data)
        {
            _context.Orders.InsertOnSubmit(data);
            _context.SubmitChanges();
        }

        public void DeleteData(Order data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Order> GetAll()
        {
            var orders = from o in _context.Orders
                         orderby o.CustomerID
                         select o;
            return new ObservableCollection<Order>(orders);
        }

        public Order GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Order data)
        {
            throw new NotImplementedException();
        }
    }
}
