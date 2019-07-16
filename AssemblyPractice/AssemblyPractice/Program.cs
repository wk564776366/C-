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
                    if (infoType != null)
                    {
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
                }

                #endregion 遍历属性

                #region 创建对象

                AssemblyInformation ss = new AssemblyInformation();
                ss.Query();

                setTitle("构造函数");
                //加载程序集
                assembly = Assembly.Load("AssemblyTest.AssemblyInfo");
                Type typeTest = assembly.GetType("AssemblyTest.AssemblyInfo.AssemblyInformation");
                //无参构造函数
                object oTest = Activator.CreateInstance(typeTest);

                ((AssemblyInformation)oTest).Query();
                ((AssemblyTest.Interface.InterfaceParent)oTest).Query();
                var constructor = SimpleFactory.CreateConstructor();
                constructor.Query();
                //有参构造函数
                oTest = Activator.CreateInstance(typeTest, new object[] { "param1", 123 });
                ((AssemblyTest.Interface.InterfaceParent)oTest).Query();

                //调用私有方法
                var privateType = assembly.GetType("AssemblyTest.AssemblyInfo.Singleton");
                Activator.CreateInstance(privateType, true);

                //创建泛型
                assembly = Assembly.Load("AssemblyTest.AssemblyInfo");
                typeTest = assembly.GetType("AssemblyTest.AssemblyInfo.GenericClass`1");
                typeTest = typeTest.MakeGenericType(typeof(int));
                Activator.CreateInstance(typeTest);

                #endregion 创建对象

                #region 调用实例方法、静态方法、重载方法

                setTitle("调用实例方法、静态方法、重载方法");
                assembly = Assembly.Load("AssemblyTest.AssemblyInfo");
                typeTest = assembly.GetType("AssemblyTest.AssemblyInfo.AssemblyInformation");
                oTest = Activator.CreateInstance(typeTest);
                foreach (var item in assembly.GetTypes())
                {
                    Console.WriteLine(item.ToString());
                    foreach (var item1 in item.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                    {
                        Console.WriteLine(item1.Name);
                    }
                }

                var methodTest = typeTest.GetMethod("ShowMsg");
                methodTest.Invoke(oTest, null);

                methodTest = typeTest.GetMethod("ShowMsg1");
                methodTest.Invoke(oTest, new object[] { "str" });

                methodTest = typeTest.GetMethod("ShowMsg2");
                methodTest.Invoke(oTest, new object[] { "str", 123 });

                methodTest = typeTest.GetMethod("ShowMsg3", new Type[] { });
                methodTest.Invoke(oTest, null);

                methodTest = typeTest.GetMethod("ShowMsg3", new Type[] { typeof(string) });
                methodTest.Invoke(oTest, new object[] { "string" });

                methodTest = typeTest.GetMethod("ShowMsg4", BindingFlags.NonPublic | BindingFlags.Instance);
                methodTest.Invoke(oTest, null);

                methodTest = typeTest.GetMethod("ShowMsg5");
                methodTest.Invoke(null, null);

                methodTest = typeTest.GetMethod("ShowMsg6");
                methodTest = methodTest.MakeGenericMethod(typeof(int));
                methodTest.Invoke(oTest, new object[] { 123 });

                #endregion 调用实例方法、静态方法、重载方法

                setTitle("调用属性");

                #region 调用属性

                assembly = Assembly.Load("AssemblyTest.AssemblyInfo");
                typeTest = assembly.GetType("AssemblyTest.AssemblyInfo.AssemblyInformation");
                oTest = Activator.CreateInstance(typeTest);

                foreach (var properties in typeTest.GetProperties())
                {
                    Console.WriteLine(properties.Name);
                    Console.WriteLine(properties.GetValue(oTest));
                    if (properties.Name.Equals("publicName"))
                    {
                        properties.SetValue(oTest, "str");
                    }
                    Console.WriteLine(properties.GetValue(oTest));
                }

                #endregion 调用属性
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