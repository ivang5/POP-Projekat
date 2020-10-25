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
    /// Interaction logic for KartePutnikWindow.xaml
    /// </summary>
    public partial class KartePutnikWindow : Window
    {
        

        public KartePutnikWindow()
        {
            InitializeComponent();
            Data.Instance.UcitajSvePutnikKarte();
            DGKarte.ItemsSource = Data.Instance.PutnikKarte;

            DGKarte.IsSynchronizedWithCurrentItem = true;

            DGKarte.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Data.Instance.PutnikKarte.Clear();
            this.Close();
        }
    }
}
