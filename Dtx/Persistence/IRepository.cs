namespace Dtx.Persistence
{
	public interface IRepository<T> : IQueryRepository<T> where T : Domain.Interfaces.IBaseEntitys
	{
		System.Threading.Tasks.Task InsertAsync(T entity);

		System.Threading.Tasks.Task UpdateAsync(T entity);

		System.Threading.Tasks.Task DeleteAsync(T entity);

		System.Threading.Tasks.Task<bool> DeleteByIdAsync(int id);
	}
}
