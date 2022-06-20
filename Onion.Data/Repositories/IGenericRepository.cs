namespace Onion.Data.Repositories;

public interface IGenericRepository<T> where T : IBaseEntity
{
    IEnurable<T> GetAll();
    T GetById(int id);
}