namespace WebApplication06.Models;

public class InstructorRole : BaseEntity
{
    public string Role { get; set; }

    // //
    public IEnumerable<InstructorUserRole> InstructorUserRoles { get; set; }
}
