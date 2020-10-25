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
    /// Interaction logic for AddNEditPutnikWindow.xaml
    /// </summary>
    public partial class AddNEditPutnikWindow : Window
    {
        public enum EOpcija { DODAVANJE, IZMENA }
        private EOpcija opcija;
        private Korisnik korisnik;
        private Korisnik noviKorisnik;

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public AddNEditPutnikWindow(Korisnik korisnik, EOpcija opcija = EOpcija.DODAVANJE)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            this.opcija = opcija;

            CbPol.Items.Add("Musko");
            CbPol.Items.Add("Zensko");

            this.DataContext = korisnik;
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = korisnik;
            if (opcija == EOpcija.DODAVANJE)
            {
                Data.Instance.Korisnici.Add(korisnik);
                // UNOS U BAZU
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "insert into Korisnici ([ime], [prezime], [email], [adresa], [pol], [korisnickoIme], [lozinka], [tip], [aktivan]) values(@ime,@prezime,@email,@adresa,@pol,@korisnickoIme,@lozinka,@tip,@aktivan)";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ime", TxtIme.Text);
                        cmd.Parameters.AddWithValue("@prezime", TxtPrezime.Text);
                        cmd.Parameters.AddWithValue("@email", TxtEmail.Text);
                        cmd.Parameters.AddWithValue("@adresa", TxtAdresa.Text);
                        cmd.Parameters.AddWithValue("@pol", CbPol.Text);
                        cmd.Parameters.AddWithValue("@korisnickoIme", TxtKorisnickoIme.Text);
                        cmd.Parameters.AddWithValue("@lozinka", TxtLozinka.Text);
                        cmd.Parameters.AddWithValue("@tip", "Putnik");
                        cmd.Parameters.AddWithValue("@aktivan", "true");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Uspesna registracija!");
                    }
                }
            }
            else if (opcija == EOpcija.IZMENA)
            {
                //MENJANJE U BAZI
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Korisnici set ime=@ime,prezime=@prezime,email=@email,adresa=@adresa,pol=@pol,korisnickoIme=@korisnickoIme,lozinka=@lozinka where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ime", korisnik.Ime);
                        cmd.Parameters.AddWithValue("@prezime", korisnik.Prezime);
                        cmd.Parameters.AddWithValue("@email", korisnik.Email);
                        cmd.Parameters.AddWithValue("@adresa", korisnik.Adresa);
                        cmd.Parameters.AddWithValue("@pol", korisnik.Pol);
                        cmd.Parameters.AddWithValue("@korisnickoIme", korisnik.KorisnickoIme);
                        cmd.Parameters.AddWithValue("@lozinka", korisnik.Lozinka);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Profil uspesno izmenjen!");
                    }
                }
            }
            this.Close();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
