using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfAppSnooker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Versenyzo> versenyzok = new List<Versenyzo>();
        public MainWindow()
        {
            InitializeComponent();
         

       string [] readVersenyzo = File.ReadAllLines("snooker.txt");
            for (int i = 1; i < readVersenyzo.Length; i++)
            {
                string [] item = readVersenyzo[i].Split(';');
                Versenyzo versenyzo = new Versenyzo(Convert.ToInt32(item[0]), item[1], item[2], Convert.ToInt32(item[3]));
                versenyzok.Add(versenyzo);
            }


            
//----------------------------------------------------------------------------------------------------

        /*    versenyzok = LoadFromCSV("snooker.txt");
            dgTablazat.ItemsSource = versenyzok;
            cbOrszag.ItemsSource = versenyzok.Select(x => x.Orszag).Distinct().OrderBy(x => x);
            cbOrszag.SelectedIndex = 0;  */
        }

    /*    private List<Versenyzo>? LoadFromCSV(string fileName)
        {
            var newList = new List<Versenyzo>();
            foreach (var CSV_line in File.ReadAllLines(fileName).Skip(1))
            {
                newList.Add(new Versenyzo(CSV_line));
            }
            return newList;
        }*/
//--------------------------------------------------------------------------------------------------------
        private void btnF3_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show($"3. feladat: A világranglistán {versenyzok.Count} versenyző szerepel");
        }

        private void btnF4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"4. feladat: A versenyzők átlagosan {versenyzok.Average(x => x.Nyeremeny):f2} fontot kerestek");
        }

        private void btnF5_Click(object sender, RoutedEventArgs e)  // legördülő menü: országok listája
        {
            //string orszagNeve = txtOrszag.Text;
                  string orszagNeve = cbOrszag.SelectedItem.ToString();
                  MessageBox.Show($"5. feladat: A legjobban kereső {orszagNeve} versenyző adatait láthatja!");

                  Versenyzo? keresettVersenyzo = versenyzok.Where(x => x.Orszag == orszagNeve).MaxBy(x => x.Nyeremeny);
                  //Versenyzo? keresettVersenyzo = versenyzokListaja.Where(x => x.Orszag == txtOrszag.Text).OrderBy(x => x.Nyeremeny).Last();
                  lblHelyezes.Content = keresettVersenyzo.Helyezes;
                  lblNev.Content = keresettVersenyzo.Nev;
                  lblOrszag.Content = keresettVersenyzo.Orszag;
                  lblNyeremeny.Content = $"{keresettVersenyzo.Nyeremeny * int.Parse(txtArfolyam.Text):n0} Ft";
                   

        }

        private void btnF6_Click(object sender, RoutedEventArgs e)
        {
            string seged = versenyzok.Any(x => x.Orszag == txtVanIlyenOrszag.Text) ? "Van" : "Nincs";
            MessageBox.Show($"6. feladat: {seged} versenyző a következő országból : {txtVanIlyenOrszag.Text}");

        }

        private void btnF7_Click(object sender, RoutedEventArgs e)
        {
            lbStatisztika.Items.Clear();
            lbStatisztika.Items.Add($"7. feladat: Statisztika:");
            lbStatisztika.Items.Add($"Minimum : {sliMinLetszam.Value} fő");
            foreach (var csoport in versenyzok.GroupBy(x => x.Orszag))
            {
                if (csoport.Count() >= sliMinLetszam.Value)
                {
                    lbStatisztika.Items.Add($"{csoport.Key} - {csoport.Count()} fő");
                }
            }


        }
    }
}

