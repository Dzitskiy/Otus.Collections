using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Collections
{
    internal class ConcurrentDemo
    {
        public static async Task Show()
        {
            //await List();
            await Dict();
            //CompareCollections();
        }


        private static void CompareCollections()
        {
            var sw = new Stopwatch();
            var l1 = new List<int>();
            var l2 = new ConcurrentBag<int>();

            sw.Start();
            for (var i = 0; i < 100_000_000; i++)
            {
                l1.Add(i);
            }
            sw.Stop();

            Console.WriteLine($"List = {sw.ElapsedMilliseconds}");
            sw.Reset();
            sw.Start();
            for (var i = 0; i < 100_000_000; i++)
            {
                l2.Add(i);
            }
            sw.Stop();

            Console.WriteLine($"ConcurrentBag = {sw.ElapsedMilliseconds}");
        }

        private static async Task List()
        {
            //List<int> numbersBag = new();

            ConcurrentBag<int> numbersBag = new();

            //var locObj = new object();

            Parallel.For(0, 1000, i =>
            {
                //lock (locObj)
                numbersBag.Add(i);
            });

            Console.WriteLine(numbersBag.Count);
        }

        private static async Task Dict()
        {
            //var dict = new Dictionary<int, int>();

            var dict = new ConcurrentDictionary<int, int>();

            // Заполняем словать начальными данными
            for (int i = 0; i < 10; i++)
            {
                dict[i] = i;
            }

            var l = new object();

            // Задача 1: Модифицируем словарь в бесконечном цикле (в другом потоке)
            var modifTask = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    //lock (l)
                    //{
                    dict.TryAdd(1, 1); // Добавляем или обновляем элемент
                    dict.Remove(1, out var v); // Удаляем элемент
                    //}
                    Thread.Sleep(1);
                }
            });

            // Задача 2: Перебор словаря
            var enumTask = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    //lock (l)
                    { 
                        foreach (var kvp in dict)
                        {
                            // Просто читаем элементы
                            var key = kvp.Key;
                            var value = kvp.Value;
                            Thread.Sleep(1);
                        }
                    }
                    //}
                }
            });

            await Task.WhenAll(modifTask, enumTask);

            //Ожидаем завершения задач
            Console.WriteLine("Waiting");

            Console.ReadKey();
        }

        private static void Queue()
        {
            // Construct a ConcurrentQueue.
            var cq = new ConcurrentQueue<int>();

            // Заполняем очередь

            var targetSum = 0;
            for (int i = 0; i < 10000; i++)
            {
                targetSum += i;
                cq.Enqueue(i);
            }

            int outerSum = 0;

            var action = () =>
            {
                int localSum = 0;
                while (cq.TryDequeue(out var localValue))
                {
                    localSum += localValue;
                }

                //outerSum += localSum;   
                Interlocked.Add(ref outerSum, localSum);
            };

            var actions = new List<Action>();
            for (var i = 0; i < 50; i++)
            {
                actions.Add(action);
            }

            // Запускаем параллельно 4 задачи
            Parallel.Invoke(actions.ToArray());

            Console.WriteLine($"outerSum = {outerSum}, should be {targetSum}");
        }
    }
}