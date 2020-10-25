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
    /// Interaction logic for AerodromiWindow.xaml
    /// </summary>
    public partial class AerodromiWindow : Window
    {

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public AerodromiWindow()
        {
            InitializeComponent();
            DGAerodromi.ItemsSource = Data.Instance.Aerodromi;
            DGAerodromi.IsSynchronizedWithCurrentItem = true;

            DGAerodromi.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            DGAerodromi.SelectedIndex = -1;
        }

        private bool SelektovaniAerodrom()
        {
            if (DGAerodromi.SelectedIndex == -1)
            {
                MessageBox.Show("Nije selektovan nijedan aerodrom!");
                return true;
            }
            else
                return false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovaniAerodrom())
            {
                return;
            }
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Aerodrom selektovaniAerodrom = DGAerodromi.SelectedItem as Aerodrom;

                int id = selektovaniAerodrom.Id;
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Aerodromi set aktivan=0 where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                Data.Instance.Aerodromi.Remove(selektovaniAerodrom);
                DGAerodromi.Items.Refresh();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Aerodrom noviAerodrom = new Aerodrom();
            AddNEditWindow few = new AddNEditWindow(noviAerodrom);
            bool? rez = few.ShowDialog();
            DGAerodromi.Items.Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovaniAerodrom())
            {
                return;
            }
            Aerodrom selektovaniAerodrom = DGAerodromi.SelectedItem as Aerodrom;
            AddNEditWindow few = new AddNEditWindow(selektovaniAerodrom, AddNEditWindow.EOpcija.IZMENA);
            if (few.ShowDialog() == true)
            {
                DGAerodromi.Items.Refresh();
            }
            
        }

        private int IndeksAerodroma(String sifra)
        {
            int indeks = -1;
            for (int i=0; i<Data.Instance.Aerodromi.Count; i++)
            {
                if (Data.Instance.Aerodromi[i].Sifra.Equals(sifra))
                {
                    indeks = i;
                    break;
                }
            }
            return indeks;
        }
    }
}
