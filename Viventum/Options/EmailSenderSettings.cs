namespace Viventum.Options
{
    public class EmailSenderSettings
    {
        public string Host { get; set; }
        public string From { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public string Domain { get; set; }
        public string AdminEmail { get; set; }

        public string FolderPath { get; set; }
    }
}
