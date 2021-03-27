using Intro3D.Domain.Interfaces;
using Intro3D.Domain.Models;
using Intro3D.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intro3D.Infrastructure.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudyContext context) : base(context)
        {

        }

        public Student GetByEmail(string email)
        {
            return Db.Students.FirstOrDefault(w => w.Email == email);
        }
    }
}
