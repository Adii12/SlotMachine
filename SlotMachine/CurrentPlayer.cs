using System;
namespace CurrentPlayer
{
    public class CurrentPlayer
    {
        private string username;
        private double balance;
        public CurrentPlayer(string username, double balance)
        {
            this->username = username;
            this->balance = balance;
        }
        public void setBalance(double balance)
        {
            this->balance = balance;
        }
        public string getUsername()
        {
            return username;
        }
        public double getBalance()
        {
            return balance;
        }
    }
}
