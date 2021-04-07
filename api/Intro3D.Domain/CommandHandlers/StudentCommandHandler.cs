using Intro3D.Domain.Commands;
using Intro3D.Domain.Core.Bus;
using Intro3D.Domain.Interfaces;
using Intro3D.Domain.Models;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Intro3D.Domain.CommandHandlers
{
    public class StudentCommandHandler : CommandHandler,
         IRequestHandler<RegisterStudentCommand, bool>,
         IRequestHandler<UpdateStudentCommand, bool>,
         IRequestHandler<RemoveStudentCommand, bool>
    {
        private readonly IMemoryCache _cache;
        private readonly IMediatorHandler _bus;
        private readonly IStudentRepository _studentRepository;

        public StudentCommandHandler(IMemoryCache cache, IUnitOfWork uow, IMediatorHandler bus,
            IStudentRepository studentRepository)
            : base(cache, uow, bus)
        {
            _cache = cache;
            _bus = bus;
            _studentRepository = studentRepository;
        }

        public Task<bool> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            // 命令验证
            if (!request.IsValid())
            {
                // 错误信息收集
                // NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            // 实例化领域模型，这里才真正的用到了领域模型
            // 注意这里是通过构造函数方法实现
            var address = new Address(request.Province, request.City, request.County, request.Street);
            var student = new Student(request.Name, request.Email, request.Phone, request.BirthDate, address);

            if (_studentRepository.GetByEmail(student.Email) != null)
            {
                //这里对错误信息进行发布，目前采用缓存形式
                List<string> errorInfo = new List<string>() { "该邮箱已经被使用！" };
                _cache.Set("ErrorData", errorInfo);

                return Task.FromResult(false);
            }

            // 持久化
            _studentRepository.Add(student);

            // 统一提交
            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
