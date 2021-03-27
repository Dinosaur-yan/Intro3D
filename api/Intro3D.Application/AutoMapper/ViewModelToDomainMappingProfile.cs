using AutoMapper;
using Intro3D.Application.ViewModels;
using Intro3D.Domain.Models;

namespace Intro3D.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<StudentViewModel, Student>()
                .ForPath(d => d.Address.Province, o => o.MapFrom(s => s.Province))
                .ForPath(d => d.Address.City, o => o.MapFrom(s => s.City))
                .ForPath(d => d.Address.County, o => o.MapFrom(s => s.County))
                .ForPath(d => d.Address.Street, o => o.MapFrom(s => s.Street));


            ////这里以后会写领域命令，所以不能和DomainToViewModelMappingProfile写在一起。
            ////学生视图模型 -> 添加新学生命令模型
            //CreateMap<StudentViewModel, RegisterNewStudentCommand>()
            //    .ConstructUsing(c => new RegisterNewStudentCommand(c.Name, c.Email, c.BirthDate));
            ////学生视图模型 -> 更新学生信息命令模型
            //CreateMap<StudentViewModel, UpdateStudentCommand>()
            //    .ConstructUsing(c => new UpdateStudentCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }
    }
}
