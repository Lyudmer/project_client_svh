using ClientSVH.DocsBodyCore.Services;
using ClientSVH.DocsBodyCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClientSVH.DocsBodyCore
{
    public class DocsBodyDBConnectionSettings
    {
          public string MongoDBContext { get; set; } = null!;
          public string DatabaseName { get; set; } = null!;
          public string DBCollectionName { get; set; } = null!;
       
    }
}
