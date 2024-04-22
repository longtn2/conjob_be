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
    public enum job_typeenum
    {
        remote,
        fulltime,
        parttime,
        onsite,
        hybrid,
        freelance
    };
    public class JobModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double budget { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public job_typeenum job_type { get; set; }
        public string location { get; set; }
        public DateTime expired_day { get; set; }
        public int quanlity { get; set; }
        public string status { get; set; }
        [JsonIgnore]
        public virtual ICollection<ApplicantModel> applicants { get; set; }
        [JsonIgnore]
        public virtual ICollection<PostModel> posts { get; set; }
        public int category_id { get; set; }
        [JsonIgnore]
        [ForeignKey("category_id")]
        public CategoryModel category { get; set; }
        public int user_id { get; set; }
        [JsonIgnore]
        [ForeignKey("user_id")]
        public UserModel user { get; set; }
    }
}
