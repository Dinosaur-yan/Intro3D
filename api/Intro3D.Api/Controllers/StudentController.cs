using Intro3D.Application.Interfaces;
using Intro3D.Application.ViewModels;
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
        public ActionResult<StudentViewModel> CreateStudent([FromBody] StudentViewModel studentViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Ok(ModelState.ErrorCount);

                // 执行添加方法
                _studentAppService.Register(studentViewModel);
                return Ok(studentViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
