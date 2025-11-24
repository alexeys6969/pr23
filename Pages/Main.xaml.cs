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
using static System.Net.Mime.MediaTypeNames;

namespace OrderingGifts_Шашин.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public bool isClicked = false;
        public Main()
        {
            InitializeComponent();
            MainWindow.connect.LoadData(Connection.tabels.order);
            RefreshInterface();
        }

        private void Gregory(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gregory!", "Gregory!", MessageBoxButton.YesNo, MessageBoxImage.Information);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.OrderAdd(new Order()));
        }

        private void filter_click(object sender, RoutedEventArgs e)
        {
            if (!isClicked)
            {
                parrent.Children.Clear();
                string query = "SELECT * FROM [order];";
                var pc = MainWindow.connect.QueryAccess(query);

                if (pc != null)
                {
                    MainWindow.connect.LoadData(Connection.tabels.order);
                    RefreshInterfaceWithSorting();
                }
                isClicked = true;
            } else
            {
                parrent.Children.Clear();
                string query = "SELECT * FROM [order];";
                var pc = MainWindow.connect.QueryAccess(query);

                if (pc != null)
                {
                    MainWindow.connect.LoadData(Connection.tabels.order);
                    RefreshInterface();
                }
                isClicked = false;
            }


        }

        public void RefreshInterfaceWithSorting()
        {
            var sortedOrders = MainWindow.connect.order.OrderBy(order => order.dateSendMessage).ToList();

            foreach (Order ord in sortedOrders)
            {
                parrent.Children.Add(new Order_Item(ord));
            }
        }

        public void RefreshInterface()
        {
            parrent.Children.Clear();
            foreach (Order ord in MainWindow.connect.order)
            {
                parrent.Children.Add(new Order_Item(ord));
            }
        }
    }
}
