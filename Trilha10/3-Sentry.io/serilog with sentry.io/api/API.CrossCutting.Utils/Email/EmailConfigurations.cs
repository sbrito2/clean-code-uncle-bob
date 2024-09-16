﻿namespace API.CrossCutting.Utils.Email
{
    public class EmailConfigurations
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string Sender { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Receiver { get; set; }
        public string DisplayName { get; set; }
    }
}
