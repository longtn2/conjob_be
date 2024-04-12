using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Post
{
    public class PostDetailsDTO
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public FileEnum Type_File { get; set; }
        public string NameFile { get; set; }
    }
}
