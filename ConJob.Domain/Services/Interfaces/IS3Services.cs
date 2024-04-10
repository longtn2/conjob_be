using ConJob.Domain.DTOs.S3;
using ConJob.Domain.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IS3Services
    {
        public Task UploadImage(IFormFile file);
        public ServiceResponse<S3ResponseDTO> PresignedUpload(string file_name, string file_type, string user_id);
    }
}
