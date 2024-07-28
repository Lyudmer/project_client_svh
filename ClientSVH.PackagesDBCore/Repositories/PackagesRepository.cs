using ClientSVH.PackagesDBCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClientSVH.PackagesDBCore.Repositories
{
    public class PackagesRepository
    {
        private readonly PackagesDBContext _dbContext;
        public PackagesRepository(PackagesDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(int UserId, Package package)
        {
            package = new Package() { UserId= UserId };

            await _dbContext.AddAsync(package);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Package>> Get()
        {
            return await _dbContext.Packages
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .ToListAsync();
        }
        public async Task<List<Package>> GetWithDoc()
        {
            return await _dbContext.Packages
                .AsNoTracking()
                .Include(p => p.Documents)
                .ToListAsync();
        }
        public async Task<Package?> GetById(int id)
        {
            return await _dbContext.Packages
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Package>> GetByFilter(int userid , int status)
        {
            var query = _dbContext.Packages.AsNoTracking();
            if (userid>0)
            { query = query.Where(p => p.UserId==userid); }
            if (status>-1)
            { query = query.Where(p => p.StatusId==status); }

            return await query.ToListAsync();
        }
        public async Task<List<Package>> GetByPage(int page, int page_size)
        {
            return await _dbContext.Packages
                .AsNoTracking()
                .Skip((page - 1) * page_size)
                .Take(page_size)
                .ToListAsync();
        }
        public async Task Update(int Id, int status)
        {
            await _dbContext.Packages
                .Where(p => p.Id == Id)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.StatusId, status)
                                          .SetProperty(p => p.ModifyDate, DateTime.Now));
        }
        public async Task Delete(int Id)
        {
            await _dbContext.Packages
                .Where(u => u.Id == Id)
                .ExecuteDeleteAsync();
        }
    }
}
