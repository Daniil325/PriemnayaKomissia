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
    public partial class FacultWin : Window
    {
        Query controller;
        public FacultWin()
        {
            InitializeComponent();
        }

        private void WinLoad(object sender, RoutedEventArgs e)
        {
            controller = new Query(ConnectionString.ConnStr);
            grid.ItemsSource = controller.Facultet_Update().DefaultView;
            grid.Columns[0].Header = "Код";
            grid.Columns[1].Header = "Название";
        }

        private void FacultetAdd(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Некорректный ввод данных");
            }
            else
            {
                controller.Facultet_Add(tbName.Text);
                MessageBox.Show("Добавлено");
                tbName.Clear();
                grid.ItemsSource = controller.Facultet_Update().DefaultView;
            }
        }
    }
}
