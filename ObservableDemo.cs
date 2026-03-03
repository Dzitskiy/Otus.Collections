using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Collections
{
    public class ObservableDemo
    {
        public static void Show()
        {

            var col = new ObservableCollection<string>() {
                "a",
                "b",
                "c",
                "d" };


            // ПОДПИСКА НА ИЗМЕНЕНИЕ КОЛЛЕКЦИИ
            col.CollectionChanged += Col_CollectionChanged;


            Console.WriteLine(Formatted(col));

            col.Add("e");
            col.Add("f");
            col.Add("F");
            col.RemoveAt(1);
            col.Remove("d");
            col[2] = "AAAAA";
            col.Insert(1, "YYYYYYYYYYY");

            Console.WriteLine(Formatted(col));

            col.Clear();


            //o.CollectionChanged += O_CollectionChanged;
            //o1.CollectionChanged += O_CollectionChanged;
            //o1.Add("");
            //Console.WriteLine("Добавим попеременно a и b");
            //o.Add("a");
            //o.Add("b");

            //Console.WriteLine("Удалим нулевой элемент 0");
            //o.RemoveAt(0);

            //Console.WriteLine("Добавим попеременно с и в");
            //o.Add("с");
            //o.Add("в");
            //Console.WriteLine("Заменим");
            //o[1] = "e";

            //Console.WriteLine($"[{string.Join(",", o)}]");
            //o.Clear();

        }


        /// <summary>
        ///  КОЛЛЕКЦИЯ ПОМЕНЯЛАСЬ - ЧТО-ТО ДЕЛАЕМ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Col_CollectionChanged(
            object? sender,
            NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"ADDED: new items = {Formatted(e.NewItems)}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"REMOVE: deleted items = {Formatted(e.OldItems)}");

                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine($"REPLACE: from = {Formatted(e.OldItems)}, to from = {Formatted(e.NewItems)}");

                    break;
                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine("CLEAR");
                    break;
            }




        }

        private static string Formatted(IList? values)
        {
            if (values == null)
            {
                return "[]";
            }
            var a = new object[values.Count];
            values.CopyTo(a, 0);
            return $"[{string.Join(",", a)}]";
        }
    }
}
