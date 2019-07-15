using System;
using AssemblyTest.Interface;

namespace AssemblyTest.IocTest
{
    public class AssemblyIocInformation : InterfaceParent
    {
        public static string publicName { get; set; }
        private static string privateName { get; set; }
        private int age;
        public string publicFields;

        public AssemblyIocInformation()
        {
            Console.WriteLine("这里是无参构造函数");
        }

        public AssemblyIocInformation(string strName, int intAge)
        {
            publicName = strName;
            age = intAge;
            Console.WriteLine("这里是无参构造函数, name={0}, age = {1}", publicName, age);
        }

        public void Query()
        {
            Console.WriteLine("Query: 当前程序集 {0}", this.GetType());
        }

        public void ShowMsg()
        {
            Console.WriteLine("ShowMsg(): 当前程序集 {0}, name:{1}, age:{2}", this.GetType(), publicName, age);
        }
    }
}