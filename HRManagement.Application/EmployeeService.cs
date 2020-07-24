using System;
using System.Collections.Generic;
using System.Linq;
using HRManagement.Domain;

namespace HRManagement.Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public Guid Create(EmployeeDto dto)
        {
            var id = Guid.NewGuid();
            var langs = dto.Languages.Select(a => new Language()
            {
                Level = a.Level, LanguageName = a.LanguageName
            }).ToList();
            var employee = new Employee(id,dto.Lastname,dto.Firstname,dto.Age,dto.EmployeeNumber, langs);
            _repository.Create(employee);
            return id;
        }

        public void Update(Guid id, EmployeeDto dto)
        {
            var employee = _repository.GetById(id);
            if (employee == null) throw new Exception("Employee Not Found!");

            var langs = dto.Languages.Select(a => new Language()
            {
                Level = a.Level,
                LanguageName = a.LanguageName
            }).ToList();
            employee.Update(dto.Lastname,dto.Firstname,dto.Age,dto.EmployeeNumber, langs);
            _repository.Update(employee);
        }

        public void Delete(Guid id)
        {
            var employee = _repository.GetById(id);
            if (employee == null) return;
            _repository.Delete(employee);
        }

        public EmployeeDto GetById(Guid id)
        {
            var employee = _repository.GetById(id);
            return Map(employee);
        }

        public List<EmployeeDto> GetAll(int page = 0, int count = 0)
        {
            var employees = _repository.GetAll(page, count);
            return Map(employees);
        }

        private EmployeeDto Map(Employee employee)
        {
            return new EmployeeDto()
            {
                Age = employee.Age,
                Lastname = employee.Lastname,
                Firstname = employee.Firstname,
                EmployeeNumber = employee.EmployeeNumber,
                Languages = employee.Languages.Select(a => new LanguageDto()
                {
                    Level = a.Level,
                    LanguageName = a.LanguageName
                }).ToList()
            };
        }
        private List<EmployeeDto> Map(List<Employee> employees)
        {
            return employees.Select(Map).ToList();
        }
    }
}
