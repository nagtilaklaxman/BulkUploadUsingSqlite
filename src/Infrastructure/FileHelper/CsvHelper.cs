using System;
using System.Globalization;
using CsvHelper;
using Infrastructure.Interfaces.FileHelper;

namespace Infrastructure.FileHelper
{
    public class CsvHelper<T> : ICsvHelper<T> where T : new()
    {
        public CsvHelper()
        {

        }

        public IList<T> Read(string filePath)
        {
            var records = new List<T>();
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var temp = csv.GetRecords<T>();
                records = temp?.ToList() ?? new List<T>();
            }

            return records;
        }

        public bool Write(IList<T> data, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data);
            }
            return true;
        }
    }
}

