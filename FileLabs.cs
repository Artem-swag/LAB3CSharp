using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Lab_03_C__
{
    public static class FileLabs
    {
        public static void FillBinaryFile(string path, int count)
        {
            var rnd = new Random();

            using (var fs = new FileStream(path, FileMode.Create))
            {
                using (var bw = new BinaryWriter(fs))
                {
                    for (int i = 0; i < count; i++)
                    {
                        bw.Write(rnd.Next(-50, 50));
                    }
                }
            }
        }

        public static void Task4_5(string inputPath, string outputPath)
        {
            var seen = new HashSet<int>();

            using (var fsIn = new FileStream(inputPath, FileMode.Open))
            {
                using (var br = new BinaryReader(fsIn))
                {
                    using (var fsOut = new FileStream(outputPath, FileMode.Create))
                    {
                        using (var bw = new BinaryWriter(fsOut))
                        {
                            while (br.BaseStream.Position < br.BaseStream.Length)
                            {
                                int num = br.ReadInt32();
                                if (seen.Add(num))
                                {
                                    bw.Write(num);
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Задание 4 выполнено: дубликаты удалены.");
        }

        [Serializable]
        public struct Toy
        {
            public string Name;
            public decimal Price;
            public int MinAge;
            public int MaxAge;
        }

        public static void FillXmlFile(string path, int count)
        {
            var rnd = new Random();
            var toys = new List<Toy>();
            string[] names = { "Кукла", "Машинка", "Конструктор", "Мяч", "Кубики", "Пазл" };

            for (int i = 0; i < count; i++)
            {
                Toy t = new Toy();
                t.Name = names[rnd.Next(names.Length)];
                t.Price = rnd.Next(100, 5000);
                t.MinAge = rnd.Next(1, 6);
                t.MaxAge = rnd.Next(6, 15);
                toys.Add(t);
            }

            var serializer = new XmlSerializer(typeof(List<Toy>));

            using (var fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, toys);
            }
        }

        public static void Task5_5(string path, decimal k)
        {
            var serializer = new XmlSerializer(typeof(List<Toy>));
            List<Toy> toys;

            // Читаем данные из XML
            using (var fs = new FileStream(path, FileMode.Open))
            {
                toys = (List<Toy>)serializer.Deserialize(fs);
            }

            // Пункт 5: Вывод всех игрушек для наглядности
            Console.WriteLine("\n Все игрушки в файле ");
            for (int i = 0; i < toys.Count; i++)
            {
                Toy t = toys[i];
                Console.WriteLine($"{i + 1}. {t.Name} | Цена: {t.Price} руб. | Возраст: {t.MinAge}-{t.MaxAge} лет");
            }

            // Пункт 6: Поиск подходящих с флагом
            Console.WriteLine($"\n Игрушки дешевле {k} руб., подходящие для 5 лет ");
            bool found = false;

            for (int i = 0; i < toys.Count; i++)
            {
                Toy t = toys[i];
                if (t.Price <= k && t.MinAge <= 5 && t.MaxAge >= 5)
                {
                    Console.WriteLine($" - {t.Name} ({t.Price} руб., {t.MinAge}-{t.MaxAge} лет)");
                    found = true;
                }
            }

            // Если ничего не нашли
            if (!found)
            {
                Console.WriteLine("Подходящих игрушек не найдено.");
            }
        }

        public static void FillTextFile6(string path, int count)
        {
            var rnd = new Random();

            using (var sw = new StreamWriter(path))
            {
                for (int i = 0; i < count; i++)
                {
                    sw.WriteLine(rnd.Next(-100, 100));
                }
            }
        }

        public static bool Task6_5(string path, int b)
        {
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int num;
                    if (int.TryParse(line, out num) && num == b)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void FillTextFile7(string path, int lines, int numsPerLine)
        {
            var rnd = new Random();

            using (var sw = new StreamWriter(path))
            {
                for (int i = 0; i < lines; i++)
                {
                    string line = "";
                    for (int j = 0; j < numsPerLine; j++)
                    {
                        line += rnd.Next(1, 100).ToString();
                        if (j < numsPerLine - 1) line += " ";
                    }
                    sw.WriteLine(line);
                }
            }
        }

        public static long Task7_5(string path, int k)
        {
            long sum = 0;

            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < parts.Length; i++)
                    {
                        int num;
                        if (int.TryParse(parts[i], out num) && num % k == 0)
                        {
                            sum += num;
                        }
                    }
                }
            }
            return sum;
        }

        public static void FillTextFile8(string path, int lines)
        {
            string[] samples =
            {
                "Привет мир",
                "Строка с цифрой 123",
                "Без цифр вообще",
                "Еще 42 и 7",
                "Просто текст"
            };
            var rnd = new Random();

            using (var sw = new StreamWriter(path))
            {
                for (int i = 0; i < lines; i++)
                {
                    sw.WriteLine(samples[rnd.Next(samples.Length)]);
                }
            }
        }

        public static void Task8_5(string inputPath, string outputPath)
        {
            using (var sr = new StreamReader(inputPath))
            {
                using (var sw = new StreamWriter(outputPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        bool hasDigits = false;
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (char.IsDigit(line[i]))
                            {
                                hasDigits = true;
                                break;
                            }
                        }

                        if (!hasDigits)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
            Console.WriteLine("Задание 8 выполнено: строки без цифр скопированы.");
        }

        public static void PrintBinaryFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл {path} не найден.");
                return;
            }

            using (var fs = new FileStream(path, FileMode.Open))
            {
                using (var br = new BinaryReader(fs))
                {
                    Console.WriteLine($"Содержимое {path}:");
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        Console.Write(br.ReadInt32() + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void PrintTextFile(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine($"Файл {path} не найден.");
                return;
            }

            using (var sr = new StreamReader(path))
            {
                Console.WriteLine($"Содержимое {path}:");
                string line;
                int lineNumber = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine($"{lineNumber}: {line}");
                    lineNumber++;
                }
                Console.WriteLine();
            }
        }
    }
}