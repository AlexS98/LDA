using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    public interface IValidator<T>
    {
        bool IsValueOk(T s);
        string ErrorMessage { get; }
    }
}
