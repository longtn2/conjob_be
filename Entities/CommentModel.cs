﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConJob.Entities
{
    public class CommentModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string content { get; set; }
        public int user_id { get; set; }
        [JsonIgnore]
        [ForeignKey("user_id")]
        public UserModel users { get; set; }
        public int post_id { get; set; }
        [JsonIgnore]
        [ForeignKey("post_id")]
        public PostModel posts { get; set; }

    }
}
