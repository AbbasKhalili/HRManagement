using System;
using System.Collections.Generic;
using HRFramework;

namespace HRManagement.Domain
{
    public interface IEmployeeRepository : IRepository
    {
        void Create(Employee entity);
        void Delete(Employee entity);
        void Update(Employee entity);


        Employee GetById(Guid id);
        List<Employee> GetAll(int page=0, int count=0);

    }
}