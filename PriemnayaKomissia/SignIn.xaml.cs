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
    public partial class SignIn : Window
    {
        Query controller;
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PriemnayaKomissia.Properties.Settings.ConnStr"].ConnectionString);

        public SignIn()
        {
            InitializeComponent();
        }

        private void WinLoad(object sender, RoutedEventArgs e)
        {
            con1.Open();
            controller = new Query(ConnectionString.ConnStr);

            SqlCommand command1 = new SqlCommand("SELECT login FROM Users", con1);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            SqlDataReader reader1 = command1.ExecuteReader();
            DataTable data1 = new DataTable();
            data1.Columns.Add("login", typeof(string));
            data1.Load(reader1);
            cmFio.DisplayMemberPath = "login";
            cmFio.SelectedValuePath = "login";
            cmFio.ItemsSource = data1.DefaultView;
        }

        private void SignInUser(object sender, RoutedEventArgs e)
        {
            string query = "SELECT role FROM Users WHERE login = '" + cmFio.SelectedValue.ToString() + "' AND pass = '" + tbPassword.Text + "'";
            SqlCommand cmd_ysl = new SqlCommand(query, con1);
            string ysl_id;
            if (cmd_ysl.ExecuteScalar() == null)
            {
                MessageBox.Show("Повторите попытку");
            }
            else
            {
                string ysl_idf = cmd_ysl.ExecuteScalar().ToString();
                ysl_id = ysl_idf.ToString();
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE login = '" + cmFio.SelectedValue.ToString() + "' AND pass = '" + tbPassword.Text + "'", con1);
                adapter.SelectCommand = command;
                adapter.Fill(dt);

                string query1 = "SELECT id FROM Users WHERE ((login = '" + cmFio.SelectedValue.ToString() + "') AND (pass = '" + tbPassword.Text + "'))";
                SqlCommand cmd_ysl1 = new SqlCommand(query1, con1);
                string ysl_idf1 = cmd_ysl1.ExecuteScalar().ToString();
                int idd = int.Parse(ysl_idf1);

                if ((dt.Rows.Count > 0))
                {
                    if (ysl_id == "админ                                             ")
                    {
                        MainWindow mainForm = new MainWindow();
                        mainForm.Show();
                        this.Close();
                    }

                    if (ysl_id == "оператор                                          ")
                    {
                        MainWindow2 mainForm = new MainWindow2();
                        mainForm.Show();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Повторите попытку");
                }
            }
        }
    }
}