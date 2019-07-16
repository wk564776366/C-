using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyTest.AssemblyInfo
{
    public class Singleton
    {
        private Singleton()
        {
            Console.WriteLine("私有构造函数：{0}", this.GetType());
        }
    }
}