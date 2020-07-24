using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace HRManagement.Domain.Tests.Unit
{
    public class EmployeeTests
    {
        private readonly EmployeeBuilder _builder;
         public EmployeeTests()
        {
            _builder = new EmployeeBuilder();
        }

        [Fact]
        public void Constructor_should_create_Employee_properly()
        {
            var employee = BuildExpectedEmployee();

            employee.Id.Should().Be(EmployeeConst.Id);
            employee.Firstname.Should().Be(EmployeeConst.Firstname);
            employee.Lastname.Should().Be(EmployeeConst.Lastname);
            employee.Age.Should().Be(EmployeeConst.Age);
            employee.EmployeeNumber.Should().Be(EmployeeConst.EmployeeNumber);
            employee.Languages.Should().BeEquivalentTo(EmployeeConst.Languages);
        }

        [Fact]
        public void update_should_modify_the_Employee_properties()
        {
            const string firstname = "Joe";
            const string lastname = "Rise";
            const long employeeNumber = 14002;
            const int age = 45;
            var langs = new List<Language>() { new Language()
            {
                Level = 2,LanguageName = "French"
            } };
            
            var employee = BuildExpectedEmployee();

            employee.Update(lastname, firstname,age, employeeNumber, langs);

            employee.Id.Should().Be(EmployeeConst.Id);
            employee.Firstname.Should().Be(firstname);
            employee.Lastname.Should().Be(lastname);
            employee.Age.Should().Be(age);
            employee.EmployeeNumber.Should().Be(employeeNumber);
            employee.Languages.Should().BeEquivalentTo(langs);
        }

        private Employee BuildExpectedEmployee()
        {
            return _builder.WithFirstname(EmployeeConst.Firstname).WithLastname(EmployeeConst.Lastname).WithAge(EmployeeConst.Age)
                .WithEmployeeNumber(EmployeeConst.EmployeeNumber).WithLanguage(EmployeeConst.Languages).Build();
        }
    }
}
