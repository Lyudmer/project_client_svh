using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientSVH.PackagesDBCore.Entity
{
    public class Status
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public bool RunWf { get; set; }
        public bool MkRes { get; set; }
        public int oldst { get; set; }
        public int newst { get; set; }
        public StatusGraph? StatusGraph { get; set; }
        public int pid { get; set; }
        public Package? Package { get; set; }
    }
}
