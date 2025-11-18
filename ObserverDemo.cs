namespace Otus.Collections
{
    public interface IPaperSubscriberObserver
    {
        void Receive(string paperName);
    }

    public class Human : IPaperSubscriberObserver
    {
        private readonly string _fullName;

        public Human(string fullName)
        {
            _fullName = fullName;
        }

        public void Receive(string paperName)
        {
            Console.WriteLine($"My name is {_fullName} and I received '{paperName}' ");
        }
    }

    /// <summary>
    /// Издатель газет (Observable)
    /// </summary>
    public class PaperPublisher
    {
        private readonly List<IPaperSubscriberObserver> Subscribers = new();

        public void Subscribe(IPaperSubscriberObserver newSubscriber)
        {
            if (!Subscribers.Contains(newSubscriber))
            {
                Subscribers.Add(newSubscriber);
            }
        }

        public void PrintNewsPaper(string name)
        {
            Console.WriteLine("--------------");
            Console.WriteLine($"New issue of '{name}', Sending to subscribers");
            Console.WriteLine("--------------");

            foreach (var s in Subscribers)
            {
                s.Receive(name);
            }
        }
    }

    public class ObserverDemo
    {

        public static void Show()
        {

            var p = new PaperPublisher();
            var h1 = new Human("Ivan Petrov");
            var h2 = new Human("Andrew Sidorov");
            var h3 = new Human("Helen Ivanova");

            p.Subscribe(h1);
            p.Subscribe(h2);
            p.PrintNewsPaper("Argumenty i facty №1");

            Console.WriteLine();

            p.Subscribe(h3);
            p.PrintNewsPaper("Argumenty if facty №2");
            p.PrintNewsPaper("Izvestia №1");
        }
    }

}
