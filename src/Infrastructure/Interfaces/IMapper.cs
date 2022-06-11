namespace Infrastructure.Interfaces;

public interface IMapper<in TSource ,TTarget> where TSource : class  where TTarget : class
{
    public Task<TTarget> Map(TSource source);
    public Task<IEnumerable<TTarget>> Map(IEnumerable<TSource> sourceRecords);
}