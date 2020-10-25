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
    /// Interaction logic for AddNEditAvion.xaml
    /// </summary>
    public partial class AddNEditAvion : Window
    {
        public enum EOpcija { DODAVANJE, IZMENA }
        private EOpcija opcija;
        private Avion avion;
        private Avion noviAvion;

        string sql = null;
        public const String CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pecar\Desktop\ja\pop-2018-sf-30-2017\ConsoleApp1\AerodromWPF\Database.mdf;Integrated Security=True";

        public AddNEditAvion(Avion avion, EOpcija opcija = EOpcija.DODAVANJE)
        {
            InitializeComponent();
            this.avion = avion;
            this.opcija = opcija;

            this.DataContext = avion;
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = avion;
            this.DialogResult = true;
            if (opcija == EOpcija.DODAVANJE)
            {
                Data.Instance.Avioni.Add(avion);
                //UNOS U BAZU
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "insert into Avioni ([brojLeta], [sedistaBiznis], [sedistaEkonomska], [nazivAviokompanije], [aktivan]) values(@brojLeta,@sedistaBiznis,@sedistaEkonomska,@nazivAviokompanije,@aktivan)";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@brojLeta", TxtBrojLeta.Text);
                        cmd.Parameters.AddWithValue("@sedistaBiznis", TxtSedistaBiznis.Text);
                        cmd.Parameters.AddWithValue("@sedistaEkonomska", TxtSedistaEkonomska.Text);
                        cmd.Parameters.AddWithValue("@nazivAviokompanije", TxtNazivAviokompanije.Text);
                        cmd.Parameters.AddWithValue("@aktivan", "true");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Avion sacuvan!");
                    }
                }
                Data.Instance.UcitajSveAvione();
            }
            else if (opcija == EOpcija.IZMENA)
            {
                int id = avion.Id;
                //MENJANJE U BAZI
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    sql = "update Avioni set brojLeta=@brojLeta,sedistaBiznis=@sedistaBiznis,sedistaEkonomska=@sedistaEkonomska,nazivAviokompanije=@nazivAviokompanije where id=@id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@brojLeta", avion.BrojLeta);
                        cmd.Parameters.AddWithValue("@sedistaBiznis", avion.SedistaBiznis);
                        cmd.Parameters.AddWithValue("@sedistaEkonomska", avion.SedistaEkonomska);
                        cmd.Parameters.AddWithValue("@nazivAviokompanije", avion.NazivAviokompanije);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Avion uspesno izmenjen!");
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
