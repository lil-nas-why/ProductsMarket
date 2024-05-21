using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MarketDB;

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
            var source = marketEntities.GetContext().products.ToList();
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

            if(_selectedProduct!= null)
            {
                using (var context = marketEntities.GetContext())
                {
                    var basketItem = new BasketProducts
                    {
                        idBasketProduct = _selectedProduct.idProducts,
                        quantity = 1
                    };
                    marketEntities.GetContext().BasketProducts.Add(basketItem);
                    marketEntities.GetContext().SaveChanges();
                }

                var basketWindow = new BasketWindow();
                basketWindow.UpdateBasketItem();
                basketWindow.Show();
            }
        }
    }
}
