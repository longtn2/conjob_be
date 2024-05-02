using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using ConJob.Domain.Constant;
using ConJob.Domain.DTOs.File;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ConJob.Domain.Services
{
    public class S3Services: IS3Services
    {
        private readonly S3Settings _s3Settings;

        public S3Services(IOptions<S3Settings> s3Settings)
        {
            _s3Settings = s3Settings.Value;
        }

        private string GetPath(string file_name, string file_type, string user_id)
        {
            var result = String.Format(_s3Settings.PathUpload, user_id, file_type, file_name);
            return result;
        }

        public async Task UploadImage(IFormFile file)
        {
            var credentials = new BasicAWSCredentials(_s3Settings.AccessKey, _s3Settings.SecretKey);
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
                BucketName = _s3Settings.BucketName,
                CannedACL = S3CannedACL.PublicRead
            };

            var fileTransferUtility = new TransferUtility(client);
            await fileTransferUtility.UploadAsync(uploadRequest);
        }

        private string GetURL(string Key, HttpVerb verb)
        {
            try
            {
                AWSConfigsS3.UseSignatureVersion4 = true;
                TimeSpan expirationTime = TimeSpan.FromMinutes(60);
                using var client = new AmazonS3Client(_s3Settings.AccessKey, _s3Settings.SecretKey, RegionEndpoint.APSoutheast1);
                var request = new GetPreSignedUrlRequest
                {
                    BucketName = _s3Settings.BucketName,
                    Key = Key,
                    Expires = DateTime.UtcNow.Add(expirationTime),
                    Verb = verb,
                    Protocol = Protocol.HTTPS
                };

                var url = client.GetPreSignedURL(request);
                return url;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private bool IsTypeAccepted(string file_type)
        {
            return CJConstant.ACCEPT_TYPE.Split("|").Contains(file_type.ToLower());
        }
        public ServiceResponse<S3ResponseDTO> PresignedUpload(string file_name, string file_type,string action, string user_id)
        {
            
            ServiceResponse<S3ResponseDTO> serviceResponse = new ServiceResponse<S3ResponseDTO>();
            if (!IsTypeAccepted(file_type))
            {
                serviceResponse.ResponseType = EServiceResponseTypes.EResponseType.BadRequest;
                serviceResponse.Message = "File type is not Supported!";
            }
            else
            {
                serviceResponse.Data = new S3ResponseDTO()
                {
                    url = GetURL(GetPath(file_name, action, user_id), HttpVerb.PUT),
                    method = "PUT",
                    expired = DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                };
            }
            return serviceResponse;
        }

        public ServiceResponse<S3ResponseDTO> PresignedGet(string file_url)
        {
            ServiceResponse<S3ResponseDTO> serviceResponse = new ServiceResponse<S3ResponseDTO>();
            serviceResponse.Data = new S3ResponseDTO()
            {
                url = GetURL(file_url, HttpVerb.GET),
                method = "GET",
                expired = DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
            };
            return serviceResponse;
        }
    }
}
