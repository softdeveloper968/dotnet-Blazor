using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
    public class EmailViewModel
    {
        public string Receiver { get; set; }
        public string[] ToEmail { get; set; }
        public string[] CCEmail { get; set; }
        public string[] BCCEmail { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}
