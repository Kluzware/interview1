using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewConsoleApp2
{
    internal class Program
    {
        // Jaki będzie wynik programu?
        // What will be result of this code?
        static async Task Main(string[] args)
        {
            var collection = new List<string>();

            Task.Run(() =>
            {
                try
                {
                    Parallel.Invoke(
                         () => collection.Add("m"),
                         () => collection.Add("b"),
                         () => collection.Add("a"),
                         () => throw new LetsFailSomethingException(),
                         () => collection.Add("n"),
                         () => collection.Add("k")
                    );

                }
                catch (LetsFailSomethingException)
                {                  
                    Console.WriteLine("Hello from LetsFailSomethingException");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hello from {ex.GetType()}");
                }
            });

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
