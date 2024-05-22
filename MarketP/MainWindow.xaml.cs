using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MarketP
{
    public partial class MainWindow : Window
    {
        private products _selectedProduct;
        public MainWindow()
        {
            InitializeComponent();
            UpdateSource();
        }

        private void UpdateSource()
        {
            var s = marketEntities1.GetContext().products;
            var source = s.ToList();
            if(!String.IsNullOrWhiteSpace(SearchBar.Text))
            {
                source = source.Where(x => x.nameProducts.ToLower().Contains(SearchBar.Text.ToLower())).ToList();
            }
            ProductsLV.ItemsSource = source;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSource();
        }

        private void ProductsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedProduct = (products)ProductsLV.SelectedItem;
        }

        private void GoToBasket_Click(object sender, RoutedEventArgs e)
        {
            

            if (_selectedProduct!= null)
            {
                using (var context = marketEntities1.GetContext())
                {
                    var basketItem = new BasketProducts
                    {
                        idBasketProduct = _selectedProduct.idProducts,
                        quantity = 1,
                        nameProductB = _selectedProduct.nameProducts,
                        customerB = _selectedProduct.customer,
                        expiration = _selectedProduct.expiration,
                        priceB = _selectedProduct.price,
                        sale = _selectedProduct.sale,
                       
                        
                    };
                    marketEntities1.GetContext().BasketProducts.Add(basketItem);
                    marketEntities1.GetContext().SaveChanges();
                    marketEntities1.GetContext().BasketProducts.ToList();
                }

            }
        }

        private void basket_Click(object sender, RoutedEventArgs e)
        {
            var basketWindow = new BasketWindow();
            basketWindow.UpdateBasketItem();
            basketWindow.ShowDialog();
        }
    }
}
