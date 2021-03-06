using Domain.Common.Entities;
using CSharpFunctionalExtensions;
using Domain.Common.interfaces.FileHelper;

namespace Infrastructure.Common.FileHelper
{
    public abstract class BaseFileHelper<T> : IFileHelper<T> where T : new()
    {
        public abstract Task<List<T>> Read(string filePath);


        public async virtual Task<Result<bool, BulkError>> SaveAsync(Stream stream, string filePath)
        {
            EnsureFolder(filePath);
            await using FileStream fs = new(filePath, FileMode.Create);
            await stream.CopyToAsync(fs);

            return true;
        }

        protected virtual void EnsureFolder(string path)
        {
            // If path is a file name only, directory name will be an empty string
            if (!string.IsNullOrWhiteSpace(path) && path.Length > 0)
            {
                var directoryName = Path.GetDirectoryName(path);
                if (!string.IsNullOrWhiteSpace(directoryName) && directoryName.Length > 0)
                {
                    // Create all directories on the path that don't already exist
                    Directory.CreateDirectory(directoryName);
                }
            }
        }

        public abstract bool Write(IList<T> data, string filePath);


    }
}

