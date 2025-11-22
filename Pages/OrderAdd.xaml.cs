using OrderingGifts_Шашин.Classes;
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

namespace OrderingGifts_Шашин.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderAdd.xaml
    /// </summary>
    public partial class OrderAdd : Page
    {
        Order ord_itm;
        public OrderAdd()
        {
            InitializeComponent();

        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {

        }

        private void Gregory(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gregory!", "Gregory!", MessageBoxButton.YesNo, MessageBoxImage.Information);
        }

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }
    }
}
