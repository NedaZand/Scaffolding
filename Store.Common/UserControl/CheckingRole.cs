
using Store.Core.Domain.StoreTables.User;
using System.Linq;

namespace Store.WebEssential.UserControl
{
    public class CheckingRole : ICheckingRole
    {
        #region Methods
        public bool HasAccess(Permission permission, ApplicationUser user)
        {
            
                foreach (var roles in user.ApplicationRoles)
                {
                    if (roles.Permissions.Where(x => x.SystemName == permission.SystemName).Count() > 0)
                        return true;
                }
            return false;
        }
    }
    #endregion Methods
}
