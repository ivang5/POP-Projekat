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
    /// Interaction logic for KarteWindow.xaml
    /// </summary>
    public partial class KarteWindow : Window
    {

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public KarteWindow()
        {
            InitializeComponent();
            DGKarte.ItemsSource = Data.Instance.Karte;
            DGKarte.IsSynchronizedWithCurrentItem = true;

            DGKarte.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            DGKarte.SelectedIndex = -1;
        }

        private bool SelektovanaKarta()
        {
            if (DGKarte.SelectedIndex == -1)
            {
                MessageBox.Show("Nije selektovana nijedna karta!");
                return true;
            }
            else
                return false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovanaKarta())
            {
                return;
            }
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Karta selektovanaKarta = DGKarte.SelectedItem as Karta;

                int id = selektovanaKarta.Id;
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Karte set aktivan=0 where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                Data.Instance.Karte.Remove(selektovanaKarta);

                DGKarte.Items.Refresh();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Karta novaKarta = new Karta();
            AddNEditKarta few = new AddNEditKarta(novaKarta);
            bool? rez = few.ShowDialog();
            DGKarte.Items.Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovanaKarta())
            {
                return;
            }
            Karta selektovanaKarta = DGKarte.SelectedItem as Karta;
            AddNEditKarta few = new AddNEditKarta(selektovanaKarta, AddNEditKarta.EOpcija.IZMENA);
            if (few.ShowDialog() == true)
            {
                DGKarte.Items.Refresh();
            }

        }
    }
}
