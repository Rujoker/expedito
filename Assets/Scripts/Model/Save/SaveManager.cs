using System.IO;
using SimpleJSON;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Model.Save
{
    public class SaveManager : ISaveManager
    {
        private const string Filename = "/save.json";
        private JSONNode saveData = new JSONObject();

        public SaveManager()
        {
            Load();
        }
        
        public void Load()
        {
            var path = Application.persistentDataPath + Filename;
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                saveData = JSON.Parse(json);
            }
        }
        
        public void Save()
        {
            var json = saveData.ToString();
            File.WriteAllText(Application.persistentDataPath + Filename, json);
        }

        public JSONNode GetValue(string key)
        {
            return saveData.GetValueOrDefault(key, null);
        }
        
        public void PutValue(string key, object value)
        {
            saveData.Add(key, value.ToString());
        }
    }
}