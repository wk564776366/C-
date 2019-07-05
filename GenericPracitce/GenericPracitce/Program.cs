using System;
using System.Collections.Generic;

namespace GenericPracitce
{
    /// <summary>
    /// -只是简单的讲解协变和逆变以及自定义协变逆变
    /// -讲解地址https://blog.csdn.net/qq_29756987/article/details/94626915
    /// </summary>
    public class Program 
    {
        static void Main(string[] args)
        {

            Human human = new Human();
            Chinese chinese = new Chinese();
            Human chuman = new Chinese();

            List<Human> listHunma = new List<Human>();
            List<Chinese> listChinese = new List<Chinese>();

            //这里List<Human>和List<Chinese>并不存在继承关系所以会报错
            //List<Human> list = new List<Chinese>();

            //协变 可以理解为string->object 关键字为out 可以理解为输出，输出就有返回值，所以T作为返回值
            IEnumerable<Human> list = new List<Chinese>();

            //Custom covariant
            ICustomEnable<Human> customEnumerable = new CustomEnumerable<Chinese>();

            //逆变 可以理解为object->string 关键字为in 可以理解为输入，所以T作为传入值
            ICustomContravariant<Chinese> contravariant = new CustomContravariant<Human>();
        }
    }
}
