using System;
using System.Text;
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

        public Matrix(int n, int m, bool readFromKeyboard, Checker checker)
        {
            _matrix = new double[n, m];
            if (readFromKeyboard)
            {
                Console.WriteLine($"Введите {n * m} элементов матрицы {n}x{m} (по строкам от первых к последним):");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        string prompt = $"[{i},{j}]: ";
                        _matrix[i, j] = checker.ReadDouble(prompt);
                    }
                }
            }
        }

        private Matrix(double[,] matrix)
        {
            _matrix = matrix;
        } 

        public int Rows
        {
            get
            {
                return _matrix.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return _matrix.GetLength(1);
            }
        }

        public static Matrix CreatePattern()
        {
            int n = 5;
            var m = new double[n, n];
            int[,] pattern =
            {
                { 0,  0,  5,  0,  0 },
                { 0,  3, 29,  7,  0 },
                { 2, 23, 41, 31, 11 },
                { 0, 19, 37, 13,  0 },
                { 0,  0, 17,  0,  0 }
            };

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = pattern[i, j];
                }
            }
            return new Matrix(m);
        }

        public static Matrix GenerateSecondArray(int n)
        {
            var res = new double[n, n];
            var rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i > j) 
                    {
                        res[i, j] = rnd.NextDouble() * (150 - (-70)) + (-70);
                    }
                    else       
                    {
                        res[i, j] = rnd.NextDouble() * (170 - 17) + 17;
                    }
                }
            }
            return new Matrix(res);
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
            {
                throw new ArgumentException("Несовместимые размеры для умножения");
            }

            var res = new double[a.Rows, b.Cols];

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Cols; j++)
                {
                    for (int k = 0; k < a.Cols; k++)
                    {
                        res[i, j] += a._matrix[i, k] * b._matrix[k, j];
                    }
                }
            }
            return new Matrix(res);
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new ArgumentException("Несовместимые размеры для вычитания");
            }

            var res = new double[a.Rows, a.Cols];

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    res[i, j] = a._matrix[i, j] - b._matrix[i, j];
                }
            }
            return new Matrix(res);
        }

        public Matrix Transpose()
        {
            var res = new double[Cols, Rows];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    res[j, i] = _matrix[i, j];
                }
            }
            return new Matrix(res);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    sb.Append($"{_matrix[i, j],8:F2} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static void Task2_5(Matrix mat)
        {
            int n = mat.Rows;
            double maxSum = double.MinValue;
            int bestDiag = 0;

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
                    bestDiag = offset;
                }
            }
            Console.WriteLine($"Максимальная сумма {maxSum:F2} у диагонали со смещением {bestDiag} от главной.");
        }
    }
}