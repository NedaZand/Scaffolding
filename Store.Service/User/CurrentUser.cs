using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Store.Core.Domain.StoreTables.User;

namespace Store.Service.User
{
    public static class CurrentUser
    {
        public static ApplicationUser GetCurrentUser
        {
            get
            {
                return DependencyResolver.Current.GetService<IUserService>().GetById(HttpContext.Current.User.Identity.GetUserId());
            }
        }
    }
}