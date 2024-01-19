using Newtonsoft.Json;
using Services.Interfaces;

namespace Services
{
    public class JsonFileService : IJsonFileService
    {
        public void CheckAndUpdateFile<T>(List<T> dataList, string filePath)
        {
            if (!File.Exists(filePath))
            {
                UpdateData(dataList, filePath);
            }
            else
            {
                List<T> existingData = ReadData<T>(filePath);
                UpdateData(existingData, filePath);
                dataList.AddRange(existingData);
            }
        }

        public List<T> ReadData<T>(string path)
        {
            string existingData = File.ReadAllText(path);
            if (string.IsNullOrEmpty(existingData)) return new List<T>();
            return JsonConvert.DeserializeObject<List<T>>(existingData);
        }

        public void UpdateData<T>(List<T> data, string path)
        {
            string serializedData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, serializedData);
        }


    }
}
