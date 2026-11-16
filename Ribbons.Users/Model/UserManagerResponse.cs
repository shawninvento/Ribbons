using Ribbons.Validation;
using System.Collections.Generic;

namespace Ribbons.Users.Model
{
    public abstract class UserManagerResponse<TStatus>
    {
        public TStatus Status { get; internal set; }
        public string Message { get; internal set; }
        public IEnumerable<ValidationError> ValidationErrors { get; internal set; }
    }
}