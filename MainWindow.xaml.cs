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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Pages.Main main;
        public static MainWindow mainWindow;
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            main = new Pages.Main();
            OpenPageMain();
        }

        public void OpenPageMain()
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 1;
            animation.To = 0;
            animation.Duration = TimeSpan.FromSeconds(0.2);
            animation.Completed += delegate
            {
                frame.Navigate(main);
                DoubleAnimation animation1 = new DoubleAnimation();
                animation1.From = 0;
                animation1.To = 1;
                animation1.Duration = TimeSpan.FromSeconds(0.4);
                frame.BeginAnimation(Frame.OpacityProperty, animation1);
            };
            frame.BeginAnimation(Frame.OpacityProperty, animation);
        }
    }
}
