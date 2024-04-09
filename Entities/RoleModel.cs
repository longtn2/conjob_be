﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConJob.Entities
{
    public class RoleModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; } = string.Empty;

        public byte RoleAccessLevel { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRoleModel> UserRoles { get; set; }
    }
}
