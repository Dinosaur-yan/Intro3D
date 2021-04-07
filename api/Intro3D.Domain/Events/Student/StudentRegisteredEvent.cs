using Intro3D.Domain.Core.Events;
using System;

namespace Intro3D.Domain.Events
{
    public class StudentRegisteredEvent : Event
    {
        // 构造函数初始化，整体事件是一个值对象
        public StudentRegisteredEvent(Guid id, string name, string email, string phone, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        public string Phone { get; private set; }
    }
}
