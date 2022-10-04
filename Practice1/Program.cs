using System;
using System.Threading;
using System.Threading.Tasks;
namespace Practice1
{
    internal class Program
    {   
        private static void Main()
        {
            Action action = new Action(WriteStringFirst);
            Action action1 = new Action(WriteStringSecond);

            Thread threadOne = new Thread(WriteStringFirst);
            Thread threadTwo = new Thread(WriteStringSecond);


            //Task taskOne = new Task(action);

            Console.Write("Выберите операцию \n 1) Вывести символы с помощью Thread\n 2) Вывести символы с помощью Task\n");
            String numberOperation = Console.ReadLine();

            Console.WriteLine("Нажмите для старта...");
            Console.ReadKey();
            switch (numberOperation)
            {
                case "1":
                    threadOne.Start();
                    threadTwo.Start();
                    break;
                case "2":
                    TaskFactory taskFactory = Task.Factory;
                    taskFactory.StartNew(WriteStringFirst);
                    taskFactory.StartNew(WriteStringSecond);
                    break;
                default:
                    return;
            }

            //for (int i = 0; i < 1000 ; i++)
            //{
            //    Console.WriteLine($"task_1({i},{ thread.ManagedThreadId})");
            //}
            Console.ReadLine();
        }

        private static void WriteStringFirst()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Поток 1, ({i})");
            }
        }
        private static void WriteStringSecond()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Поток 2, ({i})");
            }
        }
    }
}
