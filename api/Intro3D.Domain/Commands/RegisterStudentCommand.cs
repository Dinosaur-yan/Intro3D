using Intro3D.Domain.Validations;
using System;

namespace Intro3D.Domain.Commands
{
    /// <summary>
    /// 注册一个添加 Student 命令
    /// 基础抽象学生命令模型
    /// </summary>
    public class RegisterStudentCommand : StudentCommand
    {
        // set 受保护，只能通过构造函数方法赋值
        public RegisterStudentCommand(string name, string email, string phone, DateTime birthDate, string province, string city, string county, string street)
        {
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Province = province;
            City = city;
            County = county;
            Street = street;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterStudentCommandValidation().Validate(this);//注意：这个就是命令验证，我们会在下边实现它
            return ValidationResult.IsValid;
        }
    }
}
