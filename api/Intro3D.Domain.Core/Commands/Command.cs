using FluentValidation.Results;
using System;

namespace Intro3D.Domain.Core.Commands
{
    /// <summary>
    /// 抽象命令基类
    /// </summary>
    public abstract class Command
    {
        protected Command()
        {

        }
        // 时间戳
        public DateTime Timestamp { get; private set; }

        // 验证结果，需要引用FluentValidation
        public ValidationResult ValidationResult { get; set; }

        // 定义抽象方法，是否有效
        public abstract bool IsValid();
    }
}
