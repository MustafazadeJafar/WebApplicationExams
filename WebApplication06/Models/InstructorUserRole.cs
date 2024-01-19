namespace WebApplication06.Models;

public class InstructorUserRole : BaseEntity
{
    public string AppUserId { get; set; }
    public int InstructorRoleId { get; set; }

    // //
    public AppUser? AppUser { get; set; }
    public InstructorRole? InstructorRole { get; set; }
}
