using System.ComponentModel.DataAnnotations;
using WebApplication05.Models;

namespace WebApplication05.ViewModels.AuthVMs;

public class RegisterVM : LoginVM
{
    [MaxLength(63)]
    public string Fullname { get; set; }
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    public AppUser ToAppUser()
    {
        return new()
        {
            Fullname = this.Fullname,
            UserName = this.UserName,
        };
    }
}
