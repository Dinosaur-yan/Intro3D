using AutoMapper;
using Intro3D.Application.ViewModels;
using Intro3D.Domain.Models;

namespace Intro3D.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// 创建关系映射
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}
