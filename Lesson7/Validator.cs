using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    public class Validator
    {
        public CheckType ValidatorType { get; private set; }
        public int CheckValue { get; private set; } = int.MinValue;
        public string ErrorMessage 
        {
            get
            {
                return $"{ValidatorType} {CheckValue}";
            } 
        }

        public Validator(CheckType type)
        {
            ValidatorType = type;
        }

        public Validator(CheckType type, int checkValue) : this(type)
        {
            CheckValue = checkValue;
        }

        public bool IsValueOk(string s)
        {
            switch (ValidatorType)
            {
                case CheckType.StringMinLength: return s.Trim().Length >= CheckValue;
                case CheckType.StringMaxLength: return s.Trim().Length <= CheckValue;
                case CheckType.StringNotEmpty: return !string.IsNullOrWhiteSpace(s);
                case CheckType.StringFirstUpperCase: return s.Length > 0 && char.IsUpper(s[0]);
                case CheckType.StringNoWhiteSpace: return !s.Contains(" ");
                case CheckType.StringContainChar: return s.Contains((char)CheckValue);
                default: return false;
            }
        }

        public bool IsValueOk(int i)
        {
            switch (ValidatorType)
            {
                case CheckType.IntMoreOrEqualThan: return i >= CheckValue;
                default: return false;
            }
        }
    }
}
