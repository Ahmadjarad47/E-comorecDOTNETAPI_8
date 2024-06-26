namespace E_comorec.API.Helper
{
    public class APIValidationError : BaseResponse
    {
        public APIValidationError() : base(400)
        {
        }
        public IEnumerable<string> Error { get; set; }
    }
}
