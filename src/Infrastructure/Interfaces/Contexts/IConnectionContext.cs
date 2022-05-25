using System;
using System.Data;

namespace Infrastructure.Interfaces
{
    public interface IConnectionContext
    {
        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        IDbConnection GetConnection { get; }
    }
}

