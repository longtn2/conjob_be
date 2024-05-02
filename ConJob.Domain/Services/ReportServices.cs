using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.Report;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.Domain.Services
{
    public class ReportServices : IReportServices
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRespository;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public ReportServices(IMapper mapper, IReportRepository reportRespository, IUserRepository userRepository, IPostRepository postRepository)
        {
            _mapper = mapper;
            _reportRespository = reportRespository;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task<ServiceResponse<ReportByUserDTO>> reportPost(ReportDTO reportDTO)
        {
            var serviceReponse = new ServiceResponse<ReportByUserDTO>();
            if (reportDTO == null)
            {
                serviceReponse.ResponseType = EResponseType.BadRequest;
            }
            else
            {
                try
                {
                    var report = _mapper.Map<ReportModel>(reportDTO);
                    report.post = _postRepository.GetById(reportDTO.post_id)!;
                    report.user = _userRepository.GetById(reportDTO.user_id)!;
                    var checkReport = _reportRespository.GetReport(report.user.id, report.post.id);
                    if (report.user == null || report.post == null)
                    {
                        serviceReponse.ResponseType = EResponseType.CannotCreate;
                    }
                    else if (checkReport == null)
                    {
                        await _reportRespository.AddAsync(report);
                        serviceReponse.ResponseType = EResponseType.Success;
                        serviceReponse.Message = "Successful reported"; ;
                    }
                    else
                    {
                        serviceReponse.Message = "The post is reported";
                        serviceReponse.ResponseType = EResponseType.BadRequest;
                    }

                }
                catch (Exception ex)
                {
                    serviceReponse.ResponseType = EResponseType.CannotCreate;
                    serviceReponse.Message = ex.Message;
                }

            }
            return serviceReponse;
        }
    }
}
