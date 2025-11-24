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
        public OrderAdd(Order _order)
        {
            InitializeComponent();
            ord_itm = _order;

            if(ord_itm.fio_user != null)
            {
                addLabel.Content = "Изменение заказа";
                addTB.Text = "Изменить заказ";
                fioTB.Text = ord_itm.fio_user;
                textTB.Text = ord_itm.message_text;
                adressTB.Text = ord_itm.adress;
                dateTB.Text = ord_itm.dateSendMessage.ToString("dd.MM.yyyy HH:mm");
                emailTB.Text = ord_itm.email;
            }
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.connect.ItsFio(fioTB.Text))
            {
                MessageBox.Show("Укажите ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(textTB.Text.Trim()))
            {
                MessageBox.Show("Укажите текст сообщения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (textTB.Text.Length > 35)
            {
                MessageBox.Show($"Сообщение слишком длинное {'\n'}Максимальная длина 35 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(adressTB.Text.Trim()))
            {
                MessageBox.Show("Укажите адрес", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!MainWindow.connect.ItsDateTime(dateTB.Text))
            {
                MessageBox.Show("Укажите дату в верном формате", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!MainWindow.connect.ItsEmail(emailTB.Text))
            {
                MessageBox.Show("Укажите адрес электронной почты в верном формате", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ord_itm.fio_user == null)
            {
                int id = MainWindow.connect.SetActualId(Connection.tabels.order);
                string query = $"INSERT INTO [order]([Код], [fio_user], [message_text], [adress], [dateSendMessage], [email]) VALUES ({id.ToString()}, '{fioTB.Text}', '{textTB.Text}', '{adressTB.Text}', '{dateTB.Text}', '{emailTB.Text}')";
                var pc = MainWindow.connect.QueryAccess(query);
                if (pc != null)
                {
                    MainWindow.connect.LoadData(Connection.tabels.order);
                    MessageBox.Show("Успешное добавление записи", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.mainWindow.frame.Navigate(new Pages.Main());
                } else
                {
                    MessageBox.Show("Запрос не обработан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                string query = $"UPDATE [order] SET " +
                   $"[fio_user] = '{fioTB.Text}', " +
                   $"[message_text] = '{textTB.Text}', " +
                   $"[adress] = '{adressTB.Text}', " +
                   $"[dateSendMessage] = '{dateTB.Text}', " +
                   $"[email] = '{emailTB.Text}' " +
                   $"WHERE [Код] = {ord_itm.Id}";
                var pc = MainWindow.connect.QueryAccess(query);
                if (pc != null)
                {
                    MainWindow.connect.LoadData(Connection.tabels.order);
                    MessageBox.Show("Успешное изменение записи", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.mainWindow.frame.Navigate(new Pages.Main());
                }
                else
                {
                    MessageBox.Show("Запрос не обработан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
