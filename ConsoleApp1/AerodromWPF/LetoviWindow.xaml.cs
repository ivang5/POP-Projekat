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
    /// Interaction logic for LetoviWindow.xaml
    /// </summary>
    public partial class LetoviWindow : Window
    {

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public LetoviWindow()
        {
            InitializeComponent();
            DGLetovi.ItemsSource = Data.Instance.Letovi;
            DGLetovi.IsSynchronizedWithCurrentItem = true;

            DGLetovi.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            DGLetovi.SelectedIndex = -1;
        }

        private bool SelektovaniLet()
        {
            if (DGLetovi.SelectedIndex == -1)
            {
                MessageBox.Show("Nije selektovan nijedan let!");
                return true;
            }
            else
                return false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovaniLet())
            {
                return;
            }
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Let selektovaniLet = DGLetovi.SelectedItem as Let;

                int id = selektovaniLet.Id;
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Letovi set aktivan=0 where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                Data.Instance.Letovi.Remove(selektovaniLet);

                DGLetovi.Items.Refresh();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Let noviLet = new Let();
            AddNEditLet few = new AddNEditLet(noviLet);
            bool? rez = few.ShowDialog();
            DGLetovi.Items.Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovaniLet())
            {
                return;
            }
            Let selektovaniLet = DGLetovi.SelectedItem as Let;
            AddNEditLet few = new AddNEditLet(selektovaniLet, AddNEditLet.EOpcija.IZMENA);
            if (few.ShowDialog() == true)
            {
                DGLetovi.Items.Refresh();
            }

        }
    }
}
