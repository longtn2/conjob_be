using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Post
{
    public class PostDetailsDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string caption { get; set; }
        public string author { get; set; }
        public FileEnum type_file { get; set; }
        public string name_file { get; set; }
        public string url_file { get; set; }
        public DateTime? created_at { get; set; }
        public int likes { get; set; }
        public bool is_deleted { get; set; }
        public bool is_actived { get; set; }
    }
}
