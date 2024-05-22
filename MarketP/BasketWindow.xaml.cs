using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using Counter;
 

namespace MarketP
{
    public partial class BasketWindow : Window
    {

        private TotalCounter totalCounter = new TotalCounter();
        
        public BasketWindow()
        {
            InitializeComponent();
            UpdateBasketItem();

            totalCounter.SumDiscount();
            Total.Text = totalCounter.result.ToString();
        }

        public void UpdateBasketItem()
        {
            var source = marketEntities1.GetContext().BasketProducts.ToList();
            ProductsBasketLV.ItemsSource = source;
        }

        private void CountSale_Click(object sender, RoutedEventArgs e)
        {
            totalCounter.SaleDiscount();
            TotalSale.Text = totalCounter.saleResult.ToString();
        }

        

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
