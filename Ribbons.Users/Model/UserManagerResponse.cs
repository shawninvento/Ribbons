using Ribbons.Validation;
using System.Collections.Generic;

namespace Ribbons.Users.Model
{
    public abstract class UserManagerResponse<TStatus>
    {
        public TStatus Status { get; internal set; }
        public string Message { get; internal set; }
        public IEnumerable<ValidationError> ValidationErrors { get; internal set; }

        protected UserManagerResponse(TStatus status, string message)
        {
            Status = status;
            Message = message;
        }

        protected UserManagerResponse(TStatus status, string message, IEnumerable<ValidationError> validationErrors)
        {
            Status = status;
            Message = message;
            ValidationErrors = validationErrors;
        }
    }
}