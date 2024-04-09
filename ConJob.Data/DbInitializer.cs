using ConJob.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //modelBuilder.Entity<UserModel>().HasData(
            //       new UserModel() {
            //           Id = 1,
            //        FirstName = "Fawnia",
            //        LastName = "Szymanowski",
            //        Email = "fszymanowski0@com.com",
            //        PhoneNumber = "0335487991",
            //        Password = "74a14ea74c47ecdf30f940974dc9dc20"

            //       },
            //       new UserModel() {
            //           Id = 2,
            //           FirstName = "Fawnia",
            //           LastName = "Alexandros",
            //           Email = "apeacocke1@google.ca",
            //           PhoneNumber = "0354579415",
            //           Password = "c52c635d98738ff357b13d9e4368aff6"
            //       },
            //       new UserModel()
            //       {
            //           Id = 3,
            //           FirstName = "Cazzie",
            //           LastName = "Pancoast",
            //           Email = "cpancoast2@wsj.com",
            //           PhoneNumber = "0354596415",
            //           Password = "7f45928bce3ba52d77dee0cf1a8bbfdf"
            //       }
    

            //);

            modelBuilder.Entity<RoleModel>().HasData(
                new RoleModel()
                {
                    Id = 1,
                    RoleName = "Admin",
                    RoleAccessLevel = 5,
                    RoleDescription = "Là admin cuyền lực."
                },
                new RoleModel()
                {
                    Id = 2,
                    RoleName = "TimViec",
                    RoleAccessLevel = 1,
                    RoleDescription = "Là nole tư bản đi tìm kiếm miếng cơm manh áo."
                },
                new RoleModel()
                {
                    Id = 3,
                    RoleName = "PhatViec",
                    RoleAccessLevel = 1,
                    RoleDescription = "Là tư bản đi kiếm những con chiêng ngoan đạo."
                }
               );
        }
    }
}
