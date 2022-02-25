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
    public partial class UsersWin : Window
    {
        Query controller;
        public UsersWin()
        {
            InitializeComponent();
        }

        private void WinLoad(object sender, RoutedEventArgs e)
        {
            controller = new Query(ConnectionString.ConnStr);
            grid.ItemsSource = controller.User_Update().DefaultView;
            grid.Columns[0].Header = "Код";
            grid.Columns[1].Header = "Логин";
            grid.Columns[2].Header = "Пароль";
            grid.Columns[3].Header = "Роль";
        }

        private void AbiturientAdd(object sender, RoutedEventArgs e)
        {
            if (rb1.IsChecked == true)
            {
                controller.User_Add(tbName.Text, tbAddress.Text, "админ");
                rb1.IsChecked = false;
                Clear();

            }
            if (rb2.IsChecked == true)
            {
                controller.User_Add(tbName.Text, tbAddress.Text, "оператор");
                rb2.IsChecked = false;
                Clear();
            }
        }

        private void Clear()
        {
            MessageBox.Show("Добавлено");
            tbAddress.Clear();
            tbName.Clear();
            grid.ItemsSource = controller.User_Update().DefaultView;
        }
    }
}
