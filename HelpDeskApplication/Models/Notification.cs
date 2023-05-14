namespace HelpDeskApplication.Models
{
    public class Notification
    {
        public Notification(string type, string meesage)
        {
            Type = type;
            Meesage = meesage;
        }

        public string Type { get; set; }
        public string Meesage { get; set; }
    }
}
