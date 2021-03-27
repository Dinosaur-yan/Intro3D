using Intro3D.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Intro3D.Application.Interfaces
{
    public interface IStudentAppService : IDisposable
    {
        StudentViewModel GetById(Guid id);

        IEnumerable<StudentViewModel> GetAll();

        void Register(StudentViewModel studentViewModel);

        void Update(StudentViewModel studentViewModel);

        void Remove(Guid id);
    }
}
