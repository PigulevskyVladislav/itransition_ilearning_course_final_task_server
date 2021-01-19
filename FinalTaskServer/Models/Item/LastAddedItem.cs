using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTaskServer.Models
{
    [Table("view_item_category_top10_desc")]
    public class LastAddedItem
    {
        [Column("item_id")]
        public int id { get; set; }
        [Column("item_name")]
        public string name { get; set; }
        [Column("category_name")]
        public string collection_name { get; set; }
    }
}
