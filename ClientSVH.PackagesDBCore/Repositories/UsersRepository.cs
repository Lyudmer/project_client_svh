using ClientSVH.PackagesDBCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClientSVH.PackagesDBCore.Repositories
{
    public class UsersRepository
    {
        private readonly PackagesDBContext _dbContext;
        public UsersRepository(PackagesDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> Get()
        {
            return await _dbContext.Users
                .AsNoTracking()
                .OrderBy(u => u.FullName)
                .ToListAsync();
        }
        public async Task<List<User>> GetWithPkg()
        {
            return await _dbContext.Users
                .AsNoTracking()
                .Include(u => u.Packages)
                .ToListAsync();
        }
        public async Task<User?> GetById(int id)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<List<User>> GetByFilter(string FullName, string Email)
        {
            var query = _dbContext.Users.AsNoTracking();
            if (string.IsNullOrEmpty(FullName))
            { query = query.Where(u => u.FullName.Contains(FullName)); }
            if (string.IsNullOrEmpty(Email))
            { query = query.Where(u => u.Email.Contains(Email)); }

            return await query.ToListAsync();
        }
        public async Task<List<User>> GetByPage(int page, int page_size)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .Skip((page - 1) * page_size)
                .Take(page_size)
                .ToListAsync();
        }

        public async Task Add(int Id, string Login, string Password, string FullName, string Email)
        {
            var UserEntity = new User
            {
                Id = Id,
                Login = Login,
                Password = Password,
                FullName = FullName,
                Email = Email
            };
            await _dbContext.AddAsync(UserEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(int Id, string Login, string Password, string FullName, string Email)
        {

            await _dbContext.Users
                .Where(u => u.Id == Id)
                .ExecuteUpdateAsync(s => s.SetProperty(u => u.Login, Login)
                                          .SetProperty(u => u.Password, Password)
                                          .SetProperty(u => u.FullName, FullName)
                                          .SetProperty(u => u.Email, Email)
                                          .SetProperty(u => u.ModifyDate, DateTime.Now));
        }
        public async Task Delete(int Id)
        {

            await _dbContext.Users
                .Where(u => u.Id == Id)
                .ExecuteDeleteAsync();
        }
    }
}
