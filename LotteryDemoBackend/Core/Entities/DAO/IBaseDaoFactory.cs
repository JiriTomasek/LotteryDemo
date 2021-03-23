namespace Core.Entities.DAO
{
    public interface IBaseDaoFactory
    {
        ICommonDao<T> GetDao<T>() where T : class;
        ICommonDao<T> GetDifferentContextDao<T>() where T : class;

    }
}