using System;
using System.Reflection;

namespace AssemblyPractice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //使用Assembly.Load的方式加载程序集，不需要后缀
                Assembly assembly = Assembly.Load("AssemblyTest.Interface");
                //使用Assembly.LoadFile的方式加载程序集，参数需要完整的路径以及文件类型（需要文件后缀），LoadFile方法不加载以来项
                Assembly assemblyLoadFile = Assembly.LoadFile(@"F:\Practice\AssemblyPractice\AssemblyTest.Interface\bin\Debug\AssemblyTest.Interface.dll");
                //使用Asseblly.LoadFrom的方式加载程序及，参数可以为完整路径，也可以为程序集名称（需要文件后缀）
                Assembly assemblyLoadFromFullPath = Assembly.LoadFrom(@"AssemblyTest.Interface.dll");
                Assembly assemblyLoadFromFileName = Assembly.LoadFrom(@"F:\Practice\AssemblyPractice\AssemblyTest.Interface\bin\Debug\AssemblyTest.Interface.dll");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}