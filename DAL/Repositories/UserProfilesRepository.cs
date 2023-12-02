using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserProfilesRepository : IUserProfilesRepository
    {
        private readonly DataContext _dataContext;

        public UserProfilesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task CreateAsync(UserProfile entity, CancellationToken cancellationToken = default)
        {
            await _dataContext.UserProfiles.AddAsync(entity, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dataContext.UserProfiles.FindAsync(id, cancellationToken);
            if (entity != null)
            {
                _dataContext.UserProfiles.Remove(entity);
                await _dataContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<ICollection<UserProfile>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _dataContext.UserProfiles.ToListAsync(cancellationToken);
            return result;
        }

        public async Task<UserProfile> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _dataContext.UserProfiles.FindAsync(id, cancellationToken);
            return result;
        }

        public async Task UpdateAsync(UserProfile entity, CancellationToken cancellationToken = default)
        {
            _dataContext.UserProfiles.Update(entity);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
