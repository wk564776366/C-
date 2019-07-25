using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaPractice
{
    public class DelegatePractice
    {
        public delegate void OnParamDelegate(int iParam);

        public delegate string OnParamWithReturnDelegate(double iParam);

        public delegate void NoParamDelegate();

        public void ShowDelegate()
        {
            //{
            //    OnParamDelegate onParamDelegate = new OnParamDelegate(this.DoSomething);
            //    onParamDelegate.Invoke(1);

            //    OnParamWithReturnDelegate onParamWithReturnDelegate = new OnParamWithReturnDelegate(this.DoSomething);
            //    onParamWithReturnDelegate.Invoke(1.2);
            //}
            {
                OnParamDelegate onParamDelegate = new OnParamDelegate(delegate (int i)
                {
                    Console.WriteLine("iParam:{0}", i);
                });
                onParamDelegate.Invoke(1);
            }
            {
                OnParamDelegate onParamDelegate = new OnParamDelegate((int i) =>
                {
                    Console.WriteLine("iParam:{0}", i);
                });
                onParamDelegate.Invoke(1);
            }
            {
                OnParamDelegate onParamDelegate = new OnParamDelegate((i) =>
                {
                    Console.WriteLine("iParam:{0}", i);
                });
                onParamDelegate.Invoke(1);
            }
            {
                //无参
                Action actNoParam = new Action(() => { Console.WriteLine("NoParam"); });
                actNoParam.Invoke();

                //有参
                Action<int> actWithParam = new Action<int>((t) => { Console.WriteLine("{0}", t); });
                actWithParam.Invoke(1);

                //有参
                Func<int> FuncNoParam = new Func<int>(() => { return 1; });
                FuncNoParam.Invoke();

                //无参
                Func<int, string> FuncWithParam = new Func<int, string>((t) => { return t.ToString(); });
                FuncWithParam.Invoke(123);
            }
            {
                Action actNoParam = new Action(() => { Console.WriteLine("NoParam"); });
                Action<int> actWithParam = new Action<int>((t) => { Console.WriteLine("{0}", t); });
                //1.如果参数只有一个可以省略参数外面的()
                //Action<int> actWithParam = new Action<int>((t) => { Console.WriteLine("{0}", t); });
                Action<int> actWithParam1 = new Action<int>(t => { Console.WriteLine("{0}", t); });

                //2.如果为无参数的则直接使用()
                //Action actNoParam = new Action(() => { Console.WriteLine("NoParam"); });
                Action actNoParam2 = new Action(() => { Console.WriteLine("NoParam"); });

                //3.如果方法体只有一行，这可以省略方法体外的{}以及方法体的分号；
                Action actNoParam3 = new Action(() => Console.WriteLine("NoParam"));
                Action<int> actWithParam3 = new Action<int>(t => Console.WriteLine("{0}", t));

                //4.我们再说委托的时候有说道在声明委托的时候，可以直接将方法赋给委托
                //OnParamWithReturnDelegate onParamWithReturnDelegate = this.DoSomething;
                Action actNoParam4 = () => Console.WriteLine("NoParam");
                Action<int> actWithParam4 = t => Console.WriteLine("{0}", t);
            }
        }

        //private void DoSomething(int iParam)
        //{
        //    Console.WriteLine("iParam:{0}", iParam);
        //}

        //public string DoSomething(double dParam)
        //{
        //    return dParam.ToString();
        //}
    }
}