using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AgentApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool numberCheck = true;
            var service = new ServiceCollection().AddTransient<IAgentService, AgentService>();

            using var serviceProvider = service.BuildServiceProvider();
            var worker = new ItemsAgent(serviceProvider.GetService<IAgentService>()!);
            //Console.WriteLine("Введите логин");
            //var login = Console.ReadLine();
            //Console.WriteLine("Введите пароль");
            //var pass = Console.ReadLine();
            //var agent = worker.Auth(new AuthRequest { Login = login, Password = pass });
            //bool isGlows = false;

            string number = "";
            while (true)
            {
                Console.WriteLine("Введите инвентарный номер");
                try
                {
                    number = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(number))
                    {
                        
                        break;
                    }
                    else throw new Exception();

                }
                catch
                {
                    Console.WriteLine("Вы ввели некорректные данные");
                }
            }

            string name = "";
            while (true)
            {
                Console.WriteLine("Введите наименование");
                try
                {
                    name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        
                        break;
                    }
                    else throw new Exception();

                }
                catch
                {
                    Console.WriteLine("Вы ввели некорректные данные");
                }
            }

            int amount = 0;
            while (true)
            {
                Console.WriteLine("Введите количество");
                try
                {
                    amount = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Вы ввели не число");
                }
            }


            var response = worker.AddNewItem(new AddRequest { Number = number, Name = name, Amount= amount }).Result;
            if (response.Res) Console.WriteLine("Объект успешно добавлен");
            else Console.WriteLine("Объект не был добавлен. Попробуйте снова");
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}