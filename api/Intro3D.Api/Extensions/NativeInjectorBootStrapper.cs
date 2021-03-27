using Intro3D.Application.Interfaces;
using Intro3D.Application.Services;
using Intro3D.Domain.Interfaces;
using Intro3D.Infrastructure.Data.Context;
using Intro3D.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Intro3D.Api.Extensions
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // 注入 Application 应用层
            services.AddScoped<IStudentAppService, StudentAppService>();


            // 注入 Infra - Data 基础设施数据层
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<StudyContext>();//上下文

        }
    }
}
