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
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml;

namespace ProjeTyö1
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
 {
        //int _Value = default(int);

        Random rnd = new Random(); // Nopan arvo
        int counter = 0, Health = 100; // Energian arvo
        

        struct sTapahtumat // Hakee tiedot Array.xml dokumentista
        {
            public string Vaihtoehto1, Vaihtoehto2, Vaihtoehto3, Tulos1, Tulos2, Tulos3, Tulos4, Tulos5, Tulos6, Tulos7, Tulos8, Tulos9, Tarina;
        }
        sTapahtumat[] asiat = new sTapahtumat[6];

        public Game()
        {
            InitializeComponent();
            FillArray();
            
        }
        public void FillArray()
        {
            XmlReader reader = XmlReader.Create("Array.xml"); // Avaa xml.reader
            int i = 0;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Tarina") // Hae tarina
                {
                    reader.Read();
                    asiat[i].Tarina = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Vaihtoehto1") // Hae vaihtoehto1
                {
                    reader.Read();
                    asiat[i].Vaihtoehto1 = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Vaihtoehto2") // Hae vaihtoehto2
                {
                    reader.Read();
                    asiat[i].Vaihtoehto2 = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Vaihtoehto3") // Hae vaihtoehto3
                {
                    reader.Read();
                    asiat[i].Vaihtoehto3 = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Tulos1") // Hae negatiivinen tulos vaihtoehto ykköselle
                {
                    reader.Read();
                    asiat[i].Tulos1 = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Tulos2") // Hae neutraali tulos vaihtoehto ykköselle
                {
                    reader.Read();
                    asiat[i].Tulos2 = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Tulos3") // Hae positiivinen tulos vaihtoehto ykköselle
                {
                    reader.Read();
                    asiat[i].Tulos3 = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Tulos4") // Hae negatiivinen tulos vaihtoehto kakkoselle
                {
                    reader.Read();
                    asiat[i].Tulos4 = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Tulos5") // Hae neutraali tulos vaihtoehto kakkoselle
                {
                    reader.Read();
                    asiat[i].Tulos5 = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Tulos6") // Hae positiivinen tulos vaihtoehto kakkoselle
                {
                    reader.Read();
                    asiat[i].Tulos6 = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Tulos7") // Hae negatiivinen tulos vaihtoehto kolmoselle
                {
                    reader.Read();
                    asiat[i].Tulos7 = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Tulos8") // Hae neutraali tulos vaihtoehto kolmoselle
                {
                    reader.Read();
                    asiat[i].Tulos8 = reader.Value;

                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Tulos9") // Hae positiivinen tulos vaihtoehto kolmoselle
                {
                    reader.Read();
                    asiat[i].Tulos9 = reader.Value;
                    i++;
                }

            }
            reader.Close(); // Sulje xml.reader
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            txtEvents.Background = (Brush)bc.ConvertFrom("#DAE5F3");
            border1.Background = (Brush)bc.ConvertFrom("#DAE5F3"); //Tarina textblockin taustaväri
            border2.Background = (Brush)bc.ConvertFrom("#DAE8FA");// btnOption1 taustaväri
            border3.Background = (Brush)bc.ConvertFrom("#819DC0");// btnOption2 taustaväri
            border4.Background = (Brush)bc.ConvertFrom("#ABC0D4");// btnOption3 taustaväri
            lblHealth.Content = "Energy: " + Health;
            btnOption1.Content = asiat[counter].Vaihtoehto1;
            btnOption2.Content = asiat[counter].Vaihtoehto2;
            btnOption3.Content = asiat[counter].Vaihtoehto3;
            txtStory.Text = asiat[counter].Tarina;
            BitmapImage myBitMapImage = new BitmapImage(); // Luodaan uusi bitmapimage
            myBitMapImage.BeginInit();
            //string kuvatiedosto = "sanky.jpg";
            myBitMapImage.UriSource = new Uri("pack://application:,,,/sanky.jpg"); // Source kulkee sovelluksen mukana
            myBitMapImage.DecodePixelWidth = 155;
            myBitMapImage.EndInit();
            imgKuva.Source = myBitMapImage;
           
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e) 
        {
            MainWindow objMainWindow = new MainWindow();
            objMainWindow.Show();
            this.Close(); // Sulkee ikkunan
        }
        int NopanTulokset(int dice) // Aliohjelma määrittää nopalle indexin
        {
            int noppa = 0;
            if (dice >= 1 && dice <= 3) 
            {
                noppa = 0; // Negatiivinen
                Storyboard NoppaHuono = (Storyboard)TryFindResource("NoppaHuonoAnim"); // muuttaa lblDice taustan punaiseksi jos noppa heittää 1-3
                NoppaHuono.Pause();
                NoppaHuono.Begin();
            }
            else if (dice >= 4 && dice <= 7) 
            {
                noppa = 1; // Neutraali
                Storyboard NoppaNeutraali = (Storyboard)TryFindResource("NoppaNeutraaliAnim"); // muuttaa lblDice taustan keltaiseksi jos noppa heittää 4-7
                NoppaNeutraali.Pause();
                NoppaNeutraali.Begin();
            }
            else 
            {
                noppa = 2; // Positiviinen
                Storyboard NoppaHyvä = (Storyboard)TryFindResource("NoppaHyväAnim"); // muuttaa lblDice taustan vihreäksi jos noppa heittää 8-10
                NoppaHyvä.Pause();
                NoppaHyvä.Begin();
            }
            return noppa;
        }



        public void btnDice_Click(object sender, RoutedEventArgs e)
        {
           
            var bc = new BrushConverter();
            int dice = rnd.Next(1, 11);

           
            lblDice.Content = "Dice result: " + dice;
            if (btnOption1.IsChecked == true) // Sijoittaa tuloksen, uuden energiamäärän sekä aiemman valinnan labeleihin/textboxiin kun on valittu vaihtoehto1
            {
                switch (NopanTulokset(dice)) 
                {
                    case 0: txtEvents.Text = (asiat[counter].Tulos1); // Negatiivinen noppatulos
                        Health = HpSysteemi(NopanTulokset(dice), Health, counter);
                        lblEvents.Content = asiat[counter].Vaihtoehto1;
                        break;
                    case 1: txtEvents.Text = (asiat[counter].Tulos2); // Neutraali noppatulos
                        Health = HpSysteemi(NopanTulokset(dice), Health, counter);
                        lblEvents.Content = asiat[counter].Vaihtoehto1;
                        break;
                    case 2: txtEvents.Text = (asiat[counter].Tulos3); // Positiivinen noppatulos
                        Health = HpSysteemi(NopanTulokset(dice), Health, counter);
                        lblEvents.Content = asiat[counter].Vaihtoehto1;
                        break;
                }

            }
            if (btnOption2.IsChecked == true) // Sijoittaa tuloksen, uuden energiamäärän sekä aiemman valinnan labeleihin/textboxiin kun on valittu vaihtoehto2
            {
                switch (NopanTulokset(dice))
                {
                    case 0: txtEvents.Text = (asiat[counter].Tulos4); // Negatiivinen noppatulos
                        Health = HpSysteemi(NopanTulokset(dice), Health, counter);
                        lblEvents.Content = asiat[counter].Vaihtoehto2;
                        break;
                    case 1: txtEvents.Text = (asiat[counter].Tulos5); // Neutraali noppatulos
                        Health = HpSysteemi(NopanTulokset(dice), Health, counter);
                        lblEvents.Content = asiat[counter].Vaihtoehto2;
                        break;
                    case 2: txtEvents.Text = (asiat[counter].Tulos6); // Positiivinen noppatulos
                        Health = HpSysteemi(NopanTulokset(dice), Health, counter);
                        lblEvents.Content = asiat[counter].Vaihtoehto2;
                        break;
                }
            }
            if (btnOption3.IsChecked == true) // Sijoittaa tuloksen, uuden energiamäärän sekä aiemman valinnan labeleihin/textboxiin kun on valittu vaihtoehto3
            {
                switch (NopanTulokset(dice))
                {
                    case 0: txtEvents.Text = (asiat[counter].Tulos7); // Negatiivinen noppatulos
                        Health = HpSysteemi(NopanTulokset(dice), Health, counter);
                        lblEvents.Content = asiat[counter].Vaihtoehto3;
                        break;
                    case 1: txtEvents.Text = (asiat[counter].Tulos8); // Neutraali noppatulos
                        Health = HpSysteemi(NopanTulokset(dice), Health, counter);
                        lblEvents.Content = asiat[counter].Vaihtoehto3;
                        break;
                    case 2: txtEvents.Text = (asiat[counter].Tulos9); // Positiivinen noppatulos
                        Health = HpSysteemi(NopanTulokset(dice), Health, counter);
                        lblEvents.Content = asiat[counter].Vaihtoehto3;
                        break;
                }
            }
            if (Health >= 100)
            {
                Storyboard HpYliSata = (Storyboard)TryFindResource("HpYliSata"); // Muuttaa lblHealthin taustan vihreäksi kun energia on 100 tai enemmän
                HpYliSata.Pause();
                HpYliSata.Begin();
            }
            if (Health < 100 && Health > 0)
            {
                Storyboard HpAlleSata = (Storyboard)TryFindResource("HpAlleSata"); //Muuttaa lblHealthin taustan keltaiseksi kun energia on 100:n ja 0:n välillä
                HpAlleSata.Pause();
                HpAlleSata.Begin();
            }
            if (Health == 0 || Health < 0)
            {
                Storyboard HpNolla = (Storyboard)TryFindResource("HpNolla"); // Muuttaa lblHealthin taustan punaiseksi kun energia on 0 tai vähemmän
                HpNolla.Pause();
                HpNolla.Begin();
            }
            if (counter < 4) // lopettaa kuvien vaihdon kun counter on 4 (peli päättyy)
            {
                BitmapImage myBitMapImage = new BitmapImage();
                myBitMapImage.BeginInit();
                //string kuvatiedosto = @"C:\Users\user\Desktop\vamk simulator\ProjeTyö1\ProjeTyö1\" + counter.ToString() + ".jpg";
                myBitMapImage.UriSource = new Uri("pack://application:,,,/" + counter.ToString() + ".jpg");
                myBitMapImage.DecodePixelWidth = 155;
                imgKuva.Source = myBitMapImage;
                myBitMapImage.EndInit();
            }
            counter++;
            btnOption1.Content = asiat[counter].Vaihtoehto1;
            btnOption2.Content = asiat[counter].Vaihtoehto2;
            btnOption3.Content = asiat[counter].Vaihtoehto3;
            txtStory.Text = asiat[counter].Tarina;
            lblHealth.Content = "Energy: " + Health;
           
            PeliLoppuu(Health,counter); // Kutsuu aliohjelman PeliLoppuu
        }
       
        public int HpSysteemi(int NopanTulokset, int Health, int counter) // Tällä aliohjelmalla määritellään Energian lasku/nousu jokaiselle eri tulokselle
        {
            if (NopanTulokset == 0) // Negatiivinen noppatulos
            {
                if (btnOption1.IsChecked == true) // Vaihtoehto1
                {
                    switch (counter)
                    {
                        case 0: // Ensimmäinen valinta vaihtoehto1, Negatiivinen noppatulos
                            Health = Health - 50; 
                            break;
                        case 1: // Toinen valinta vaihtoehto1, Negatiivinen noppatulos
                            Health = Health - 25;
                            break;
                        case 2: // Kolmas valinta vaihtoehto1, Negatiivinen noppatulos
                            Health = Health - 50;
                            break;
                        case 3: // Neljäs valinta vaihtoehto1, Negatiivinen noppatulos
                            Health = Health - Health;
                            break;
                        case 4: // Viides valinta vaihtoehto1, Negatiivinen noppatulos
                            Health = Health - Health;
                            break;
                    }
                }
                if (btnOption2.IsChecked == true) // Vaihtoehto2
                {
                    switch (counter)
                    {
                        case 0: // Ensimmäinen valinta vaihtoehto2, Negatiivinen noppatulos
                            Health = Health - 50;
                            break;
                        case 1: // Toinen valinta vaihtoehto2, Negatiivinen noppatulos
                            Health = Health - Health;
                            break;
                        case 2: // Kolmas valinta vaihtoehto2, Negatiivinen noppatulos
                            Health = Health - 25;
                            break;
                        case 3: // Neljäs valinta vaihtoehto2, Negatiivinen noppatulos
                            Health = Health - 50;
                            break;
                        case 4: // Viides valinta vaihtoehto2, Negatiivinen noppatulos
                            Health = Health - Health;
                            break;
                    }
                }
                if (btnOption3.IsChecked == true) // Vaihtoehto3
                {
                    switch (counter)
                    {
                        case 0: // Ensimmäinen valinta vaihtoehto3, Negatiivinen noppatulos
                            Health = Health - 50;
                            break;
                        case 1: // Toinen valinta vaihtoehto3, Negatiivinen noppatulos
                            Health = Health - 25;
                            break;
                        case 2: // Kolmas valinta vaihtoehto3, Negatiivinen noppatulos
                            Health = Health - 50;
                            break;
                        case 3: // Neljäs valinta vaihtoehto3, Negatiivinen noppatulos
                            Health = Health - 50;
                            break;
                        case 4: // Viides valinta vaihtoehto3, Negatiivinen noppatulos
                            Health = Health - 50;
                            break;
                    }
                }
                return Health;
            }
            else if (NopanTulokset == 2) // Positiivinen noppatulos
            {
                if (btnOption1.IsChecked == true) // Vaihtoehto1
                {
                    switch (counter)
                    {
                        case 0: // Ensimmäinen valinta vaihtoehto1, Positiivinen noppatulos
                            Health = Health + 50;
                            break;
                        case 1: // Toinen valinta vaihtoehto1, Positiivinen noppatulos
                            Health = Health + 25;
                            break;
                        case 2: // Kolmas valinta vaihtoehto1, Positiivinen noppatulos
                            Health = Health + 50;
                            break;
                        case 3: // Neljäs valinta vaihtoehto1, Positiivinen noppatulos
                            Health = Health + 100;
                            break;
                        case 4: // Viides valinta vaihtoehto1, Positiivinen noppatulos
                            Health = Health - Health;
                            break;
                    }
                }
                    if (btnOption2.IsChecked == true) // Vaihtoehto2
                    {
                        switch (counter)
                        {
                            case 0: // Ensimmäinen valinta vaihtoehto2, Positiivinen noppatulos
                                Health = Health + 50;
                                break;
                            case 1: // Toinen valinta vaihtoehto2, Positiivinen noppatulos
                                Health = Health + 25;
                                break;
                            case 2: // Kolmas valinta vaihtoehto2, Positiivinen noppatulos
                                Health = Health + 25;
                                break;
                            case 3: // Neljäs valinta vaihtoehto2, Positiivinen noppatulos
                                Health = Health + 100;
                                break;
                            // Viidennettä casea ei tarvita koska peli päättyy tähän
                        }

                    }
                    if (btnOption3.IsChecked == true) // Vaihtoehto3
                    {
                        switch (counter)
                        {
                            case 0: // Ensimmäinen valinta vaihtoehto3, Positiivinen noppatulos
                                Health = Health + 50;
                                break;
                            case 1: // Toinen valinta vaihtoehto3, Positiivinen noppatulos
                                Health = Health + 25;
                                break;
                            case 2: // Kolmas valinta vaihtoehto3, Positiivinen noppatulos
                                Health = Health + 50;
                                break;
                            case 3: // Neljäs valinta vaihtoehto3, Positiivinen noppatulos
                                Health = Health + 100;
                                break;
                            // Viidennettä casea ei tarvita koska peli päättyy tähän
                        }
                    }
                
                return Health;
                }
                    
                else //neutraali noppatulos 
                {
                    if (btnOption1.IsChecked == true) // Vaihtoehto1
                    {
                        switch (counter)
                        {
                            case 4: // Viides valinta vaihtoehto1, Neutraali noppatulos, Dark souls ending
                                Health = Health - Health;
                                break;



                        }
                    }
                    if (btnOption2.IsChecked == true) // Vaihtoehto2
                    {
                        switch (counter)
                        {
                            case 3: // Neljäs valinta vaihtoehto2, Neutraali noppatulos, Vieruskaverilunttaus
                                Health = Health - Health;
                                break;
                            case 4: // Viides valinta vaihtoehto2, Neutraali noppatulos
                                Health = Health - 100;
                                break;
                        }
                    }
                    if (btnOption3.IsChecked == true) // Vaihtoehto3
                    {
                        switch (counter)
                        {
                            case 3: // Neljännes valinta vaihtoehto3, Neutraali noppatulos
                                Health = Health - Health;
                                break;
                        }
                    }
                    return Health;
                }
        }
        public void PeliLoppuu(int Health, int counter)
        {
            if (Health <= 0) // Bad ending loppu
            {
                MessageBox.Show("Kaiken kokemasi jälkeen masennuit ja sinulla ei ole enään mitään syytä elää.");
                MainWindow objMainWin = new MainWindow();
                objMainWin.Show();
                this.Close();
            }
            else if (counter == 5 && Health >= 0) // Happy ending loppu
            {
                lblHealth.Content = "Energy: " + Health;
                MessageBox.Show("Selvisit tämän kouluviikon, nähdään taas ensi maanantaina.");
                MainWindow objMainWin = new MainWindow();
                objMainWin.Show();
                this.Close();
            }
           
        }
      
    }

}
