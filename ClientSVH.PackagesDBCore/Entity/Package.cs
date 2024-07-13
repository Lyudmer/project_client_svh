using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClientSVH.DataAccess.Entity
{
    public class Package
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
       
        public string? UUId { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Document> Documents { get; set; } = [];

        public int StatusId { get; set; }
        public Status? Status { get; set; }
    }
}
