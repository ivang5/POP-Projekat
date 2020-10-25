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
    /// Interaction logic for AddNEditLet.xaml
    /// </summary>
    public partial class AddNEditLet : Window
    {
        public enum EOpcija { DODAVANJE, IZMENA }
        private EOpcija opcija;
        private Let let;
        private Let noviLet;

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public AddNEditLet(Let let, EOpcija opcija = EOpcija.DODAVANJE)
        {
            InitializeComponent();
            this.let = let;
            this.opcija = opcija;

            this.DataContext = let;
            //TxtSifra.Text = let.Sifra;
            //TxtDestinacija.Text = let.Destinacija;
            //TxtOdrediste.Text = let.Odrediste;
            //TxtVremePolaska.Text = let.VremePolaska.ToString();
            //TxtVremeDolaska.Text = let.VremeDolaska.ToString();
            //TxtCena.Text = let.Cena.ToString();
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {

            this.DataContext = let;
            //let.Sifra = TxtSifra.Text;
            //let.Destinacija = TxtDestinacija.Text;
            //let.Odrediste = TxtOdrediste.Text;
            //let.VremePolaska = Convert.ToDateTime(TxtVremePolaska.Text);
            //let.VremeDolaska = Convert.ToDateTime(TxtVremeDolaska.Text);
            //let.Cena = Convert.ToDouble(TxtCena.Text);

            this.DialogResult = true;
            if (opcija == EOpcija.DODAVANJE)
            {
                Data.Instance.Letovi.Add(let);
                // UNOS U BAZU
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "insert into Letovi ([sifra], [pilot], [brojLeta], [destinacija], [odrediste], [vremePolaska], [vremeDolaska], [cena], [aktivan]) values(@sifra,@pilot,@brojLeta,@destinacija,@odrediste,@vremePolaska,@vremeDolaska,@cena,@aktivan)";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sifra", TxtSifra.Text);
                        cmd.Parameters.AddWithValue("@pilot", TxtPilot.Text);
                        cmd.Parameters.AddWithValue("@brojLeta", TxtBrojLeta.Text);
                        cmd.Parameters.AddWithValue("@destinacija", TxtDestinacija.Text);
                        cmd.Parameters.AddWithValue("@odrediste", TxtOdrediste.Text);
                        cmd.Parameters.AddWithValue("@vremePolaska", TxtVremePolaska.Text);
                        cmd.Parameters.AddWithValue("@vremeDolaska", TxtVremeDolaska.Text);
                        cmd.Parameters.AddWithValue("@cena", TxtCena.Text);
                        cmd.Parameters.AddWithValue("@aktivan", "true");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Let sacuvan!");
                    }
                }
                Data.Instance.UcitajSveLetove();
            }
            else if (opcija == EOpcija.IZMENA)
            {
                int id = let.Id;
                //MENJANJE U BAZI
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Letovi set sifra=@sifra,pilot=@pilot,brojLeta=@brojLeta,odrediste=@odrediste,destinacija=@destinacija,vremePolaska=@vremePolaska,vremeDolaska=@vremeDolaska,cena=@cena where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@sifra", TxtSifra.Text);
                        cmd.Parameters.AddWithValue("@pilot", TxtPilot.Text);
                        cmd.Parameters.AddWithValue("@brojLeta", let.BrojLeta);
                        cmd.Parameters.AddWithValue("@destinacija", let.Destinacija);
                        cmd.Parameters.AddWithValue("@odrediste", let.Odrediste);                        
                        cmd.Parameters.AddWithValue("@vremePolaska", TxtVremePolaska.Text);
                        cmd.Parameters.AddWithValue("@vremeDolaska", TxtVremeDolaska.Text);
                        cmd.Parameters.AddWithValue("@cena", let.Cena);
                        cmd.Parameters.AddWithValue("@aktivan", "true");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Let uspesno izmenjen!");
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
