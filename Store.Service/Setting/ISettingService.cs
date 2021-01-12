using System.Collections.Generic;

namespace Store.Service.Setting
{
    public interface ISettingService
    {
        List<Core.Domain.Setting.Setting> GetAll();
        Core.Domain.Setting.Setting GetById(int id);
        Core.Domain.Setting.Setting GetByKey(string key);
        void Insert(Core.Domain.Setting.Setting entity);
        T LoadSetting<T>();
        void Remove(Core.Domain.Setting.Setting entity);
        void SaveSetting<T>(T model);
        void SetSetting<T>(string key, string value);
        void Update(Core.Domain.Setting.Setting entity);
        T GetSettingByKey<T>(string key, T defaultValue = default(T));
    }
}