using System;
using System.Collections.Generic;

namespace PracticheskayaRabota23
{
    // Класс для задачи №8: Рейсы самолётов
    class Flight
    {
        public string FlightNumber { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Destination { get; set; }

        public Flight(string flightNumber, string departureTime, string arrivalTime, string destination)
        {
            FlightNumber = flightNumber;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Destination = destination;
        }

        public override string ToString()
        {
            return $"Рейс: {FlightNumber}, Вылет: {DepartureTime}, Прилёт: {ArrivalTime}, Пункт назначения: {Destination}";
        }
    }

    // Класс для задачи №10: Ученики и оценки
    class Student
    {
        public int Number { get; set; }
        public string FullName { get; set; }
        public int Grade1 { get; set; }
        public int Grade2 { get; set; }
        public int Grade3 { get; set; }

        // Средняя оценка вычисляется как математическое округление арифметического среднего
        public int AverageGrade
        {
            get
            {
                double avg = (Grade1 + Grade2 + Grade3) / 3.0;
                return (int)Math.Round(avg, MidpointRounding.AwayFromZero);
            }
        }

        public Student(int number, string fullName, int grade1, int grade2, int grade3)
        {
            Number = number;
            FullName = fullName;
            Grade1 = grade1;
            Grade2 = grade2;
            Grade3 = grade3;
        }

        // Классификация по средней оценке:
        // Отличник: AverageGrade == 5,
        // Хорошист: AverageGrade == 4,
        // Троечник: AverageGrade <= 3.
        public string GetCategory()
        {
            int avg = AverageGrade;
            if (avg == 5)
                return "Отличник";
            else if (avg == 4)
                return "Хорошист";
            else
                return "Троечник";
        }

        public override string ToString()
        {
            return $"№: {Number}, Ф.И.О.: {FullName}, Оценки: {Grade1}, {Grade2}, {Grade3}, Средняя: {AverageGrade} - {GetCategory()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool exitMain = false;
            while (!exitMain)
            {
                Console.WriteLine("Выберите задачу для запуска:");
                Console.WriteLine("8  - Рейсы самолётов");
                Console.WriteLine("10 - Ученики и оценки");
                Console.WriteLine("0  - Выход");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "8":
                        RunTask8();
                        break;
                    case "10":
                        RunTask10();
                        break;
                    case "0":
                        exitMain = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Повторите ввод.");
                        break;
                }
                Console.WriteLine();
            }
        }

        // Метод для вывода всех рейсов
        static void DisplayFlights(List<Flight> flights)
        {
            Console.WriteLine("\n--- Список всех рейсов ---");
            if (flights.Count == 0)
                Console.WriteLine("Список рейсов пуст.");
            else
            {
                for (int i = 0; i < flights.Count; i++)
                {
                    Console.WriteLine($"{i}: {flights[i]}");
                }
            }
        }

        // Задача №8: Рейсы самолётов с подменю для выбора метода List<T>
        static void RunTask8()
        {
            Console.Write("Сколько рейсов вы хотите ввести? ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.Write("Введите корректное положительное число: ");
            }

            List<Flight> flights = new List<Flight>();

            // Ввод данных с проверкой уникальности времени вылета
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nВвод данных для рейса {i + 1}:");
                Console.Write("Введите номер рейса: ");
                string flightNum = Console.ReadLine();

                string departure;
                while (true)
                {
                    Console.Write("Введите время вылета (например, 10:30): ");
                    departure = Console.ReadLine();
                    if (flights.Exists(f => f.DepartureTime.Equals(departure, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("Ошибка: рейс с таким временем вылета уже существует. Повторите ввод.");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write("Введите время прилёта (например, 13:45): ");
                string arrival = Console.ReadLine();

                Console.Write("Введите пункт назначения: ");
                string dest = Console.ReadLine();

                flights.Add(new Flight(flightNum, departure, arrival, dest));
            }

            // Подменю для демонстрации методов List<T> для рейсов
            bool exitSubMenu = false;
            while (!exitSubMenu)
            {
                Console.WriteLine("\nВыберите метод List<T> для демонстрации в задаче 8:");
                Console.WriteLine("1 - Insert");
                Console.WriteLine("2 - AddRange");
                Console.WriteLine("3 - RemoveAt");
                Console.WriteLine("4 - Remove");
                Console.WriteLine("5 - Contains");
                Console.WriteLine("6 - IndexOf");
                Console.WriteLine("7 - FindAll");
                Console.WriteLine("8 - Вывести все рейсы");
                Console.WriteLine("0 - Завершить демонстрацию для задачи 8");
                Console.Write("Ваш выбор: ");
                string methodChoice = Console.ReadLine();

                switch (methodChoice)
                {
                    case "1": // Insert
                        Console.Write("Введите индекс, куда вставить новый рейс: ");
                        int insertIndex;
                        while (!int.TryParse(Console.ReadLine(), out insertIndex) || insertIndex < 0 || insertIndex > flights.Count)
                        {
                            Console.Write("Введите корректный индекс: ");
                        }
                        Console.Write("Введите номер нового рейса: ");
                        string newFlightNum = Console.ReadLine();
                        Console.Write("Введите время вылета нового рейса: ");
                        string newDeparture = Console.ReadLine();
                        Console.Write("Введите время прилёта нового рейса: ");
                        string newArrival = Console.ReadLine();
                        Console.Write("Введите пункт назначения нового рейса: ");
                        string newDest = Console.ReadLine();
                        Flight newFlight = new Flight(newFlightNum, newDeparture, newArrival, newDest);
                        flights.Insert(insertIndex, newFlight);
                        Console.WriteLine("Новый рейс вставлен: " + newFlight);
                        break;
                    case "2": // AddRange
                        Console.Write("Сколько дополнительных рейсов добавить? ");
                        int addRangeCount;
                        while (!int.TryParse(Console.ReadLine(), out addRangeCount) || addRangeCount <= 0)
                        {
                            Console.Write("Введите корректное число: ");
                        }
                        Flight[] additionalFlights = new Flight[addRangeCount];
                        for (int i = 0; i < addRangeCount; i++)
                        {
                            Console.WriteLine($"\nВвод данных для дополнительного рейса {i + 1}:");
                            Console.Write("Введите номер рейса: ");
                            string afn = Console.ReadLine();
                            Console.Write("Введите время вылета: ");
                            string adt = Console.ReadLine();
                            Console.Write("Введите время прилёта: ");
                            string aat = Console.ReadLine();
                            Console.Write("Введите пункт назначения: ");
                            string adest = Console.ReadLine();
                            additionalFlights[i] = new Flight(afn, adt, aat, adest);
                        }
                        flights.AddRange(additionalFlights);
                        Console.WriteLine("Дополнительные рейсы успешно добавлены методом AddRange.");
                        break;
                    case "3": // RemoveAt
                        Console.Write("Введите индекс рейса для удаления: ");
                        int removeIndex;
                        while (!int.TryParse(Console.ReadLine(), out removeIndex) || removeIndex < 0 || removeIndex >= flights.Count)
                        {
                            Console.Write("Введите корректный индекс: ");
                        }
                        Flight removedFlight = flights[removeIndex];
                        flights.RemoveAt(removeIndex);
                        Console.WriteLine("Удалён рейс: " + removedFlight);
                        break;
                    case "4": // Remove
                        Console.Write("Введите номер рейса, который нужно удалить: ");
                        string removeFlightNum = Console.ReadLine();
                        Flight flightToRemove = flights.Find(f => f.FlightNumber.Equals(removeFlightNum, StringComparison.OrdinalIgnoreCase));
                        if (flightToRemove != null)
                        {
                            flights.Remove(flightToRemove);
                            Console.WriteLine("Рейс удалён: " + flightToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Рейс с данным номером не найден.");
                        }
                        break;
                    case "5": // Contains
                        Console.Write("Введите номер рейса для проверки наличия: ");
                        string searchFlightNum = Console.ReadLine();
                        Flight foundFlight = flights.Find(f => f.FlightNumber.Equals(searchFlightNum, StringComparison.OrdinalIgnoreCase));
                        if (foundFlight != null)
                        {
                            bool containsFlight = flights.Contains(foundFlight);
                            Console.WriteLine($"Рейс с номером {searchFlightNum} {(containsFlight ? "найден" : "не найден")} методом Contains.");
                        }
                        else
                        {
                            Console.WriteLine("Рейс не найден для проверки.");
                        }
                        break;
                    case "6": // IndexOf
                        Console.Write("Введите номер рейса для определения его индекса: ");
                        string indexFlightNum = Console.ReadLine();
                        Flight flightForIndex = flights.Find(f => f.FlightNumber.Equals(indexFlightNum, StringComparison.OrdinalIgnoreCase));
                        if (flightForIndex != null)
                        {
                            int flightIndex = flights.IndexOf(flightForIndex);
                            Console.WriteLine($"Индекс рейса с номером {indexFlightNum}: {flightIndex}");
                        }
                        else
                        {
                            Console.WriteLine("Рейс не найден для определения индекса.");
                        }
                        break;
                    case "7": // FindAll
                        Console.Write("Введите пункт назначения для поиска рейсов: ");
                        string findDest = Console.ReadLine();
                        List<Flight> foundFlights = flights.FindAll(f => f.Destination.Equals(findDest, StringComparison.OrdinalIgnoreCase));
                        Console.WriteLine($"Найдено рейсов с пунктом назначения \"{findDest}\": {foundFlights.Count}");
                        foreach (var f in foundFlights)
                        {
                            Console.WriteLine(f);
                        }
                        break;
                    case "8": // Вывести все рейсы
                        DisplayFlights(flights);
                        break;
                    case "0":
                        exitSubMenu = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Повторите ввод.");
                        break;
                }
                Console.WriteLine();
            }
        }

        // Метод для вывода всех учеников
        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("\n--- Список всех учеников ---");
            if (students.Count == 0)
                Console.WriteLine("Список учеников пуст.");
            else
            {
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"{i}: {students[i]}");
                }
            }
        }

        // Задача №10: Ученики и оценки с подменю для выбора метода List<T>
        static void RunTask10()
        {
            Console.Write("Сколько учеников вы хотите ввести? ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.Write("Введите корректное положительное число: ");
            }

            List<Student> students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nВвод данных для ученика {i + 1}:");
                Console.Write("Введите порядковый номер: ");
                int number;
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("Введите корректный порядковый номер: ");
                }

                Console.Write("Введите Ф.И.О.: ");
                string fio = Console.ReadLine();

                int grade1, grade2, grade3;
                Console.Write("Введите первую оценку (от 2 до 5): ");
                while (!int.TryParse(Console.ReadLine(), out grade1) || grade1 < 2 || grade1 > 5)
                {
                    Console.Write("Введите корректную оценку (от 2 до 5): ");
                }
                Console.Write("Введите вторую оценку (от 2 до 5): ");
                while (!int.TryParse(Console.ReadLine(), out grade2) || grade2 < 2 || grade2 > 5)
                {
                    Console.Write("Введите корректную оценку (от 2 до 5): ");
                }
                Console.Write("Введите третью оценку (от 2 до 5): ");
                while (!int.TryParse(Console.ReadLine(), out grade3) || grade3 < 2 || grade3 > 5)
                {
                    Console.Write("Введите корректную оценку (от 2 до 5): ");
                }

                students.Add(new Student(number, fio, grade1, grade2, grade3));
            }

            // Подменю для демонстрации методов List<T> для учеников
            bool exitSubMenu = false;
            while (!exitSubMenu)
            {
                Console.WriteLine("\nВыберите метод List<T> для демонстрации в задаче 10:");
                Console.WriteLine("1 - Insert");
                Console.WriteLine("2 - AddRange");
                Console.WriteLine("3 - RemoveAt");
                Console.WriteLine("4 - Remove");
                Console.WriteLine("5 - Contains");
                Console.WriteLine("6 - IndexOf");
                Console.WriteLine("7 - FindAll (классификация по категориям с вычислением средней оценки)");
                Console.WriteLine("8 - Вывести всех учеников");
                Console.WriteLine("0 - Завершить демонстрацию для задачи 10");
                Console.Write("Ваш выбор: ");
                string methodChoice = Console.ReadLine();

                switch (methodChoice)
                {
                    case "1": // Insert
                        Console.Write("Введите индекс, куда вставить нового ученика: ");
                        int insertIndex;
                        while (!int.TryParse(Console.ReadLine(), out insertIndex) || insertIndex < 0 || insertIndex > students.Count)
                        {
                            Console.Write("Введите корректный индекс: ");
                        }
                        Console.Write("Введите порядковый номер нового ученика: ");
                        int newNumber;
                        while (!int.TryParse(Console.ReadLine(), out newNumber))
                        {
                            Console.Write("Введите корректный порядковый номер: ");
                        }
                        Console.Write("Введите Ф.И.О. нового ученика: ");
                        string newFio = Console.ReadLine();
                        Console.Write("Введите первую оценку (от 2 до 5): ");
                        int newGrade1 = int.Parse(Console.ReadLine());
                        Console.Write("Введите вторую оценку (от 2 до 5): ");
                        int newGrade2 = int.Parse(Console.ReadLine());
                        Console.Write("Введите третью оценку (от 2 до 5): ");
                        int newGrade3 = int.Parse(Console.ReadLine());
                        Student newStudent = new Student(newNumber, newFio, newGrade1, newGrade2, newGrade3);
                        students.Insert(insertIndex, newStudent);
                        Console.WriteLine("Вставлен новый ученик: " + newStudent);
                        break;
                    case "2": // AddRange
                        Console.Write("Сколько учеников добавить? ");
                        int addCount;
                        while (!int.TryParse(Console.ReadLine(), out addCount) || addCount <= 0)
                        {
                            Console.Write("Введите корректное число: ");
                        }
                        Student[] additionalStudents = new Student[addCount];
                        for (int i = 0; i < addCount; i++)
                        {
                            Console.WriteLine($"\nВвод данных для дополнительного ученика {i + 1}:");
                            Console.Write("Введите порядковый номер: ");
                            int num = int.Parse(Console.ReadLine());
                            Console.Write("Введите Ф.И.О.: ");
                            string fioAdd = Console.ReadLine();
                            Console.Write("Введите первую оценку (от 2 до 5): ");
                            int g1 = int.Parse(Console.ReadLine());
                            Console.Write("Введите вторую оценку (от 2 до 5): ");
                            int g2 = int.Parse(Console.ReadLine());
                            Console.Write("Введите третью оценку (от 2 до 5): ");
                            int g3 = int.Parse(Console.ReadLine());
                            additionalStudents[i] = new Student(num, fioAdd, g1, g2, g3);
                        }
                        students.AddRange(additionalStudents);
                        Console.WriteLine("Дополнительные ученики успешно добавлены методом AddRange.");
                        break;
                    case "3": // RemoveAt
                        Console.Write("Введите индекс ученика для удаления: ");
                        int removeIndex;
                        while (!int.TryParse(Console.ReadLine(), out removeIndex) || removeIndex < 0 || removeIndex >= students.Count)
                        {
                            Console.Write("Введите корректный индекс: ");
                        }
                        Student removedStudent = students[removeIndex];
                        students.RemoveAt(removeIndex);
                        Console.WriteLine("Удалён ученик: " + removedStudent);
                        break;
                    case "4": // Remove
                        Console.Write("Введите Ф.И.О. ученика (или его часть) для удаления: ");
                        string removeFio = Console.ReadLine();
                        Student studentToRemove = students.Find(s => s.FullName.IndexOf(removeFio, StringComparison.OrdinalIgnoreCase) >= 0);
                        if (studentToRemove != null)
                        {
                            students.Remove(studentToRemove);
                            Console.WriteLine("Удалён ученик: " + studentToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Ученика не найдено.");
                        }
                        break;
                    case "5": // Contains
                        Console.Write("Введите Ф.И.О. ученика для проверки наличия: ");
                        string checkFio = Console.ReadLine();
                        Student foundStudent = students.Find(s => s.FullName.IndexOf(checkFio, StringComparison.OrdinalIgnoreCase) >= 0);
                        if (foundStudent != null)
                        {
                            bool containsStudent = students.Contains(foundStudent);
                            Console.WriteLine($"Учениκ с Ф.И.О. содержащим \"{checkFio}\" {(containsStudent ? "найден" : "не найден")} методом Contains.");
                        }
                        else
                        {
                            Console.WriteLine("Ученика не найдено.");
                        }
                        break;
                    case "6": // IndexOf
                        Console.Write("Введите Ф.И.О. ученика для определения его индекса: ");
                        string indexFio = Console.ReadLine();
                        Student studentForIndex = students.Find(s => s.FullName.IndexOf(indexFio, StringComparison.OrdinalIgnoreCase) >= 0);
                        if (studentForIndex != null)
                        {
                            int idx = students.IndexOf(studentForIndex);
                            Console.WriteLine($"Индекс ученика: {idx}");
                        }
                        else
                        {
                            Console.WriteLine("Ученика не найдено.");
                        }
                        break;
                    case "7": // FindAll – классификация с вычислением средней оценки
                        List<Student> otlichniki = students.FindAll(s => s.AverageGrade == 5);
                        List<Student> khoroshi = students.FindAll(s => s.AverageGrade == 4);
                        List<Student> troechniki = students.FindAll(s => s.AverageGrade <= 3);
                        Console.WriteLine("\n--- Результаты классификации учеников ---");
                        Console.WriteLine($"\nОтличники (средняя оценка 5) – всего {otlichniki.Count}:");
                        foreach (var s in otlichniki)
                            Console.WriteLine(s);
                        Console.WriteLine($"\nХорошисты (средняя оценка 4) – всего {khoroshi.Count}:");
                        foreach (var s in khoroshi)
                            Console.WriteLine(s);
                        Console.WriteLine($"\nТроечники (средняя оценка 3 или 2) – всего {troechniki.Count}:");
                        foreach (var s in troechniki)
                            Console.WriteLine(s);
                        break;
                    case "8": // Вывести всех учеников
                        DisplayStudents(students);
                        break;
                    case "0":
                        exitSubMenu = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Повторите ввод.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
