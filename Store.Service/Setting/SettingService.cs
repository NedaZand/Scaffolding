using Store.Core.CommonHelper;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Setting
{
    public class SettingService : ISettingService
    {
        private readonly IRepository<Core.Domain.Setting.Setting> _repository;
        public SettingService(IRepository<Core.Domain.Setting.Setting> repository)
        {
            _repository = repository;
        }
        public void Insert(Core.Domain.Setting.Setting entity)
        {
            _repository.Insert(entity);
        }
        public void Remove(Core.Domain.Setting.Setting entity)
        {
            _repository.Remove(entity);
        }
        public void Update(Core.Domain.Setting.Setting entity)
        {
            _repository.Edit(entity);
        }
        public List<Core.Domain.Setting.Setting> GetAll()
        {
            return _repository.Entities.ToList();
        }
        public Core.Domain.Setting.Setting GetById(int id)
        {
            return _repository.GetById(id);
        }
        public T LoadSetting<T>()
        {
            var settingObject = Activator.CreateInstance<T>();
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.CanRead || prop.CanWrite)
                {
                    var key = typeof(T).Name + "." + prop.Name;
                    var settingProperty = GetByKey(key);
                    if (settingProperty == null)
                    {
                        continue;
                    }
                    object value = CustomTypeConverter.GetCustomeConverter(prop.PropertyType).ConvertFromInvariantString(settingProperty.Value);
                    prop.SetValue(settingObject, value, null);
                }
            }
            return settingObject;
        }
        public Store.Core.Domain.Setting.Setting GetByKey(string key)
        {
            return _repository.Entities.SingleOrDefault(x => x.Name == key);
        }
        public void SetSetting<T>(string key, string value)
        {
            key = key.Trim().ToLowerInvariant();
            string valueStr = CustomTypeConverter.GetCustomeConverter(typeof(T)).ConvertToInvariantString(value);
            var setting = GetAll().Where(x => x.Name.Contains(key));
            if (setting.Count() > 0)
            {
                var entity = GetById(setting.FirstOrDefault().Id);
                entity.Value = valueStr;
                Update(entity);
            }
            else
            {
                var entity = new Core.Domain.Setting.Setting
                {
                    Name = key,
                    Value = valueStr
                };
                Insert(entity);
            }
        }
        public void SaveSetting<T>(T model)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (!prop.CanRead || !prop.CanWrite)
             
                    continue;
                if (!CustomTypeConverter.GetCustomeConverter(prop.PropertyType).CanConvertFrom(typeof(string)))
                    continue;
                var key = typeof(T).Name + "." + prop.Name;
               
                dynamic value = prop.GetValue(model, null);
                if (value != null)
                    SetSetting<T>(key,value.ToString());
                else
                    SetSetting<T>(key, "");

            }

        }
        public virtual T GetSettingByKey<T>(string key, T defaultValue = default(T))
        {
            if (String.IsNullOrEmpty(key))
                return defaultValue;

            var settings = GetAll();
            key = key.Trim().ToLowerInvariant();
            //if (settings.ContainsKey(key))
            //{
            //    var settingsByKey = settings[key];
            //    var setting = settingsByKey.FirstOrDefault(x => x.StoreId == storeId);

            //    //load shared value?
            //    if (setting == null && storeId > 0 && loadSharedValueIfNotFound)
            //        setting = settingsByKey.FirstOrDefault(x => x.StoreId == 0);


            //}
            try
            {
                return (T)Convert.ChangeType(settings.FirstOrDefault(x => x.Name == key).Value, typeof(T));

            }
            catch (Exception e)
            {

                return defaultValue;
            }
        }
    }
}
