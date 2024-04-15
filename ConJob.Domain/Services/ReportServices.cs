using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.Report;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.Domain.Services
{
    public class ReportServices : IReportServices
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRespository;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly AppDbContext _context;

        public ReportServices(IMapper mapper, IReportRepository reportRespository, IUserRepository userRepository, IPostRepository postRepository,AppDbContext context)
        {
            _mapper = mapper;
            _reportRespository = reportRespository;
            _userRepository = userRepository;
            _postRepository = postRepository;
            _context = context;
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
                    report.Post = _postRepository.GetById(reportDTO.post_id)!;
                    report.User = _userRepository.GetById(reportDTO.user_id)!;
                    var checkReport =_reportRespository.GetReport(report.User,report.Post);
                    if (report.User == null || report.Post == null)
                    {
                        serviceReponse.ResponseType = EResponseType.CannotCreate;
                    }
                    else if(checkReport == null)
                    {
                        await _reportRespository.AddAsync(report);
                        serviceReponse.ResponseType = EResponseType.Success;
                        serviceReponse.Data = _mapper.Map<ReportByUserDTO>(report);
                    }
                    else
                    {
                        serviceReponse.Message = "The post is reported";
                        serviceReponse.ResponseType= EResponseType.BadRequest;
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
