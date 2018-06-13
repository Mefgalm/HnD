using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HnD.Business.Interfaces.Models;
using HnD.Business.Interfaces.Services;

namespace HnD.Business.Services
{
    [ValidateObject]
    public class Test
    {
        [ValidateObject]
        public HeroName HeroName { get; set; }
        
        [ValidateObject]
        public HeroPassword HeroPassword { get; set; }
    }
    
    public class HeroService : IHeroService
    {
        public void Create(HeroName heroName, HeroPassword heroPassword)
        {
            var test = new List<ValidationResult>();
            Validator.TryValidateObject(heroName, new ValidationContext(heroName), test);
            Validator.TryValidateObject(heroPassword, new ValidationContext(heroPassword), test);                        
        }

        public void Test(Test test)
        {
            var testList = new List<ValidationResult>();
            Validator.TryValidateObject(test, new ValidationContext(test), testList);
        }
    }
    
    
    public class ValidateObjectAttribute : ValidationAttribute
    {
        /// <summary>
        /// Ises the valid.
        /// </summary>
        /// <returns>The valid.</returns>
        /// <param name="value">Value.</param>
        /// <param name="validationContext">Validation context.</param>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
                return ValidationResult.Success;            

            var results = new List<ValidationResult>();
            var context = new ValidationContext(value);

            Validator.TryValidateObject(value, context, results, true);

            CompositeValidationResult compositeResults = null;

            if (results.Any())
            {
                compositeResults = new CompositeValidationResult(string.Format("Validation for {0} failed!", validationContext.DisplayName), new [] { validationContext.DisplayName });
                results.ForEach(compositeResults.AddResult);
            } else 
            {
                compositeResults = null;
            }

            return compositeResults;
        }
    }

    /// <summary>
    /// Composite validation result.
    /// </summary>
    public class CompositeValidationResult : ValidationResult
    {
        private readonly List<ValidationResult> _results = new List<ValidationResult>();

        /// <summary>
        /// Gets the results.
        /// </summary>
        /// <value>The results.</value>
        public IEnumerable<ValidationResult> Results => _results;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:YoiPos.Attributes.CompositeValidationResult"/> class.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        public CompositeValidationResult(string errorMessage) 
            : base(errorMessage) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:YoiPos.Attributes.CompositeValidationResult"/> class.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="memberNames">Member names.</param>
        public CompositeValidationResult(string errorMessage, IEnumerable<string> memberNames) 
            : base(errorMessage, memberNames) 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:YoiPos.Attributes.CompositeValidationResult"/> class.
        /// </summary>
        /// <param name="validationResult">Validation result.</param>
        protected CompositeValidationResult(ValidationResult validationResult) 
            : base(validationResult) 
        { 
        }

        /// <summary>
        /// Adds the result.
        /// </summary>
        /// <param name="validationResult">Validation result.</param>
        public void AddResult(ValidationResult validationResult) => _results.Add(validationResult);
    }
}