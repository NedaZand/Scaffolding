using Store.Core.Domain.StoreTables;
using Store.Core.Domain.StoreTables.StoreRoom;
using Store.Core.Domain.StoreTables.User;
using Store.Core.Domain.StoreTables.Work;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Stores
{
    public class StockService : IStockService
    {
        private readonly IRepository<Stock> _repository;
        private readonly StoreContext _context;
        public StockService(IRepository<Stock> repository)
        {
            _repository = repository;
            _context = new StoreContext();
        }
        public void Insert(Stock entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(Stock entity)
        {
            _repository.Remove(entity);
        }
        public void Update(Stock entity)
        {
            _repository.Edit(entity);
        }

        public Stock GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Stock> FilterData(int start, int lenght, string search, int sortColumn, string sortDirection, int? equipmentId = null)
        {
            //var equipments = _context.Equipment;

            var query = _repository.Table;

            //if (!string.IsNullOrEmpty(search))
            //{
            //    query = query.Where(x => (_context.Equipment.Find(x.EquipmentId)) != null && (_context.Equipment.Find(x.EquipmentId)).Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.MissingNumberStock.ToString().Contains(search.Trim().ToLower()) || x.StockReady.ToString().Contains(search.Trim().ToLower()) || x.TotalStock.ToString().Contains(search.Trim().ToLower()) || x.DefectiveNumberStock.ToString().Contains(search.Trim().ToLower()));
            //}

            //query = query.Where(x => equipments.Any(e => e.MinimumInventory != 0 && e.MinimumInventory == x.TotalStock));

            //query = query.Where(x => equipments.Any(e => (x.MainStock * e.MinimumInventoryPercentage) / 100 == x.TotalStock));

            if (equipmentId.HasValue)

                query = query.Where(x => x.EquipmentId == equipmentId);
           

            var list = query.ToList();

            return list.GetRange(start, Math.Min(lenght, list.Count - start)).ToList();
        }
        public List<Stock> GetAll(int? equipmentId = null)
        {
            var query = _repository.Table;

            if (equipmentId.HasValue)

                query = query.Where(x => x.EquipmentId == equipmentId.Value);

            var list = query.ToList();

            return list.ToList();
        }
        public int Count(string search,int? equipmentId = null)
        {
            var query = _repository.Table;


            //if (!string.IsNullOrEmpty(search))
            //{
            //    query = query.Where(x => (_context.Equipment.Find(x.EquipmentId))!=null && (_context.Equipment.Find(x.EquipmentId)).Title.Trim().ToLower().Contains(search.Trim().ToLower()) || x.MissingNumberStock.ToString().Contains(search.Trim().ToLower()) || x.StockReady.ToString().Contains(search.Trim().ToLower()) || x.TotalStock.ToString().Contains(search.Trim().ToLower()) || x.DefectiveNumberStock.ToString().Contains(search.Trim().ToLower()));
            //}

            if (equipmentId.HasValue)

                query = query.Where(x => x.EquipmentId == equipmentId);

           

            var list = query.ToList();

            return query.Count();
        }
    }
}
