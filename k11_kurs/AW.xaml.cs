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
using System.Windows.Shapes;

namespace k11_kurs
{
    /// <summary>
    /// Логика взаимодействия для AW.xaml
    /// </summary>
    public partial class AW : Window
    {
        DB.Model2 Model2 = new DB.Model2();
        public AW()
        {
            InitializeComponent();
            List<string> vs = new List<string>();
            vs.Add("мин.");
            vs.Add("ч.");
            VR.ItemsSource = vs;
        }

        private void EBT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void DBT_Click(object sender, RoutedEventArgs e)
        {
            VID.Text = "";
            VNaz.Text = "";
            VP.Text = "";
            VM.Text = "";
            VR.SelectedItem = 0;
        }

        private void ZBT_Click(object sender, RoutedEventArgs e)
        {
            Model2.Uslugi.Load();
            int qwe = int.Parse(VID.Text);
            StringBuilder osh = new StringBuilder();
            if (Model2.Uslugi.Where(x => x.id_usl == qwe).FirstOrDefault() != null)
            {
                osh.Append("Уже есть такое значение ID\n");
            }
            string ss = VNaz.Text;
            if (Model2.Uslugi.Where(z => z.Name_usl == ss).FirstOrDefault() != null)
            {
                osh.Append("Уже есть такая услуга\n");
            }
            if (VID.Text == "" || VNaz.Text == "" || VP.Text == "" || VM.Text == "")
            {
                osh.Append("Есть пустые ячейки\n");
            }
            if (osh.Length > 0)
            {
                MessageBox.Show(osh.ToString());
            }
            else
            {
                Uslugi uslugi = new Uslugi();
                uslugi.id_usl = int.Parse(VID.Text);
                uslugi.Name_usl = VNaz.Text;
                uslugi.Price = VP.Text + "руб.";
                uslugi.Time_usl = VM.Text + " " + VR.SelectedItem;
                Model2.Uslugi.Add(uslugi);
                Model2.SaveChanges();
                MessageBox.Show("Данные записаны");
            }
        }
    }
}
