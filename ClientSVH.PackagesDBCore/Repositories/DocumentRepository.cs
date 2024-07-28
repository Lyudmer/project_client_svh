
using ClientSVH.PackagesDBCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClientSVH.PackagesDBCore.Repositories
{
    public class DocumentRepository
    {
        private readonly PackagesDBContext _dbContext;
        public DocumentRepository(PackagesDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(int PkgId, Document Docs)
        {
            Docs = new Document() { Pid = PkgId };

            await _dbContext.AddAsync(Docs);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Document>> Get()
        {
            return await _dbContext.Document
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .ToListAsync();
        }
        
        public async Task<Document?> GetById(int id)
        {
            return await _dbContext.Document
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Document>> GetByFilter(int pid)
        {
            var query = _dbContext.Document
                .AsNoTracking();
            if (pid > 0)
            { query = query.Where(p => p.Pid == pid); }

            return await query.ToListAsync();
        }
        public async Task<List<Document>> GetByPage(int page, int page_size)
        {
            return await _dbContext.Document
                .AsNoTracking()
                .Skip((page - 1) * page_size)
                .Take(page_size)
                .ToListAsync();
        }
        public async Task Update(int Id)
        {
            await _dbContext.Document
                .Where(p => p.Id == Id)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.ModifyDate, DateTime.Now));
        }
        public async Task Delete(int Id)
        {

            await _dbContext.Document
                .Where(u => u.Id == Id)
                .ExecuteDeleteAsync();
        }
    }
}
