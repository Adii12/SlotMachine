﻿/*
 * Init()
 * CloseConnection()
 * InsertUser()
 * SelectAll()
 * AuthenticateUser()
 * UpdateBalance()
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Database {
    public class Database {
        private SQLiteConnection conn = null;

        public void Init() {
            if (!File.Exists("Database.sqlite"))
                SQLiteConnection.CreateFile("Database.sqlite");

            try {
                conn = new SQLiteConnection("Data Source = Database.sqlite; Version = 3");
                conn.Open();
                Debug.WriteLine("aa");
                //WriteLog("Connected to database");
            }
            catch (Exception ex) {
                //WriteLog(ex.ToString()); ;
                return;
            }

            CreateTable();
            CreateWinnersTable();
        }

        public void CloseConnection() {
            if (conn != null) {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
            else {
               // WriteLog("There is no connection with database to close");
            }
        }

        private void CreateTable() {
            string stmt = "CREATE TABLE IF NOT EXISTS Users(ID INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT UNIQUE, Password TEXT, Balance REAL)";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
               // WriteLog(ex.ToString());
            }
        }

        private string CreateHash(string text) {
            byte[] input = System.Text.Encoding.UTF8.GetBytes(text);
            HashAlgorithm cryptoProvider = new SHA256CryptoServiceProvider();

            byte[] hashValue = cryptoProvider.ComputeHash(input);

            return System.Text.Encoding.UTF8.GetString(hashValue);
        }

        public void InsertUser(string username, string password) {
            string HashedPassword = CreateHash(password);
            
            string stmt = "INSERT INTO Users(Username, Password, Balance) VALUES('" + username + "','" + HashedPassword + "', 0.0)";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                //WriteLog(ex.ToString());
            }
        }

        public string SelectAll() {
            string stmt = "SELECT * FROM Users";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);
            SQLiteDataReader reader = null;

            try {
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            string data = "";

            if (reader != null) {
                for (int i = 0; i < reader.FieldCount; ++i) {
                    data += reader.GetName(i) + "  ";
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

            return null;
        }

        public bool AuthenticateUser(string username, string password) {
            string HashedPassword = CreateHash(password);
            string stmt = "SELECT * FROM Users WHERE Username='" + username + "' AND Password='" + HashedPassword + "'";

            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);
            SQLiteDataReader reader = null;

            try {
                reader = cmd.ExecuteReader();
            }catch(Exception ex) {
                //WriteLog(ex.ToString());
            }

            string data = "not found";

            if (reader != null) {
                while (reader.Read()) {
                    data += reader.GetInt32(0).ToString() + " ";
                    data += reader.GetString(1) + " ";
                    data += reader.GetString(2) + " ";
                    data += reader.GetDouble(3) + " ";
                    data += "\n";
                }
                reader.Close();
            }

            if (data != "not found")
                return true;
            else
                return false;
        }

        public void UpdateBalance(string username, double new_balance, double old_balance) {
            double final_balance = new_balance + old_balance;
            
            string stmt="UPDATE Users " +
                        "SET Balance="+final_balance+
                        " WHERE Username='"+username+"'";

            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }catch(Exception ex) {
                //WriteLog(ex.ToString());
            }
        }
        
        //find user by username to check if there are no duplicates when inserting new account
       public bool FindUser(string username) {
            string stmt = "SELECT * FROM Users WHERE Username='"+username+"'";

            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);
            SQLiteDataReader reader = null;

            try {
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) {
                //WriteLog(ex.ToString());
            }

            string data = "not found";

            if (reader != null) {
                while (reader.Read()) {
                    data += reader.GetInt32(0).ToString() + " ";
                    data += reader.GetString(1) + " ";
                    data += reader.GetString(2) + " ";
                    data += reader.GetDouble(3) + " ";
                    data += "\n";
                }
                reader.Close();
            }

            if (data != "not found")
                return true;
            else
                return false;
        }


        private void CreateWinnersTable() {
            string stmt = "CREATE TABLE IF NOT EXISTS Winners(ID INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT, Winnings INTEGER)";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }catch(Exception ex) {

            }
        }

        public void InsertWinner(string username, int winnings) {
            string stmt = "INSERT INTO Winners(Username, Winnings) VALUES('" + username + "'," + winnings + ")";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);

            try {
                cmd.ExecuteNonQuery();
            }catch(Exception ex) {

            }
        }

        public string SelectWinners() {
            string stmt = "SELECT * FROM Winners ORDER BY Winnings DESC";
            SQLiteCommand cmd = new SQLiteCommand(stmt, conn);
            SQLiteDataReader reader = null;

            try {
                reader = cmd.ExecuteReader();
            }catch(Exception ex) {

            }

            string data = " ";

            if (reader != null) {
                while (reader.Read()) {
                    data += reader.GetInt32(0).ToString()+ " ";
                    data += reader.GetString(1) + " ";
                    data += reader.GetInt32(2).ToString() + " ";
                    data += "\n";
                }
                reader.Close();
                
                return data;
            }

            return null;
        }

     /*   private void WriteLog(string text) {
            System.IO.FileStream LogFile = new FileStream(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString() + "\\Logs.txt", FileMode.OpenOrCreate);
            string TimeStamp = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");

            TextWriterTraceListener txtListener = new TextWriterTraceListener(LogFile);
            Trace.Listeners.Add(txtListener);
            Trace.AutoFlush = true;
            Trace.WriteLine(TimeStamp + "\t" + text);

            LogFile.Dispose();
            LogFile.Close();
            
        }*/
    }
}