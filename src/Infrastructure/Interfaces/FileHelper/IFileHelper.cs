using System;
namespace Infrastructure.Interfaces.FileHelper
{

    public interface IFileHelper<T> where T : new()
    {
        public Task<bool> SaveAsync(Stream stream, string filePath);
        public bool Write(IList<T> data, string filePath);
        public IList<T> Read(string filePath);
    }
    public interface ICsvHelper<T> : IFileHelper<T> where T : new()
    {

    }
    public interface IExcelHelper<T> : IFileHelper<T> where T : new()
    {

    }
}

