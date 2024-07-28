using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientSVH.PackagesDBCore.Entity
{ 
    public class Document
    {
        public int Id { get; set; }
        public Guid DocId { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public string? Number { get; set; }
        public DateTime DocDate { get; set; }
        public string? ModeCode { get; set; }
        public int SizeDoc { get; set; }
        public string? Idmd5 { get; set; }   
        public string? IdSha256 { get; set; }

        public int Pid { get; set; }
        public Package? Package { get; set; }
    }
}
