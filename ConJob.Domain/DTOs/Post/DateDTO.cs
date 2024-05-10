﻿using ConJob.Entities.Validation;
using System.ComponentModel.DataAnnotations;

namespace ConJob.Domain.DTOs.Post
{
    public class DateDTO
    {
        [DataType(DataType.Date)]
        [DateNotInTheFuture]
        [DateRange("end_date")]
        public DateTime? start_date { get; set; }
        [DataType(DataType.Date)]
        [DateNotInTheFuture]
        public DateTime? end_date { get; set; }
    }
}
