using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTaskServer.Models
{
    [Table("item")]
    public class Item
    {
        [Column("item_id")]
        public int id { get; set; }
        [Column("item_name")]
        public string name { get; set; }
    }
}
