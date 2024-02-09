﻿namespace Services.Interfaces
{
    public interface IJsonFileService
    {
        public void CheckAndUpdateFile<T>(List<T> dataList, string filePath);
        public List<T> ReadData<T>(string path);
        public void UpdateData<T>(List<T> transactions, string path);
    }
}