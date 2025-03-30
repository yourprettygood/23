using System;
using System.Collections.Generic;

namespace StudentGradesExample
{
    class Student
    {
        public int Number { get; set; }
        public string FullName { get; set; }
        public int Grade1 { get; set; }
        public int Grade2 { get; set; }
        public int Grade3 { get; set; }

        public Student(int number, string fullName, int grade1, int grade2, int grade3)
        {
            Number = number;
            FullName = fullName;
            Grade1 = grade1;
            Grade2 = grade2;
            Grade3 = grade3;
        }

        // Вычисление среднего балла с округлением вверх
        public int AverageGrade()
        {
            double avg = (Grade1 + Grade2 + Grade3) / 3.0;
            return (int)Math.Ceiling(avg);
        }

        // Определение категории ученика по округленному среднему баллу
        public string GetCategory()
        {
            int avg = AverageGrade();
            if (avg == 5)
                return "Отличники";
            else if (avg == 4)
                return "Хорошисты";
            else if (avg == 3)
                return "Троечники";
            else
                return "Неопределено";
        }

        public override string ToString()
        {
            return $"№{Number} - {FullName}, оценки: {Grade1}, {Grade2}, {Grade3} (округленный средний балл: {AverageGrade()})";
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введите количество учеников: ");
            int n = ReadInt();

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nВвод информации об ученике №{i + 1}:");

                Console.Write("Порядковый номер: ");
                int number = ReadInt();

                Console.Write("Ф.И.О.: ");
                string fullName = Console.ReadLine();

                Console.Write("Оценка 1 (1, 2, 3, 4 или 5): ");
                int grade1 = ReadGrade();

                Console.Write("Оценка 2 (1, 2, 3, 4 или 5): ");
                int grade2 = ReadGrade();

                Console.Write("Оценка 3 (1, 2, 3, 4 или 5): ");
                int grade3 = ReadGrade();

                students.Add(new Student(number, fullName, grade1, grade2, grade3));
            }

            // Создаем списки для каждой категории на основе округленного среднего балла
            List<Student> excellent = students.FindAll(s => s.GetCategory() == "Отличники");
            List<Student> good = students.FindAll(s => s.GetCategory() == "Хорошисты");
            List<Student> average = students.FindAll(s => s.GetCategory() == "Троечники");

            // Выводим результаты
            Console.WriteLine("\nСписок отличников:");
            if (excellent.Count == 0)
                Console.WriteLine("Отсутствуют.");
            else
                excellent.ForEach(s => Console.WriteLine(s));

            Console.WriteLine("\nСписок хорошистов:");
            if (good.Count == 0)
                Console.WriteLine("Отсутствуют.");
            else
                good.ForEach(s => Console.WriteLine(s));

            Console.WriteLine("\nСписок троечников:");
            if (average.Count == 0)
                Console.WriteLine("Отсутствуют.");
            else
                average.ForEach(s => Console.WriteLine(s));

            Console.WriteLine("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
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

        // Метод для безопасного чтения оценки (допустимые значения: 1, 2, 3, 4, 5)
        static int ReadGrade()
        {
            int grade;
            while (!int.TryParse(Console.ReadLine(), out grade) || (grade < 1 || grade > 5))
            {
                Console.Write("Неверный ввод. Введите оценку (1, 2, 3, 4 или 5): ");
            }
            return grade;
        }
    }
}
