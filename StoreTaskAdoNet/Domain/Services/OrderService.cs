using StoreTaskAdoNet.DataAccess.Abstractions;
using StoreTaskAdoNet.DataAccess.Concrete;
using StoreTaskAdoNet.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTaskAdoNet.Domain.Services
{
    public class OrderService
    {
        private IRepository<Order> _repository;
        public OrderService()
        {
            _repository = new OrderRepository();
        }

        public void AddOrder(Order order)
        {
            _repository.AddData(order);
        }

        public ObservableCollection<Order> GetAllOrders()
        {
            IOrderedEnumerable<Order> items = null;
            items = from o in _repository.GetAll()
                    orderby o.ProductID descending
                    select o;
            return new ObservableCollection<Order>(items);
        }
    }
}
