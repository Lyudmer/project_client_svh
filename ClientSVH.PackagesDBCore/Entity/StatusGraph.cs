using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClientSVH.PackagesDBCore.Entity
{
    public class StatusGraph
    {
        public int oldst { get; set; }
        public int newst { get; set; }
        public string? maskbit { get; set; } 
        public int StatusId { get; set; }
        public Status? Status { get; set; }
  
    }

}
