using JobApp.App.Core.Interfaces.Handlers;
using JobApp.App.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace JobApp.App.ConsoleApp
{
    static class ProgramEntry
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            AppInjection.Configure(container);
            container.RegisterType<Program>();
            var program = container.Resolve<Program>();
            program.Run(args);
        }
    }

    public class Program
    {
        private readonly ILinqChallengeHandler LinqChallengeHandler;
        public Program(ILinqChallengeHandler linqChallengeHandler)
        {
            LinqChallengeHandler = linqChallengeHandler;
        }

        public void CollatzRanking()
        {

            var result = LinqChallengeHandler.CollatzTopRanked(1, 1000000);

            Console.WriteLine();
            Console.WriteLine(result.Message);
        }

        public void EvenOddSplit()
        {
            var itemArray = new int[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

            var result = LinqChallengeHandler.EvenOddSplit(itemArray);

            Console.WriteLine();
            Console.WriteLine(result.Message);
        }

        public void NotContainsFilter()
        {
            var list = new int[] { 1, 3, 7, 29, 42, 98, 234, 93 };

            var filterList = new int[] { 4, 6, 93, 7, 55, 32, 3 };

            var result = LinqChallengeHandler.NotContainsFilter(list, filterList);

            Console.WriteLine();
            Console.WriteLine(result.Message);
        }

        public void Run(string[] args)
        {
            var option = args.Any() ? args[0] : string.Empty;
            switch (option)
            {
                case "collatz":
                case "tarefa1":
                    CollatzRanking();
                    break;
                case "tarefa2":
                    EvenOddSplit();
                    break;
                case "tarefa3":
                    NotContainsFilter();
                    break;
                default:
                    Console.WriteLine("TAREFA 1\r\n========");
                    CollatzRanking();
                    Console.WriteLine("TAREFA 2\r\n========");
                    EvenOddSplit();
                    Console.WriteLine("TAREFA 3\r\n========");
                    NotContainsFilter();
                    break;
            }
        }
    }

}
