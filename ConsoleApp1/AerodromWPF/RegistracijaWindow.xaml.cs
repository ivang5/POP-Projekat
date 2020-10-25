using AerodromWPF.Database;
using AerodromWPF.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RegistracijaWindow.xaml
    /// </summary>
    public partial class RegistracijaWindow : Window
    {

        public enum EOpcija { DODAVANJE, IZMENA }
        private EOpcija opcija;
        private Korisnik korisnik;
        private Korisnik noviKorisnik;

        public RegistracijaWindow(Korisnik korisnik, EOpcija opcija = EOpcija.DODAVANJE)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            this.opcija = opcija;

            CbPol.Items.Add("Musko");
            CbPol.Items.Add("Zensko");
            CbTip.Items.Add("Putnik");

            this.DataContext = korisnik;
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {

            this.DataContext = korisnik;
            this.DialogResult = true;
            if (opcija == EOpcija.DODAVANJE)
            {
                Data.Instance.Korisnici.Add(korisnik);
            }
            this.Close();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
