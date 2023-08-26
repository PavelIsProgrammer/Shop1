using shop.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace ShopApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                App.excelApp = new Excel.Application();
                App.excelApp.Visible = false;
                MessageBox.Show("У Вас установлен MS Excel");

                if (File.Exists(App.fileMenu))
                {
                    App.excelBook = App.excelApp.Workbooks.Open(App.fileMenu);
                }
                else
                {
                    MessageBox.Show("Файл спрайс-листом отсутствует");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Установите MS Excel");
                this.Close();
            }
        }

        public void btn_ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void btn_PriceClick(object sender, RoutedEventArgs e)
        {
            App.excelApp.Visible = true;
        }

        private void btn_CatalogClick(object sender, RoutedEventArgs e)
        {
            var authorization = new Authorization();
            Hide();
            authorization.ShowDialog();
            Show();
        }

        private void btn_OrderClick(object sender, RoutedEventArgs e)
        {
            var createOrderWindow = new CreateOrderWindow(7689.23);

            List<string> listCat = new List<string>();
            int countSheet = App.excelBook.Worksheets.Count;
            for (int i = 1; i <= countSheet; i++)
            {
                listCat.Add(App.excelBook.Worksheets[i].Name);
            }

            Hide();
            createOrderWindow.Show();
            Show();
        }
    }
}
