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

namespace k11_kurs
{
    /// <summary>
    /// Логика взаимодействия для MainVin.xaml
    /// </summary>
    public partial class MainVin : Window
    {

        public MainVin()
        {
            InitializeComponent();
            fr1.Navigate(new TextPage());
        }

        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            fr1.Navigate(new YslPage());
        }

        private void BT2_Click(object sender, RoutedEventArgs e)
        {
            fr1.Navigate(new ZapisPage());
        }

        private void BT3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }

}
