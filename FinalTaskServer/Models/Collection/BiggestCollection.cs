using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTaskServer.Models
{
    [Table("view_category_biggest_top10")]
    public class BiggestCollection
    {
        [Column("category_id")]
        public int id { get; set; }
        [Column("category_name")]
        public string name { get; set; }
        [Column("item_count")]
        public int count { get; set; }
        [Column("specification")]
        public string description { get; set; }
    }
}
