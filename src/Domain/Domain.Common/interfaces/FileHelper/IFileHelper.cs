using CSharpFunctionalExtensions;
using Domain.Common.Entities;

namespace Domain.Common.interfaces.FileHelper
{

    public interface IFileHelper<T> where T : new()
    {
        public Task<Result<bool, BulkError>> SaveAsync(Stream stream, string filePath);
        public bool Write(IList<T> data, string filePath);
        public Task<List<T>> Read(string filePath);
    }
    public interface ICsvHelper<T> : IFileHelper<T> where T : new()
    {

    }
    public interface IExcelHelper<T> : IFileHelper<T> where T : new()
    {

    }
}

