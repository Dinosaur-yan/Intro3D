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
            CreateMap<Student, StudentViewModel>()
                .ForMember(d => d.Province, o => o.MapFrom(s => s.Address.Province))
                .ForMember(d => d.City, o => o.MapFrom(s => s.Address.City))
                .ForMember(d => d.County, o => o.MapFrom(s => s.Address.County))
                .ForMember(d => d.Street, o => o.MapFrom(s => s.Address.Street));
        }
    }
}
