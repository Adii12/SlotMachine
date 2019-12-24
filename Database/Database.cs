using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Database
{
    public class Database
    {
        private SQLiteConnection conn=null;

        public void Init() {
            if (!File.Exists("Database.sqlite"))
                SQLiteConnection.CreateFile("Database.sqlite");

            try {
                conn = new SQLiteConnection("Data Source = Database.sqlite; Version = 3");
                conn.Open();
                //debug -> connected succesfully
            }catch(Exception ex) {
                //debug -> ex.toString();
                return;
            }

            CreateTable();
        }

        public void CloseConnection() {
            if (conn != null) {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
            else { 
                //debug -> there is no connection to close 
            }
        }

        private void CreateTable() {
            string stmt = "CREATE TABLE IF NOT EXISTS Users(ID INT PRIMARY KEY AUTOINCREMENT, Username TEXT, Password Text)";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) {
                //debug - ex.ToString();
            }
        }

        public void InsertUser(string username, string password) {
            string stmt = "INSERT INTO Users(Username, Password) VALUES('" + username + "','" + password + "')";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) {
                //debug - ex.ToString();
            }
        }

        public string SelectAll() {
            string stmt = "SELECT *  FROM Users";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            SQLiteDataReader reader = null;

            try {
                cmd.ExecuteReader();
            }
            catch(Exception ex) {
                //debug - ex.ToString();
            }

            string data = "";

            for(int i = 0; i < reader.FieldCount; ++i) {
                data += reader.GetName(i)+"    ";
            }

            data += "\n";

            while (reader.Read()) {
                data += reader.GetInt32(0).ToString() + " ";
                data += reader.GetString(1) + " ";
                data += reader.GetString(2) + " ";
                data += "\n";
            }
            reader.Close();

            return data;
        }
    }
}
