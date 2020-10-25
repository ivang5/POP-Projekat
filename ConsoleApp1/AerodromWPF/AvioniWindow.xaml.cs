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
    /// Interaction logic for AvioniWindow.xaml
    /// </summary>
    public partial class AvioniWindow : Window
    {

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public AvioniWindow()
        {
            InitializeComponent();
            DGAvioni.ItemsSource = Data.Instance.Avioni;
            DGAvioni.IsSynchronizedWithCurrentItem = true;

            DGAvioni.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            DGAvioni.SelectedIndex = -1;
        }

        private bool SelektovaniAvion()
        {
            if (DGAvioni.SelectedIndex == -1)
            {
                MessageBox.Show("Nije selektovan nijedan avion!");
                return true;
            }
            else
                return false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovaniAvion())
            {
                return;
            }
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Avion selektovaniAvion = DGAvioni.SelectedItem as Avion;

                int id = selektovaniAvion.Id;
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Avioni set aktivan=0 where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                Data.Instance.Avioni.Remove(selektovaniAvion);
                DGAvioni.Items.Refresh();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Avion noviAvion = new Avion();
            AddNEditAvion few = new AddNEditAvion(noviAvion);
            bool? rez = few.ShowDialog();
            DGAvioni.Items.Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovaniAvion())
            {
                return;
            }
            Avion selektovaniAvion = DGAvioni.SelectedItem as Avion;
            AddNEditAvion few = new AddNEditAvion(selektovaniAvion, AddNEditAvion.EOpcija.IZMENA);
            if (few.ShowDialog() == true)
            {
                DGAvioni.Items.Refresh();
            }

        }

        private void btnSedista_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovaniAvion())
            {
                return;
            }
            Avion selektovaniAvion = DGAvioni.SelectedItem as Avion;
            SedistaWindow sedista = new SedistaWindow();
            foreach (Sediste sediste in Data.Instance.Sedista)
                if (sediste.IdAviona == selektovaniAvion.Id)
                    Data.Instance.SedistaAvion.Add(sediste);

            sedista.Show();
        }
    }
}
