using Store.Core.Domain.StoreTables.User;

namespace Store.WebEssential.UserControl
{
    public interface ICheckingRole
    {
        bool HasAccess(Permission permission, ApplicationUser user);
    }
}