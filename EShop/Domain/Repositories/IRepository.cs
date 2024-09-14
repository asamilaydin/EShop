using System;
namespace Domain.Repositories
{
	public interface IRepository<TEntity>
	{
		Task<List<TEntity>> GetAllAsync();

		Task<TEntity> GetByIdAsync(Guid id);

		IQueryable<TEntity> GetQueryable();

		void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

		Task SaveChangeAsync();
    }
}// Daha sonra bu sınıfı Tüm projenin kullanabileceği ortak dosyaya taşı.
