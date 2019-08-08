using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace MITT.Models
{
  public class CourseManagement
  {
    private ApplicationDbContext db;
    private UserManager<ApplicationUser> userManager;

    public CourseManagement(ApplicationDbContext db)
    {
      this.db = db;
      userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
    }

    public bool IsInCourse(string userId, int courseId)
    {
      return db.ApplicationUserCourses.Any(u => u.ApplicationUsersId == userId && u.CourseId == courseId);
    }

    public ICollection<Course> GetUsersCourses(string userId)
    {
      var Courses = db.Users.Find(userId).Courses.ToList();
      return Courses;
    }
    public ICollection<ApplicationUser> GetCourseUsers(int courseId)
    {
      var Users = db.Courses.Find(courseId).ApplicationUsers.ToList();
      return Users;
    }

    public bool AddUserToCourse(string userId, int courseId)
    {
      var user = db.Users.Find(userId);
      var course = db.Courses.Find(courseId);
      if (course.ApplicationUsers.Count() < course.MAXStudent)
      {
        user.Courses.Add(course);
        db.SaveChanges();
        return true;
      }

      return false;

    }
    public bool RemoveUserFromCourse(string userId, int courseId)
    {
      var user = db.Users.Find(userId);
      var course = db.Courses.Find(courseId);
      user.Courses.Remove(course);
      db.SaveChanges();
      return true;
    }
  }
}