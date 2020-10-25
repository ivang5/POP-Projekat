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
    /// Interaction logic for AviokompanijeWindow.xaml
    /// </summary>
    public partial class AviokompanijeWindow : Window
    {

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public AviokompanijeWindow()
        {
            InitializeComponent();
            DGAviokompanije.ItemsSource = Data.Instance.Aviokompanije;
            DGAviokompanije.IsSynchronizedWithCurrentItem = true;

            DGAviokompanije.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            DGAviokompanije.SelectedIndex = -1;
        }

        private bool SelektovanaAviokompanija()
        {
            if (DGAviokompanije.SelectedIndex == -1)
            {
                MessageBox.Show("Nije selektovana nijedna avio kompanija!");
                return true;
            }
            else
                return false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovanaAviokompanija())
            {
                return;
            }
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Aviokompanija selektovanaAviokompanija = DGAviokompanije.SelectedItem as Aviokompanija;

                int id = selektovanaAviokompanija.Id;
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Aviokompanije set aktivan=0 where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                Data.Instance.Aviokompanije.Remove(selektovanaAviokompanija);

                DGAviokompanije.Items.Refresh();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Aviokompanija novaAviokompanija = new Aviokompanija();
            AddNEditAviokompanija few = new AddNEditAviokompanija(novaAviokompanija);
            bool? rez = few.ShowDialog();
            DGAviokompanije.Items.Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovanaAviokompanija())
            {
                return;
            }
            Aviokompanija selektovanaAviokompanija = DGAviokompanije.SelectedItem as Aviokompanija;
            AddNEditAviokompanija few = new AddNEditAviokompanija(selektovanaAviokompanija, AddNEditAviokompanija.EOpcija.IZMENA);
            if (few.ShowDialog() == true)
            {
                DGAviokompanije.Items.Refresh();
            }
        }

        private void btnLetovi_Click(object sender, RoutedEventArgs e)
        {
            while (SelektovanaAviokompanija())
            {
                return;
            }
            Aviokompanija selektovanaAviokompanija = DGAviokompanije.SelectedItem as Aviokompanija;
            AviokompanijeLetoviWindow letovi = new AviokompanijeLetoviWindow();
            letovi.Show();

            foreach (Let let in Data.Instance.Letovi)
            {
                if (let.Sifra == selektovanaAviokompanija.Sifra)
                    Data.Instance.AviokompanijeLetovi.Add(let);
            }
        }
    }
}