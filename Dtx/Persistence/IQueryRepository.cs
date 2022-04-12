namespace Dtx.Persistence
{
	public interface IQueryRepository<T> where T : Dtx.Domain.Interfaces.IBaseEntitys
	{
		System.Threading.Tasks.Task<T> GetByIdAsync(int id);

		System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync();
	}
}
