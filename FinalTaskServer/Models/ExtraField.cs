using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTaskServer.Models
{
    [Table("view_extra_field_of_item")]
    public class ExtraField
    {
        [Column("item_id")]
        public int id { get; set; }
        [Column("field_name")]
        public string name { get; set; }
        [Column("field_value")]
        public string value { get; set; }
    }
}
