namespace Onion.Data.Repositories;

public abstract class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
    where TEntity : class, IBaseEntity
    where TContext : AppDbContext
{
    private readonly TContext _context;
    public GenericRepository(TContext context)
    {
        _context = context;
    }
    public async Task<TEntity> Add(TEntity entity)
    {
        _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }
    public async Task<TEntity> Delete(int id)
    {
        var entity = await context.Set<TEntity>().FindAsync(id);
        if(entity is null) 
            return entity;
        
        _context.Set<TEntity>().RemoveAsync();
        return entity;
    }
    public async Task<List<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
    public async Task<TEntity> Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }
}