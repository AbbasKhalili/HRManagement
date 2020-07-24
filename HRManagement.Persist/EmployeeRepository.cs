using System;
using System.Collections.Generic;
using System.Linq;
using HRManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HRManagement.Persist
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public void Create(Employee entity)
        {
            _context.Employees.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Employee entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public Employee GetById(Guid id)
        {
            return _context.Employees.Include(a => a.Languages).FirstOrDefault(a => a.Id == id);
        }

        public List<Employee> GetAll(int page = 0, int count = 0)
        {
            var query = _context.Employees.Include(a => a.Languages);
            if (page > 0 && count > 0)
                return query.Skip((page - 1) * count).Take(count).ToList();
            return query.ToList();
        }
    }
}

    
