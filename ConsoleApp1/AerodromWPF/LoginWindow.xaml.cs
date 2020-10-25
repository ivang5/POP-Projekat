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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            Korisnik noviKorisnik = new Korisnik();
            AddNEditPutnikWindow few = new AddNEditPutnikWindow(noviKorisnik);
            bool? rez = few.ShowDialog();
        }

        private void BtnLetovi_Click(object sender, RoutedEventArgs e)
        {
            LetoviWindow letoviWindow = new LetoviWindow();
            letoviWindow.Show();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string korIme = TxtKorisnickoIme.Text;
            string korLozinka = TxtLoznika.Text;
            bool pronadjenKor = false;
            string tipKorisnika = "nista";
            Data.Instance.UcitajSveKorisnike();
            //foreach (Korisnik korisnik in Data.Instance.Korisnici)
                //MessageBox.Show(korisnik.korisnickoIme + " " + korisnik.lozinka);
            foreach (Korisnik korisnik in Data.Instance.Korisnici)
            {
                if (korIme.Equals(korisnik.korisnickoIme.Trim()) && korLozinka.Equals(korisnik.lozinka.Trim()))
                {
                    pronadjenKor = true;
                    Data.Instance.UlogovanKorisnik = korisnik;
                    if (korisnik.Tip.ToString().Equals("Admin"))
                    {
                        tipKorisnika = "Admin";
                    }
                    else if (korisnik.Tip.ToString().Equals("Putnik"))
                    {
                        tipKorisnika = "Putnik";
                    }
                }

            }
            if (pronadjenKor == true)
            {
                if (tipKorisnika.Equals("Admin"))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else if (tipKorisnika.Equals("Putnik"))
                {
                    MainPutnikWindow mainPutnikWindow = new MainPutnikWindow();
                    mainPutnikWindow.Show();
                }
            }

            else if (pronadjenKor == false)
            { 
                MessageBox.Show("Niste uneli validne podatke!");
            }
            
        }
    }
}
