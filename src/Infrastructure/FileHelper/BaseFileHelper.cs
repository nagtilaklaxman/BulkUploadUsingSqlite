using Infrastructure.Interfaces.FileHelper;

namespace Infrastructure.FileHelper
{
    public abstract class BaseFileHelper<T> : IFileHelper<T> where T : new()
    {
        public abstract IList<T> Read(string filePath);


        public async virtual Task<bool> SaveAsync(Stream stream, string filePath)
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

