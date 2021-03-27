using Intro3D.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intro3D.Domain.Commands
{
    public class RemoveStudentCommand : StudentCommand
    {
        // set 受保护，只能通过构造函数方法赋值
        public RemoveStudentCommand(string name, string email, string phone, DateTime birthDate)
        {
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveStudentCommandValidation().Validate(this);//注意：这个就是命令验证，我们会在下边实现它
            return ValidationResult.IsValid;
        }
    }
}
