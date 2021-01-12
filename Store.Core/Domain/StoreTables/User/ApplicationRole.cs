using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.User
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {
            Permissions = new List<Permission>();
            ApplicationUsers = new List<ApplicationUser>();
        }
        public bool IsActive { get; set; }
        public string PersianName { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual List<Permission> Permissions { get; set; }
        [InverseProperty("ApplicationRoles")]
        public virtual List<ApplicationUser> ApplicationUsers { get; set; }
    }
}
