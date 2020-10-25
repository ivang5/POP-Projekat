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
    /// Interaction logic for AddNEditKarta.xaml
    /// </summary>
    public partial class AddNEditKarta : Window
    {
        public enum EOpcija { DODAVANJE, IZMENA }
        private EOpcija opcija;
        private Karta karta;
        private Karta novaKarta;

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public AddNEditKarta(Karta karta, EOpcija opcija = EOpcija.DODAVANJE)
        {
            InitializeComponent();
            this.karta = karta;
            this.opcija = opcija;

            this.DataContext = karta;
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {

            this.DataContext = karta;
            this.DialogResult = true;
            if (opcija == EOpcija.DODAVANJE)
            {
                Data.Instance.Karte.Add(karta);
                // UNOS U BAZU
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "insert into Karte ([brojLeta], [brojSedista], [nazivPutnika], [klasaSedista], [kapija], [cena], [aktivan]) values(@brojLeta,@brojSedista,@nazivPutnika,@klasaSedista,@kapija,@cena,@aktivan)";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@brojLeta", TxtBrojLeta.Text);
                        cmd.Parameters.AddWithValue("@brojSedista", TxtBrojSedista.Text);
                        cmd.Parameters.AddWithValue("@nazivPutnika", TxtNazivPutnika.Text);
                        cmd.Parameters.AddWithValue("@klasaSedista", TxtKlasaSedista.Text);
                        cmd.Parameters.AddWithValue("@kapija", TxtKapija.Text);
                        cmd.Parameters.AddWithValue("@cena", TxtCena.Text);
                        cmd.Parameters.AddWithValue("@aktivan", "true");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Karta sacuvana!");
                    }
                }
            }
            else if (opcija == EOpcija.IZMENA)
            {
                int id = karta.Id;
                //MENJANJE U BAZI
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Karte set brojLeta=@brojLeta,brojSedista=@brojSedista,nazivPutnika=@nazivPutnika,klasaSedista=@klasaSedista,kapija=@kapija,cena=@cena where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@brojLeta", karta.BrojLeta);
                        cmd.Parameters.AddWithValue("@brojSedista", karta.BrojSedista);
                        cmd.Parameters.AddWithValue("@nazivPutnika", karta.NazivPutnika);
                        cmd.Parameters.AddWithValue("@klasaSedista", karta.KlasaSedista);
                        cmd.Parameters.AddWithValue("@kapija", karta.Kapija);
                        cmd.Parameters.AddWithValue("@cena", karta.Cena);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Karta uspesno izmenjena!");
                    }
                }
            }
            this.Close();

                
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
