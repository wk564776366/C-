using System;
using AssemblyTest.Interface;

namespace AssemblyTest.AssemblyInfo
{
    public class AssemblyInformation : InterfaceParent
    {
        public static string publicName { get; set; }
        private static string privateName { get; set; }
        private int age;
        public string publicFields;

        public AssemblyInformation()
        {
            Console.WriteLine("这里是无参构造函数");
        }

        public AssemblyInformation(string strName, int intAge)
        {
            publicName = strName;
            age = intAge;
            Console.WriteLine("这里是有参构造函数, name={0}, age = {1}", publicName, age);
        }

        public void Query()
        {
            Console.WriteLine("Query: 当前程序集 {0}", this.GetType());
        }

        public void ShowMsg()
        {
            Console.WriteLine("ShowMsg(): 当前程序集 {0}", this.GetType());
        }

        public void ShowMsg1(string str)
        {
            Console.WriteLine("ShowMsg1(): 当前程序集 {0}, 传入参数:{1}, 类型:{2}", this.GetType(), str, str.GetType());
        }

        public void ShowMsg2(string str, int num)
        {
            Console.WriteLine("ShowMsg2(): 当前程序集 {0}, 传入参数:{1} {2}, 类型:{3}{4}", this.GetType(), str, str.GetType(), num, num.GetType());
        }

        public void ShowMsg3()
        {
            Console.WriteLine("ShowMsg3(): 当前程序集 {0}", this.GetType());
        }

        public void ShowMsg3(string str)
        {
            Console.WriteLine("ShowMsg3(): 当前程序集 {0}, 传入参数:{1}, 类型:{2}", this.GetType(), str, str.GetType());
        }

        public void ShowMsg3(string str, int num)
        {
            Console.WriteLine("ShowMsg3(): 当前程序集 {0}, 传入参数:{1} {2}, 类型:{3}{4}", this.GetType(), str, str.GetType(), num, num.GetType());
        }

        private void ShowMsg4()
        {
            Console.WriteLine("ShowMsg4(): 私有方法：{0}", this.GetType());
        }

        public static void ShowMsg5()
        {
            Console.WriteLine("ShowMsg5(): 静态方法");
        }

        public void ShowMsg6<T>(T t)
        {
            Console.WriteLine("ShowMsg6(): 泛型方法 泛型参数类型{0}", typeof(T));
        }
    }
}