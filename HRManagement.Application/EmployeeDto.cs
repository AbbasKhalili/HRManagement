using System.Collections.Generic;

namespace HRManagement.Application
{
    public class EmployeeDto
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int Age { get; set; }
        public long EmployeeNumber { get; set; }


        public List<LanguageDto> Languages { get; set; }
    }

    public class LanguageDto
    {
        public string LanguageName { get; set; }
        public int Level { get; set; }
    }
}