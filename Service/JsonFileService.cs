using Newtonsoft.Json;    // used for serialization and deserialization
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
                // reads the existing data from the file, updates file with both existing as well as new dataList and appends.
                List<T> existingData = ReadData<T>(filePath);
                UpdateData(existingData, filePath);
                dataList.AddRange(existingData);
            }
        }

        public List<T> ReadData<T>(string path)
        {
            string existingData = File.ReadAllText(path);
            if (string.IsNullOrEmpty(existingData)) return new List<T>();
            return JsonConvert.DeserializeObject<List<T>>(existingData);   // reads JSON and deserizalizes to data (list of objects)
        }

        public void UpdateData<T>(List<T> data, string path)
        {
            string serializedData = JsonConvert.SerializeObject(data, Formatting.Indented);  // serialize the data (list of objects) into JSON format.
            File.WriteAllText(path, serializedData);
        }


    }
}
