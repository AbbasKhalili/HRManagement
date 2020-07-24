using System;
using System.Collections.Generic;

namespace HRManagement.Application
{
    public interface IEmployeeService
    {
        Guid Create(EmployeeDto dto);
        void Update(Guid id, EmployeeDto dto);
        void Delete(Guid id);



        EmployeeDto GetById(Guid id);
        List<EmployeeDto> GetAll(int page = 0, int count = 0);
    }
}