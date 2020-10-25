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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AerodromWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAerodromi_Click(object sender, RoutedEventArgs e)
        {
            AerodromiWindow aerodromiWindow = new AerodromiWindow();
            aerodromiWindow.Show();
        }

        private void BtnLetovi_Click(object sender, RoutedEventArgs e)
        {
            LetoviWindow letoviWindow = new LetoviWindow();
            letoviWindow.Show();
        }

        private void BtnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            KorisniciWindow korisniciWindow = new KorisniciWindow();
            korisniciWindow.Show();
        }

        private void BtnAviokompanije_Click(object sender, RoutedEventArgs e)
        {
            AviokompanijeWindow aviokompanijeWindow = new AviokompanijeWindow();
            aviokompanijeWindow.Show();
        }

        private void BtnAvioni_Click(object sender, RoutedEventArgs e)
        {
            AvioniWindow aviokoniWindow = new AvioniWindow();
            aviokoniWindow.Show();
        }

        private void BtnKarte_Click(object sender, RoutedEventArgs e)
        {
            KarteWindow karteWindow = new KarteWindow();
            karteWindow.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
