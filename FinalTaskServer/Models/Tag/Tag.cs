using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTaskServer.Models
{
    [Table("tag")]
    public class Tag
    {
        [Column("tag_id")]
        public int id { get; set; }
        [Column("tag_name")]
        public string name { get; set; }
    }
}
