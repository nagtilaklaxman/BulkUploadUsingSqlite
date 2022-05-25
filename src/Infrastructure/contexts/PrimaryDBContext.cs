using System;
using System.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.contexts
{
    public class PrimaryDBContext : IPrimaryDBContext
    {
        public PrimaryDBContext()
        {
        }

        public IDbConnection GetConnection => throw new NotImplementedException();
    }
}

