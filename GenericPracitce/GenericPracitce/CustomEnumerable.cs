using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPracitce
{
    //协变关键字为out
    public interface ICustomEnable<out T>
    {
        T Get();
    }

    //T作为返回值
    public class CustomEnumerable<T>:ICustomEnable<T>
    {
        public T Get()
        {
            return default(T);
        }
    }
}
