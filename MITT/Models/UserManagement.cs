using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace MITT.Models
{
  public class UserManagement
  {
    private ApplicationDbContext db;
    private UserManager<ApplicationUser> usersManager;

    public UserManagement(ApplicationDbContext db)
    {
      this.db = db;
      usersManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
    }
    public bool IsUserInRole(string userId, string roleName)
    {
      return usersManager.IsInRole(userId, roleName);
    }
    public ICollection<string> GetUserRoles(string userId)
    {
      return usersManager.GetRoles(userId);
    }
    public bool AddUserToRole(string userId, string roleName)
    {
      return usersManager.AddToRole(userId, roleName).Succeeded;
    }
    public bool RemoveUserFromRole(string userId, string roleName)
    {
      return usersManager.RemoveFromRole(userId, roleName).Succeeded;
    }

    public ICollection<ApplicationUser> UsersInRole(string roleName)
    {
      var result = new List<ApplicationUser>();
      var allUsers = db.Users;
      foreach (var user in allUsers)
      {
        if (IsUserInRole(user.Id, roleName))
        {
          result.Add(user);
        }
      }

      return result;
    }
    public ICollection<ApplicationUser> UsersNotInRole(string roleName)
    {
      var result = new List<ApplicationUser>();
      var allUsers = db.Users;
      foreach (var user in allUsers)
      {
        if (!IsUserInRole(user.Id, roleName))
        {
          result.Add(user);
        }
      }

      return result;
    }
  }
}