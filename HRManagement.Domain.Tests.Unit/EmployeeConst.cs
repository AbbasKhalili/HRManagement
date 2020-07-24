using System;
using System.Collections.Generic;

namespace HRManagement.Domain.Tests.Unit
{
    public static class EmployeeConst
    {
        public static Guid Id = Guid.NewGuid();
        public const string Lastname = "Robert";
        public const string Firstname = "Martin";
        public const int Age = 55;
        public const long EmployeeNumber = 1000;

        public static readonly List<Language> Languages = new List<Language>()
        {
            new Language() {LanguageName = "English", Level = 1}
        };
    }
}