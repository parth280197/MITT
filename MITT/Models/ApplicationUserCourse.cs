using System.Collections.Generic;

namespace MITT.Models
{
  public class ApplicationUserCourse
  {
    public int Id { get; set; }
    public string ApplicationUsersId { get; set; }
    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    public int CourseId { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
  }
}