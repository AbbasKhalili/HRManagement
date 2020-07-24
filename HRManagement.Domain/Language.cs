using System;
using HRFramework;

namespace HRManagement.Domain
{
    public class Language : ValueObjectBase<Language>
    {
        public string LanguageName { get; set; }
        public int Level { get; set; }
        public override bool SameValueAs(Language valueObject)
        {
            return this.LanguageName == valueObject?.LanguageName && this.Level==valueObject?.Level;
        }
        
        public long Id { get; set; }
        public virtual Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
    }
}