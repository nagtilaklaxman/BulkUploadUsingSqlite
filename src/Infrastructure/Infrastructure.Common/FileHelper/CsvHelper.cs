using System;
using System.Globalization;
using CsvHelper;
using Domain.Common.interfaces.FileHelper;

namespace Infrastructure.Common.FileHelper
{
    public class CsvHelper<T> : BaseFileHelper<T>, ICsvHelper<T> where T : new()
    {
        public CsvHelper()
        {

        }

        public override IList<T> Read(string filePath)
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

        public override bool Write(IList<T> data, string filePath)
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

