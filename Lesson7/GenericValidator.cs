using System;

namespace Lesson7
{
    public class GenericValidator<T> : IValidator<T>
    {
        private string errorMessage;

        public Predicate<T> Check { get; private set; }

        public string ErrorMessage => errorMessage;

        public GenericValidator(Predicate<T> check, string eMessage)
        {
            Check = check;
            errorMessage = eMessage;
        }

        public bool IsValueOk(T s) => Check(s);
    }
}
