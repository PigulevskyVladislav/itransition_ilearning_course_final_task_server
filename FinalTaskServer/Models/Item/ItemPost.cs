using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinalTaskServer.Models
{
    public class ItemPost
    {
        public Item item { get; set; }
        public int[] tagIds { get; set; }
    }
}
