using Infrastructure.DomainEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleWebApiCore.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpGet("GetDepartment")]
        public Department Get(int Id)
        {
            return _departmentService.GetDepartment(Id);
        }

        [HttpPost("SaveDepartment")]
        public IActionResult Save(DepartmentRequest department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Department dept = new Department() { Name = department.Name, Description = department.Description };
            _departmentService.SaveDepartment(dept);
            return Ok(dept);
        }
        [HttpPost("UpdateDepartment")]
        public IActionResult Update(DepartmentRequest department, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Department dept = new Department() { Name = department.Name, Description = department.Description };
            _departmentService.UpdateDepartment(dept, Id);
            var info = _departmentService.GetDepartment(Id);
            return Ok(info);

        }
        [HttpDelete("DeleteDepartment")]
        public IActionResult Delete(int Id)
        {
            _departmentService.DeleteDepartment(Id);
            return Ok();

        }
    }
}
