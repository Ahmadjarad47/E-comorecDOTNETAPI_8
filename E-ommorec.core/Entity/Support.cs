namespace E_commorec.core.Entity
{
    public class Support
    {
        public int Id { get; set; }
        public string WhoSendMessage { get; set; }
        public string TheMessage { get; set; }
        public string WhoReponsed { get; set; }
        public string TheResponse { get; set; }
        public DateTime WhenResponsed { get; set; }
        public bool ReadTheResponsed { get; set; } = false;
    }
}
