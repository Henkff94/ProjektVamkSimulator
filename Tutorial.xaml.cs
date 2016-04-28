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

namespace ProjeTyö1
{
    /// <summary>
    /// Interaction logic for Tutorial.xaml
    /// </summary>
    public partial class Tutorial : Window
    {
        public Tutorial()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWin = new MainWindow();
            objMainWin.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtTutorial.Text = ("Peli on tehty mahdollisimman helpoksi. Tarvitset vain kirjoittaa nimesi ja painaa enteriä ja sen jälkeen peli on Click & Play. Peli päättyy jos energiasi laskee nollaan tai selviät kouluviikon haasteista.");
        }
    }
}
