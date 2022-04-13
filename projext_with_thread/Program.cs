using System;
using System.Collections.Generic;
using System.Threading;

namespace projext_with_thread
{
    class Program
    {
        static void Main(string[] args)
        {

            var dummyrequest = new DummyRequestHandler();
            List<string> list = new List<string>();
            Console.WriteLine("\nEnter your message.If you want to finish,enter '/exit' ");
           string new_string = Console.ReadLine();
            while (new_string != "/exit")
            {
                Console.WriteLine("Не угадал");
                while (true)
                {
                    Console.WriteLine("\nEnter your arguments. If you want to end, enter '/end'. ");
                    string string_arguments = Console.ReadLine();
                    if (string_arguments.Contains("/end")) break;
                    list.Add(string_arguments);
                }
                ThreadPool.QueueUserWorkItem(callback => auxiliary_func(new_string, list.ToArray()));
                Console.WriteLine("Enter message");
                new_string = Console.ReadLine();
            }
            Console.WriteLine("Угадал!");
        }

        static void auxiliary_func(string message,string[] arguments)
        {
            var some_iden = Guid.NewGuid().ToString("D");

            try {
                var answer = new DummyRequestHandler().HandleRequest(message, arguments);
                Console.WriteLine($"Message was delivered with identificator{some_iden}. Answer is {answer}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message was delivered with identificator{some_iden}. Fall with {ex.Message}");
            }

        }
    }
}

/// <summary>
/// Предоставляет возможность обработать запрос.
/// </summary>
public interface IRequestHandler
{
    /// <summary>
    /// Обработать запрос.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="arguments">Аргументы запроса.</param>
    /// <returns>Результат выполнения запроса.</returns>
    string HandleRequest(string message, string[] arguments);
}


/// <summary>
/// Тестовый обработчик запросов.
/// </summary>
public class DummyRequestHandler : IRequestHandler
{
    /// <inheritdoc />
    public string HandleRequest(string message, string[] arguments)
    {
        // Притворяемся, что делаем что то.
        Thread.Sleep(10_000);
        if (message.Contains("упади"))
        {
            throw new Exception("Я упал, как сам просил");
        }
        return Guid.NewGuid().ToString("D");
    }
}