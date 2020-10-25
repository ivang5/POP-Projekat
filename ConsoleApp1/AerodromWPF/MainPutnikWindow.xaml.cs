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
    /// Interaction logic for MainPutnikWindow.xaml
    /// </summary>
    public partial class MainPutnikWindow : Window
    {
        Korisnik ulogovaniKorisnik = Data.Instance.UlogovanKorisnik;

        public MainPutnikWindow()
        {
            InitializeComponent();
        }

        private void BtnLetovi_Click(object sender, RoutedEventArgs e)
        {
            LetoviPutnikWindow letoviPutnikWindow = new LetoviPutnikWindow();
            letoviPutnikWindow.Show();
        }

        private void BtnKarte_Click(object sender, RoutedEventArgs e)
        {
            KartePutnikWindow kartePutnikWindow = new KartePutnikWindow();
            kartePutnikWindow.Show();
        }

        private void BtnProfil_Click(object sender, RoutedEventArgs e)
        {
            AddNEditPutnikWindow editPutnik = new AddNEditPutnikWindow(ulogovaniKorisnik, AddNEditPutnikWindow.EOpcija.IZMENA);
            editPutnik.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
