using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriemnayaKomissia.Controller
{
    class Query
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dt;

        public Query(string Conn)
        {
            connection = new SqlConnection(Conn);
            dt = new DataTable();
        }

        public DataTable Facultet_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM Facultet", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public void Facultet_Add(string name)
        {
            connection.Open();
            string id_query = "SELECT MAX(id) FROM Facultet";
            SqlCommand cmd = new SqlCommand(id_query, connection);
            string iid = cmd.ExecuteScalar().ToString();
            int id = int.Parse(iid);
            id = id + 1;
            command = new SqlCommand("INSERT INTO Facultet([id], [name])" +
                " Values(@id, @name)", connection);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("name", name);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public DataTable Special_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM zp_spec", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public void Special_Add(string name, int id_facult, int place_cnt)
        {
            connection.Open();
            string id_query = "SELECT MAX(id) FROM Special";
            SqlCommand cmd = new SqlCommand(id_query, connection);
            string iid = cmd.ExecuteScalar().ToString();
            int id = int.Parse(iid);
            id = id + 1;
            command = new SqlCommand("INSERT INTO Special([id], [name], [id_facult], [place_cnt])" +
                " Values(@id, @name, @id_facult, @place_cnt)", connection);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("name", name);
            command.Parameters.AddWithValue("id_facult", id_facult);
            command.Parameters.AddWithValue("place_cnt", place_cnt);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public DataTable Abiturient_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM Abiturient", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public void Abiturient_Add(string fio, string address, string phone)
        {
            connection.Open();
            string id_query = "SELECT MAX(id) FROM Abiturient";
            SqlCommand cmd = new SqlCommand(id_query, connection);
            string iid = cmd.ExecuteScalar().ToString();
            int id = int.Parse(iid);
            id = id + 1;
            command = new SqlCommand("INSERT INTO Abiturient([id], [fio], [address], [phone])" +
                " Values(@id, @fio, @address, @phone)", connection);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("fio", fio);
            command.Parameters.AddWithValue("address", address);
            command.Parameters.AddWithValue("phone", phone);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public DataTable User_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM Users", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public void User_Add(string login, string pass, string role)
        {
            connection.Open();
            string id_query = "SELECT MAX(id) FROM Users";
            SqlCommand cmd = new SqlCommand(id_query, connection);
            string iid = cmd.ExecuteScalar().ToString();
            int id = int.Parse(iid);
            id = id + 1;
            command = new SqlCommand("INSERT INTO Users([id], [login], [pass], [role])" +
                " Values(@id, @login, @pass, @role)", connection);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("login", login);
            command.Parameters.AddWithValue("pass", pass);
            command.Parameters.AddWithValue("role", role);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public DataTable EgeResult_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM zp_egeres", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        
        public void EgeResult_Delete(int id_zyavl)
        {
            connection.Open();

            command = new SqlCommand("DELETE FROM EgeResult WHERE id_zyavl = " + id_zyavl + "", connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void EgeResult_Add(int id_zyavl, int ege1, int ege2, int ege3)
        {
            connection.Open();
            string id_query = "SELECT MAX(id) FROM EgeResult";
            SqlCommand cmd = new SqlCommand(id_query, connection);
            string iid = cmd.ExecuteScalar().ToString();
            int id = int.Parse(iid);
            id = id + 1;
            command = new SqlCommand("INSERT INTO EgeResult([id], [id_zyavl], [ege1], [ege2], [ege3])" +
                " Values(@id, @id_zyavl, @ege1, @ege2, @ege3)", connection);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("id_zyavl", id_zyavl);
            command.Parameters.AddWithValue("ege1", ege1);
            command.Parameters.AddWithValue("ege2", ege2);
            command.Parameters.AddWithValue("ege3", ege3);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public DataTable Zayavlenie_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM zp_zayavlenie", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public void Zayavlenie_Add(int id_abitur, int id_spec)
        {
            connection.Open();
            string id_query = "SELECT MAX(id) FROM Zayavlenie";
            SqlCommand cmd = new SqlCommand(id_query, connection);
            string iid = cmd.ExecuteScalar().ToString();
            int id = int.Parse(iid);
            id = id + 1;
            command = new SqlCommand("INSERT INTO Zayavlenie([id], [id_abitur], [id_spec])" +
                " Values(@id, @id_abitur, @id_spec)", connection);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("id_abitur", id_abitur);
            command.Parameters.AddWithValue("id_spec", id_spec);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public DataTable DopBall_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM zp_dopball", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public void DopBall_Add(int id_vid, int id_abitur, int ball)
        {
            connection.Open();
            string id_query = "SELECT MAX(id) FROM DopBall";
            SqlCommand cmd = new SqlCommand(id_query, connection);
            string iid = cmd.ExecuteScalar().ToString();
            int id = int.Parse(iid);
            id = id + 1;
            command = new SqlCommand("INSERT INTO DopBall([id], [id_vid], [id_abitur], [ball])" +
                " Values(@id, @id_vid,  @id_abitur, @ball)", connection);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("id_vid", id_vid);
            command.Parameters.AddWithValue("id_abitur", id_abitur);
            command.Parameters.AddWithValue("ball", ball);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public DataTable VIdDostizhenie_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM VIdDostizhenie", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public void VIdDostizhenie_Add(string name)
        {
            connection.Open();
            string id_query = "SELECT MAX(id) FROM VIdDostizhenie";
            SqlCommand cmd = new SqlCommand(id_query, connection);
            string iid = cmd.ExecuteScalar().ToString();
            int id = int.Parse(iid);
            id = id + 1;
            command = new SqlCommand("INSERT INTO VIdDostizhenie([id], [name])" +
                " Values(@id, @name)", connection);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("name", name);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public DataTable VidDocument_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM VidDocument", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public void VidDocument_Add(string name)
        {
            connection.Open();
            string id_query = "SELECT MAX(id) FROM VidDocument";
            SqlCommand cmd = new SqlCommand(id_query, connection);
            string iid = cmd.ExecuteScalar().ToString();
            int id = int.Parse(iid);
            id = id + 1;
            command = new SqlCommand("INSERT INTO VidDocument([id], [name])" +
                " Values(@id, @name)", connection);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("name", name);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public DataTable PredostavlDoc_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM zp_predastavldoc", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public void PredostavlDoc_Add(int id_abitur, int id_vidDoc, string docNum)
        {
            connection.Open();
            string id_query = "SELECT MAX(id) FROM PredostavlDoc";
            SqlCommand cmd = new SqlCommand(id_query, connection);
            string iid = cmd.ExecuteScalar().ToString();
            int id = int.Parse(iid);
            id = id + 1;
            command = new SqlCommand("INSERT INTO PredostavlDoc([id], [id_abitur], [id_vidDoc], [docNum])" +
                " Values(@id, @id_abitur, @id_vidDoc, @docNum)", connection);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("id_abitur", id_abitur);
            command.Parameters.AddWithValue("id_vidDoc", id_vidDoc);
            command.Parameters.AddWithValue("docNum", docNum);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable Otchet1_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM View_1", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        public DataTable Otchet2_Update()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM View_2 WHERE Статус = '" + "открыто" + "'", connection);
            dt.Clear();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
    }
}
