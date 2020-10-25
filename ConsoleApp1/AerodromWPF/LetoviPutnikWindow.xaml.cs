using AerodromWPF.Database;
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
    /// Interaction logic for LetoviPutnikWindow.xaml
    /// </summary>
    public partial class LetoviPutnikWindow : Window
    {
        public LetoviPutnikWindow()
        {
            InitializeComponent();
            DGLetovi.ItemsSource = Data.Instance.Letovi;
            DGLetovi.IsSynchronizedWithCurrentItem = true;

            DGLetovi.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            DGLetovi.SelectedIndex = -1;
        }

        private bool SelektovaniLet()
        {
            if (DGLetovi.SelectedIndex == -1)
            {
                MessageBox.Show("Nije selektovan nijedan let!");
                return true;
            }
            else
                return false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
