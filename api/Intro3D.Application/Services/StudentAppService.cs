using AutoMapper;
using Intro3D.Application.Interfaces;
using Intro3D.Application.ViewModels;
using Intro3D.Domain.Interfaces;
using Intro3D.Domain.Models;
using System;
using System.Collections.Generic;

namespace Intro3D.Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentAppService(
            IStudentRepository studentRepository,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentRepository.GetById(id));
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<StudentViewModel>>(_studentRepository.GetAll());
        }

        public void Register(StudentViewModel studentViewModel)
        {
            _studentRepository.Add(_mapper.Map<Student>(studentViewModel));
        }

        public void Update(StudentViewModel studentViewModel)
        {
            _studentRepository.Update(_mapper.Map<Student>(studentViewModel));
        }

        public void Remove(Guid id)
        {
            _studentRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
