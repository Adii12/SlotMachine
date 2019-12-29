using System;
namespace CurrentPlayer
{
    public class CurrentPlayer
    {
        private string username;
        private double balance;
        static private CurrentPlayer instance = null;
        static public CurrentPlayer getInstance()
        {
            if (instance == null)
            {
                instance = new CurrentPlayer();
            }
            return instance;
        }
        private CurrentPlayer()
        {
            
        }
        public void setBalance(double balance)
        {
            this.balance = balance;
        }
        public void setUsername(string username)
        {
            this.username = username;
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
