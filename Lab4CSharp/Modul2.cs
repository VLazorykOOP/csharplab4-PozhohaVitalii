using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    using System;

    public class MatrixLong
    {
        protected long[,] LongArray;
        protected uint n, m;
        protected int codeError;
        protected static int num_m;

        public MatrixLong()
        {
            n = m = 1;
            LongArray = new long[1, 1];
            codeError = 0;
            num_m++;
        }

        public MatrixLong(uint rows, uint columns)
        {
            n = rows;
            m = columns;
            LongArray = new long[n, m];
            codeError = 0;
            num_m++;
        }

        public MatrixLong(uint rows, uint columns, long initializationValue)
        {
            n = rows;
            m = columns;
            LongArray = new long[n, m];
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    LongArray[i, j] = initializationValue;
                }
            }
            codeError = 0;
            num_m++;
        }

        ~MatrixLong()
        {
            Console.WriteLine("Matrix destructor called");
        }
        public void FillMatrixWithRandomValues()
        {
            Random random = new Random();

            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    LongArray[i, j] = random.Next();
                }
            }
        }


        public void DisplayMatrix()
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.Write($"{LongArray[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        public void SetAllElements(long value)
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    LongArray[i, j] = value;
                }
            }
        }

        public static int GetMatrixCount()
        {
            return num_m;
        }
        public void InputMatrix()
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.Write($"Enter element at position [{i}, {j}]: ");
                    if (!long.TryParse(Console.ReadLine(), out LongArray[i, j]))
                    {
                        Console.WriteLine("Invalid input. Setting codeError to -1.");
                        codeError = -1;
                        return;
                    }
                }
            }
        }

        public void OutputMatrix()
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.Write($"{LongArray[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        public void AssignValue(long value)
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    LongArray[i, j] = value;
                }
            }
        }

        public static int CountMatrices()
        {
            return num_m;
        }

        public uint Rows
        {
            get { return n; }
        }

        public uint Columns
        {
            get { return m; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        public long this[uint row, uint column]
        {
            get
            {
                if (row < n && column < m)
                {
                    codeError = 0;
                    return LongArray[row, column];
                }
                else
                {
                    Console.WriteLine("Invalid indices. Setting codeError to -1.");
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                if (row < n && column < m)
                {
                    LongArray[row, column] = value;
                    codeError = 0;
                }
                else
                {
                    Console.WriteLine("Invalid indices. Setting codeError to -1.");
                    codeError = -1;
                }
            }
        }

        public long this[uint index]
        {
            get
            {
                if (index < n * m)
                {
                    codeError = 0;
                    return LongArray[index / m, index % m];
                }
                else
                {
                    Console.WriteLine("Invalid index. Setting codeError to -1.");
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                if (index < n * m)
                {
                    LongArray[index / m, index % m] = value;
                    codeError = 0;
                }
                else
                {
                    Console.WriteLine("Invalid index. Setting codeError to -1.");
                    codeError = -1;
                }
            }
        }

        public static MatrixLong operator ++(MatrixLong matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    matrix.LongArray[i, j]++;
                }
            }
            return matrix;
        }

        public static MatrixLong operator --(MatrixLong matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    matrix.LongArray[i, j]--;
                }
            }
            return matrix;
        }

        public static bool operator true(MatrixLong matrix)
        {
            if (matrix.n != 0 && matrix.m != 0)
            {
                for (uint i = 0; i < matrix.n; i++)
                {
                    for (uint j = 0; j < matrix.m; j++)
                    {
                        if (matrix.LongArray[i, j] != 0)
                            return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(MatrixLong matrix)
        {
            return !matrix;
        }

        public static bool operator !(MatrixLong matrix)
        {
            return matrix.n == 0 || matrix.m == 0;
        }

        public static MatrixLong operator ~(MatrixLong matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    matrix.LongArray[i, j] = ~matrix.LongArray[i, j];
                }
            }
            return matrix;
        }

        // Арифметичні бінарні операції

        // Додавання
        public static MatrixLong operator +(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same size for addition.");
                matrix1.codeError = -1;
                return matrix1;
            }

            MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        // Додавання скаляра
        public static MatrixLong operator +(MatrixLong matrix, long scalar)
        {
            MatrixLong result = new MatrixLong(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] + scalar;
                }
            }

            return result;
        }

        // Віднімання
        public static MatrixLong operator -(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same size for subtraction.");
                matrix1.codeError = -1;
                return matrix1;
            }

            MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }

        // Віднімання скаляра
        public static MatrixLong operator -(MatrixLong matrix, long scalar)
        {
            MatrixLong result = new MatrixLong(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] - scalar;
                }
            }

            return result;
        }

        // Множення
        public static MatrixLong operator *(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.m != matrix2.n)
            {
                Console.WriteLine("Number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication.");
                matrix1.codeError = -1;
                return matrix1;
            }

            MatrixLong result = new MatrixLong(matrix1.n, matrix2.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix2.m; j++)
                {
                    result[i, j] = 0;
                    for (uint k = 0; k < matrix1.m; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }
        /*
        // Множення на вектор
        public static MatrixLong operator *(MatrixLong matrix, VectorLong vector)
        {
            if (matrix.m != vector.Size)
            {
                Console.WriteLine("Number of columns in the matrix must be equal to the size of the vector for multiplication.");
                matrix.codeError = -1;
                return matrix;
            }

            MatrixLong result = new MatrixLong(matrix.n, 1);

            for (uint i = 0; i < matrix.n; i++)
            {
                result[i, 0] = 0;
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, 0] += matrix[i, j] * vector[(int)j];
                }
            }

            return result;
        }
        */
        // Множення на скаляр
        public static MatrixLong operator *(MatrixLong matrix, long scalar)
        {
            MatrixLong result = new MatrixLong(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }

            return result;
        }

        // Ділення
        public static MatrixLong operator /(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same size for division.");
                matrix1.codeError = -1;
                return matrix1;
            }

            MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix2[i, j] != 0)
                    {
                        result[i, j] = matrix1[i, j] / matrix2[i, j];
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero. Setting codeError to -1.");
                        result.codeError = -1;
                        return result;
                    }
                }
            }

            return result;
        }

        // Ділення на скаляр
        public static MatrixLong operator /(MatrixLong matrix, long scalar)
        {
            if (scalar != 0)
            {
                MatrixLong result = new MatrixLong(matrix.n, matrix.m);

                for (uint i = 0; i < matrix.n; i++)
                {
                    for (uint j = 0; j < matrix.m; j++)
                    {
                        result[i, j] = matrix[i, j] / scalar;
                    }
                }

                return result;
            }
            else
            {
                Console.WriteLine("Cannot divide by zero. Setting codeError to -1.");
                matrix.codeError = -1;
                return matrix;
            }
        }

        // Остача від ділення
        public static MatrixLong operator %(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same size for calculating the remainder of division.");
                matrix1.codeError = -1;
                return matrix1;
            }

            MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix2[i, j] != 0)
                    {
                        result[i, j] = matrix1[i, j] % matrix2[i, j];
                    }
                    else
                    {
                        Console.WriteLine("Cannot calculate remainder when the divisor is zero. Setting codeError to -1.");
                        result.codeError = -1;
                        return result;
                    }
                }
            }

            return result;
        }

        // Остача від ділення на скаляр
        public static MatrixLong operator %(MatrixLong matrix, long scalar)
        {
            if (scalar != 0)
            {
                MatrixLong result = new MatrixLong(matrix.n, matrix.m);

                for (uint i = 0; i < matrix.n; i++)
                {
                    for (uint j = 0; j < matrix.m; j++)
                    {
                        result[i, j] = matrix[i, j] % scalar;
                    }
                }

                return result;
            }
            else
            {
                Console.WriteLine("Cannot calculate remainder when the divisor is zero. Setting codeError to -1.");
                matrix.codeError = -1;
                return matrix;
            }
        }

        // Побітове додавання
        public static MatrixLong operator |(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same size for bitwise OR.");
                matrix1.codeError = -1;
                return matrix1;
            }

            MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] | matrix2[i, j];
                }
            }

            return result;
        }

        // Побітове додавання скаляра
        public static MatrixLong operator |(MatrixLong matrix, ulong scalar)
        {
            MatrixLong result = new MatrixLong(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] | (long)scalar;
                }
            }

            return result;
        }

        // Побітове додавання за модулем 2
        public static MatrixLong operator ^(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same size for bitwise XOR.");
                matrix1.codeError = -1;
                return matrix1;
            }

            MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] ^ matrix2[i, j];
                }
            }

            return result;
        }

        // Побітове додавання за модулем 2 скаляра
        public static MatrixLong operator ^(MatrixLong matrix, ulong scalar)
        {
            MatrixLong result = new MatrixLong(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] ^ (long)scalar;
                }
            }

            return result;
        }

        // Побітове множення
        public static MatrixLong operator &(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same size for bitwise AND.");
                matrix1.codeError = -1;
                return matrix1;
            }

            MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] & matrix2[i, j];
                }
            }

            return result;
        }

        // Побітове множення скаляра
        public static MatrixLong operator &(MatrixLong matrix, ulong scalar)
        {
            MatrixLong result = new MatrixLong(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] & (long)scalar;
                }
            }

            return result;
        }
        /*
        // Побітовий зсув вправо
        public static MatrixLong operator >>(MatrixLong matrix, uint shift)
        {
            MatrixLong result = new MatrixLong(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] >> (int)shift;
                }
            }

            return result;
        }

        // Побітовий зсув вліво
        public static MatrixLong operator <<(MatrixLong matrix, uint shift)
        {
            MatrixLong result = new MatrixLong(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] << (int)shift;
                }
            }

            return result;
        }
        */
        // Порівняння матриць за індексом
        public static bool operator ==(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (ReferenceEquals(matrix1, null) && ReferenceEquals(matrix2, null))
            {
                return true;
            }
            if (ReferenceEquals(matrix1, null) || ReferenceEquals(matrix2, null))
            {
                return false;
            }

            if (matrix1.n == matrix2.n && matrix1.m == matrix2.m)
            {
                for (uint i = 0; i < matrix1.n; i++)
                {
                    for (uint j = 0; j < matrix1.m; j++)
                    {
                        if (matrix1.LongArray[i, j] != matrix2.LongArray[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(MatrixLong matrix1, MatrixLong matrix2)
        {
            return !(matrix1 == matrix2);
        }

        public static bool operator >(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.n == matrix2.n && matrix1.m == matrix2.m)
            {
                for (uint i = 0; i < matrix1.n; i++)
                {
                    for (uint j = 0; j < matrix1.m; j++)
                    {
                        if (matrix1.LongArray[i, j] <= matrix2.LongArray[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                // Handle the case when matrices have different sizes
                throw new ArgumentException("Matrices must have the same size for comparison.");
            }
        }

        public static bool operator >=(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.n == matrix2.n && matrix1.m == matrix2.m)
            {
                for (uint i = 0; i < matrix1.n; i++)
                {
                    for (uint j = 0; j < matrix1.m; j++)
                    {
                        if (matrix1.LongArray[i, j] < matrix2.LongArray[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                // Handle the case when matrices have different sizes
                throw new ArgumentException("Matrices must have the same size for comparison.");
            }
        }

        public static bool operator <(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.n == matrix2.n && matrix1.m == matrix2.m)
            {
                for (uint i = 0; i < matrix1.n; i++)
                {
                    for (uint j = 0; j < matrix1.m; j++)
                    {
                        if (matrix1.LongArray[i, j] >= matrix2.LongArray[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                // Handle the case when matrices have different sizes
                throw new ArgumentException("Matrices must have the same size for comparison.");
            }
        }

        public static bool operator <=(MatrixLong matrix1, MatrixLong matrix2)
        {
            if (matrix1.n == matrix2.n && matrix1.m == matrix2.m)
            {
                for (uint i = 0; i < matrix1.n; i++)
                {
                    for (uint j = 0; j < matrix1.m; j++)
                    {
                        if (matrix1.LongArray[i, j] > matrix2.LongArray[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                // Handle the case when matrices have different sizes
                throw new ArgumentException("Matrices must have the same size for comparison.");
            }
        }

    }
    
    internal class Modul2
    {
    }
}
