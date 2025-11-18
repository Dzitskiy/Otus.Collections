1. Паттерн Observer
**Сущность паттерна:** разделение отправителя и получателя событий.
Пример реализации через IObservable<T> и IObserver<T>.
Сравнение с традиционными событиями в C# (event и delegate).
Применение в реактивном программировании (Rx.NET, UI-байндинг).

2. ObservableCollection
**Назначение:** коллекция, уведомляющая об изменениях содержимого.
Интерфейс INotifyCollectionChanged и событие CollectionChanged.
Связь с WPF и MVVM (автоматическое обновление UI).
**Ограничения:** не потокобезопасна, предназначена для одного потока.

3. System.Collections.Immutable
Принцип неизменяемости и его преимущества: потокобезопасность, предсказуемость состояния, возможность совместного доступа.
**Основные типы:** ImmutableList<T>, ImmutableDictionary<TKey, TValue>, ImmutableArray<T>, ImmutableQueue<T>, ImmutableStack<T>.
Создание и модификация через методы Add, Remove, SetItem, создающие новые коллекции.
**Сценарии использования:** функциональный стиль, параллельные вычисления, кэширование.

4. System.Collections.Concurrent
Проблема синхронизации доступа к общим данным.
**Потокобезопасные коллекции .NET:** ConcurrentDictionary, ConcurrentQueue, ConcurrentBag, ConcurrentStack, BlockingCollection.
Внутренняя реализация (lock-free структуры, сегментация).
**Типичные сценарии:** очереди задач, кэширование, обработка логов и сообщений.
