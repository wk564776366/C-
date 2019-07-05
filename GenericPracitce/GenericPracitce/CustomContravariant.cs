using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPracitce
{
    //逆变关键字为in
    public interface ICustomContravariant<in T>
    {
        void Show(T t);
    }

    //T作为传入值
    public class CustomContravariant<T>: ICustomContravariant<T>
    {

        public void Show(T t)
        {

        }
    }
}
