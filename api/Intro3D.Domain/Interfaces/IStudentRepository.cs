using Intro3D.Domain.Models;

namespace Intro3D.Domain.Interfaces
{
    /// <summary>
    /// IStudentRepository 接口
    /// </summary>
    public interface IStudentRepository : IRepository<Student>
    {
        /// <summary>
        /// 根据email获取对象
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns></returns>
        Student GetByEmail(string email);
    }
}
