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
    public class NotificationModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string notifi_content {  get; set; }
        public bool status { get; set; }
        public bool is_accept { get; set; }
        public int from_user_notifi_id {  get; set; }
        [JsonIgnore]
        [ForeignKey("from_user_notifi_id")]
        public UserModel from_user_notification { get; set; }
        
    }
}
