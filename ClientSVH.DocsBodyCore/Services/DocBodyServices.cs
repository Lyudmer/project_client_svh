using ClientSVH.DocsBodyCore.Entity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClientSVH.DocsBodyCore.Services
{
    public class DocBodyServices
    {
        
        private readonly IMongoCollection<DocBody> _docBodyCollection;

        public DocBodyServices(
            IOptions<DocsBodyDBConnectionSettings> DocBodyDBSettings)
        {
            var mongoClient = new MongoClient(
                DocBodyDBSettings.Value.MongoDBContext);

            var mongoDatabase = mongoClient.GetDatabase(
               DocBodyDBSettings.Value.DatabaseName);

            _docBodyCollection = mongoDatabase.GetCollection<DocBody>(
                DocBodyDBSettings.Value.DBCollectionName);
        }

        public async Task<List<DocBody>> GetAsync() =>
            await _docBodyCollection.Find(_ => true).ToListAsync();

        public async Task<DocBody?> GetAsync(int id) =>
            await _docBodyCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<DocBody?> GetAsync(Guid Docid) =>
           await _docBodyCollection.Find(x => x.DocId == Docid).FirstOrDefaultAsync();

        public async Task CreateAsync(DocBody newDocBody) =>
            await _docBodyCollection.InsertOneAsync(newDocBody);

        public async Task UpdateAsync(int id, DocBody updatedDocBody) =>
            await _docBodyCollection.ReplaceOneAsync(x => x.Id == id, updatedDocBody);
        public async Task UpdateAsync(Guid Docid, DocBody updatedDocBody) =>
           await _docBodyCollection.ReplaceOneAsync(x => x.DocId == Docid, updatedDocBody);
        public async Task RemoveAsync(int id) =>
            await _docBodyCollection.DeleteOneAsync(x => x.Id == id);
        public async Task RemoveAsync(Guid Docid) =>
            await _docBodyCollection.DeleteOneAsync(x => x.DocId == Docid);
    }
}
