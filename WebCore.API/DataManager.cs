using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WebCore.API.Utils;

namespace WebCore.API
{
    public class DataManager
    {
        private string filePath;

        public DataManager()
        {
            this.filePath = Path.Combine("App_Data", "data.json");
        }

        public JArray LoadData()
        {
            return JsonSerialization.ReadFromJsonFile<JArray>(filePath);
        }

        public void SaveData(JArray data)
        {
            JsonSerialization.WriteToJsonFile(filePath, data);
        }
    }
}
