using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ClientSVH.DataAccess.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }
        public ICollection<Package> Packages { get; set; } = new List<Package>();
       
    }
}
