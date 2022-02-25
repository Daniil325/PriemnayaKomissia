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

namespace PriemnayaKomissia
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FacultWinOpen(object sender, RoutedEventArgs e)
        {
            FacultWin f = new FacultWin();
            f.Show();
        }

        private void AbiturWinOpen(object sender, RoutedEventArgs e)
        {
            AbiturWin f = new AbiturWin();
            f.Show();
        }

        private void EgeResWinOpen(object sender, RoutedEventArgs e)
        {
            EgeResWin f = new EgeResWin();
            f.Show(); 
        }

        private void SpecWinOpen(object sender, RoutedEventArgs e)
        {
            SpecWin f = new SpecWin();
            f.Show();
        }

        private void DopBalWinOpen(object sender, RoutedEventArgs e)
        {
            DopBalWin f = new DopBalWin();
            f.Show();
        }

        private void DocWinOpen(object sender, RoutedEventArgs e)
        {
            DocWin f = new DocWin();
            f.Show();
        }

        private void PredostDocWinOpen(object sender, RoutedEventArgs e)
        {
            PredostDocWin f = new PredostDocWin();
            f.Show();
        }

        private void ZayavlenieWinOpen(object sender, RoutedEventArgs e)
        {
            ZayavlenieWin f = new ZayavlenieWin();
            f.Show();
        }

        private void DostizhWinOpen(object sender, RoutedEventArgs e)
        {
            DostizhWin f = new DostizhWin();
            f.Show();
        }

        private void Otchet1WinOpen(object sender, RoutedEventArgs e)
        {
            Otchet1Win f = new Otchet1Win();
            f.Show();
        }

        private void Otchet2WinOpen(object sender, RoutedEventArgs e)
        {
            Otchet2Win f = new Otchet2Win();
            f.Show();
        }

        private void UsersWinOpen(object sender, RoutedEventArgs e)
        {
            UsersWin f = new UsersWin();
            f.Show();
        }
    }
}
