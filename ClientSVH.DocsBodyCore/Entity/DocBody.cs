using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClientSVH.DocsBodyCore.Entity
{
    public class DocBody
    {
        [BsonElement("body_id")]
        public int Id { get; set; }
        [BsonElement("create_date")]
        public DateTime CreateDate { get; set; }

        [BsonElement("doc_id")]
        public Guid DocId { get; set; }
        
        [BsonElement("doc_body")]
        public string DocText { get; set; } = null!;

    }
}
