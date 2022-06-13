namespace Domain.Common.interfaces;

public interface IMapper<TSource ,TTarget> where TSource : class  where TTarget : class
{
    public Task<TTarget> Map(TSource source);
    public Task<IEnumerable<TTarget>> Map(IEnumerable<TSource> sourceRecords);
    public Task<TSource> Map(TTarget source);
    public Task<IEnumerable<TSource>> Map(IEnumerable<TTarget> sourceRecords);
}