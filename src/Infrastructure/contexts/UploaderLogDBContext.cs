using System.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.contexts
{
    public class UploaderLogDBContext : IUploaderLogDBContext
    {
        public UploaderLogDBContext()
        {
        }

        public IDbConnection GetConnection => throw new NotImplementedException();
    }
}

