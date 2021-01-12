using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables.User;
using Store.Core.Domain.StoreTables.Work;
using Store.Essential;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Models.Stores.StoreRoom
{
    public class ShowEquipments : BaseModel
    {
        public ShowEquipments(List<OutputHasEquipmentModel> outOutMaterial = null, List<InputHasEquipmentModel> inPutMaterial = null)
        {
            InPutMaterial = inPutMaterial;
            OutOutMaterial = outOutMaterial;
        }

        public List<InputHasEquipmentModel> InPutMaterial { get; set; }
        public List<OutputHasEquipmentModel> OutOutMaterial { get; set; }
    }
}
