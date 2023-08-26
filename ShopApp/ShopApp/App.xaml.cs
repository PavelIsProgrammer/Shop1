using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace ShopApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string Login = "admin";
        public static string Password = "shop";

        public static Excel.Application excelApp;
        public static Excel.Workbook excelBook;
        public static Excel.Worksheet excelSheet;
        public static Excel.Range excelCells;

        //Пути к файлам приложения
        public static string pathExe = Environment.CurrentDirectory;
        public static string fileMenu = pathExe + @"\PriceList.xlsx";

        protected override void OnExit(ExitEventArgs e)
        {
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
            GC.Collect();
            base.OnExit(e);
        }
    }
}
