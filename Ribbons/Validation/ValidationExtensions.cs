using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Validation
{
    public static class ValidationExtensions
    {
        public static bool TryValidateObject(this object obj, out List<ValidationError> validationErrors)
        {
            List<ValidationResult> validationResults = [];
            
            validationErrors = [];

            bool result = Validator.TryValidateObject(obj, new ValidationContext(obj), validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                foreach (string propertyName in validationResult.MemberNames)
                {
                    validationErrors.Add(new()
                    {
                        PropertyName = propertyName,
                        ErrorMessage = validationResult.ErrorMessage
                    });
                }
            }

            return result;
        }
    }
}