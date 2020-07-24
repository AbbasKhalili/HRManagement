using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HRFramework;

namespace HRManagement.Domain
{
    public class Employee : EntityBase<Guid>
    {
        public string Lastname { get; private set; }
        public string Firstname { get; private set; }
        public int Age { get; private set; }
        public long EmployeeNumber { get; private set; }
        

        private List<Language> _languages;
        

        public IReadOnlyCollection<Language> Languages => new ReadOnlyCollection<Language>(_languages);

        protected Employee() { }
        public Employee(Guid id, string lastname, string firstname, int age, long employeeNumber, List<Language> languages)
        {
            Id = id;
            SetProperties(lastname, firstname, age, employeeNumber, languages);
        }

        public void Update(string lastname, string firstname, int age, long employeeNumber, List<Language> languages)
        {
            SetProperties(lastname, firstname, age, employeeNumber, languages);
        }

        private void SetProperties(string lastname, string firstname, int age, long employeeNumber, List<Language> languages)
        {
            Lastname = lastname;
            Firstname = firstname;
            Age = age;
            EmployeeNumber = employeeNumber;
            _languages = languages;
        }
    }
}
