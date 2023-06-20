using StoreTaskAdoNet.DataAccess.SqlServer;
using StoreTaskAdoNet.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTaskAdoNet.Domain.ViewModel
{
    public class OrdersViewModel : BaseViewModel
    {
        private readonly OrderService _orderService;

        private ObservableCollection<Order> allOrders;
        public ObservableCollection<Order> AllOrders
        {
            get { return allOrders; }
            set { allOrders = value; OnPropertyChanged(); }
        }

        public OrdersViewModel()
        {
            _orderService = new OrderService();
            AllOrders = _orderService.GetAllOrders();
        }
    }
}
