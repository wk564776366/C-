using System;
using System.Configuration;
using System.Reflection;

namespace AssemblyPractice
{
    public class SimpleFactory
    {
        private static string assemblyType = ConfigurationManager.AppSettings["AssemblyType"];
        private static string assemblyName = assemblyType.Split(',')[0];
        private static string assemblyClassName = assemblyType.Split(',')[1];

        public static AssemblyTest.Interface.InterfaceParent CreateConstructor()
        {
            //加载程序集
            Assembly assembly = Assembly.Load(assemblyName);
            //获取程序中指定的Type对象，这个对象名称我们可以根据上方的GetTypes()方法遍历出来
            Type assemblyType = assembly.GetType(assemblyClassName);
            object oTest = Activator.CreateInstance(assemblyType);
            return (AssemblyTest.Interface.InterfaceParent)oTest;
        }
    }
}