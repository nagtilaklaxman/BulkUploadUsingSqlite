using System.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.contexts
{
    public class UploaderJobDBContext : IUploaderJobDBContext
    {
        public UploaderJobDBContext()
        {
        }

        public IDbConnection GetConnection => throw new NotImplementedException();
    }
}

