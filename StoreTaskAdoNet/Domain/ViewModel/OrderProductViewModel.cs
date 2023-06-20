using StoreTaskAdoNet.Commands;
using StoreTaskAdoNet.DataAccess.SqlServer;
using StoreTaskAdoNet.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StoreTaskAdoNet.Domain.ViewModel
{
    public class OrderProductViewModel : BaseViewModel
    {
        public RelayCommand OrderCommand { get; set; }

        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;

        private Product productInfo;
        public Product ProductInfo
        {
            get { return productInfo; }
            set { productInfo = value; OnPropertyChanged(); }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged(); }
        }

        public OrderProductViewModel()
        {
            _productService = new ProductService();
            _customerService = new CustomerService();
            _orderService = new OrderService();

            ProductInfo = new Product();

            OrderCommand = new RelayCommand((bj) =>
            {                                
                var customer = _customerService.GetCustomerByUsername(Username);

                if (customer != null)
                {
                    if (Amount <= ProductInfo.Quantity)
                    {
                        ProductInfo.Quantity -= Amount;
                        _productService.UpdateProduct(ProductInfo);

                        var order = new Order
                        {
                            Date = DateTime.Now,
                            Amount = Amount,
                            CustomerID = customer.ID,
                            ProductID = ProductInfo.ID,
                        };

                        _orderService.AddOrder(order);
                        MessageBox.Show("Product has been successfully ordered.", "Successful!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    else
                    {
                        MessageBox.Show("There isn't that much product.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                else
                {
                    MessageBox.Show("There is no such user.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
