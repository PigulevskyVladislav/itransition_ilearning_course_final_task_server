﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinalTaskServer.Models
{
    [Table("category")]
    public class Collection
    {
        [Column("category_id")]
        public int id { get; set; }
        [Column("category_name")]
        public string name { get; set; }
        [Column("specification")]
        public string description { get; set; }
        [Column("picture")]
        public string picture { get; set; }
        [Column("extra_field_name")]
        public string extra_field_name { get; set; }
        [Column("category_type_id"), ForeignKey("category_type_id")]
        public int type_id { get; set; }
        [Column("client_id"), ForeignKey("client_id")]
        public int user_id { get; set; }
    }
}
