using System.ComponentModel.DataAnnotations;

namespace E_commorec.core.DTO;

public record UserLoginDTO([Required] string EmailOrUserName, [Required] string password);

