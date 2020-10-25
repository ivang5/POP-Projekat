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
    /// Interaction logic for AddNEditWindow.xaml
    /// </summary>
    public partial class AddNEditWindow : Window
    {
        public enum EOpcija { DODAVANJE, IZMENA }
        private EOpcija opcija;
        private Aerodrom aerodrom;
        private Aerodrom noviAerodrom;

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public AddNEditWindow(Aerodrom aerodrom, EOpcija opcija = EOpcija.DODAVANJE)
        {
            InitializeComponent();
            this.aerodrom = aerodrom;
            this.opcija = opcija;

            this.DataContext = aerodrom;
            //TxtSifra.Text = aerodrom.Sifra;
            //TxtGrad.Text = aerodrom.Grad;
            //TxtNaziv.Text = aerodrom.Naziv;
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            //aerodrom.Sifra = TxtSifra.Text;
            //aerodrom.Grad = TxtGrad.Text;
            //aerodrom.Naziv = TxtNaziv.Text;
            this.DataContext = aerodrom;
            this.DialogResult = true;
            if (opcija == EOpcija.DODAVANJE)
            {
                Data.Instance.Aerodromi.Add(aerodrom);
                //UNOS U BAZU
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "insert into Aerodromi ([sifra], [naziv], [grad], [aktivan]) values(@sifra,@naziv,@grad,@aktivan)";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sifra", TxtSifra.Text);
                        cmd.Parameters.AddWithValue("@naziv", TxtNaziv.Text);
                        cmd.Parameters.AddWithValue("@grad", TxtGrad.Text);
                        cmd.Parameters.AddWithValue("@aktivan", "true");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Aerodrom sacuvan!");
                    }
                }
            }
            else if (opcija == EOpcija.IZMENA)
            {
                int id = aerodrom.Id;
                //MENJANJE U BAZI
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Aerodromi set sifra=@sifra,naziv=@naziv,grad=@grad,aktivan=@aktivan where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@sifra", aerodrom.Sifra);
                        cmd.Parameters.AddWithValue("@naziv", aerodrom.Naziv);
                        cmd.Parameters.AddWithValue("@grad", aerodrom.Grad);
                        cmd.Parameters.AddWithValue("@aktivan", aerodrom.Aktivan);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Aerodrom uspesno izmenjen!");
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
