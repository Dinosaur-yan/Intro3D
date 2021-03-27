using Intro3D.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intro3D.Domain.Models
{
    /// <summary>
    /// 住址
    /// 由于值对象是不可变的，所以应该是只读的（即具有“只获取”属性），这是事实没错。 
    /// 但是，值对象通常会被执行序列化和反序列化操作以遍历消息队列，并且由于是只读的，
    /// 这阻止了反序列化器分配值，因此只需将其保留为 private set，且其只读程度让此机制成为可能。
    /// </summary>
    [Owned]
    public class Address : ValueObject<Address>
    {
        public Address()
        { 
        
        }

        public Address(string province, string city, string county, string street)
        {
            Province = province;
            City = city;
            County = county;
            Street = street;
        }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; private set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// 区县
        /// </summary>
        public string County { get; private set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; private set; }

        protected override bool EqualsCore(Address other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
