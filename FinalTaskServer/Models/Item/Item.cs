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
        [Column("extra_field")]
        public string extra_field { get; set; }
        [Column("category_id"), ForeignKey("category_id")]
        public int collection_id { get; set; }
    }
}
