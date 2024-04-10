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
using ConJob.Domain.Response;
using ConJob.Domain.DTOs.S3;
using Amazon.S3.Model;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using Amazon;
using System.Data.Entity.Core.Objects;

namespace ConJob.Domain.Services
{
    public class S3Services: IS3Services
    {
        private readonly S3Settings _w3Settings;


        public S3Services(IOptions<S3Settings> w3Settings)
        {
            _w3Settings = w3Settings.Value;
        }
        private string getPath(string file_name, string file_type, string user_id)
        {
            var result = String.Format(_w3Settings.PathUpload, user_id, file_type, file_name);
            return result;
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
        public ServiceResponse<S3ResponseDTO> PresignedUpload(string file_name, string file_type, string user_id)
        {
            ServiceResponse<S3ResponseDTO> serviceResponse = new ServiceResponse<S3ResponseDTO>();
            try
            {
                AWSConfigsS3.UseSignatureVersion4 = true;
                TimeSpan expirationTime = TimeSpan.FromMinutes(60);
                using var client = new AmazonS3Client(_w3Settings.AccessKey, _w3Settings.SecretKey, RegionEndpoint.SAEast1);
                var request = new GetPreSignedUrlRequest
                {
                    BucketName = _w3Settings.BucketName,
                    Key = getPath(file_name, file_type, user_id),
                    Expires = DateTime.UtcNow.Add(expirationTime),
                    Verb = HttpVerb.PUT,
                    Protocol = Protocol.HTTPS
                };

                var url = client.GetPreSignedURL(request);
                serviceResponse.Data = new S3ResponseDTO()
                {
                    url = url,
                    method = "PUT"
                };
            }
            catch (Exception ex)
            {
                throw;
            }
            return serviceResponse;
        }

        public ServiceResponse<S3ResponseDTO> PresignedGet(string file_url)
        {
            ServiceResponse<S3ResponseDTO> serviceResponse = new ServiceResponse<S3ResponseDTO>();
            try
            {
                TimeSpan expires = TimeSpan.FromMinutes(60);
                AWSConfigsS3.UseSignatureVersion4 = true;
                using var client = new AmazonS3Client(_w3Settings.AccessKey, _w3Settings.SecretKey, RegionEndpoint.SAEast1);
                var request = new GetPreSignedUrlRequest
                {
                    BucketName = _w3Settings.BucketName,
                    Key = file_url,
                    Expires = DateTime.UtcNow.Add(expires),
                    Verb = HttpVerb.GET,
                    Protocol = Protocol.HTTPS
                };
                var url = client.GetPreSignedURL(request);
                serviceResponse.Data = new S3ResponseDTO()
                {
                    url = url,
                    method = "GET"
                };
            }
            catch (Exception ex) {

                throw;
            }
            return serviceResponse;
        }
        /// <summary>
        /// Generates a presigned URL which will be used to upload an object to
        /// an Amazon S3 bucket.
        /// </summary>
        /// <param name="client">The initialized Amazon S3 client object used to call
        /// GetPreSignedURL.</param>
        /// <param name="bucketName">The name of the Amazon S3 bucket to which the
        /// presigned URL will point.</param>
        /// <param name="objectKey">The name of the file that will be uploaded.</param>
        /// <param name="duration">How long (in hours) the presigned URL will
        /// be valid.</param>
        /// <returns>The generated URL.</returns>
        public static string GeneratePreSignedURL(
            IAmazonS3 client,
            string bucketName,
            string objectKey,
            double duration)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                Verb = HttpVerb.PUT,
                Expires = DateTime.UtcNow.AddHours(duration),
            };

            string url = client.GetPreSignedURL(request);
            return url;
        }

    }
}
