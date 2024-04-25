using ConJob.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Storage
{
    public class S3Helper : IS3Helper
    {
        private readonly IS3Services _s3Services;
        
        public S3Helper(IS3Services s3Services)
        {
            _s3Services = s3Services;
        }

        public string getPesignedURL(string file_path)
        {
            return _s3Services.PresignedGet(file_path).Data.url;
        }
    }
}
