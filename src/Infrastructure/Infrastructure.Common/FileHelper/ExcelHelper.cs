using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Excel;
using Domain.Common.interfaces.FileHelper;

namespace Infrastructure.Common.FileHelper
{
    public class ExcelHelper<T> : BaseFileHelper<T>, IExcelHelper<T> where T : new()
    {
        public override IList<T> Read(string filePath)
        {
            using var reader = new CsvReader(new ExcelParser(filePath));
            var temp = reader.GetRecords<T>();
            var records = temp?.ToList() ?? new List<T>();
            return records;
        }

        public override bool Write(IList<T> data, string filePath)
        {
            using (var writer = new ExcelWriter(filePath))
            {
                writer.WriteRecords(data);
            }
            return true;
        }
    }
}

