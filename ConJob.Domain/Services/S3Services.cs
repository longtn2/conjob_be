using Amazon.Runtime;
using Amazon.S3.Transfer;
using Amazon.S3;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConJob.Entities.Config;
using Microsoft.Extensions.Options;
using ConJob.Domain.Services.Interfaces;

namespace ConJob.Domain.Services
{
    public class S3Services: IS3Services
    {
        private readonly S3Settings _w3Settings;


        public S3Services(IOptions<S3Settings> w3Settings)
        {
            _w3Settings = w3Settings.Value;
        }
        public async Task UploadImage(IFormFile file)
        {
            var credentials = new BasicAWSCredentials(_w3Settings.AccessKey, _w3Settings.SecretKey);
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.SAEast1
            };
            using var client = new AmazonS3Client(credentials, config);
            await using var newMemoryStream = new MemoryStream();
            file.CopyTo(newMemoryStream);

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = newMemoryStream,
                Key = file.FileName,
                BucketName = _w3Settings.BucketName,
                CannedACL = S3CannedACL.PublicRead
            };

            var fileTransferUtility = new TransferUtility(client);
            await fileTransferUtility.UploadAsync(uploadRequest);
        }
    }
}
