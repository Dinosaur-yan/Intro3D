using Intro3D.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Intro3D.Domain.EventHandlers
{
    public class StudentEventHandler :
        INotificationHandler<StudentRegisteredEvent>,
        INotificationHandler<StudentUpdatedEvent>,
        INotificationHandler<StudentRemovedEvent>
    {
        public Task Handle(StudentRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // 恭喜您，注册成功，欢迎加入我们。

            return Task.CompletedTask;
        }

        public Task Handle(StudentUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // 恭喜您，更新成功，请牢记修改后的信息。

            return Task.CompletedTask;
        }

        public Task Handle(StudentRemovedEvent notification, CancellationToken cancellationToken)
        {
            // 您已经删除成功啦，记得以后常来看看。

            return Task.CompletedTask;
        }
    }
}
