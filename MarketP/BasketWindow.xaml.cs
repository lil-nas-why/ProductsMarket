using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using Path = System.IO.Path;

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
            var source = marketEntities1.GetContext().BasketProducts.ToList();

            //string path = "C:\\Users\\Student\\Desktop\\krico\\MarketP\\Checks\\Check.txt";

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Cheks", "chek1.txt");

            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
          
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var product in source)
                {
                    sw.WriteLine($"Наименование: {product.nameProductB}, Продавец: {product.customerB}, Цена: {product.priceB}, Скидка: {product.sale}");
                }

                sw.WriteLine($"Итог: {totalCounter.result}, Общая скидка: {totalCounter.saleResult}");
            }

            ProductsBasketLV.ItemsSource = null;
            this.Close();
        }
    }
}
