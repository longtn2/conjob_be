using ConJob.Entities;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<JobModel>().HasData(
               new JobModel()

               {

                   id = 1,

                   title = "Đây là công việc về media",

                   description = "photograper làm để chụp ảnh cá xấu đang ăn",

                   budget = 2000,

                   job_type = job_typeenum.fulltime,

                   location = "12 Đường Nguyễn Văn Linh, Phường Hải Châu, Quận Hải Châu, Thành phố Đà Nẵng",

                   expired_day = new DateTime(2024, 4, 30),

                   quantity = 20,

                   status = 1,

                   user_id = 3,

               },
               new JobModel()

               {

                   id = 2,

                   title = "Đây là công việc liên quan đến Backend",

                   description = "Code dự án Web trong 2 tháng",

                   budget = 5000,

                   job_type = job_typeenum.fulltime,

                   location = "45 Lê Lợi, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh",

                   expired_day = new DateTime(2024, 4, 30),

                   quantity = 1,

                   status = 0,

                   user_id = 5,

               },
               new JobModel()
               {
                   id = 3,
                   title = "Nhà ảnh độc lập từ xa",
                   description = "Tìm kiếm nhà ảnh độc lập để chụp hình cho đời sống dưới biển.",
                   budget = 2000,
                   job_type = job_typeenum.fulltime,
                   location = "78 Đường Lý Thường Kiệt, Phường Văn Miếu, Quận Đống Đa, Thành phố Hà Nội",
                   expired_day = new DateTime(2024, 4, 30),
                   quantity = 20,
                   status = 0,
                   user_id = 3,
               },
               new JobModel()
               {
                   id = 4,
                   title = "Lập trình viên Backend toàn thời gian",
                   description = "Phát triển dự án web trong 2 tháng.",
                   budget = 5000,
                   job_type = job_typeenum.fulltime,
                   location = "23 Phố Hàng Gai, Quận Hoàn Kiếm, Thành phố Hà Nội",
                   expired_day = new DateTime(2024, 4, 30),
                   quantity = 1,
                   status = 1,
                   user_id = 4,
               },
               new JobModel()
               {
                   id = 5,
                   title = "Biên tập video bán thời gian",
                   description = "Chỉnh sửa video cho các dự án khác nhau.",
                   budget = 2500,
                   job_type = job_typeenum.parttime,
                   location = "56 Đường Nguyễn Huệ, Phường Phạm Ngũ Lão, Quận 1, Thành phố Hồ Chí Minh",
                   expired_day = new DateTime(2024, 5, 20),
                   quantity = 8,
                   status = 1,
                   user_id = 5,
               },
               new JobModel()
               {
                   id = 6,
                   title = "Người viết nội dung tại chỗ",
                   description = "Tạo ra nội dung hấp dẫn cho blog của công ty.",
                   budget = 1200,
                   job_type = job_typeenum.onsite,
                   location = "34 Phố Hàng Bông, Quận Hoàn Kiếm, Thành phố Hà Nội",
                   expired_day = new DateTime(2024, 5, 25),
                   quantity = 12,
                   status = 0,
                   user_id = 3,
               },
               new JobModel()
               {
                   id = 7,
                   title = "Phát triển viên RESTful API kết hợp",
                   description = "87 Đường Hai Bà Trưng, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh",
                   budget = 4000,
                   job_type = job_typeenum.hybrid,
                   location = "101 Đường Hùng Vương, Phường Nguyễn Du, Quận 1, Thành phố Hồ Chí Minh",
                   expired_day = new DateTime(2024, 5, 18),
                   quantity = 1,
                   status = 1,
                   user_id = 2,
               },
               new JobModel()
               {
                   id = 8,
                   title = "Thiết kế đồ họa tự do",
                   description = "Tạo ra các thiết kế đồ họa cho các khách hàng khác nhau theo cách tự do.",
                   budget = 3000,
                   job_type = job_typeenum.freelance,
                   location = "29 Đường Lê Lai, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh",
                   expired_day = new DateTime(2024, 5, 22),
                   quantity = 1,
                   status = 1,
                   user_id = 4,
               },
               new JobModel()
               {
                   id = 9,
                   title = "Kỹ sư phần mềm toàn thời gian",
                   description = "Phát triển ứng dụng phần mềm toàn thời gian cho một công ty công nghệ.",
                   budget = 6000,
                   job_type = job_typeenum.fulltime,
                   location = "17 Đường Lý Tự Trọng, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh",
                   expired_day = new DateTime(2024, 5, 30),
                   quantity = 1,
                   status = 0,
                   user_id = 3,
               },
               new JobModel()
               {
                   id = 10,
                   title = "Quản lý truyền thông xã hội từ xa",
                   description = "Quản lý tài khoản truyền thông xã hội từ xa cho một công ty tiếp thị.",
                   budget = 1800,
                   job_type = job_typeenum.remote,
                   location = "63 Phố Hàng Trống, Quận Hoàn Kiếm, Thành phố Hà Nội",
                   expired_day = new DateTime(2024, 5, 20),
                   quantity = 1,
                   status = 1,
                   user_id = 5,
               },
               new JobModel()
               {
                   id = 11,
                   title = "Người tạo nội dung bán thời gian",
                   description = "Tạo nội dung bán thời gian cho các nền tảng trực tuyến khác nhau.",
                   budget = 1500,
                   job_type = job_typeenum.parttime,
                   location = "8 Phố Hàng Điếu, Quận Hoàn Kiếm, Thành phố Hà Nội",
                   expired_day = new DateTime(2024, 5, 15),
                   quantity = 10,
                   status = 0,
                   user_id = 2,
               },
               new JobModel()
               {
                   id = 12,
                   title = "Chuyên gia tiếp thị kết hợp",
                   description = "Phát triển và triển khai các chiến lược tiếp thị với khả năng làm việc từ xa.",
                   budget = 3000,
                   job_type = job_typeenum.hybrid,
                   location = "72 Đường Trần Hưng Đạo, Phường Phan Chu Trinh, Quận Hoàn Kiếm, Thành phố Hà Nội",
                   expired_day = new DateTime(2024, 5, 18),
                   quantity = 1,
                   status = 1,
                   user_id = 3,
               },
               new JobModel()
               {
                   id = 13,
                   title = "Thiết kế UI/UX tại chỗ",
                   description = "Thiết kế giao diện người dùng và trải nghiệm tại chỗ cho một công ty phần mềm.",
                   budget = 3500,
                   job_type = job_typeenum.onsite,
                   location = "39 Đường Lê Thánh Tôn, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh",
                   expired_day = new DateTime(2024, 5, 25),
                   quantity = 1,
                   status = 0,
                   user_id = 4,
               },
               new JobModel()
               {
                   id = 14,
                   title = "Người viết bài tự do",
                   description = "Viết bài cho các khách hàng khác nhau theo cách tự do.",
                   budget = 2000,
                   job_type = job_typeenum.freelance,
                   location = "20 Phố Hàng Bài, Quận Hoàn Kiếm, Thành phố Hà Nội",
                   expired_day = new DateTime(2024, 5, 22),
                   quantity = 1,
                   status = 1,
                   user_id = 5,
               },
               new JobModel()
               {
                   id = 15,
                   title = "Trợ lý ảo bán thời gian",
                   description = "Hỗ trợ các nhiệm vụ hành chính bán thời gian cho một công ty từ xa.",
                   budget = 1000,
                   job_type = job_typeenum.parttime,
                   location = "54 Đường Hồ Tùng Mậu, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh",
                   expired_day = new DateTime(2024, 5, 20),
                   quantity = 5,
                   status = 0,
                   user_id = 2,
               },
               new JobModel()
               {
                   id = 16,
                   title = "Quản lý dự án kết hợp",
                   description = "Quản lý các dự án với khả năng làm việc từ xa và tại chỗ.",
                   budget = 4500,
                   job_type = job_typeenum.hybrid,
                   location = "95 Đường Đề Thám, Phường Phạm Ngũ Lão, Quận 1, Thành phố Hồ Chí Minh",
                   expired_day = new DateTime(2024, 5, 18),
                   quantity = 1,
                   status = 1,
                   user_id = 3,
               },
               new JobModel()
               {
                   id = 17,
                   title = "Nhà ảnh tự do",
                   description = "Chụp ảnh cưới cho cặp đôi tại Hà Nội.",
                   budget = 3000,
                   job_type = job_typeenum.freelance,
                   location = "41 Phố Hàng Trống, Quận Hoàn Kiếm, Thành phố Hà Nội",
                   expired_day = new DateTime(2024, 5, 22),
                   quantity = 1,
                   status = 0,
                   user_id = 4,
               },
               new JobModel()
               {
                   id = 18,
                   title = "Phát triển viên ứng dụng di động toàn thời gian",
                   description = "Phát triển ứng dụng di động cho một công ty khởi nghiệp.",
                   budget = 5000,
                   job_type = job_typeenum.fulltime,
                   location = "68 Đường Lê Lợi, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh",
                   expired_day = new DateTime(2024, 5, 30),
                   quantity = 1,
                   status = 0,
                   user_id = 5,
               },
               new JobModel()
               {
                   id = 19,
                   title = "Biên tập viên phim tự do",
                   description = "Biên tập video quảng cáo cho các doanh nghiệp tại Hà Nội.",
                   budget = 2500,
                   job_type = job_typeenum.freelance,
                   location = "25 Đường Lý Thường Kiệt, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh",
                   expired_day = new DateTime(2024, 5, 20),
                   quantity = 3,
                   status = 0,
                   user_id = 3,
               },
               new JobModel()
               {
                   id = 20,
                   title = "Nhà thiết kế đồ họa toàn thời gian",
                   description = "Thiết kế đồ họa cho các dự án web và in ấn.",
                   budget = 4000,
                   job_type = job_typeenum.fulltime,
                   location = "10 Đường Trần Phú, Phường Lê Lợi, Thành phố Vinh, Tỉnh Nghệ An",
                   expired_day = new DateTime(2024, 5, 25),
                   quantity = 2,
                   status = 1,
                   user_id = 2,
               }
        );
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
                   is_email_confirmed = true,
                   avatar= "https://i.pinimg.com/originals/27/0c/be/270cbeb639f6d0ed64f3106daaeccc1d.jpg"

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
                   is_email_confirmed = true,
                   avatar = "https://th.bing.com/th/id/OIP.MbAE6jT-VnWsVr9ANrkYNwHaKw?rs=1&pid=ImgDetMain"


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
                   is_email_confirmed = true,
                   avatar = "https://th.bing.com/th/id/R.47e446cab641c16b2a6f8c9db520ee19?rik=0vd8lTgoDpgUzQ&pid=ImgRaw&r=0"

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
                   is_email_confirmed = true,
                   avatar = "https://th.bing.com/th/id/OIP.-Xu8PRNaVrwqZ1J-f4E16wHaHa?w=1200&h=1200&rs=1&pid=ImgDetMain"

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
                   is_email_confirmed = true,
                   avatar = "https://th.bing.com/th/id/OIP.-q9JRr6eAAyyBL3s-3g1PgHaKt?rs=1&pid=ImgDetMain"

               }
        );
            modelBuilder.Entity<RoleModel>().HasData(
                   new RoleModel()

                   {

                       id = 1,

                       role_name = "Admin",

                       role_description = "manage it all"

                   },
                   new RoleModel()

                   {

                       id = 2,

                       role_name = "Job Seeker",

                       role_description = "They are people looking for work"

                   },
                   new RoleModel()

                   {

                       id = 3,

                       role_name = "Job Giver",

                       role_description = "They are someone who goes to work"

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
                      to_user_id = 3,
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
                  },
                  new NotificationModel()
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

                      url = "https://media.2dep.vn/upload/thucquyen/2022/05/19/dat-villa-la-ai-hot-tiktoker-9x-trieu-view-co-chuyen-tinh-xuyen-bien-gioi-voi-ban-gai-indonesia-social-1652941149.jpg",

                  },
                  new FileModel()

                  {

                      id = 2,

                      name = "anh thong soai ca",

                      type = FileEnum.Img,

                      url = "https://newsmd2fr.keeng.vn/tiin/archive/imageslead/2023/06/14/90_c373d5ac0433257417f21a0a5e07fa11.jpg",

                  },
                  new FileModel()
                  {
                      id = 3,

                      name = "justin",

                      type = FileEnum.Video,

                      url = "https://videos.pexels.com/video-files/6698049/6698049-uhd_3840_2160_25fps.mp4",
                  },
                  new FileModel()
                  {
                      id = 4,

                      name = "guiboss",

                      type = FileEnum.Img,

                      url = "https://cdn.eva.vn/upload/2-2020/images/2020-05-05/don-xin-viec-ba-dao-2-1588672247-395-width1214height806.jpg",
                  },
                  new FileModel()
                  {
                      id = 5,

                      name = "Xinnn",

                      type = FileEnum.Img,

                      url = "https://cdn.eva.vn/upload/2-2020/images/2020-05-05/don-xin-viec-ba-dao-1-1588672247-922-width610height813.jpg",
                  },
                  new FileModel()
                  {
                      id = 6,

                      name = "Xinviecti",

                      type = FileEnum.Video,

                      url = "https://videos.pexels.com/video-files/2084066/2084066-hd_1920_1080_24fps.mp4",
                  },
                  new FileModel()
                  {
                      id = 7,

                      name = "Diemyeu",

                      type = FileEnum.Video,

                      url = "https://videos.pexels.com/video-files/2795169/2795169-uhd_3840_2160_25fps.mp4",
                  },
                  new FileModel()
                  {
                      id = 8,

                      name = "DungDai",

                      type = FileEnum.Video,

                      url = "https://videos.pexels.com/video-files/3959712/3959712-uhd_4096_2160_25fps.mp4",
                  },
                  new FileModel()
                  {
                      id = 9,

                      name = "LonR",

                      type = FileEnum.Img,

                      url = "https://cdn.eva.vn/upload/2-2020/images/2020-05-05/don-xin-viec-ba-dao-6-1588672247-471-width1212height798.jpg",
                  },
                  new FileModel()
                  {
                      id = 10,

                      name = "NgonHonNYC",

                      type = FileEnum.Img,

                      url = "https://jobsgo.vn/blog/wp-content/uploads/2023/03/stt-tuyen-dung-hay-content-tuyen-dung-hai-huoc.png",
                  },
                  new FileModel()
                  {
                      id = 11,

                      name = "Bia",

                      type = FileEnum.Img,

                      url = "https://th.bing.com/th/id/OIP.HY0HMmxb_o1ri0wKsIq2jgHaHa?rs=1&pid=ImgDetMain",

                  },
                   new FileModel()
                   {
                       id = 12,
                       name = "Ảnh khỏa thân",
                       type = FileEnum.Img,
                       url = "https://th.bing.com/th/id/OIP.aVQAa1WSb_Ct4kzZpeCm7AHaHa?rs=1&pid=ImgDetMain",
                   },
                   new FileModel()
                   {
                       id = 13,
                       name = "Ngón giữa",
                       type = FileEnum.Img,
                       url = "https://toigingiuvedep.vn/wp-content/uploads/2021/12/anh-ngon-tay-giua-450x600.jpg",
                   },
                   new FileModel()
                   {
                       id = 14,
                       name = "Súng",
                       type = FileEnum.Img,
                       url = "https://videos.pexels.com/video-files/3223449/3223449-uhd_3840_2160_24fps.mp4",
                   },
                    new FileModel()
                    {
                        id = 15,
                        name = "Ảnh nhóm",
                        type = FileEnum.Img,
                        url = "https://th.bing.com/th/id/R.5f2c346baa2978dd9df6c4a2e093e00f?rik=VwvG7bfjVAc4bw&pid=ImgRaw&r=0",
                    },
                    new FileModel()
                    {
                        id = 16,
                        name = "Ảnh nữ",
                        type = FileEnum.Img,
                        url = "https://scontent.fdad3-4.fna.fbcdn.net/v/t39.30808-6/439864769_3640571656182795_4383749922632562270_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=5f2048&_nc_ohc=x-BvE_1KWXMAb4mSMIZ&_nc_ht=scontent.fdad3-4.fna&oh=00_AfCr0ciTDobk0kNf6V8TLjSk1OQB5afqkW-526xvn0JPsw&oe=662E6F0F",
                    },
                     new FileModel()
                     {
                         id = 17,
                         name = "Ảnh nữ",
                         type = FileEnum.Video,
                         url = "https://videos.pexels.com/video-files/9335837/9335837-hd_1920_1080_25fps.mp4 ",
                     }
            );
            modelBuilder.Entity<MessengerModel>().HasData(
                  new MessengerModel()

                  {

                      id = 1,

                      message_content = "ê tao có công việc này ngon nè ",

                      send_user_id = 2,

                      receive_user_id = 3,

                  },
                  new MessengerModel()

                  {

                      id = 2,

                      message_content = "Việc gì vậy?",

                      send_user_id = 3,

                      receive_user_id = 2,

                  },
                  new MessengerModel()

                  {

                      id = 3,

                      message_content = "Đi múa lân 2 ngày cho lân sư đoàn, giá cả thương lượng",

                      send_user_id = 2,

                      receive_user_id = 3,

                  },
                  new MessengerModel()

                  {

                      id = 4,

                      message_content = "Nghe cũng okela á.Tao muốn due giá là 200k cho 1 ngày . Mày chốt không",

                      send_user_id = 3,

                      receive_user_id = 2,

                  },
                  new MessengerModel()

                  {

                      id = 5,

                      message_content = "Oke thôi.2h ngày 12th 5 nhé ",

                      send_user_id = 2,

                      receive_user_id = 3,

                  },
                  new MessengerModel()

                  {

                      id = 6,

                      message_content = "oke chốt",

                      send_user_id = 3,

                      receive_user_id = 2,

                  }
            );
            modelBuilder.Entity<ApplicantModel>().HasData(
                new ApplicantModel()
                {
                    id = 1,
                    user_id = 2,
                    job_id = 1,
                    apply_date = new DateTime(2024, 4, 29),
                    status = "Đã nộp",
                },
                new ApplicantModel()
                {
                    id = 2,
                    user_id = 4,
                    job_id = 2,
                    apply_date = new DateTime(2024, 4, 29),
                    status = "Đã nộp",
                }
                );
            modelBuilder.Entity<PostModel>().HasData(
                new PostModel()
                {
                    id = 1,
                    caption = "Bạn là một nhiếp ảnh gia tài năng và đam mê việc ghi lại những khoảnh khắc độc đáo dưới nước? Chúng tôi đang tìm kiếm những nhà ảnh độc lập để ghi lại cuộc sống đa dạng dưới biển.",
                    user_id = 3,
                    job_id = 3,
                    file_id = 3,
                    title = "Nhà ảnh độc lập từ xa",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 2,
                    caption = "Bạn có kinh nghiệm trong lập trình và muốn thử thách bản thân với một dự án web trong vòng 2 tháng? Hãy tham gia vào đội ngũ của chúng tôi và đóng góp vào việc phát triển dự án!",
                    user_id = 3,
                    job_id = 2,
                    file_id = 2,
                    title = "Code dự án Web trong 2 tháng",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 3,
                    caption = "Bạn là một nhiếp ảnh gia tự do và đam mê việc ghi lại những khoảnh khắc đẹp của cặp đôi trong ngày trọng đại? Hãy tham gia vào đội ngũ của chúng tôi và tạo ra những bức ảnh cưới đẹp nhất cho khách hàng!",
                    user_id = 3,
                    job_id = 17,
                    file_id = 1,
                    title = "Nhà ảnh tự do",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
               {
                   id = 4,
                   caption = "Chúng tôi đang tìm kiếm một Lập trình viên Backend tài năng để tham gia vào dự án web và đóng góp vào việc phát triển trong 2 tháng.",
                   user_id = 3,
                   job_id = 4,
                   file_id = 10,
                   title = "Lập trình viên Backend toàn thời gian",
                   created_at = new DateTime(2024, 4, 29)
               },
                new PostModel()
               {
                   id = 5,
                   caption = "Bạn có khả năng chỉnh sửa video và muốn tham gia vào các dự án sáng tạo khác nhau? Hãy gia nhập đội ngũ của chúng tôi và đóng góp vào việc tạo ra video chất lượng cao!",
                   user_id = 3,
                   job_id = 5,
                   file_id = 9,
                   title = "Biên tập video bán thời gian",
                   created_at = new DateTime(2024, 4, 29)
               },
                new PostModel()
               {
                   id = 6,
                   caption = "Bạn có khả năng tạo ra nội dung sáng tạo và muốn thể hiện tài năng của mình trên blog của công ty? Hãy tham gia vào đội ngũ của chúng tôi và tạo ra những bài viết hấp dẫn!",
                   user_id = 3,
                   job_id = 11,
                   file_id = 8,
                   title = "Người viết nội dung tại chỗ",
                   created_at = new DateTime(2024, 4, 29)
               },
                new PostModel()
                {
                    id = 7,
                    caption = "Bạn có kỹ năng phát triển RESTful APIs và muốn làm việc từ xa? Chúng tôi đang tìm kiếm những Phát triển viên RESTful API kết hợp để đóng góp vào dự án web của chúng tôi.",
                    user_id = 3,
                    job_id = 7,
                    file_id = 7,
                    title = "Phát triển viên RESTful API kết hợp",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 8,
                    caption = "Bạn là một người sáng tạo và muốn tự do trong việc thiết kế đồ họa? Chúng tôi đang tìm kiếm Thiết kế đồ họa tự do để tạo ra các thiết kế độc đáo cho khách hàng.",
                    user_id = 3,
                    job_id = 8,
                    file_id = 6,
                    title = "Thiết kế đồ họa tự do",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                  {
                      id = 9,
                      caption = "Bạn là một kỹ sư phần mềm tài năng và muốn tham gia vào việc phát triển ứng dụng phần mềm toàn thời gian? Hãy tham gia vào đội ngũ của chúng tôi và đóng góp vào dự án công nghệ của chúng tôi.",
                      user_id = 3,
                      job_id = 9,
                      file_id = 5,
                      title = "Kỹ sư phần mềm toàn thời gian",
                      created_at = new DateTime(2024, 4, 29)
                  },
                new PostModel()
               {
                   id = 10,
                   caption = "Bạn có khả năng quản lý truyền thông xã hội và muốn làm việc từ xa? Hãy tham gia vào đội ngũ của chúng tôi và quản lý tài khoản truyền thông xã hội cho các chiến dịch tiếp thị của chúng tôi.",
                   user_id = 5,
                   job_id = 16,
                   file_id = 4,
                   title = "Quản lý truyền thông xã hội từ xa",
                   created_at = new DateTime(2024, 4, 29)
               },
                new PostModel()
               {
                   id = 11,
                   caption = "Bạn là một người sáng tạo và muốn tạo nội dung độc đáo cho các nền tảng trực tuyến? Chúng tôi đang tìm kiếm Người tạo nội dung bán thời gian để tham gia vào các dự án sáng tạo.",
                   user_id = 5,
                   job_id = 15,
                   file_id = 3,
                   title = "Người tạo nội dung bán thời gian",
                   created_at = new DateTime(2024, 4, 29)
               },
                new PostModel()
               {
                   id = 12,
                   caption = "Bạn là một chuyên gia tiếp thị sáng tạo và muốn tham gia vào việc phát triển các chiến lược tiếp thị? Chúng tôi đang tìm kiếm Chuyên gia tiếp thị kết hợp để đóng góp vào các dự án tiếp thị của chúng tôi.",
                   user_id = 5,
                   job_id = 12,
                   file_id = 2,
                   title = "Chuyên gia tiếp thị kết hợp",
                   created_at = new DateTime(2024, 4, 29)
               },
                new PostModel()
                {
                    id = 13,
                    caption = "Bạn có khả năng thiết kế giao diện người dùng và muốn làm việc tại chỗ? Chúng tôi đang tìm kiếm Thiết kế UI/UX tại chỗ để tham gia vào các dự án phần mềm.",
                    user_id = 5,
                    job_id = 14,
                    file_id = 1,
                    title = "Thiết kế UI/UX tại chỗ",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 14,
                    caption = "Bạn là một người viết bài có tài năng và muốn làm việc tự do? Chúng tôi đang tìm kiếm Người viết bài tự do để tạo ra nội dung chất lượng cho các khách hàng.",
                    user_id = 5,
                    job_id = 20,
                    file_id = 10,
                    title = "Người viết bài tự do",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 15,
                    caption = "Viết bài cho các khách hàng khác nhau theo cách tự do.",
                    user_id = 5,
                    job_id = 14,
                    file_id = 9,
                    title = "Tìm việc người viết bài tự do",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 16,
                    caption = "Tôi là một người đam mê sáng tạo và muốn tham gia vào lĩnh vực biên tập video. Tôi có kinh nghiệm trong chỉnh sửa video và mong muốn được góp phần vào các dự án sáng tạo. Rất mong được cơ hội làm việc cùng các bạn!",
                    user_id = 4,
                    job_id = 5,
                    file_id = 8,
                    title = "Biên tập video",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 17,
                    caption = "Tôi là một người đam mê sáng tạo và muốn tham gia vào lĩnh vực biên tập video. Tôi có kinh nghiệm trong chỉnh sửa video và mong muốn được góp phần vào các dự án sáng tạo. Rất mong được cơ hội làm việc cùng các bạn!",
                    user_id = 4,
                    job_id = 5,
                    file_id = 5,
                    title = "Biên tập video",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 18,
                    caption = "Tôi là một người đam mê viết lập trình và muốn tham gia vào lĩnh vực phát triển RESTful APIs. Tôi tự tin vào khả năng lập trình của mình và mong muốn được góp phần vào việc phát triển các dự án web. Rất mong nhận được cơ hội từ các nhà tuyển dụng!",
                    user_id = 4,
                    job_id = 7,
                    file_id = 4,
                    title = "Phát triển viên RESTful API",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 19,
                    caption = "Tôi là một người đam mê sáng tạo và muốn tham gia vào lĩnh vực biên tập video. Tôi có kinh nghiệm trong chỉnh sửa video và mong muốn được góp phần vào các dự án sáng tạo. Rất mong được cơ hội làm việc cùng các bạn!",
                    user_id = 4,
                    job_id = 5,
                    file_id = 5,
                    title = "Biên tập video",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 20,
                    caption = "Tôi là một người đam mê viết lập trình và muốn tham gia vào lĩnh vực phát triển RESTful APIs. Tôi tự tin vào khả năng lập trình của mình và mong muốn được góp phần vào việc phát triển các dự án web. Rất mong nhận được cơ hội từ các nhà tuyển dụng!",
                    user_id = 2,
                    job_id = 7,
                    file_id = 3,
                    title = "Phát triển viên RESTful API",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 21,
                    caption = "Tôi là một người đam mê viết lập trình và mong muốn có cơ hội tham gia vào các dự án phát triển ứng dụng di động. Tôi tự tin vào khả năng lập trình của mình và mong muốn được góp phần vào việc tạo ra các sản phẩm chất lượng. Rất mong nhận được sự quan tâm từ các nhà tuyển dụng!",
                    user_id = 2,
                    job_id = 18,
                    file_id = 2,
                    title = "Phát triển viên ứng dụng di động",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 22,
                    caption = "Tôi là một người đam mê viết lách và mong muốn có cơ hội làm việc trong lĩnh vực tạo nội dung. Tôi tự tin vào khả năng sáng tạo của mình và mong muốn được góp phần vào việc phát triển nội dung cho các dự án trực tuyến. Rất mong nhận được sự quan tâm và cơ hội từ các nhà tuyển dụng!",
                    user_id = 2,
                    job_id = 11,
                    file_id = 1,
                    title = "Người tạo nội dung",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 23,
                    caption = "Tôi là một người đam mê thiết kế đồ họa và mong muốn có cơ hội làm việc trong lĩnh vực này. Tôi tự tin vào khả năng sáng tạo của mình và mong muốn được góp phần vào việc tạo ra các thiết kế đẹp mắt cho các dự án web và in ấn. Rất mong nhận được cơ hội từ các nhà tuyển dụng!",
                    user_id = 2,
                    job_id = 20,
                    file_id = 10,
                    title = "Nhà thiết kế đồ họa",
                    created_at = new DateTime(2024, 4, 29)
                }, 
                new PostModel()
                {
                    id = 24,
                    caption = "Tôi là một người yêu thích viết lách và mong muốn có cơ hội làm việc trong lĩnh vực tạo nội dung. Tôi tự tin vào khả năng sáng tạo của mình và mong muốn được góp phần vào việc phát triển nội dung cho các dự án trực tuyến. Rất mong nhận được sự quan tâm và cơ hội từ các nhà tuyển dụng!",
                    user_id = 4,
                    job_id = 11,
                    file_id = 7,
                    title = "Người tạo nội dung",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 25,
                    caption = "Tôi là một lập trình viên có kinh nghiệm trong phát triển ứng dụng di động và đam mê công việc của mình. Tôi mong muốn có cơ hội tham gia vào các dự án phát triển ứng dụng di động và đóng góp vào việc tạo ra các sản phẩm chất lượng. Rất mong nhận được sự quan tâm từ các nhà tuyển dụng!",
                    user_id = 4,
                    job_id = 18,
                    file_id = 6,
                    title = "Phát triển viên ứng dụng di động",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 26,
                    caption = "Yêu cái đẹp",
                    user_id = 2,
                    job_id = 20,
                    file_id = 12,
                    title = "Nhà thẩm định hình thể",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 27,
                    caption = "Yêu nhậu nhẹt",
                    user_id = 2,
                    job_id = 20,
                    file_id = 11,
                    title = "Nhà thưởng ẩm thực",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 28,
                    caption = "Nghệ thuật tay",
                    user_id = 2,
                    job_id = 20,
                    file_id = 13,
                    title = "Nghệ thuật tay",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 29,
                    caption = "Hình ảnh mạnh mẽ",
                    user_id = 2,
                    job_id = 20,
                    file_id = 14,
                    title = "Hình ảnh mạnh mẽ",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 30,
                    caption = "Chúng ta là những người bạn thân ",
                    user_id = 2,
                    job_id = 20,
                    file_id = 15,
                    title = "Chúng ta là những người bạn thân , luôn luôn đồng hành cùng nhau",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 31,
                    caption = "Nghệ thuật lừa dối ánh trăng",
                    user_id = 2,
                    job_id = 20,
                    file_id = 15,
                    title = "Hình ảnh nghệ thuật",
                    created_at = new DateTime(2024, 4, 29)
                },
                new PostModel()
                {
                    id = 32,
                    caption = "Đem đến cho người dùng trải nghiệm tuyệt vời ",
                    user_id = 3,
                    job_id = 3,
                    file_id = 17,
                    title = "Mát xa bấm huyệt",
                    created_at = new DateTime(2024, 4, 29)
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
        }
    }
}
