using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTaskServer.Models
{
    [Table("client")]
    public class Client
    {
        [Column("client_id")]
        public int id { get; set; }
        [Column("client_login")]
        public string login { get; set; }
        public string email { get; set; }
        [Column("client_password")]
        public string password { get; set; }
        [Column("is_admin")]
        public bool isAdmin { get; set; }
        [Column("is_light")]
        public bool isLight { get; set; }
    }
}
