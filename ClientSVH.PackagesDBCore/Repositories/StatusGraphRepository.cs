using ClientSVH.PackagesDBCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClientSVH.PackagesDBCore.Repositories
{
    public class StatusGraphRepository
    {
        private readonly PackagesDBContext _dbContext;
        public StatusGraphRepository(PackagesDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<StatusGraph>> GetOld()
        {
            return await _dbContext.StatusGraph
                .AsNoTracking()
                .OrderBy(st => st.oldst)
                .ToListAsync();
        }
        public async Task<List<StatusGraph>> GetNew()
        {
            return await _dbContext.StatusGraph
                .AsNoTracking()
                .OrderBy(st => st.newst)
                .ToListAsync();
        }
        
        public async Task<List<StatusGraph>> GetByPage(int page, int page_size)
        {
            return await _dbContext.StatusGraph
                .AsNoTracking()
                .Skip((page - 1) * page_size)
                .Take(page_size)
                .ToListAsync();
        }
        public async Task Add(int oldst, int newst, string maskbit)
        {
            var StatusGraphEntity = new StatusGraph
            {
                oldst = oldst,
                newst = newst,
                maskbit = maskbit
            };
            await _dbContext.AddAsync(StatusGraphEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateOld(int oldst, int newst, string maskbit)
        {

            await _dbContext.StatusGraph
                .Where(u => u.oldst == oldst)
                .ExecuteUpdateAsync(s => s.SetProperty(u => u.newst, newst)
                                          .SetProperty(u => u.maskbit, maskbit));
        }
        public async Task UpdateNew(int oldst, int newst, string maskbit)
        {

            await _dbContext.StatusGraph
                .Where(u => u.newst == newst)
                .ExecuteUpdateAsync(s => s.SetProperty(u => u.oldst, oldst)
                                          .SetProperty(u => u.maskbit, maskbit));
        }
        public async Task Delete(int oldst,int newst)
        {

            await _dbContext.StatusGraph
                .Where(u => u.oldst == oldst)
                .Where(u => u.newst == newst)
                .ExecuteDeleteAsync();
        }
    }
}
