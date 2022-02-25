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
    public partial class EgeResWin : Window
    {
        Query controller;
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PriemnayaKomissia.Properties.Settings.ConnStr"].ConnectionString);

        public EgeResWin()
        {
            InitializeComponent();
        }

        private void WinLoad(object sender, RoutedEventArgs e)
        {
            con1.Open();
            controller = new Query(ConnectionString.ConnStr);
            grid.ItemsSource = controller.EgeResult_Update().DefaultView;

            SqlCommand command1 = new SqlCommand("SELECT id FROM Zayavlenie", con1);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            SqlDataReader reader1 = command1.ExecuteReader();
            DataTable data1 = new DataTable();
            data1.Columns.Add("id", typeof(string));
            data1.Load(reader1);
            cmProd.DisplayMemberPath = "id";
            cmProd.SelectedValuePath = "id";
            cmProd.ItemsSource = data1.DefaultView;
        }

        private void EdIzmerAdd(object sender, RoutedEventArgs e)
        {
            foreach (object t in grid.ItemsSource)
            {
                DataRowView row = t as DataRowView;
                if (row != null)
                {
                    if (int.Parse(cmProd.SelectedValue.ToString()) == int.Parse(row[1].ToString()))
                    {
                        controller.EgeResult_Delete(int.Parse(cmProd.SelectedValue.ToString()));
                    }
                }
            }
            controller.EgeResult_Add(int.Parse(cmProd.SelectedValue.ToString()), int.Parse(tbEGE1.Text), int.Parse(tbEGE2.Text), int.Parse(tbEGE3.Text));
            MessageBox.Show("Добавлено");
            tbEGE1.Clear();
            tbEGE2.Clear();
            tbEGE3.Clear();
            grid.ItemsSource = controller.EgeResult_Update().DefaultView;
        }
    }
}
