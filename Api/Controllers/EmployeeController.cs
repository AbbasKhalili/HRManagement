using System;
using System.Collections.Generic;
using HRManagement.Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<EmployeeDto> Get(int page = 0, int count = 0)
        {
            return _service.GetAll(page, count);
        }

        [HttpGet("{id}")]
        public EmployeeDto Get(Guid id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public Guid Post(EmployeeDto dto)
        {
            return _service.Create(dto);
        }

        [HttpPut("{id}")]
        public void Post(Guid id, EmployeeDto dto)
        {
             _service.Update(id, dto);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.Delete(id);
        }
    }
}
