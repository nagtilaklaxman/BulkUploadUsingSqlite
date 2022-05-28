using System;
using Core.Entities;

namespace Core.interfaces
{
    public interface IBulkDataProcessor<T> where T : BulkEntity
    {
        IReadOnlyList<T> Data { get; }
        Task<IList<T>> Receive(IList<T> data);
        Task<IList<T>> Modify(IList<T> data);
        Task<IList<T>> Remove(IList<T> data);
    }
}

