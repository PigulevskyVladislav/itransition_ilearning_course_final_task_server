using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinalTaskServer.Models
{
    [Table("item")]
    public class Item
    {
        [Column("item_id")]
        public int id { get; set; }
        [Column("item_name")]
        public string name { get; set; }
        [JsonIgnore]
        [Column("category_id"), ForeignKey("category_id")]
        public int collection_id { get; set; }
    }
}
