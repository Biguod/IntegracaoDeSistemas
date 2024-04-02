using Avaliacao1.JonStore.Domain.Models.Common;
using Avaliacao1.JonStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Linq.Expressions;

namespace Avaliacao1.JonStore.Repository.Common
{
    public class BaseRepository<T> where T : BaseClass
    {
        protected readonly JonStoreDbContext _databaseContext;
        public BaseRepository(IServiceScopeFactory serviceScopeFactory)
        {
            var scope = serviceScopeFactory.CreateScope();
            _databaseContext = scope.ServiceProvider.GetRequiredService<JonStoreDbContext>();
        }

        public async Task SaveChanges()
        {
            try
            {
                await this._databaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(T model)
        {
            _databaseContext.Set<T>().Remove(model);
            await SaveChanges();
        }

        public async Task<Guid> Create(T model)
        {
            await this._databaseContext.Set<T>().AddAsync(model);
            await SaveChanges();

            return model.Id;
        }

        public async Task Update(T model)
        {
            model.LastUpdate = DateTime.Now;
            this._databaseContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _databaseContext.Set<T>().ToListAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var entity = await _databaseContext.Set<T>().Where(w => w.Id == id).FirstOrDefaultAsync();
                _databaseContext.Set<T>().Remove(entity);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<T> GetOne(Guid id)
        {
            return await _databaseContext.Set<T>().Where(w => w.Id == id).FirstOrDefaultAsync();
        }


        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await _databaseContext.Set<T>().AnyAsync(predicate);
        }
    }
}
