using System.Collections.Generic;

namespace MITT.Models
{
  public class Course
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    public int MAXStudent { get; set; }
  }
}