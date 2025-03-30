using System;
using System.Collections.Generic;

namespace FlightScheduleExample
{
    // Класс, описывающий рейс самолёта
    class Flight
    {
        // Поля и свойства
        public string FlightNumber { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public DateTime ArrivalTime
        {
            get { return _arrivalTime; }
            private set
            {
                // Проверка: время прилёта должно быть позже времени вылета
                if (value <= DepartureTime)
                    throw new ArgumentException("Время прилёта должно быть позже времени вылета.");
                _arrivalTime = value;
            }
        }
        private DateTime _arrivalTime;
        public string Destination { get; private set; }

        // Конструктор с параметрами
        public Flight(string flightNumber, DateTime departureTime, DateTime arrivalTime, string destination)
        {
            FlightNumber = flightNumber;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime; // вызовет проверку
            Destination = destination;
        }

        // Переопределение метода ToString для форматированного вывода
        public override string ToString()
        {
            return $"Рейс № {FlightNumber}: вылет {DepartureTime}, прилет {ArrivalTime}, пункт назначения: {Destination}";
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введите количество рейсов N: ");
            int n = ReadInt();

            // Создаем массив рейсов
            Flight[] flightArray = new Flight[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nВведите данные для рейса № {i + 1}:");
                flightArray[i] = InputFlight();
            }

            // Создаем коллекцию List<Flight> и заполняем её данными из массива
            List<Flight> flights = new List<Flight>(flightArray);

            // Демонстрация работы методов List<T>

            // 1. Add: добавление нового рейса
            Console.WriteLine("\nДемонстрация метода Add - добавление нового рейса.");
            Flight newFlight = new Flight("NEW123",
                DateTime.Now.AddHours(1),
                DateTime.Now.AddHours(3),
                "Москва");
            flights.Add(newFlight);
            Console.WriteLine("Новый рейс добавлен: " + newFlight);

            // 2. Insert: вставка рейса по указанному индексу
            Console.WriteLine("\nДемонстрация метода Insert - вставка рейса по индексу 0.");
            Flight insertedFlight = new Flight("INS456",
                DateTime.Now.AddHours(2),
                DateTime.Now.AddHours(4),
                "Санкт-Петербург");
            flights.Insert(0, insertedFlight);
            Console.WriteLine("Вставленный рейс: " + insertedFlight);

            // 3. Remove: удаление рейса (удаляем рейс с номером "INS456")
            Console.WriteLine("\nДемонстрация метода Remove - удаление рейса с номером INS456.");
            bool removed = flights.Remove(insertedFlight);
            Console.WriteLine(removed ? "Рейс удалён." : "Рейс не найден для удаления.");

            // 4. RemoveAt: удаление рейса по индексу (удаляем рейс с индексом 0)
            Console.WriteLine("\nДемонстрация метода RemoveAt - удаление рейса по индексу 0.");
            if (flights.Count > 0)
            {
                Console.WriteLine("Удаляем рейс: " + flights[0]);
                flights.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("Список рейсов пуст.");
            }

            // 5. Find: поиск рейса по номеру
            Console.WriteLine("\nДемонстрация метода Find - поиск рейса с номером NEW123.");
            Flight found = flights.Find(f => f.FlightNumber == "NEW123");
            Console.WriteLine(found != null ? "Найден рейс: " + found : "Рейс не найден.");

            // 6. GetRange: получение диапазона рейсов (если элементов не меньше 2)
            Console.WriteLine("\nДемонстрация метода GetRange - получение диапазона из 2 элементов начиная с индекса 0.");
            if (flights.Count >= 2)
            {
                List<Flight> range = flights.GetRange(0, 2);
                foreach (var f in range)
                    Console.WriteLine(f);
            }
            else
            {
                Console.WriteLine("Недостаточно элементов для получения диапазона.");
            }

            // 7. ToArray: копирование коллекции в массив
            Console.WriteLine("\nДемонстрация метода ToArray - копирование коллекции в массив.");
            Flight[] copiedArray = flights.ToArray();
            foreach (var f in copiedArray)
                Console.WriteLine(f);

            // Дополнительная задача:
            // Ввод информации о рейсах уже выполнен, теперь запрашиваем пункт назначения и выводим рейсы
            Console.Write("\nВведите пункт назначения для поиска рейсов: ");
            string destinationSearch = Console.ReadLine();
            List<Flight> filteredFlights = flights.FindAll(f => f.Destination.Equals(destinationSearch, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nРейсы с пунктом назначения \"{destinationSearch}\":");
            if (filteredFlights.Count == 0)
            {
                Console.WriteLine("Рейсы не найдены.");
            }
            else
            {
                foreach (var f in filteredFlights)
                {
                    Console.WriteLine(f);
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }

        // Метод для ввода рейса
        static Flight InputFlight()
        {
            Console.Write("Номер рейса: ");
            string flightNumber = Console.ReadLine();

            Console.Write("Время вылета (формат: yyyy-MM-dd HH:mm): ");
            DateTime departureTime = ReadDateTime();

            Console.Write("Время прилета (формат: yyyy-MM-dd HH:mm): ");
            DateTime arrivalTime = ReadDateTime();

            // Проверка, что время прилета позже вылета, если нет – повторный ввод
            while (arrivalTime <= departureTime)
            {
                Console.WriteLine("Время прилета должно быть позже времени вылета. Повторите ввод.");
                Console.Write("Время прилета (формат: yyyy-MM-dd HH:mm): ");
                arrivalTime = ReadDateTime();
            }

            Console.Write("Пункт назначения: ");
            string destination = Console.ReadLine();

            return new Flight(flightNumber, departureTime, arrivalTime, destination);
        }

        // Метод для безопасного чтения целого числа
        static int ReadInt()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Неверный ввод. Введите целое число: ");
            }
            return result;
        }

        // Метод для безопасного чтения даты и времени
        static DateTime ReadDateTime()
        {
            DateTime dt;
            while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.Write("Неверный формат. Введите дату и время в формате yyyy-MM-dd HH:mm: ");
            }
            return dt;
        }
    }
}
