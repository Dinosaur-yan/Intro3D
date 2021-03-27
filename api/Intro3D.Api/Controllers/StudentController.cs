using Intro3D.Application.Interfaces;
using Intro3D.Application.ViewModels;
using Intro3D.Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Intro3D.Api.Controllers
{
    /// <summary>
    /// 学生
    /// </summary>
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        /// <summary>
        /// 获取所有学生信息
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetAll))]
        public ActionResult<IEnumerable<StudentViewModel>> GetAll()
        {
            return Ok(_studentAppService.GetAll());
        }

        /// <summary>
        /// 创建学生信息
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = nameof(CreateStudent))]
        public ActionResult CreateStudent([FromBody] StudentViewModel studentViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Ok(ModelState.ErrorCount);


                //添加命令验证，采用构造函数方法实例
                RegisterStudentCommand registerStudentCommand = new RegisterStudentCommand(studentViewModel.Name, studentViewModel.Email, studentViewModel.Phone, studentViewModel.BirthDate);

                if (!registerStudentCommand.IsValid())
                {
                    List<string> errorInfo = new List<string>();
                    //获取到错误，请思考这个Result从哪里来的 
                    foreach (var error in registerStudentCommand.ValidationResult.Errors)
                    {
                        errorInfo.Add(error.ErrorMessage);
                    }
                    return Ok(errorInfo);
                }

                // 执行添加方法
                _studentAppService.Register(studentViewModel);
                return Ok(studentViewModel);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
