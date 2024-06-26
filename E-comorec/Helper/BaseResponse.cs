using System.ComponentModel.DataAnnotations.Schema;

namespace E_comorec.API.Helper;

public class BaseResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    [NotMapped]
    public int State { get; set; }
    public BaseResponse(int state)
    {
        State = state;
        if (State == -1)
        {
            StatusCode = 400;
            Message = "The model is null";
        }
        else if (State == -2)
        {
            StatusCode = 400;
            Message = "This Email already Exisit";
        }
        else if (State == -3)
        {
            StatusCode = 400;
            Message = "This UserName already Exisit";
        }
        else if (State == -4)
        {
            StatusCode = 400;
            Message = "invalid";
        }
        else if (State == -5)
        {
            StatusCode = 400;
            Message = " user not register or found";
        }
        else if (State == -6)
        {
            StatusCode = 400;
            Message = "invalid password";
        }
        else if (State == -7)
        {
            StatusCode = 400;
            Message = "Confierm your email";
        }
        else if (State == -8)
        {
            StatusCode = 400;
            Message = "code expierd";
        }
        else
        {
            StatusCode = 400;
            Message = "Bad Request";
        }
    }
    public BaseResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? DefaultMessage(statusCode);
    }
    private string DefaultMessage(int statuscode)
       => statuscode switch
       {
           200 => "Done !",
           400 => "Bad Request",
           401 => "Not Authorized",
           404 => "Not Found",
           500 => "Server Error",
           _ => null
       };

}
