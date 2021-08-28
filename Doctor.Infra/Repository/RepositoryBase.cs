using Doctor.Domain.Interface;
using Doctor.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Doctor.Infra.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        protected readonly DbContextOptions<ContextBdDoctor> _contextBdDoctor;
        protected DbSet<TEntity> _dbSet;
        protected ContextBdDoctor _dataContext;

        public RepositoryBase(DbContextOptions<ContextBdDoctor> contextBdLivraria)
        {
            _contextBdDoctor = contextBdLivraria;
            _dataContext = new ContextBdDoctor(_contextBdDoctor);
            _dbSet = _dataContext.Set<TEntity>();
        }

        public void Add(TEntity Objeto)
        {
            _dbSet.Add(Objeto);
            _dataContext.SaveChanges();
        }

        public async Task Delete(TEntity Objeto)
        {
            using (var data = new ContextBdDoctor(_contextBdDoctor))
            {
                data.Set<TEntity>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();

            }

            disposed = true;
        }

        public async Task<TEntity> GetEntityById(long Id)
        {
            using (var data = new ContextBdDoctor(_contextBdDoctor))
            {
                return await data.Set<TEntity>().FindAsync(Id);
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            using (var data = new ContextBdDoctor(_contextBdDoctor))
            {
                return await data.Set<TEntity>().AsNoTracking().ToListAsync();
            }
        }



        public async Task<int> Update(TEntity Objeto)
        {
            using (var data = new ContextBdDoctor(_contextBdDoctor))
            {
                var update = data.Set<TEntity>().Update(Objeto);
                return await data.SaveChangesAsync();
            }
        }
    }
}
