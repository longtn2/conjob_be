using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Post
{
    public enum FileEnum
    {
        Video,
        Img
    }
    public class PostDTO
    {
        public string title { get; set; }
        public string caption { get; set; }
        public string author { get; set; }
        public FileEnum type_file { get; set; }
        public string name_file { get; set; }
        public string url_file { get; set; }

    }
}
