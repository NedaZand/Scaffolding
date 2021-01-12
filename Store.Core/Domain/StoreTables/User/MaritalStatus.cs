
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Store.Core.Domain.StoreTables.User
{
    public enum MaritalStatus:int
    {
        /// <summary>
        /// انتخاب
        /// </summary>
        [Display(Name = "انتخاب")]
        Unknown = 0,

        /// <summary>
        /// مجرد
        /// </summary>
        [Display(Name = "مجرد")]
        Single = 1,

        /// <summary>
        /// متاهل
        /// </summary>
        [Display(Name = "متاهل")]
        Married = 2

    }
}
