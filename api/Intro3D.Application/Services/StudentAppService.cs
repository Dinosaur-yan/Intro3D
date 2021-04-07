using AutoMapper;
using Intro3D.Application.Interfaces;
using Intro3D.Application.ViewModels;
using Intro3D.Domain.Commands;
using Intro3D.Domain.Core.Bus;
using Intro3D.Domain.Interfaces;
using Intro3D.Domain.Models;
using System;
using System.Collections.Generic;

namespace Intro3D.Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IStudentRepository _studentRepository;

        public StudentAppService(
            IMapper mapper,
            IMediatorHandler bus,
            IStudentRepository studentRepository
            )
        {
            _mapper = mapper;
            _bus = bus;
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
            //_studentRepository.Add(_mapper.Map<Student>(studentViewModel));
            //_studentRepository.SaveChanges();

            var registerCommand = _mapper.Map<RegisterStudentCommand>(studentViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void Update(StudentViewModel studentViewModel)
        {
            _studentRepository.Update(_mapper.Map<Student>(studentViewModel));
            _studentRepository.SaveChanges();
        }

        public void Remove(Guid id)
        {
            _studentRepository.Remove(id);
            _studentRepository.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
