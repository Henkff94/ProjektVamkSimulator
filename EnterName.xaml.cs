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
    /// Interaction logic for EnterName.xaml
    /// </summary>
    public partial class EnterName : Window
    {
        public EnterName()
        {
            InitializeComponent();
        }
        // Textboxiin kirjoitettu max 10 merkkiä siirretään HelloNimi Windowiin, määritelty MaxLength="10"

        private void txtNimi_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.Key == Key.Return || e.Key == Key.Enter)
                {
                    string value = txtNimi.Text;
                    HelloNimi Nimi = new HelloNimi(value);
                    Nimi.Show();
                    this.Close();
                }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtAlkuTeksti.Text = ("Tervehdys opiskelija! Heräät keskellä yötä ilman mitään muistikuvaa. Sinun pitäisi lähteä aamulla Vaasan ammattikorkeakouluun ja olet unohtanut nimesi. Mikä on nimesi? (10 merkkiä max) Paina enter jatkaaksesi");
        }
    }
}
