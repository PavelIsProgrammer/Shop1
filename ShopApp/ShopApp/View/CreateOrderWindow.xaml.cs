using ShopApp;
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
using System.Windows.Shapes;

namespace shop.View
{
    public partial class CreateOrderWindow : Window
    {
        public double sumCard;
        public double sumOrder;

        public CreateOrderWindow(double sumCard)
        {
            InitializeComponent();
            this.sumCard = sumCard;
            tb_fromCard.Text += sumCard.ToString();
        }

        private void butMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void butCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            sumOrder = Math.Round(rand.NextDouble() * sumCard, 2);

                MessageBox.Show($"Сумма Вашего заказа составила {sumOrder}");
                View.Bucket bucket = new Bucket();
                bucket.Owner = this;
                bucket.ShowDialog();
                this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listCategoty.Items.Clear();
            for (int i = 1; i <= App.excelBook.Worksheets.Count; i++)
            {
                listCategoty.Items.Add(App.excelBook.Worksheets[i].Name);
            }
        }

        private void listCategoty_SelectionChenged(object sender, SelectionChangedEventArgs e)
        {
            string categoryName = listCategoty.SelectedItem.ToString();
            MessageBox.Show(categoryName);
        }
    }
}
