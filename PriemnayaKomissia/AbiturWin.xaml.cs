using PriemnayaKomissia.Controller;
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
    public partial class AbiturWin : Window
    {
        Query controller;
        public AbiturWin()
        {
            InitializeComponent();
        }

        private void WinLoad(object sender, RoutedEventArgs e)
        {
            controller = new Query(ConnectionString.ConnStr);
            grid.ItemsSource = controller.Abiturient_Update().DefaultView;
            grid.Columns[0].Header = "Код";
            grid.Columns[1].Header = "ФИО";
            grid.Columns[2].Header = "Адрес";
            grid.Columns[3].Header = "Телефон";
        }

        private void AbiturientAdd(object sender, RoutedEventArgs e)
        {
            if ((tbName.Text.Trim().Length == 0) || (tbAddress.Text.Trim().Length == 0) || (tbPhone.Text.Trim().Length == 0))
            {
                MessageBox.Show("Некорректный ввод данных");
            }
            else
            {
                controller.Abiturient_Add(tbName.Text, tbAddress.Text, tbPhone.Text);
                MessageBox.Show("Добавлено");
                tbName.Clear();
                tbAddress.Clear();
                tbPhone.Clear();
                grid.ItemsSource = controller.Abiturient_Update().DefaultView;
            }
        }
    }
}
