﻿namespace AspNetCoreWebApiTemplate.Data.Repositories
{
    using Common;
    using Data;
    
    using Microsoft.EntityFrameworkCore;
    
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public EfRepository(AppDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected AppDbContext Context { get; set; }

        public virtual IQueryable<TEntity> All() => this.DbSet;

        public virtual IQueryable<TEntity> AllAsNoTracking() => this.DbSet.AsNoTracking();

        public virtual Task AddAsync(TEntity entity) => this.DbSet.AddAsync(entity).AsTask();

        public virtual void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity) => this.DbSet.Remove(entity);

        public Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();

        public Task<int> GetCount()
        {
            return this.DbSet.CountAsync();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}