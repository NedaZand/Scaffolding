using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables;
using Store.Data;


namespace Store.Service.StoreRoom
{
    public class EquipmentTypeService : IEquipmentTypeService
    {
       
        private readonly StoreContext _context;
        public EquipmentTypeService(IRepository<EquipmentType> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public int Count(string search = null)
        {
            throw new NotImplementedException();
        }

        public List<EquipmentType> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var list = _repository.Entities.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x => x.Title.Trim().ToLower().Contains(search.Trim().ToLower())).ToList();
            }


            //if (fromDate.HasValue)
            //{
            //    list = list.Where(x => x.DateEstablished>=fromDate).ToList();
            //}
            //if (toDate.HasValue)
            //{
            //    list = list.Where(x => x.DateEstablished <= toDate).ToList();
            //}
            //switch (sortColumn)
            //{
            //    case 1:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.Title).ToList() : list.OrderByDescending(x => x.Title).ToList();
            //        break;
            //    case 2:
            //        list = sortDirection == "asc" ? list.OrderBy(x => x.Description).ToList() : list.OrderByDescending(x => x.Description).ToList();
            //        break;
            //    default:
            //        break;
            //}
            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }

        public List<EquipmentType> GetAll(string search = null)
        {
            throw new NotImplementedException();
        }

        public EquipmentType GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(EquipmentType entity)
        {
            _repository.Insert(entity);
        }

        public void Remove(EquipmentType entity)
        {
            _repository.Remove(entity);
        }

        public void Update(EquipmentType entity)
        {
            _repository.Edit(entity);
        }
    }
}
