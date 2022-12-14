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
    /// Логика взаимодействия для ZapisPage.xaml
    /// </summary>
    public partial class ZapisPage : Page
    {
        DB.Model2 mdb = new DB.Model2();
        DB.Model3 db3 = new DB.Model3();
        public ZapisPage()
        {
            InitializeComponent();
            mdb.Uslugi.Load();
            db3.Zapis.Load();
            dtgS.ItemsSource = mdb.Uslugi.Local;
            dtgZ.ItemsSource = db3.Zapis.Local;
            if (Admin.admin == true)
            {
                DobBT.Visibility = Visibility.Visible;
                DelBT.Visibility = Visibility.Visible;
                RBT.Visibility = Visibility.Visible;
            }
            else if (Admin.admin == false) 
            {
                DobBT.Visibility = Visibility.Hidden;
                DelBT.Visibility = Visibility.Hidden;
                RBT.Visibility = Visibility.Hidden;
            }
        }
        Uslugi us = new Uslugi();
        bool q = false;
        private void ABT_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder qw = new StringBuilder();
            us = (Uslugi)dtgS.SelectedItem;
            if (IDV.Text == "")
            {
                qw.Append("Введите номер для услуги");
            }
         
            if (qw.Length > 0)
            {
                MessageBox.Show(qw.ToString());
            }
            else
            {
                if (us != null)
                {
                    Zapis zapis = new Zapis();
                    zapis.idz = int.Parse(IDV.Text);
                    zapis.Name_zap = us.Name_usl;
                    zapis.Date = datePicker1.SelectedDate;
                    zapis.Price = us.Price;
                    db3.Zapis.Add(zapis);
                    db3.SaveChanges();
                    q = true;
                }
                else { MessageBox.Show("Вы ничего не выбрали"); }
                if (q == true)
                {
                    MessageBox.Show("Все успешно");
                }
                else if (q == false) { MessageBox.Show("Ошибка при записи"); }
            }
        }
        Zapis Zs = new Zapis();
        private void DelBT_Click(object sender, RoutedEventArgs e)
        {
            Zs = (Zapis)dtgZ.SelectedItem;
            if (Zs != null)
            {
                try
                {
                    if (MessageBox.Show("Вы действительно хотите удалить эту услугу?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        db3.Zapis.Remove(Zs);
                        db3.SaveChanges();
                        dtgS.ItemsSource = db3.Zapis.Local.OrderBy(x => x.idz);
                    }
                }
                catch
                {
                    MessageBox.Show("----------------");
                }
            }
        }

        private void DobBT_Click(object sender, RoutedEventArgs e)
        {
            DobWindow dobWindow = new DobWindow();
            dobWindow.Show();
        }

        private void RBT_Click(object sender, RoutedEventArgs e)
        {
            mdb.Uslugi.Load();
            db3.Zapis.Load();
            dtgS.ItemsSource = mdb.Uslugi.Local;
            dtgZ.ItemsSource = db3.Zapis.Local;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            TextPage textPage = new TextPage();
            this.NavigationService.Navigate(textPage);
        }
    }
}
