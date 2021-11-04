using SimpleJSON;

namespace SergeyPchelintsev.Expedito.Model.Save
{
    public interface ISaveManager
    {
        void Load();
        void Save();

        JSONNode GetValue(string key);
        void PutValue(string key, object value);
    }
}