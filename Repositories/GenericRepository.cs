﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
    {
        protected AppDbContext Context = context;

        private readonly DbSet<T> _dbSet = context.Set<T>();

        //IQueryable<T> kullanılması sayesinde filtreleme işlemleri veritabanı seviyesinde yapılabilir.
        public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)=>_dbSet.Where(predicate).AsQueryable().AsNoTracking();

        //Cevap zaten hazırsa veya senkron dönülebiliyorsa ValueTask kullanılır.
        public ValueTask<T?> GetByIdAsync(int id) => _dbSet.FindAsync(id);
        public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);

       
    }
}
