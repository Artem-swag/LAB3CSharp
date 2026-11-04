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
                        RunTask8();
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
            Console.WriteLine("--- Задание 1.5 ---");

            int n = checker.ReadInt("Введите размерность n: ");
            int m = checker.ReadInt("Введите размерность m: ");

            Console.WriteLine("\n[Первый массив] Ввод с клавиатуры:");
            Matrix mat1 = new Matrix(n, m, true, checker);
            Console.WriteLine("Первый массив:");
            Console.WriteLine(mat1.ToString());

            Console.WriteLine("\n[Второй массив] Случайные числа по правилу:");
            Matrix mat2 = Matrix.GenerateSecondArray(n);
            Console.WriteLine(mat2.ToString());

            Console.WriteLine("\n[Третий массив] Узор 5x5:");
            Matrix mat3 = Matrix.CreatePattern();
            Console.WriteLine(mat3.ToString());

            Pause();
        }

        static void RunTask2(Checker checker)
        {
            Console.Clear();
            Console.WriteLine("--- Задание 2.5 ---");
            Console.WriteLine("Создадим случайный массив для поиска диагонали.");

            int n = checker.ReadInt("Введите размерность n: ");
            Matrix mat = Matrix.GenerateSecondArray(n);

            Console.WriteLine("Исходный массив:");
            Console.WriteLine(mat.ToString());

            Console.WriteLine("\nПоиск диагонали с максимальной суммой:");
            Matrix.Task2_5(mat);

            Pause();
        }

        static void RunTask3(Checker checker)
        {
            Console.Clear();
            Console.WriteLine("--- Задание 3.5 ---");
            Console.WriteLine("Матричное выражение: A^T * B - C^T");

            int n = checker.ReadInt("Введите размерность матриц n (например, 2): ");

            Matrix A = Matrix.GenerateSecondArray(n);
            Matrix B = Matrix.GenerateSecondArray(n);
            Matrix C = Matrix.GenerateSecondArray(n);

            Console.WriteLine("\nМатрица A:");
            Console.WriteLine(A.ToString());
            Console.WriteLine("Матрица B:");
            Console.WriteLine(B.ToString());
            Console.WriteLine("Матрица C:");
            Console.WriteLine(C.ToString());

            Console.WriteLine("\nВычисление A^T * B - C^T...");
            Matrix result = A.Transpose() * B - C.Transpose();

            Console.WriteLine("Результат:");
            Console.WriteLine(result.ToString());

            Pause();
        }

        static void RunTask4()
        {
            Console.Clear();
            Console.WriteLine("--- Задание 4.5 ---");
            Console.WriteLine("Бинарные файлы: удаление повторных вхождений.");

            string input = "input4.bin";
            string output = "output4.bin";

            Console.WriteLine("Заполнение исходного файла 20 случайными числами...");
            FileLabs.FillBinaryFile(input, 20);

            Console.WriteLine("Удаление дубликатов...");
            FileLabs.Task4_5(input, output);

            Pause();
        }

        static void RunTask5(Checker checker)
        {
            Console.Clear();
            Console.WriteLine("--- Задание 5.5 ---");
            Console.WriteLine("XML сериализация: игрушки.");

            string path = "toys.xml";
            FileLabs.FillXmlFile(path, 10);
            Console.WriteLine("Файл toys.xml создан с 10 игрушками.");

            int k = checker.ReadInt("Введите максимальную цену (k): ");

            Console.WriteLine("\nПодходящие игрушки для 5 лет:");
            FileLabs.Task5_5(path, k);

            Pause();
        }

        static void RunTask6(Checker checker)
        {
            Console.Clear();
            Console.WriteLine("--- Задание 6.5 ---");
            Console.WriteLine("Текстовый файл: поиск числа b.");

            string path = "task6.txt";
            FileLabs.FillTextFile6(path, 10);
            Console.WriteLine("Файл task6.txt создан.");

            int b = checker.ReadInt("Введите число b для поиска: ");
            bool contains = FileLabs.Task6_5(path, b);

            Console.WriteLine($"\nРезультат: содержит ли файл число {b}? {contains}");

            Pause();
        }

        static void RunTask7(Checker checker)
        {
            Console.Clear();
            Console.WriteLine("--- Задание 7.5 ---");
            Console.WriteLine("Текстовый файл: сумма элементов, кратных k.");

            string path = "task7.txt";
            FileLabs.FillTextFile7(path, 3, 4);
            Console.WriteLine("Файл task7.txt создан (3 строки по 4 числа).");

            int k = checker.ReadInt("Введите число k: ");
            long sum = FileLabs.Task7_5(path, k);

            Console.WriteLine($"\nСумма элементов, кратных {k}: {sum}");

            Pause();
        }

        static void RunTask8()
        {
            Console.Clear();
            Console.WriteLine("--- Задание 8.5 ---");
            Console.WriteLine("Текстовый файл: переписать строки без цифр.");

            string input = "task8_in.txt";
            string output = "task8_out.txt";

            FileLabs.FillTextFile8(input, 5);
            Console.WriteLine("Файл task8_in.txt создан.");

            FileLabs.Task8_5(input, output);

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }
    }
}