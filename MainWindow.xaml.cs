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

namespace ProjeTyö1
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

        private void btnTutorial_Click(object sender, RoutedEventArgs e)
        {
            Tutorial objTutorial = new Tutorial();
            objTutorial.Show();
            this.Close();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            EnterName objNimi = new EnterName();
            objNimi.Show();
            this.Close();
        }
    }

}
