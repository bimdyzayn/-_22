using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace задание_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива:");
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n]; 
            Random rnd = new Random();

            for (int i = 0; i < n; i++) 
            {
                array[i] = rnd.Next(100);
                    
            }


            Task task1 = new Task(() => {
                Console.WriteLine($"Сумма чисел: {array.Sum()}");
            });

            // задача продолжения
            Task task2 = task1.ContinueWith(max => Display(array.Max()));

            task1.Start();

            // ждем окончания второй задачи
            task2.Wait();
            Console.WriteLine("Выполняется работа метода Main");
            Console.ReadLine();
        }

        static void Display(int max)
        {
            Console.WriteLine($"Максимально значение массива: {max}");
        }
    }
}