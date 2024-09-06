namespace E_commorec.core.DTO
{
    public record SupportResponse
    {
        public int Id { get; set; }
        public string WhoReponsed { get; set; }
        public string TheResponse { get; set; }
    }

}
