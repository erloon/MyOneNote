namespace MyOneNote.EF
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}