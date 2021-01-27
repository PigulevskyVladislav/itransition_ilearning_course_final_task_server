using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTaskServer.Models
{
    [Table("view_category_type_en")]
    public class CollectionType
    {
        [Column("category_type_id")]
        public int id { get; set; }
        [Column("category_type_name")]
        public string name { get; set; }
    }
}
