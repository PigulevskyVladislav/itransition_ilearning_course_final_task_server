using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinalTaskServer.Models
{
    [Table("comment")]
    public class Comment
    {
        [Column("comment_id")]
        public int id { get; set; }
        [Column("comment_text")]
        public string text { get; set; }
        [Column("item_id"), ForeignKey("item_id")]
        public int item_id { get; set; }
    }
}
