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
    /// Interaction logic for SedistaWindow.xaml
    /// </summary>
    public partial class SedistaWindow : Window
    {
        public SedistaWindow()
        {
            InitializeComponent();
            DGSedista.ItemsSource = Data.Instance.SedistaAvion;
            DGSedista.IsSynchronizedWithCurrentItem = true;
            DGSedista.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            DGSedista.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Data.Instance.SedistaAvion.Clear();
            this.Close();
        }
    }
}
