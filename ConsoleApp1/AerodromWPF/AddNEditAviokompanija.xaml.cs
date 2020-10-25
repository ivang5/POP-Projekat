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
    /// Interaction logic for AddNEditAviokompanija.xaml
    /// </summary>
    public partial class AddNEditAviokompanija : Window
    {
        public enum EOpcija { DODAVANJE, IZMENA }
        private EOpcija opcija;
        private Aviokompanija aviokompanija;
        private Aviokompanija novaAviokompanija;

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public AddNEditAviokompanija(Aviokompanija aviokompanija, EOpcija opcija = EOpcija.DODAVANJE)
        {
            InitializeComponent();
            this.aviokompanija = aviokompanija;
            this.opcija = opcija;

            this.DataContext = aviokompanija;;
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {

            this.DataContext = aviokompanija;

            this.DialogResult = true;
            if (opcija == EOpcija.DODAVANJE)
            {
                Data.Instance.Aviokompanije.Add(aviokompanija);
                // UNOS U BAZU
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "insert into Aviokompanije ([sifra], [naziv], [aktivan]) values(@sifra,@naziv,@aktivan)";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sifra", TxtSifra.Text);
                        cmd.Parameters.AddWithValue("@naziv", TxtNaziv.Text);
                        cmd.Parameters.AddWithValue("@aktivan", "true");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Aviokompanija sacuvana!");
                    }
                }
            }
            else if (opcija == EOpcija.IZMENA)
            {
                int id = aviokompanija.Id;
                //MENJANJE U BAZI
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Aviokompanije set sifra=@sifra,naziv=@naziv where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@sifra", aviokompanija.Sifra);
                        cmd.Parameters.AddWithValue("@naziv", aviokompanija.Naziv);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Aviokompanija uspesno izmenjena!");
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
