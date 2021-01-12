using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables.User;
using Store.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Store.Core.Domain.StoreTables
{
    public enum PositionTypeEnum 
    {
        [Display(Name ="استادکار")]
        MasterOfWork

    }
}
