using Intro3D.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intro3D.Domain.Models
{
    public class Student : Entity
    {
        protected Student()
        {

        }

        public Student(string name, string email, string phone, DateTime birthDate, Address address)
        {
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Address = address;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; private set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDate { get; private set; }

        /// <summary>
        /// 地址外键
        /// </summary>
        public Address Address { get; private set; }
    }
}
