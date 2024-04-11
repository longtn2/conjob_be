using ConJob.Entities;
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
        public string Caption { get; set; }
        public string Author { get; set; }
        public FileEnum Type_File { get; set; }
        public string NameFile { get; set; }

    }
}
