using System;
using System.Collections.Generic;

namespace ExceptionHandling
{
    class Mail
    {
        private string loggedInUser;
        private string loggedPassword; 
        private List<Message> messages;
        private List<(string, string)> accounts;

        public Mail()
        {
            messages = new List<Message>(); 
            accounts = new List<(string, string)> ();
        }

        public void NewAccount(string username, string password)
        {
            foreach (var (existingUsername, _) in accounts) {
                if (existingUsername == username)
                {
                    throw new Exception("Account already existed");
                }
            }

            accounts.Add((username, password));
            Console.WriteLine("Account created");

        }

        public bool Login(string username, string password)
        {
            if (username == null || password == null)
            {
                throw new Exception("Invalid username or password");
            }

           
            
                loggedInUser = username;
                loggedPassword = password; 
                return true;
           
        }

        public void Logout()
        {
            loggedInUser = null;
            loggedPassword = null; 
             
        }

        public void SendMessage(string recipient, string message)
        {
            if (loggedInUser == null || loggedPassword == null)
            {
                throw new Exception("Not logged in");
            }

           
            string senderUsername = loggedInUser; 

           
            Message newMessage = new Message(senderUsername, recipient, message);
           

          
            
            messages.Add(newMessage);
        }

        public List<Message> GetInbox()
        {
            if (loggedInUser == null || loggedPassword == null)
            {
                throw new Exception("Not logged in");
            }

            
            return messages;
        }
    }

    public class Message
    {
        public Message(string sender, string recipient, string message)
        {
            Sender = sender;
            Recipient = recipient;
            MessageContent = message; 
        }

        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string MessageContent { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Mail mail = new Mail();
            mail.NewAccount("yiğit", "200"); 
            mail.NewAccount("anna", "910"); 
            mail.Login("anna", "910");
            mail.SendMessage("yiğit", "hej");
            mail.Logout();
            mail.Login("yiğit", "200");
            List<Message> inbox = mail.GetInbox();

            
            foreach (Message message in inbox)
            {
                Console.WriteLine($"From: {message.Sender}, To: {message.Recipient}, Message: {message.MessageContent}");
            }
            
        }
    }
}
