using ShopApp;
using System;
using System.Collections.Generic;
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

namespace shop.View
{
    public partial class Authorization : Window
    {
        int countTry;
        public Authorization()
        {
            InitializeComponent();
            countTry = 3;
        }

        private void butMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void butEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPassword.Password;
            if (login == App.Login && password == App.Password)
            {
                View.WorkWithCatalog workWithCatalog = new WorkWithCatalog();
                Close();
                workWithCatalog.ShowDialog();
            }
            else
            {
                countTry--;
                if (countTry == 0)
                {
                    MessageBox.Show("Все попытки исчерпаны.");
                    Close();
                }
                else
                {
                    MessageBox.Show($"Введены неверные данные. Осталось {countTry} попыток.");
                }
            }
        }
    }
}
