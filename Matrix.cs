using System;
using System.Text;
using pract;

namespace Lab_03_C__
{
    using System;
    using pract; 

    namespace Lab_03_C__
    {
        public sealed class Matrix
        {
            private double[,] _matrix;

            public Matrix()
            {
                _matrix = new double[0, 0];
            }

            public Matrix(int n, int m, Checker checker)
            {
                _matrix = new double[n, m];
                Console.WriteLine($"Введите {n * m} элементов матрицы {n}x{m} (по строкам от первых к последним):");

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        _matrix[i, j] = checker.ReadDouble($"[{i},{j}]: ");
                    }
                }
            }

            public Matrix(int n, bool generateLowerUpperMain)
            {
                _matrix = new double[n, n];

                if (!generateLowerUpperMain)
                {
                    throw new ArgumentException("Этот конструктор предназначен для генерации 2-го массива");
                }

                var rnd = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i > j) 
                        {
                            _matrix[i, j] = rnd.NextDouble() * (150.0 - (-70.0)) + (-70.0);
                        }
                        else       
                        {
                            _matrix[i, j] = rnd.NextDouble() * (170.0 - 17.0) + 17.0;
                        }
                    }
                }
            }

            public Matrix(int n)
            {
                _matrix = new double[n, n];
                var rnd = new Random();
                int center = n / 2;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int distance = Math.Abs(i - center) + Math.Abs(j - center);

                        if (distance <= center)
                        {
                            _matrix[i, j] = rnd.Next(1, 50);
                        }
                        else
                        {
                            _matrix[i, j] = 0;
                        }
                    }
                }
            }
            private Matrix(double[,] matrix)
            {
                _matrix = matrix;
            }

            public int Rows()
            {
                return _matrix.GetLength(0);
            }

            public int Cols()
            {
                return _matrix.GetLength(1);
            }

            public override string ToString()
            {
                string result = "";

                for (int i = 0; i < Rows(); i++)
                {
                    for (int j = 0; j < Cols(); j++)
                    {
                        result += $"{_matrix[i, j],8:F2} ";
                    }
                    result += "\n";
                }
                return result;
            }

            public static Matrix operator +(Matrix a, Matrix b)
            {
                if (a.Rows() != b.Rows() || a.Cols() != b.Cols())
                    throw new ArgumentException("Несовместимые размеры для сложения.");

                double[,] res = new double[a.Rows(), a.Cols()];
                for (int i = 0; i < a.Rows(); i++)
                    for (int j = 0; j < a.Cols(); j++)
                        res[i, j] = a._matrix[i, j] + b._matrix[i, j];
                return new Matrix(res);
            }

            public static Matrix operator -(Matrix a, Matrix b)
            {
                if (a.Rows() != b.Rows() || a.Cols() != b.Cols())
                    throw new ArgumentException("Несовместимые размеры для вычитания.");

                double[,] res = new double[a.Rows(), a.Cols()];
                for (int i = 0; i < a.Rows(); i++)
                    for (int j = 0; j < a.Cols(); j++)
                        res[i, j] = a._matrix[i, j] - b._matrix[i, j];
                return new Matrix(res);
            }

            public static Matrix operator *(Matrix a, Matrix b)
            {
                if (a.Cols() != b.Rows())
                    throw new ArgumentException("Несовместимые размеры для умножения.");

                double[,] res = new double[a.Rows(), b.Cols()];
                for (int i = 0; i < a.Rows(); i++)
                {
                    for (int j = 0; j < b.Cols(); j++)
                    {
                        double sum = 0;
                        for (int k = 0; k < a.Cols(); k++)
                            sum += a._matrix[i, k] * b._matrix[k, j];
                        res[i, j] = sum;
                    }
                }
                return new Matrix(res);
            }

            public Matrix Transpose()
            {
                double[,] res = new double[Cols(), Rows()];

                for (int i = 0; i < Rows(); i++)
                {
                    for (int j = 0; j < Cols(); j++)
                    {
                        res[j, i] = _matrix[i, j];
                    }
                }
                return new Matrix(res);
            }

            public static void Task2_5(Matrix mat)
            {
                int n = mat.Rows();

                double maxSum = double.MinValue;
                int bestOffset = 0;

                for (int offset = -(n - 1); offset <= (n - 1); offset++)
                {
                    double currentSum = 0;

                    for (int i = 0; i < n; i++)
                    {
                        int j = i + offset; 

                        if (j >= 0 && j < n)
                        {
                            currentSum += mat._matrix[i, j];
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        bestOffset = offset;
                    }
                }

                Console.WriteLine($"\nМаксимальная сумма элементов диагонали: {maxSum:F2}");

                if (bestOffset == 0)
                {
                    Console.WriteLine("Это главная диагональ.");
                }
                else if (bestOffset > 0)
                {
                    Console.WriteLine($"Это диагональ выше главной (смещение на {bestOffset} вправо).");
                }
                else
                {
                    Console.WriteLine($"Это диагональ ниже главной (смещение на {-bestOffset} влево).");
                }
            }

            public static void Task3_5(Checker checker)
            {
                Console.WriteLine("Задание 3.5: Вычисление выражения A^T * B - C^T");

                int n = checker.ReadInt("Введите размерность матриц n: ");
                while (n <= 0)
                {
                    Console.WriteLine("Ошибка: n должно быть > 0.");
                    n = checker.ReadInt("Введите размерность матриц n: ");
                }

                Console.WriteLine("\n Ввод матрицы A ");
                Matrix A = new Matrix(n, n, checker);

                Console.WriteLine("\n Ввод матрицы B ");
                Matrix B = new Matrix(n, n, checker);

                Console.WriteLine("\n Ввод матрицы C ");
                Matrix C = new Matrix(n, n, checker);

                Console.WriteLine("\nИсходная матрица A:");
                Console.WriteLine(A.ToString());

                Console.WriteLine("Исходная матрица B:");
                Console.WriteLine(B.ToString());

                Console.WriteLine("Исходная матрица C:");
                Console.WriteLine(C.ToString());

                Matrix result = A.Transpose() * B - C.Transpose();

                Console.WriteLine("\nРезультат (A^T * B - C^T):");
                Console.WriteLine(result.ToString());
            }
        }
    }
}