using Blog.Application.Contracts.Persistence;
using Blog.Persistence.Context;

namespace Blog.Persistence.Concrete
{
    public class UnitOfWork(AppDbContext _context) : IUnitOfWork
    {
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();  
        }
    }
}
