using Lab_03_C__.Lab_03_C__;
using pract;
using System;

namespace Lab_03_C__
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new Checker();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(" ЛАБОРАТОРНАЯ РАБОТА №3 (ВАРИАНТ 5) ");
                Console.WriteLine("1. Задание 1 (Заполнение двумерных массивов)");
                Console.WriteLine("2. Задание 2 (Поиск диагонали с макс. суммой)");
                Console.WriteLine("3. Задание 3 (Матричное выражение A^T * B - C^T)");
                Console.WriteLine("4. Задание 4 (Бинарные файлы: удаление дубликатов)");
                Console.WriteLine("5. Задание 5 (XML сериализация: игрушки)");
                Console.WriteLine("6. Задание 6 (Текстовый файл: поиск числа)");
                Console.WriteLine("7. Задание 7 (Текстовый файл: сумма кратных k)");
                Console.WriteLine("8. Задание 8 (Текстовый файл: строки без цифр)");
                Console.WriteLine("0. Выход");

                int choice = checker.ReadInt("Выберите пункт меню: ");

                switch (choice)
                {
                    case 1:
                        RunTask1(checker);
                        break;
                    case 2:
                        RunTask2(checker);
                        break;
                    case 3:
                        RunTask3(checker);
                        break;
                    case 4:
                        RunTask4();
                        break;
                    case 5:
                        RunTask5(checker);
                        break;
                    case 6:
                        RunTask6(checker);
                        break;
                    case 7:
                        RunTask7(checker);
                        break;
                    case 8:
                        RunTask8(checker);
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный пункт. Нажмите Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void RunTask1(Checker checker)
        {
            Console.Clear();
            Console.WriteLine(" Задание 1.5 ");
            Console.WriteLine("Демонстрация работы 3-х конструкторов.\n");

            int n = checker.ReadInt("Введите размерность n (> 0): ");
            while (n <= 0) n = checker.ReadInt("Ошибка. Введите n (> 0): ");

            int m = checker.ReadInt("Введите размерность m (> 0): ");
            while (m <= 0) m = checker.ReadInt("Ошибка. Введите m (> 0): ");

            Console.WriteLine("\n[Первый массив] Ввод с клавиатуры:");
            Matrix mat1 = new Matrix(n, m, checker);
            Console.WriteLine("\nПервый массив:");
            Console.WriteLine(mat1.ToString());

            Console.WriteLine("\n[Второй массив] Случайные числа по диагоналям [-70;150] и [17;170]:");
            Matrix mat2 = new Matrix(n, true);
            Console.WriteLine(mat2.ToString());

            Console.WriteLine("[Третий массив] Узор \"Ромб\" для размера n:");
            Matrix mat3 = new Matrix(n);
            Console.WriteLine(mat3.ToString());

            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }

        static void RunTask2(Checker checker)
        {
            Console.Clear();
            Console.WriteLine(" Задание 2.5 ");
            Console.WriteLine("Поиск диагонали, параллельной главной, с максимальной суммой.\n");

            int n = checker.ReadInt("Введите размерность n (> 0): ");
            while (n <= 0) n = checker.ReadInt("Ошибка. Введите n (> 0): ");

            Console.WriteLine("\nВвод матрицы с клавиатуры:");
            Matrix mat = new Matrix(n, n, checker);

            Console.WriteLine("\nИсходный массив:");
            Console.WriteLine(mat.ToString());

            Matrix.Task2_5(mat);

            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }

        static void RunTask3(Checker checker)
        {
            Console.Clear();
            Console.WriteLine(" Задание 3.5 ");
            Console.WriteLine("Вычисление матричного выражения A^T * B - C^T.\n");

            Matrix.Task3_5(checker);

            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }

        static void RunTask4()
        {
            Console.Clear();
            Console.WriteLine(" Задание 4.5 ");
            Console.WriteLine("Бинарные файлы: удаление повторных вхождений.");

            string input = "input4.bin";
            string output = "output4.bin";

            Console.WriteLine("Заполнение исходного файла 20 случайными числами...");
            FileLabs.FillBinaryFile(input, 20);

            Console.WriteLine();
            FileLabs.PrintBinaryFile(input);

            Console.WriteLine("\nУдаление дубликатов...");
            FileLabs.Task4_5(input, output);

            Console.WriteLine();
            FileLabs.PrintBinaryFile(output);

            Pause();
        }

        static void RunTask5(Checker checker)
        {
            Console.Clear();
            Console.WriteLine(" Задание 5.5 ");
            Console.WriteLine("XML сериализация: игрушки.");

            string path = "toys.xml";

            int f = checker.ReadInt("Введите количество игрушек: ");
            while (f <= 0)
            {
                Console.WriteLine("Ошибка: количество игрушек должно быть больше 0.");
                f = checker.ReadInt("Введите количество игрушек (> 0): ");
            }

            FileLabs.FillXmlFile(path, f);
            Console.WriteLine($"Файл {path} создан с {f} игрушками.");

            int k = checker.ReadInt("Введите максимальную цену (k >= 0): ");
            while (k < 0)
            {
                Console.WriteLine("Ошибка: цена не может быть отрицательной.");
                k = checker.ReadInt("Введите максимальную цену (k >= 0): ");
            }

            FileLabs.Task5_5(path, k);

            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }

        static void RunTask6(Checker checker)
        {
            Console.Clear();
            Console.WriteLine(" Задание 6.5 ");
            Console.WriteLine("Текстовый файл: поиск числа b.\n");

            string path = "task6.txt";

            int count = checker.ReadInt("Введите количество чисел для генерации (> 0): ");
            while (count <= 0)
            {
                Console.WriteLine("Ошибка: количество должно быть > 0.");
                count = checker.ReadInt("Введите количество чисел (> 0): ");
            }

            FileLabs.FillTextFile6(path, count);

            Console.WriteLine();
            FileLabs.PrintTextFile(path);

            int b = checker.ReadInt("\nВведите число b для поиска: ");

            bool contains = FileLabs.Task6_5(path, b);

            Console.WriteLine($"\nРезультат: содержит ли файл число {b}? -> {contains}");

            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }

        static void RunTask7(Checker checker)
        {
            Console.Clear();
            Console.WriteLine(" Задание 7.5 ");
            Console.WriteLine("Текстовый файл: сумма элементов, кратных k.\n");

            string path = "task7.txt";

            int lines = checker.ReadInt("Введите количество строк (> 0): ");
            while (lines <= 0) lines = checker.ReadInt("Ошибка. Введите количество строк (> 0): ");

            int numsPerLine = checker.ReadInt("Введите количество чисел в строке (> 0): ");
            while (numsPerLine <= 0) numsPerLine = checker.ReadInt("Ошибка. Введите количество чисел (> 0): ");

            FileLabs.FillTextFile7(path, lines, numsPerLine);

            Console.WriteLine();
            FileLabs.PrintTextFile(path);

            int k = checker.ReadInt("\nВведите число k (не равное 0): ");
            while (k == 0)
            {
                Console.WriteLine("Ошибка: k не может быть 0 (деление на ноль).");
                k = checker.ReadInt("Введите число k (не равное 0): ");
            }

            long sum = FileLabs.Task7_5(path, k);

            Console.WriteLine($"\nСумма элементов, кратных {k}: {sum}");

            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }

        static void RunTask8(Checker checker)
        {
            Console.Clear();
            Console.WriteLine(" Задание 8.5 ");
            Console.WriteLine("Текстовый файл: переписать строки без цифр.\n");

            string inputPath = "task8_in.txt";
            string outputPath = "task8_out.txt";

            int count = checker.ReadInt("Введите количество строк для генерации (> 0): ");
            while (count <= 0)
            {
                Console.WriteLine("Ошибка: количество должно быть > 0.");
                count = checker.ReadInt("Введите количество строк (> 0): ");
            }

            FileLabs.FillTextFile8(inputPath, count);

            Console.WriteLine("\n Исходный файл ");
            FileLabs.PrintTextFile(inputPath);

            FileLabs.Task8_5(inputPath, outputPath);

            Console.WriteLine("\n Итоговый файл (без цифр) ");
            FileLabs.PrintTextFile(outputPath);

            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }

        static void Pause()
        {
            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }
    }
}