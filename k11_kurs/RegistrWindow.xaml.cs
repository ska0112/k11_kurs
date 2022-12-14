using k11_kurs.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrWindow.xaml
    /// </summary>
    public partial class RegistrWindow : Window
    {
        DB.Model1 db1 = new DB.Model1();
        public RegistrWindow()
        {
            InitializeComponent();
        }

        Regex InputID = new Regex(@"[0-9]"); // [а-яА-Я]
        private void VID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match matchID = InputID.Match(e.Text);
            if (!matchID.Success)
            {
                e.Handled = true;
            }
        }
        Regex InputSur = new Regex(@"[а-яА-Я]");
        private void VF_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match matchSur = InputSur.Match(e.Text);
            if (!matchSur.Success)
            {
                e.Handled = true;
            }
        }

        Regex InputLogin = new Regex(@"[a-zA-Z0-9_\-\.]");
        private void VL_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match login = InputLogin.Match(e.Text);
            InputLogin.Match(e.Text);
            if (!login.Success)
            {
                e.Handled = true;
            }
        }
        private void BT2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BT3_Click(object sender, RoutedEventArgs e)
        {
            VID.Text = "";
            NV.Text = "";
            VF.Text = "";
            VM.Text = "";
            VL.Text = "";
            VP.Text = "";
        }

        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            db1.user.Load();
            int qwe = int.Parse(VID.Text);
            StringBuilder osh = new StringBuilder();
            if (db1.user.Where(x => x.id == qwe).FirstOrDefault() != null)
            {
                osh.Append("Уже есть такое значение ID\n");
            }
            if (VID.Text == "" || VF.Text =="" || NV.Text =="" || VM.Text == "" || VL.Text =="" || VP.Text == "")
            {
                osh.Append("Есть пустые ячейки\n");
            }
            if (db1.user.Where(x => x.login == VM.Text || x.password == VP.Text).FirstOrDefault() != null)
            {
                osh.Append("Такой пароль или логин уже существует\n");
            }
            if (osh.Length > 0)
            {
                MessageBox.Show(osh.ToString());
            }
            else 
            {
                db1.user.Load();
                user user = new user();
                user.id = int.Parse(VID.Text);
                user.Name = NV.Text;
                user.Surname = VF.Text;
                user.mail = VM.Text;
                user.login = VL.Text;
                user.password = VP.Text;
                db1.user.Add(user);
                db1.SaveChanges();
                MessageBox.Show("Данные записаны");
            }
        }
    }
}
