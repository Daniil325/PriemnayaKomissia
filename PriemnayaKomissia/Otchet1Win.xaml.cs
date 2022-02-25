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
using Excel = Microsoft.Office.Interop.Excel;

namespace PriemnayaKomissia
{
    public partial class Otchet1Win : Window
    {
        Query controller;
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PriemnayaKomissia.Properties.Settings.ConnStr"].ConnectionString);

        public Otchet1Win()
        {
            InitializeComponent();
        }

        private void WinLoad(object sender, RoutedEventArgs e)
        {
            con1.Open();
            controller = new Query(ConnectionString.ConnStr);
            grid.ItemsSource = controller.Otchet1_Update().DefaultView;

            SqlCommand command1 = new SqlCommand("SELECT name FROM Special", con1);
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
            string query = "SELECT * FROM View_1 WHERE Специальность = '"+ cmProd.SelectedValue.ToString() +"'";
            SqlDataAdapter command = new SqlDataAdapter(query, con1);
            System.Data.DataTable dt = new System.Data.DataTable();
            command.Fill(dt);
            grid.ItemsSource = dt.DefaultView;
        }

        private void Exc(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet wsh = (Excel.Worksheet)workbook.Sheets[1];

            for (int i = 1; i < grid.Columns.Count + 1; i++)
            {
                wsh.Cells[2, i] = grid.Columns[i - 1].Header;
            }

            for (int i = 0; i <= grid.Columns.Count - 1; i++)
            {
                for (int j = 0; j <= grid.Items.Count - 1; j++)
                {
                    TextBlock b = grid.Columns[i].GetCellContent(grid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)wsh.Cells[j + 3, i + 1];
                    myRange.Value2 = b.Text.Trim();
                }
            }

            wsh.Cells[1, 1] = "Конкурс на специальность";

            wsh.Cells[2, 2].CurrentRegion.Borders.LineStyle = Excel.XlLineStyle.xlContinuous; //границы
            wsh.Rows[2].Font.Bold = true; //вся 2-я строка становится Жирным шрифтом
            wsh.Rows[1].Font.Bold = true; //вся 1-я строка становится Жирным шрифтом
            wsh.Rows[1].Style.HorizontalAlignment = HorizontalAlignment.Center; //горизонтальное выравнивание по центру
            wsh.Range["A:H"].EntireColumn.AutoFit(); //автоподбор по ширине столбцов
            excel.Visible = true;
        }
    }
}
