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
    public partial class SpecWin : Window
    {
        Query controller;
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PriemnayaKomissia.Properties.Settings.ConnStr"].ConnectionString);
        public SpecWin()
        {
            InitializeComponent();
        }

        private void WinLoad(object sender, RoutedEventArgs e)
        {
            con1.Open();
            controller = new Query(ConnectionString.ConnStr);
            grid.ItemsSource = controller.Special_Update().DefaultView;

            SqlCommand command1 = new SqlCommand("SELECT name FROM Facultet", con1);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            SqlDataReader reader1 = command1.ExecuteReader();
            DataTable data1 = new DataTable();
            data1.Columns.Add("name", typeof(string));
            data1.Load(reader1);
            cmProd.DisplayMemberPath = "name";
            cmProd.SelectedValuePath = "name";
            cmProd.ItemsSource = data1.DefaultView;
        }

        private void EdIzmerAdd(object sender, RoutedEventArgs e)
        {
            string prod_query = "SELECT id FROM Facultet WHERE name ='" + cmProd.SelectedValue.ToString() + "'";
            SqlCommand cmd_prod = new SqlCommand(prod_query, con1);
            string prod_idf = cmd_prod.ExecuteScalar().ToString();
            int prod_id = int.Parse(prod_idf);

            controller.Special_Add(tbName.Text, prod_id, int.Parse(tbCnt.Text.ToString()));
            MessageBox.Show("Добавлено");
            grid.ItemsSource = controller.Special_Update().DefaultView;
        }
    }
}
