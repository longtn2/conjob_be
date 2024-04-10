using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConJob.Entities
{
    public enum FileEnum
    {
        Video, 
        Img
    }
    public class FileModel:BaseModel
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression("\\w+.(jpg|mp4){1}")]
        public string Name { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FileEnum Type { get; set; }
        public double Size { get; set; }

    }
}
