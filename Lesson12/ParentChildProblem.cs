using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson12
{
    public interface IBase<U>
    {
        public U SomeProp { get; set; }
    }

    public class ListElement<T, U> 
        where T : IBase<U>, new()
        where U : T, new()
    {
        public int? Age { get; set; }

        public T Creator(U obj)
        {
            return new U();
        }
    }

    public class SomeT : IBase<SomeU>
    {
        public SomeU SomeProp { get; set; }

        public SomeT()
        {
            SomeProp = new SomeU();
        }
    }

    public class SomeU : SomeT
    {
        public SomeU() : base()
        {
        }
    }
}
