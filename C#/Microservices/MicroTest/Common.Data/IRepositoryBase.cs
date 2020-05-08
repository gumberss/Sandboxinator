
namespace Common.Data
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
    }
}
