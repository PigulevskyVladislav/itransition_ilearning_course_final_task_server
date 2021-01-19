using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalTaskServer.Models
{
    [Table("items_tag")]
    public class ItemsTag
    {
        [Column("item_id")]
        public int item_id { get; set; }
        [Column("tag_id")]
        public int tag_id { get; set; }
    }
}
