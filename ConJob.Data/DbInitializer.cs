using BCrypt.Net;
using ConJob.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<UserModel>().HasData(
                   new UserModel()
                   {
                       id = 6,
                       first_name = "Admin",
                       last_name = "Dat",
                       email = "admin@com.com",
                       phone_number = "0335487991",
                       password = BCrypt.Net.BCrypt.HashPassword("123ABCabc!"),
                       address ="Hue",
                       

                       
                   }
                   /*new UserModel()
                   {
                       Id = 2,
                       FirstName = "Fawnia",
                       LastName = "Alexandros",
                       Email = "apeacocke1@google.ca",
                       PhoneNumber = "0354579415",
                       Password = "c52c635d98738ff357b13d9e4368aff6"
                   },
                   new UserModel()
                   {
                       Id = 3,
                       FirstName = "Cazzie",
                       LastName = "Pancoast",
                       Email = "cpancoast2@wsj.com",
                       PhoneNumber = "0354596415",
                       Password = "7f45928bce3ba52d77dee0cf1a8bbfdf"
                   }
*/

            );

            modelBuilder.Entity<RoleModel>().HasData(
                new RoleModel()
                {
                    id = 1,
                    role_name = "Admin",
                    role_description = "Là admin cuyền lực."
                },
                new RoleModel()
                {
                    id = 2,
                    role_name = "TimViec",
                    role_description = "Là nole tư bản đi tìm kiếm miếng cơm manh áo."
                },
                new RoleModel()
                {
                    id = 3,
                    role_name = "PhatViec",
                    role_description = "Là tư bản đi kiếm những con chiêng ngoan đạo."
                }
               );
            modelBuilder.Entity<UserRoleModel>().HasData(
                new UserRoleModel()
                {
                    id = 1,
                    role_id = 1,
                    user_id = 6,
                });
        }
    }
}
