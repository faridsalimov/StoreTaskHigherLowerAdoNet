using StoreTaskAdoNet.Commands;
using StoreTaskAdoNet.DataAccess.SqlServer;
using StoreTaskAdoNet.Domain.Services;
using StoreTaskAdoNet.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StoreTaskAdoNet.Domain.ViewModel
{
    public class ProductsViewModel : BaseViewModel
    {
        public RelayCommand SelectProductCommand { get; set; }
        public RelayCommand IcProductCommand { get; set; }

        private readonly ProductService _productService;

        private ObservableCollection<Product> allProducts;
        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged(); }
        }

        private decimal productPrice;
        public decimal ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; OnPropertyChanged(); }
        }

        private int productQuantity;
        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; OnPropertyChanged(); }
        }

        private string productDescription;
        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; OnPropertyChanged(); }
        }

        private int productDiscount;
        public int ProductDiscount
        {
            get { return productDiscount; }
            set { productDiscount = value; OnPropertyChanged(); }
        }

        private string productMode;
        public string ProductMode
        {
            get { return productMode; }
            set { productMode = value; OnPropertyChanged(); }
        }

        public ProductsViewModel()
        {
            _productService = new ProductService();
            AllProducts = _productService.GetAllProducts();
            ProductMode = "Insert";

            SelectProductCommand = new RelayCommand((obj) =>
            {
                ProductName = SelectedProduct.Name;
                ProductPrice = SelectedProduct.Price;
                ProductDiscount = (int)SelectedProduct.Discount;
                ProductQuantity = SelectedProduct.Quantity;
                ProductDescription = SelectedProduct.Description;
                ProductMode = "Change";
            });

            IcProductCommand = new RelayCommand((obj) =>
            {
                if (ProductMode == "Insert")
                {
                    var newProduct = new Product
                    {
                        Name = ProductName,
                        Price = ProductPrice,
                        Description = ProductDescription,
                        Quantity = ProductQuantity,
                        Discount = ProductDiscount
                    };

                    _productService.AddProduct(newProduct);
                    AllProducts = _productService.GetAllProducts();

                    ProductName = null;
                    ProductPrice = 0;
                    ProductDescription = null;
                    ProductQuantity = 0;
                    ProductDiscount = 0;

                    MessageBox.Show("Product has been successfully added to the database.", "Successful!", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else if (ProductMode == "Change")
                {
                    SelectedProduct.Name = ProductName;
                    SelectedProduct.Price = ProductPrice;
                    SelectedProduct.Discount = ProductDiscount;
                    SelectedProduct.Description = ProductDescription;
                    SelectedProduct.Quantity = ProductQuantity;

                    ProductName = null;
                    ProductPrice = 0;
                    ProductDescription = null;
                    ProductQuantity = 0;
                    ProductDiscount = 0;

                    MessageBox.Show("Product has been successfully changed.", "Successful!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }
    }
}