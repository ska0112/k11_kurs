using k11_kurs.DB;
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
    /// Логика взаимодействия для DobWindow.xaml
    /// </summary>
    public partial class DobWindow : Window
    {
        DB.Model3 ds = new DB.Model3();
        public DobWindow()
        {
            InitializeComponent();
        }

        private void EBT_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DBT_Click(object sender, RoutedEventArgs e)
        {
            VID.Text = "";
            VNaz.Text = "";
            VP.Text = "";
        }

        private void ZBT_Click(object sender, RoutedEventArgs e)
        {
            int qwe = int.Parse(VID.Text);
            StringBuilder osh = new StringBuilder();
            if (ds.Zapis.Where(x => x.idz == qwe).FirstOrDefault() != null)
            {
                osh.Append("Уже есть такое значение ID\n");
            }
            if (VID.Text == "" || VNaz.Text == "" || VP.Text == "")
            {
                osh.Append("Есть пустые ячейки\n");
            }
            if (osh.Length > 0)
            {
                MessageBox.Show(osh.ToString());
            }
            else
            {
                Zapis ap = new Zapis();
                ap.idz = int.Parse(VID.Text);
                ap.Name_zap = VNaz.Text;
                ap.Price = VP.Text;
                ap.Date = datePicker1.SelectedDate;
                ds.Zapis.Add(ap);
                ds.SaveChanges();
                MessageBox.Show("Записано");
            }
        }
    }
}
