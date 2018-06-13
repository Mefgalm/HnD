using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HnD.Business.Interfaces.Models
{
    public class HeroName : IValidatableObject
    {
        [Required]        
        private readonly string _name;

        public HeroName(string name)
        {
            _name = name;
        }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new[] {new ValidationResult("name is wrong")};
        }
    }

    public class HeroPassword : IValidatableObject
    {
        [Required]
        private readonly string _password;

        public HeroPassword(string password)
        {
            _password = password;
        }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new[] {ValidationResult.Success};
        }
    }
}