using PriemnayaKomissia.Controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    public partial class ZayavlenieWin : Window
    {
        Query controller;
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PriemnayaKomissia.Properties.Settings.ConnStr"].ConnectionString);

        public ZayavlenieWin()
        {
            InitializeComponent();
        }

        private void WinLoad(object sender, RoutedEventArgs e)
        {
            con1.Open();
            controller = new Query(ConnectionString.ConnStr);
            grid.ItemsSource = controller.Zayavlenie_Update().DefaultView;

            SqlCommand command1 = new SqlCommand("SELECT fio FROM Abiturient", con1);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            SqlDataReader reader1 = command1.ExecuteReader();
            DataTable data1 = new DataTable();
            data1.Columns.Add("fio", typeof(string));
            data1.Load(reader1);
            cmClient.DisplayMemberPath = "fio";
            cmClient.SelectedValuePath = "fio";
            cmClient.ItemsSource = data1.DefaultView;

            SqlCommand command2 = new SqlCommand("SELECT name FROM Special", con1);
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            SqlDataReader reader2 = command2.ExecuteReader();
            DataTable data2 = new DataTable();
            data2.Columns.Add("name", typeof(string));
            data2.Load(reader2);
            cmProd.DisplayMemberPath = "name";
            cmProd.SelectedValuePath = "name";
            cmProd.ItemsSource = data2.DefaultView;
        }

        private void EdIzmerAdd(object sender, RoutedEventArgs e)
        {
            string prod_query = "SELECT id FROM Special WHERE name ='" + cmProd.SelectedValue.ToString() + "'";
            SqlCommand cmd_prod = new SqlCommand(prod_query, con1);
            string prod_idf = cmd_prod.ExecuteScalar().ToString();
            int prod_id = int.Parse(prod_idf);

            string fio_query = "SELECT id FROM Abiturient WHERE fio ='" + cmClient.SelectedValue.ToString() + "'";
            SqlCommand fio_cmd = new SqlCommand(fio_query, con1);
            string fio_idf = fio_cmd.ExecuteScalar().ToString();
            int fio_id = int.Parse(fio_idf);

            controller.Zayavlenie_Add(fio_id, prod_id);
            MessageBox.Show("Добавлено");
            grid.ItemsSource = controller.Zayavlenie_Update().DefaultView;
        }
    }
}
