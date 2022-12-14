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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DB.Model1 db = new DB.Model1();
        public static bool admin = false;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            RegistrWindow registrWindow = new RegistrWindow();
            registrWindow.Show();
            this.Close();
        }
        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            db.user.Load();
            if (db.user.Local.Where(x => x.login == LV.Text && x.password == PV.Password).FirstOrDefault() != null)
            {
                if (db.user.Local.Where(x => x.login == LV.Text && x.password == PV.Password && x.status == true).FirstOrDefault() != null)
                {
                    Admin.admin = true;
                }
                else { Admin.admin = false; }
                    MessageBox.Show("Добро пожаловать");
                    MainVin mainVin = new MainVin();
                    mainVin.Show();
                    this.Close();             
            }
            else { MessageBox.Show("Что-то не так"); }
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
