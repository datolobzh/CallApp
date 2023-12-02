using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _dataContext;

        public UsersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(User entity, CancellationToken cancellationToken = default)
        {
            await _dataContext.Users.AddAsync(entity, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dataContext.Users.FindAsync(id, cancellationToken);
            if (entity != null)
            {
                _dataContext.Users.Remove(entity);
                await _dataContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<ICollection<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _dataContext.Users
                .ToListAsync(cancellationToken);
            return result;
        }

        public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _dataContext.Users
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return result;
        }
        public async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
        {
            _dataContext.Users.Update(entity);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

    }
}
