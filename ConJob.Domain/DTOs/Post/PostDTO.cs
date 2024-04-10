using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Post
{
    public enum ReactionEnum
    {
        like,
        heart,
        sad,
        slime,
        angry
    };
    public enum FileEnum
    {
        Video,
        Img
    }
    public class PostDTO
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public ReactionEnum Reaction { get; set; }
        public string Author { get; set; }
        public FileEnum Type_File { get; set; }
        public string NameFile { get; set; }

    }
}
