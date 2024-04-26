
using Asp.Versioning.ApplicationModels;
using System.ComponentModel.DataAnnotations;

namespace ConJob.Domain.DTOs.Post
{
    public class DateDTO
    {
        [DataType(DataType.Date)]
        public DateTime? start_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime? end_date { get; set;}
    }
}
