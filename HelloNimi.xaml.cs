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
    /// Interaction logic for HelloNimi.xaml
    /// </summary>
    public partial class HelloNimi : Window
    {
        string value;
        public HelloNimi(string _value)
        {
            InitializeComponent();
            value = _value;
        }

        private void btnContinue2_Click(object sender, RoutedEventArgs e)
        {
            Game peli = new Game();
            peli.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtHelloNimi.Text = ("Pienen mietiskelemisen jälkeen muistat, että nimesi on: " + value + ". Vedät peiton päälle ja nukahdat...");
        }
    }
}
