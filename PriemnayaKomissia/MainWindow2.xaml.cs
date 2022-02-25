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

namespace PriemnayaKomissia
{
    /// <summary>
    /// Логика взаимодействия для MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
        }

        private void ZayavlenieWinOpen(object sender, RoutedEventArgs e)
        {
            ZayavlenieWin f = new ZayavlenieWin();
            f.Show();
        }

        private void EgeResWinOpen(object sender, RoutedEventArgs e)
        {
            EgeResWin f = new EgeResWin();
            f.Show();
        }

        private void AbiturWinOpen(object sender, RoutedEventArgs e)
        {
            AbiturWin f = new AbiturWin();
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
    }
}
