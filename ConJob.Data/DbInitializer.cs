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
                   id = 1,

                   first_name = "Admin",

                   last_name = "Dat",

                   email = "admin@com.com",

                   phone_number = "0335487991",

                   password = BCrypt.Net.BCrypt.HashPassword("123ABCabc!"),

                   address = "Hue",
               },
               new UserModel()
               {
                   id = 2,

                   first_name = "Fawnia",

                   last_name = "Alexandros",

                   email = "apeacocke1@google.ca",

                   phone_number = "0354579415",

                   password = BCrypt.Net.BCrypt.HashPassword("123ABCabc!"),

                   address = "Hue",

               },

               new UserModel()

               {

                   id = 3,

                   first_name = "Cazzie",

                   last_name = "Pancoast",

                   email = "cpancoast2@wsj.com",

                   phone_number = "0354596415",

                   password = BCrypt.Net.BCrypt.HashPassword("123ABCabc!"),

                   address = "Hue",

               },

                new UserModel()

                {

                    id = 4,

                    first_name = "Marri",

                    last_name = "Dat",

                    email = "datmarri@google.ca",

                    phone_number = "0354579415",

                    password = BCrypt.Net.BCrypt.HashPassword("123ABCabc!"),

                    address = "Hue",

                },

                new UserModel()

                {

                    id = 5,

                    first_name = "Dat",

                    last_name = "khong chin",

                    email = "datkhongchin@google.ca",

                    phone_number = "0354579415",

                    password = BCrypt.Net.BCrypt.HashPassword("123ABCabc!"),

                    address = "Hue",

                }
                
                
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

                    user_id = 1,

             },
             new UserRoleModel()

             {

                    id = 2,

                    role_id = 2,

                    user_id = 2,

             },
             new UserRoleModel()
             {

                    id = 3,

                    role_id = 3,

                    user_id = 3,

             },
             new UserRoleModel()
             {

                     id = 4,

                     role_id = 2,

                     user_id = 4,
             },
             new UserRoleModel()
             {
                     id = 5,

                     role_id = 3,

                     user_id = 5,
             }
             );

            modelBuilder.Entity<FollowModel>().HasData(

                new FollowModel()
                {
                    id = 1,

                    from_user_id = 2,

                    to_user_id = 3,
                },
                 new FollowModel()
                 {

                     id = 2,

                     from_user_id = 2,

                     to_user_id = 4,
                 },
                 new FollowModel()
                 {

                     id = 3,

                     from_user_id = 3,

                     to_user_id = 4,
                 },
                 new FollowModel()
                 {
                     id = 4,

                     from_user_id = 3,

                     to_user_id = 5,
                 }
                );
            modelBuilder.Entity<SkillModel>().HasData(
                new SkillModel()
                {
                    id = 1,

                    name = "Content Creator",

                    description = "Content Creator là người sáng tạo nội dung cho các nền tảng như mạng xã hội, blog, website, YouTube, v.v. Họ có thể viết bài viết, quay video, chụp ảnh, livestream để thu hút người theo dõi và truyền tải thông điệp đến đông đảo người dùng",
                },
                new SkillModel()
                {
                    id = 2,

                    name = "Front-end developer",

                    description = "Viết mã HTML, CSS và JavaScript: Đây là những ngôn ngữ lập trình cơ bản để xây dựng giao diện web. HTML tạo cấu trúc cho trang web, CSS định dạng giao diện và JavaScript tạo tính năng tương tác cho người dùng.",
                },
                new SkillModel()
                {
                    id = 3,

                    name = "Fashion Model",

                    description = "Người mẫu ảnh là những người có ngoại hình ưa nhìn, vóc dáng cân đối, làn da khỏe đẹp và thần thái cuốn hút. Họ được đào tạo bài bản về cách tạo dáng, biểu cảm trước ống kính máy ảnh để có thể truyền tải thông điệp của nhiếp ảnh gia hoặc thương hiệu một cách hiệu quả nhất.",
                },
                new SkillModel()
                {
                    id = 4,

                    name = "Photograper",

                    description = "người sử dụng máy ảnh để ghi lại hình ảnh, khoảnh khắc, sự kiện, v.v. Họ sử dụng kỹ năng và óc sáng tạo để tạo ra những bức ảnh đẹp mắt, truyền tải thông điệp hoặc lưu giữ kỷ niệm.",
                },
                new SkillModel()
                {
                    id = 5,

                    name = "Dance",

                    description = "những người biểu diễn nghệ thuật múa, sử dụng chuyển động cơ thể, biểu cảm gương mặt và ngôn ngữ cơ thể để truyền tải thông điệp, cảm xúc và kể chuyện",
                },
                new SkillModel()
                {
                    id = 6,

                    name = "Music Producer",

                    description = "nhà sản xuất âm nhạc, hay còn được ví như người họa nên sản phẩm âm nhạc chất lượng."
                }
                );
            modelBuilder.Entity<Personal_skillModel>().HasData(
                new Personal_skillModel()
                {
                    id = 1,
                    exp = "2 năm ",
                    user_id = 3,
                    desciption = "Trong suốt 2 năm làm nghề thì tôi khá tự tin với tài năng của mình",
                    skill_id = 1,
                },
                new Personal_skillModel()
                {
                    id = 2,
                    exp = "3 năm ",
                    user_id = 2,
                    desciption = "I'am The Best",
                    skill_id = 2,
                },
                new Personal_skillModel()
                {
                    id = 3,
                    exp = "10 năm",
                    user_id = 3,
                    desciption = "Tôi là một người đa tài",
                    skill_id = 3,
                },
                new Personal_skillModel()
                {
                    id = 4,
                    exp = "từ lúc sinh ra ",
                    user_id = 4,
                    desciption = "Người có năng khiếu từ nhỏ , siêu vippro",
                    skill_id = 4,
                });
            modelBuilder.Entity<NotificationModel>().HasData(
                new NotificationModel()
                {
                    id = 1,
                    notifi_content = "node ",
                    is_accept = false,
                    status = false,
                    from_user_notifi_id = 2,
                },new NotificationModel()
                {
                    id = 2,
                    notifi_content = "node",
                    is_accept = false,
                    status = false,
                    from_user_notifi_id = 3,
                },
                new NotificationModel()
                {
                    id = 3,
                    notifi_content = "node",
                    is_accept = false,
                    status = false,
                    from_user_notifi_id = 4,

                 });
            modelBuilder.Entity<FileModel>().HasData(
                new FileModel()
                {
                    id = 1,

                    name = "anh datvila",

                    type = FileEnum.Img,

                    size = 100,

                    url = "https://media.2dep.vn/upload/thucquyen/2022/05/19/dat-villa-la-ai-hot-tiktoker-9x-trieu-view-co-chuyen-tinh-xuyen-bien-gioi-voi-ban-gai-indonesia-social-1652941149.jpg",

                },

                new FileModel()

                {

                    id = 2,

                    name = "anh thong soai ca",

                    type = FileEnum.Img,

                    size = 100,

                    url = "https://newsmd2fr.keeng.vn/tiin/archive/imageslead/2023/06/14/90_c373d5ac0433257417f21a0a5e07fa11.jpg",

                });

            modelBuilder.Entity<MessageModel>().HasData(

                new MessageModel()

                {

                    id = 1,

                    message_content = "ê tao có công việc này ngon nè ",

                    send_user_id = 2,

                    receive_user_id = 3,

                },

                new MessageModel()

                {

                    id = 2,

                    message_content = "Việc gì vậy?",

                    send_user_id = 3,

                    receive_user_id = 2,

                },

                new MessageModel()

                {

                    id = 3,

                    message_content = "Đi múa lân 2 ngày cho lân sư đoàn, giá cả thương lượng",

                    send_user_id = 2,

                    receive_user_id = 3,

                },

                new MessageModel()

                {

                    id = 4,

                    message_content = "Nghe cũng okela á.Tao muốn due giá là 200k cho 1 ngày . Mày chốt không",

                    send_user_id = 3,

                    receive_user_id = 2,

                },

                new MessageModel()

                {

                    id = 5,

                    message_content = "Oke thôi.2h ngày 12th 5 nhé ",

                    send_user_id = 2,

                    receive_user_id = 3,

                },

                new MessageModel()

                {

                    id = 6,

                    message_content = "oke chốt",

                    send_user_id = 3,

                    receive_user_id = 2,

                }

                );

            modelBuilder.Entity<CategoryModel>().HasData(

                new CategoryModel()

                {

                    id = 1,

                    name = "media",

                    description = "các ngành liên quan đến truyền thông",

                },

                new CategoryModel()

                {

                    id = 2,

                    name = "Programmer",

                    description = "Đây là cách gọi chung nhất cho người viết mã, sử dụng các ngôn ngữ lập trình để tạo ra các chương trình máy tính.",

                },

                new CategoryModel()

                {

                    id = 3,

                    name = "Content creator",

                    description = " Đây là cách gọi chung cho những người tạo ra nội dung, bao gồm bài viết, hình ảnh, video, âm nhạc, v.v. Nội dung này có thể được sử dụng cho mục đích giải trí, giáo dục, quảng cáo hoặc kinh doanh",

                }

                );

            modelBuilder.Entity<JobModel>().HasData(

                new JobModel()

                {

                    id = 1,

                    title = "Đây là công việc về media",

                    description = "photograper làm để chụp ảnh cá xấu đang ăn",

                    budget = 2000,

                    job_type = job_typeenum.fulltime,

                    location = "Bắc băng dương",

                    expired_day = new DateTime(2024, 4, 30),

                    quanlity = 20,

                    status = "gần đầy",

                    category_id = 1,

                    user_id = 3,

                },

                 new JobModel()

                 {

                     id = 2,

                     title = "Đây là công việc liên quan đến Backend",

                     description = "Code dự án Web trong 2 tháng",

                     budget = 5000,

                     job_type = job_typeenum.fulltime,

                     location = "Ấn độ dương",

                     expired_day = new DateTime(2024, 4, 30),

                     quanlity = 1,

                     status = "không một ai ",

                     category_id = 2,

                     user_id = 5,

                 });

            modelBuilder.Entity<ApplicantModel>().HasData(

                new ApplicantModel()

                {

                    id = 1,

                    user_id = 2,

                    job_id = 1,

                    apply_date = new DateTime(2024, 4, 29),

                    status = "Mới nộp",

                },

                new ApplicantModel()

                {

                    id = 2,

                    user_id = 4,

                    job_id = 2,

                    apply_date = new DateTime(2024, 4, 29),

                    status = "Mới nộp",

                }

                );

            modelBuilder.Entity<PostModel>().HasData(
                new PostModel()
                {
                    id = 1,

                    caption = "Là một người có trách nghiệm tôi luồn hoàn thành mọi việc một cách hoàn hảo",

                    user_id = 2,

                    job_id = 1,

                    file_id = 1,

                    title = "Luôn là người có trách nghiệm , I'am vippro",

                }, new PostModel()
                {
                    id = 2,

                    caption = "Là một người đỉnh cao tôi tự tin , khoe cá tính",

                    user_id = 5,

                    job_id = 2,

                    file_id = 2,

                    title = "Ai tuyển tôi không",
                }
                );
            modelBuilder.Entity<LikeModel>().HasData(

                new LikeModel()
                {
                    id = 1,

                    user_id = 4,

                    post_id = 1,

                },
                new LikeModel()
                {
                    id = 2,

                    user_id = 3,

                    post_id = 1,

                },
                new LikeModel()
                {
                    id = 3,
                    user_id = 5,
                    post_id = 1,
                }
                );
            modelBuilder.Entity<ReportModel>().HasData(
                new ReportModel()
                {
                    id = 1,
                    reason = "lừa đảo ",
                    post_id = 1,
                    user_id = 5,
                }
                );
            //modelBuilder.Entity<UserRoleModel>().HasData(
            //new UserRoleModel()
            //{
            //    id = 2,
            //    user_id = 6,
            //    role_id = 1,
            //});
        }
    }
}
