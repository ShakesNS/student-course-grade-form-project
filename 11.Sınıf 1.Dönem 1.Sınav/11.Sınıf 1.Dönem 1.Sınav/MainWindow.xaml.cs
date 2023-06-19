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

namespace _11.Sınıf_1.Dönem_1.Sınav
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbsınıflar.ItemsSource = new string[] { "11/A", "11/B", "11/C" };
            cbdersler.ItemsSource = new string[] { "Matematik", "Edebiyat" , "Fizik" };

            lbadlar.Items.Add("Ali");
            lbsoyadlar.Items.Add("çalışkan");
            lbsınıflar.Items.Add("11/A");
            lbdersler.Items.Add("Matematik");
            lbnotlar.Items.Add("45");

            lbadlar.Items.Add("veli");
            lbsoyadlar.Items.Add("tembel");
            lbsınıflar.Items.Add("11/A");
            lbdersler.Items.Add("Matematik");
            lbnotlar.Items.Add("30");

            lbadlar.Items.Add("Ayşe");
            lbsoyadlar.Items.Add("ortaşeker");
            lbsınıflar.Items.Add("11/A");
            lbdersler.Items.Add("Matematik");
            lbnotlar.Items.Add("55");
        }

        private void btnekle_Click(object sender, RoutedEventArgs e)
        {
            string hatamesajı = null;
            if (string.IsNullOrWhiteSpace(tbadekle.Text))
                hatamesajı += "ad boş bırakılmaz \n";
            if (string.IsNullOrWhiteSpace(tbsoyadekle.Text))
                hatamesajı += "soyad boş bırakılmaz \n";
            if (cbsınıflar.SelectedItem==null)
                hatamesajı += "sınıf seçilmelidir \n";
            if (cbdersler.SelectedItem==null)
                hatamesajı += "ders seçilmelidir \n";
            if (string.IsNullOrWhiteSpace(tbnotekle.Text))
                hatamesajı += "not boş bırakılmaz \n";
            else if (int.TryParse(tbnotekle.Text, out int not) == false)
                hatamesajı += "not sayı olarak girilmelidir";
            else if (int.Parse(tbnotekle.Text) < 0 || int.Parse(tbnotekle.Text) > 100)
                hatamesajı += "sayı 0 ile 100 arasında olmalıdır";

            if (hatamesajı!=null)
            {
                MessageBox.Show("lütfen aşağıdaki hataları düzeltiniz\n\n" + hatamesajı, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                lbadlar.Items.Add(tbadekle.Text);
                lbsoyadlar.Items.Add(tbsoyadekle.Text);
                lbsınıflar.Items.Add(cbsınıflar.SelectedItem);
                lbdersler.Items.Add(cbdersler.SelectedItem);
                lbnotlar.Items.Add(tbnotekle.Text);

                cbdersler.SelectedItem = null;
                tbnotekle.Clear();

            }



        }

        private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            lbadlar.SelectedIndex = lbsoyadlar.SelectedIndex = lbsınıflar.SelectedIndex = lbdersler.SelectedIndex = lbnotlar.SelectedIndex = lb.SelectedIndex;
        }

        private void btndeğiştir_Click(object sender, RoutedEventArgs e)
        {
            if (lbadlar.SelectedItem!=null)
            {

            
            string hatamesajı = null;
            if (string.IsNullOrWhiteSpace(tbadekle.Text))
                hatamesajı += "ad boş bırakılmaz \n";
            if (string.IsNullOrWhiteSpace(tbsoyadekle.Text))
                hatamesajı += "soyad boş bırakılmaz \n";
            if (cbsınıflar.SelectedItem == null)
                hatamesajı += "sınıf seçilmelidir \n";
            if (cbdersler.SelectedItem == null)
                hatamesajı += "ders seçilmelidir \n";
            if (string.IsNullOrWhiteSpace(tbnotekle.Text))
                hatamesajı += "not boş bırakılmaz \n";
            else if (int.TryParse(tbnotekle.Text, out int not) == false)
                hatamesajı += "not sayı olarak girilmelidir";
            else if (int.Parse(tbnotekle.Text) < 0 || int.Parse(tbnotekle.Text) > 100)
                hatamesajı += "sayı 0 ile 100 arasında olmalıdır";

            if (hatamesajı != null)
            {
                MessageBox.Show("lütfen aşağıdaki hataları düzeltiniz\n\n" + hatamesajı, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                    int i = lbadlar.SelectedIndex;
                lbadlar.Items[i]=tbadekle.Text;
                lbsoyadlar.Items[i]=tbsoyadekle.Text;
                lbsınıflar.Items[i]=cbsınıflar.SelectedItem;
                lbdersler.Items[i]=cbdersler.SelectedItem;
                lbnotlar.Items[i]=tbnotekle.Text;

                cbdersler.SelectedItem = null;
                tbnotekle.Clear();

            }
            }
        }

        private void btnsil_Click(object sender, RoutedEventArgs e)
        {
            if (lbadlar.SelectedItem != null)
            {
                int i = lbadlar.SelectedIndex;
                lbadlar.Items.RemoveAt(i);
                lbsoyadlar.Items.RemoveAt(i);
                lbsınıflar.Items.RemoveAt(i);
                lbdersler.Items.RemoveAt(i);
                lbnotlar.Items.RemoveAt(i);
            }
        }

        private void btnara_Click(object sender, RoutedEventArgs e)
        {
            lbadlar.SelectedIndex = -1;
            for (int i = 0; i < lbadlar.Items.Count; i++)
            {
                if (lbadlar.Items[i].ToString().ToLower()==tbadekle.Text.ToLower()&&(string.IsNullOrWhiteSpace(tbsoyadekle.Text)||lbsoyadlar.Items[i].ToString().ToLower()==tbsoyadekle.Text.ToLower()))
                {
                    lbadlar.SelectedIndex = i;
                    break;
                }
            }
            lbadlar.Focus();
        }

        private void btnrasgeleseç_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            lbadlar.SelectedIndex = rnd.Next(0, lbadlar.Items.Count);
            lbadlar.Focus();
        }
    }
}
