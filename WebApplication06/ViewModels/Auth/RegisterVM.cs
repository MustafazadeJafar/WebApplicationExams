using System.ComponentModel.DataAnnotations;
using WebApplication06.Models;

namespace WebApplication06.ViewModels.Auth;

public class RegisterVM
{
    [MaxLength(63), MinLength(3)]
    public string FullName { get; set; }
    public string UserName { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    public AppUser ToAppUser()
    {
        return new()
        {
            UserName = this.UserName,
            FullName = this.FullName,
        };
    }
}
