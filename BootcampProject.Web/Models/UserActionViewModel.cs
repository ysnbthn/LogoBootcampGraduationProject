using BootcampProject.Domain.Entities;
using System.Collections.Generic;

namespace BootcampProject.Web.Models
{
    public class UserActionViewModel
    {
        public List<ApplicationUser> Users = new List<ApplicationUser>();
        public ApplicationUser EditUser { get; set; }
    }
}
