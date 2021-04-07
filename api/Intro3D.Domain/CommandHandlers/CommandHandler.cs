using Intro3D.Domain.Core.Bus;
using Intro3D.Domain.Core.Commands;
using Intro3D.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intro3D.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;

        public CommandHandler(IMemoryCache cache, IUnitOfWork uow, IMediatorHandler bus)
        {
            _cache = cache;
            _uow = uow;
            _bus = bus;
        }

        public bool Commit()
        {
            if (_uow.Commit()) return true;

            return false;
        }

        //将领域命令中的验证错误信息收集
        //目前用的是缓存方法（以后通过领域通知替换）
        protected void NotifyValidationErrors(Command message)
        {
            List<string> errorInfo = new List<string>();
            foreach (var error in message.ValidationResult.Errors)
            {
                errorInfo.Add(error.ErrorMessage);

                //将错误信息提交到事件总线，派发出去
                //_bus.RaiseEvent(new DomainNotification("", error.ErrorMessage));
            }

            //将错误信息收集一：缓存方法（错误示范）
            _cache.Set("ErrorData", errorInfo);
        }
    }
}
