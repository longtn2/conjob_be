using ConJob.Entities;
using System.ComponentModel.DataAnnotations;

namespace ConJob.Domain.DTOs.User
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string? Avatar { get; set; }

        public List<RoleModel> Roles { get; set; }
    }
}
