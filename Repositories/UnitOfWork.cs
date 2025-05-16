namespace App.Repositories;

//Repository nesneleri arasında transactional(işlemsel) kontrol sağlar.
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();

}

