using WebApplication05.Models;

namespace WebApplication05.Areas.Admin.ViewModels.UsersAdminVMs;

public class UserListItemVM
{
    public string Id { get; set; }
    public string Username { get; set; }
    public bool IsWorker { get; set; }

    public UserListItemVM(AppUser user)
    {
        this.Id = user.Id;
        this.Username = user.UserName;
        this.IsWorker = user.IsWorker;
    }
}
