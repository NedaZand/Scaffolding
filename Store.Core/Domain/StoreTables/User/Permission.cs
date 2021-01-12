
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Core.Domain.StoreTables.User
{
    /// <summary>
    /// Represents a permission record
    /// </summary>
    public class Permission : BaseEntity
    {
        #region Ctor
        public Permission()
        {
            Roles = new List<ApplicationRole>();
            //ApplicationUsers = new List<ApplicationUser>();
           
        }

        #endregion Ctor


        #region Fields

        /// <summary>
        /// Gets or sets the permission name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the permission system name
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the permission category
        /// </summary>
        public string Category { get; set; }
        public string PersianCategoryame { get; set; }

        /// <summary>
        /// Gets or sets the permission active
        /// </summary>
        public bool Active { get; set; }

        #endregion Fields


        #region Relations

        /// <summary>
        /// Gets or sets discount usage history
        /// </summary>
        public virtual List<ApplicationRole> Roles { get; set; }

        
        /// <summary>
        /// Relation to ApplicationUser entity
        /// </summary>
        //[InverseProperty("Permissions")]

        //public virtual List<ApplicationUser> ApplicationUsers { get; set; }

        #endregion Relations
    }
}
