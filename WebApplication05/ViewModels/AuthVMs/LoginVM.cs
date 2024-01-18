using System.ComponentModel.DataAnnotations;

namespace WebApplication05.ViewModels.AuthVMs;

public class LoginVM
{
    public string UserName { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
