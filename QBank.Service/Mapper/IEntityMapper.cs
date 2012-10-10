namespace QBank.Service.Mapper
{
    public interface IEntityMapper<TDto, TEntity>
        where TEntity : class
        where TDto : class
    {
        TDto MapToDto(TEntity entity);
    }
}