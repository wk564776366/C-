using System;
using System.Reflection;
using AssemblyTest.AssemblyInfo;
using AssemblyTest.Interface;

namespace AssemblyPractice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                #region 加载程序集

                setTitle("加载程序集");
                //使用Assembly.Load的方式加载程序集，不需要后缀
                //Assembly assembly = Assembly.Load("AssemblyTest.Interface");
                Assembly assembly = Assembly.Load("AssemblyTest.AssemblyInfo");
                //使用Assembly.LoadFile的方式加载程序集，参数需要完整的路径以及文件类型（需要文件后缀），LoadFile方法不加载以来项
                Assembly assemblyLoadFile = Assembly.LoadFile(@"F:\Practice\AssemblyPractice\AssemblyTest.Interface\bin\Debug\AssemblyTest.Interface.dll");
                //使用Asseblly.LoadFrom的方式加载程序及，参数可以为完整路径，也可以为程序集名称（需要文件后缀）
                Assembly assemblyLoadFromFullPath = Assembly.LoadFrom(@"AssemblyTest.Interface.dll");
                Assembly assemblyLoadFromFileName = Assembly.LoadFrom(@"F:\Practice\AssemblyPractice\AssemblyTest.Interface\bin\Debug\AssemblyTest.Interface.dll");
                Console.WriteLine(assembly.ToString());

                #endregion 加载程序集

                #region 遍历属性

                setTitle("遍历程序集属性");
                foreach (var moudle in assembly.GetModules())
                {
                    Console.WriteLine("Module: " + moudle.FullyQualifiedName);
                }
                foreach (var type in assembly.GetTypes())
                {
                    Console.WriteLine("Type: " + type.FullName);
                    var infoType = assembly.GetType(type.ToString());
                    //构造函数
                    foreach (var Constructor in infoType.GetConstructors())
                    {
                        Console.WriteLine("Constructor: " + Constructor.ToString());
                    }

                    //字段
                    foreach (var field in infoType.GetFields())
                    {
                        Console.WriteLine("Field: " + field.Name);
                    }

                    //方法
                    foreach (var method in infoType.GetMethods())
                    {
                        Console.WriteLine("method: " + method.Name);
                    }

                    //属性
                    foreach (var properties in infoType.GetProperties())
                    {
                        Console.WriteLine("properties: " + properties.Name);
                    }
                }

                #endregion 遍历属性

                AssemblyInformation ss = new AssemblyInformation();
                ss.Query();

                //加载程序集
                assembly = Assembly.Load("AssemblyTest.AssemblyInfo");
                Type typeTest = assembly.GetType("AssemblyTest.AssemblyInfo.AssemblyInformation");
                object oTest = Activator.CreateInstance(typeTest);
                ((AssemblyTest.AssemblyInfo.AssemblyInformation)oTest).Query();
                ((AssemblyTest.Interface.InterfaceParent)oTest).Query();
                var sss = SimpleFactory.CreateConstructor();
                sss.Query();
                oTest = Activator.CreateInstance(typeTest, new object[] { "param1", 123 });
                ((AssemblyTest.Interface.InterfaceParent)oTest).Query();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        private static void setTitle(string str)
        {
            Console.WriteLine('\n' + str.PadLeft(40, '=') + "====================================");
        }
    }
}