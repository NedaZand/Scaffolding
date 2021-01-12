﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Store.Core.Domain.StoreTables.StoreRoom
{
    public class EquipmentUnit : BaseEntity
    {
        [Required]
        [Display(Name = " عنوان واحد")]
        public string Title { get; set; }
    }
}
