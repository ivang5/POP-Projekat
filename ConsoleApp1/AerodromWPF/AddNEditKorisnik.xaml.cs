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
    /// Interaction logic for AddNEditKorisnik.xaml
    /// </summary>
    public partial class AddNEditKorisnik : Window
    {
        public enum EOpcija { DODAVANJE, IZMENA }
        private EOpcija opcija;
        private Korisnik korisnik;
        private Korisnik noviKorisnik;

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public AddNEditKorisnik(Korisnik korisnik, EOpcija opcija = EOpcija.DODAVANJE)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            this.opcija = opcija;

            CbPol.Items.Add("Musko");
            CbPol.Items.Add("Zensko");
            CbTip.Items.Add("Admin");
            CbTip.Items.Add("Putnik");

            this.DataContext = korisnik;
            //TxtIme.Text = korisnik.Ime;
            //TxtPrezime.Text = korisnik.Prezime;
            //TxtEmail.Text = korisnik.Email;
            //TxtAdresa.Text = korisnik.Adresa;
            //CbPol.Text = korisnik.Pol.ToString();
            //TxtKorisnickoIme.Text = korisnik.KorisnickoIme;
            //TxtLozinka.Text = korisnik.Lozinka;
            //CbTip.Text = korisnik.Tip.ToString();
            
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = korisnik;
            //korisnik.Ime = TxtIme.Text;
            //korisnik.Prezime = TxtPrezime.Text;
            //korisnik.Email = TxtEmail.Text;
            //korisnik.Adresa = TxtAdresa.Text;
            //korisnik.Pol = (Korisnik.polenum)Enum.Parse(typeof(Korisnik.polenum), CbPol.Text);
            //korisnik.KorisnickoIme = TxtKorisnickoIme.Text;
            //korisnik.Lozinka = TxtLozinka.Text;
            //korisnik.Tip = (Korisnik.tipenum)Enum.Parse(typeof(Korisnik.tipenum), CbTip.Text);
            this.DialogResult = true;
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
                        cmd.Parameters.AddWithValue("@tip", CbTip.Text);
                        cmd.Parameters.AddWithValue("@aktivan", "true");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Korisnik sacuvan!");
                    }
                }
            }
            else if (opcija == EOpcija.IZMENA)
            {
                int id = korisnik.Id;
                //MENJANJE U BAZI
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Korisnici set ime=@ime,prezime=@prezime,email=@email,adresa=@adresa,pol=@pol,korisnickoIme=@korisnickoIme,lozinka=@lozinka,tip=@tip where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@ime", korisnik.Ime);
                        cmd.Parameters.AddWithValue("@prezime", korisnik.Prezime);
                        cmd.Parameters.AddWithValue("@email", korisnik.Email);
                        cmd.Parameters.AddWithValue("@adresa", korisnik.Adresa);
                        cmd.Parameters.AddWithValue("@pol", korisnik.Pol);
                        cmd.Parameters.AddWithValue("@korisnickoIme", korisnik.KorisnickoIme);
                        cmd.Parameters.AddWithValue("@lozinka", korisnik.Lozinka);
                        cmd.Parameters.AddWithValue("@tip", korisnik.Tip);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Korisnik uspesno izmenjen!");
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