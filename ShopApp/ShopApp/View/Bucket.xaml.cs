using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// <summary>
    /// Логика взаимодействия для Bucket.xaml
    /// </summary>
    public partial class Bucket : Window
    {
        private double finalSumCard;
        public Bucket()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            tb_summOrder.Text += (this.Owner as CreateOrderWindow).sumOrder.ToString();
            finalSumCard = (this.Owner as CreateOrderWindow).sumCard - (this.Owner as CreateOrderWindow).sumOrder;
            tb_fromCardCreate.Text += finalSumCard.ToString();
        }

        private void butMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void butCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            View.CreateOrderWindow createOrderWindow = new CreateOrderWindow(finalSumCard); //создание объекта окна
            this.Hide();
            createOrderWindow.ShowDialog(); //Показать модальное дополнительное
        }

    }
}
