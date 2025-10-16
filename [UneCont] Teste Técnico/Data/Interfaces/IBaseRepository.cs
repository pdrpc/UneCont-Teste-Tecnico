namespace _UneCont__Teste_Técnico.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
