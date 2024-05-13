
using ConJob.Domain.DTOs.Post;

namespace ConJob.Domain.Helper
{
    public static class ConvertFileType
    {
        public static FileEnum Convert(string type)
        {
            switch (type.ToLower())
            {
                case "jpg":
                case "jpeg":
                case "png":
                case "gif":
                    return FileEnum.Img;
                case "mp4":
                case "avi":
                case "mov":
                    return FileEnum.Video;
                default:
                    throw new ArgumentException("Unsupported file type");
            }
        }
    }
}
