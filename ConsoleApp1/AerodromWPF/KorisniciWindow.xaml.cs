using AerodromWPF.Database;
using AerodromWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace AerodromWPF
{
    /// <summary>
    /// Interaction logic for KorisniciWindow.xaml
    /// </summary>
    public partial class KorisniciWindow : Window
    {

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public KorisniciWindow()
        {
            InitializeComponent();
            DGKorisnici.ItemsSource = Data.Instance.Korisnici;
            DGKorisnici.IsSynchronizedWithCurrentItem = true;

            DGKorisnici.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            DGKorisnici.SelectedIndex = -1;
        }

        private bool SelektovaniKorisnik()
        {
            if (DGKorisnici.SelectedIndex == -1)
            {
                MessageBox.Show("Nije selektovan nijedan korisnik!");
                return true;
            }
            else
                return false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovaniKorisnik())
            {
                return;
            }
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Korisnik selektovaniKorisnik = DGKorisnici.SelectedItem as Korisnik;
                int id = selektovaniKorisnik.Id;

                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Korisnici set aktivan=0 where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                Data.Instance.Korisnici.Remove(selektovaniKorisnik);
                DGKorisnici.Items.Refresh();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Korisnik noviKorisnik = new Korisnik();
            AddNEditKorisnik few = new AddNEditKorisnik(noviKorisnik);
            bool? rez = few.ShowDialog();
            DGKorisnici.Items.Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            while(SelektovaniKorisnik())
            {
                return;
            }
            Korisnik selektovaniKorisnik = DGKorisnici.SelectedItem as Korisnik;
            AddNEditKorisnik few = new AddNEditKorisnik(selektovaniKorisnik,
                AddNEditKorisnik.EOpcija.IZMENA);
            if (few.ShowDialog() == true)
            {
                DGKorisnici.Items.Refresh();
            }

        }
    }
}
