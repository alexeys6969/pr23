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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderingGifts_Шашин
{
    /// <summary>
    /// Логика взаимодействия для Order_Item.xaml
    /// </summary>
    public partial class Order_Item : UserControl
    {
        Order order_item;
        public static Pages.OrderAdd add;
        public Order_Item(Order _order)
        {
            InitializeComponent();
            order_item = _order;
            if(_order.fio_user != null)
            {
                fio_itm.Text = _order.fio_user;
                mess_itm.Text = _order.message_text;
                adress_itm.Text = _order.adress;
                date_itm.Text = _order.dateSendMessage.ToString("dd.MM.yyyy HH:mm");
                email_itm.Text = _order.email;
            }

            DoubleAnimation op = new DoubleAnimation();
            op.From = 0;
            op.To = 1;
            op.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, op);
        }

        private void EditOrder(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.OrderAdd(order_item));
        }

        private void RemoveOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = $"DELETE FROM [order] WHERE [Код] = {order_item.Id.ToString()}";
                var pc = MainWindow.connect.QueryAccess(query);
                if(pc != null)
                {
                    MessageBox.Show("Успешное удаление записи", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.connect.LoadData(Connection.tabels.order);
                    MainWindow.mainWindow.frame.Navigate(new Pages.Main());
                } else
                {
                    MessageBox.Show("Запрос не обработан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
