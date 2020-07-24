using System;
using System.Collections.Generic;

namespace HRManagement.Domain.Tests.Unit
{
    public class EmployeeBuilder
    {
        private Guid Id { get; set; }
        private string Lastname { get;  set; }
        private string Firstname { get;  set; }
        private int Age { get;  set; }
        private long EmployeeNumber { get;  set; }

        private List<Language> _languages = new List<Language>();
        
        public EmployeeBuilder()
        {
            Id = EmployeeConst.Id;
        }

        public Employee Build()
        {
            var result = new Employee(Id, Lastname, Firstname, Age, EmployeeNumber, _languages);
            return result;
        }

        public EmployeeBuilder WithId(Guid id)
        {
            this.Id = id;
            return this;
        }
        public EmployeeBuilder WithFirstname(string firstname)
        {
            this.Firstname = firstname;
            return this;
        }
        public EmployeeBuilder WithLastname(string lastname)
        {
            this.Lastname = lastname;
            return this;
        }
        public EmployeeBuilder WithAge(int age)
        {
            this.Age = age;
            return this;
        }
        public EmployeeBuilder WithEmployeeNumber(long employeeNumber)
        {
            this.EmployeeNumber = employeeNumber;
            return this;
        }
        
        public EmployeeBuilder WithLanguage(List<Language> languages)
        {
            this._languages.AddRange(languages);
            return this;
        }
    }
}