﻿using System.ComponentModel.DataAnnotations;

namespace ConJob.Domain.DTOs.Authentication
{
    public class PasswordDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must contain at least 8 character")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password does not meet requirement! Atleast 8 charactor, include: 1 UpperCase, 1 LowerCase, 1 Numberic, 1 SpecialCharactor.")]
        public string password { get; set; }
    }
}
