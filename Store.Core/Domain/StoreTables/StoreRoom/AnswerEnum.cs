using Store.Core.Domain.StoreTables.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Domain.StoreTables.StoreRoom
{
    public enum AnswerEnum
    {
        [Display(Name = "مطلوب")]
        Desirable,

        [Display(Name = "نا مطلوب")]
        UnDesirable

    }
}
