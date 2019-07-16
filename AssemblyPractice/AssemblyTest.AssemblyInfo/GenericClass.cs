using System;

namespace AssemblyTest.AssemblyInfo
{
    public class GenericClass<T>
    {
        public GenericClass()
        {
            Console.WriteLine("泛型类：{0}", this.GetType());
        }
    }
}