using System;

namespace LambdaPractice
{
    public class Anonymous
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }

        public void AnonymousMethod()
        {
            Console.WriteLine("Name: {0},Age: {1},ID: {2}", Name, Age, ID);
        }
    }
}