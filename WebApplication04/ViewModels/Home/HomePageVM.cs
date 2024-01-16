using WebApplication04.ViewModels.BlogVMs;

namespace WebApplication04.ViewModels.Home;

public class HomePageVM
{
    public string AppUserImagePath { get; set; } = "assets/img/avataaars.svg";
    public IEnumerable<BlogVM> BlogVMs { get; set; }
}
