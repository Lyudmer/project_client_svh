using ClientSVH.PackagesDBCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSVH.PackagesDBCore.Repositories
{
    public class StatusRepositoty
    {
        private readonly PackagesDBContext _dbContext;
        public StatusRepositoty(PackagesDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Status>> Get()
        {
            return await _dbContext.Status
                .AsNoTracking()
                .OrderBy(st => st.Id)
                .ToListAsync();
        }
        public async Task<List<Status>> GetWithStatusGraph()
        {
            return await _dbContext.Status
                .AsNoTracking()
                .Include(s => s.StatusGraph)
                .ToListAsync();
        }
        public async Task<Status?> GetById(int id)
        {
            return await _dbContext.Status
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        
        public async Task<List<Status>> GetByPage(int page, int page_size)
        {
            return await _dbContext.Status
                .AsNoTracking()
                .Skip((page - 1) * page_size)
                .Take(page_size)
                .ToListAsync();
        }
        public async Task Add(int Id,string FullName, bool RunWf, bool MkRes)
        {
            var StatusEntity = new Status
            {
                Id = Id,
                FullName = FullName,
                RunWf = RunWf,
                MkRes = MkRes
            };
            await _dbContext.AddAsync(StatusEntity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(int Id, string FullName, bool RunWf, bool MkRes)
        {

            await _dbContext.Status
                .Where(u => u.Id == Id)
                .ExecuteUpdateAsync(s => s.SetProperty(u => u.FullName, FullName)
                                          .SetProperty(u => u.RunWf, RunWf)
                                          .SetProperty(u => u.MkRes, MkRes));
        }
        public async Task Delete(int Id)
        {

            await _dbContext.Status
                .Where(u => u.Id == Id)
                .ExecuteDeleteAsync();
        }
    }
}
