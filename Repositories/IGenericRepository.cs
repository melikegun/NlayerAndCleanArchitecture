using System.Linq.Expressions;

namespace App.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();  // Tüm verileri döndürür
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);  // Şarta göre veri döndürür
        ValueTask<T?> GetByIdAsync(int id);  // ID ile veri getirir
        ValueTask AddAsync(T entity);  // Yeni veri ekler
        void Update(T entity);  // Mevcut veriyi günceller
        void Delete(T entity);  // Veriyi siler
    }
}
