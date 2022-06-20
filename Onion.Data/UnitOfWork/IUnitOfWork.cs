namespace Onion.Data.UnitOfWork;

public interface IUnitOfWork
{
    Task Commit();
}