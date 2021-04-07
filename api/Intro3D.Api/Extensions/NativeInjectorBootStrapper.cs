using Intro3D.Application.Interfaces;
using Intro3D.Application.Services;
using Intro3D.Domain.CommandHandlers;
using Intro3D.Domain.Commands;
using Intro3D.Domain.Core.Bus;
using Intro3D.Domain.Core.Notifications;
using Intro3D.Domain.EventHandlers;
using Intro3D.Domain.Events;
using Intro3D.Domain.Interfaces;
using Intro3D.Infrastructure.Data.Bus;
using Intro3D.Infrastructure.Data.Context;
using Intro3D.Infrastructure.Data.Repository;
using Intro3D.Infrastructure.Data.UoW;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Intro3D.Api.Extensions
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // 注入 Application 应用层
            services.AddScoped<IStudentAppService, StudentAppService>();

            // 命令总线Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // 注入 领域层 - 命令领域
            // 将命令模型和命令处理程序匹配
            services.AddScoped<IRequestHandler<RegisterStudentCommand, bool>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, bool>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, bool>, StudentCommandHandler>();

            // 领域通知
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // 注入 领域层 - 领域事件
            services.AddScoped<INotificationHandler<StudentRegisteredEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentUpdatedEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentRemovedEvent>, StudentEventHandler>();

            // 注入 领域层 - Memory
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });

            // 注入 基础设施 - 数据层
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<StudyContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
