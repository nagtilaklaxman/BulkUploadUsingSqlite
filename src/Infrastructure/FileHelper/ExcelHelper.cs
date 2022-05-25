using CsvHelper;
using CsvHelper.Excel;
using Infrastructure.Interfaces.FileHelper;

namespace Infrastructure.FileHelper
{
    public class ExcelHelper<T> : IExcelHelper<T> where T : new()
    {
        public IList<T> Read(string filePath)
        {
            using var reader = new CsvReader(new ExcelParser(filePath));
            var temp = reader.GetRecords<T>();
            var records = temp?.ToList() ?? new List<T>();
            return records;
        }

        public bool Write(IList<T> data, string filePath)
        {
            using (var writer = new ExcelWriter(filePath))
            {
                writer.WriteRecords(data);
            }
            return true;
        }
    }
}

