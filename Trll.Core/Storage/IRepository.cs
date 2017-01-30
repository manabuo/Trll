namespace Trll.Core.Storage
{
    public interface IRepository<T>
    {
        T ById(int id);
    }
}