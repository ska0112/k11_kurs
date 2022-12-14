using k11_kurs.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace k11_kurs
{
    /// <summary>
    /// Логика взаимодействия для YslPage.xaml
    /// </summary>
    public partial class YslPage : Page
    {
        DB.Model2 db2 = new DB.Model2();
        public YslPage()
        {
            InitializeComponent();
            db2.Uslugi.Load();
            dtgS.ItemsSource = db2.Uslugi.Local;
            if (Admin.admin == true)
            {
                ABT.Visibility = Visibility.Visible;
                DBT.Visibility = Visibility.Visible;
                RBT.Visibility = Visibility.Visible;
            }
            else if(Admin.admin == false) { ABT.Visibility = Visibility.Hidden; DBT.Visibility = Visibility.Hidden; RBT.Visibility = Visibility.Hidden; }
        }

        private void backBT_Click(object sender, RoutedEventArgs e)
        {
            TextPage textPage = new TextPage();
            this.NavigationService.Navigate(textPage);
        }

        Uslugi us = new Uslugi();
        private void DBT_Click(object sender, RoutedEventArgs e)
        {
            us = (Uslugi)dtgS.SelectedItem;
            if (us != null)
            {
                try
                {
                    if (MessageBox.Show("Вы действительно хотите удалить эту услугу?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        db2.Uslugi.Remove(us);
                        db2.SaveChanges();
                        dtgS.ItemsSource = db2.Uslugi.Local.OrderBy(x => x.id_usl);
                    }
                }
                catch
                {
                    MessageBox.Show("----------------");
                }
            }
        }

        private void ABT_Click(object sender, RoutedEventArgs e)
        {
            AW aW = new AW();
            aW.Show();
        }

        private void RBT_Click(object sender, RoutedEventArgs e)
        {
            db2.Uslugi.Load();
            dtgS.ItemsSource = db2.Uslugi.Local;
        }
    }
}
