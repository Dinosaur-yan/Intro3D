using Intro3D.Domain.Core.Commands;
using System.Threading.Tasks;

namespace Intro3D.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        /// <summary>
        /// 发布命令，将我们的命令模型发布到中介者模块
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="command">命令模型</param>
        /// <returns></returns>
        Task SendCommand<T>(T command) where T : Command;
    }
}
