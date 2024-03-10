using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    using System;

    class VectorLong
    {
        protected long[] IntArray;
        protected uint size;
        protected int codeError;
        protected static uint num_vl;

        public VectorLong()
        {
            size = 1;
            IntArray = new long[size];
            IntArray[0] = 0;
            codeError = 0;
            num_vl++;
        }

        public VectorLong(uint newSize)
        {
            size = newSize;
            IntArray = new long[size];
            codeError = 0;
            num_vl++;
        }

        public VectorLong(uint newSize, long initValue)
        {
            size = newSize;
            IntArray = new long[size];
            for (int i = 0; i < size; i++)
            {
                IntArray[i] = initValue;
            }
            codeError = 0;
            num_vl++;
        }

        ~VectorLong()
        {
            Console.WriteLine("VectorLong object destroyed.");
        }

        public void Input()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter element at index {i}: ");
                if (!long.TryParse(Console.ReadLine(), out IntArray[i]))
                {
                    codeError = -1;
                    Console.WriteLine("Invalid input. Code error set to -1.");
                    return;
                }
            }
            codeError = 0;
        }

        public void Display()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{IntArray[i]} ");
            }
            Console.WriteLine();
        }

        public void SetValues(long value)
        {
            for (int i = 0; i < size; i++)
            {
                IntArray[i] = value;
            }
        }

        public static uint CountVectors()
        {
            return num_vl;
        }

        public uint Size
        {
            get { return size; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        public long this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    codeError = -1;
                    return 0; // or throw an exception
                }
                return IntArray[index];
            }
            set
            {
                if (index < 0 || index >= size)
                {
                    codeError = -1;
                    return;
                }
                IntArray[index] = value;
                codeError = 0;
            }
        }

        public static bool operator true(VectorLong vector)
        {
            return vector.size != 0 && Array.TrueForAll(vector.IntArray, element => element != 0);
        }

        public static bool operator false(VectorLong vector)
        {
            return vector.size == 0 || Array.TrueForAll(vector.IntArray, element => element == 0);
        }

        public static bool operator !(VectorLong vector)
        {
            return vector.size != 0;
        }

        public static VectorLong operator ~(VectorLong vector)
        {
            VectorLong result = new VectorLong(vector.size);
            for (int i = 0; i < vector.size; i++)
            {
                result.IntArray[i] = ~vector.IntArray[i];
            }
            return result;
        }

        public static VectorLong operator +(VectorLong vector1, VectorLong vector2)
        {
            int size = Math.Max((int)vector1.size, (int)vector2.size);
            VectorLong result = new VectorLong((uint)size);

            for (int i = 0; i < size; i++)
            {
                result.IntArray[i] = vector1[i] + vector2[i];
            }
            return result;
        }

        public static VectorLong operator +(VectorLong vector, long scalar)
        {
            VectorLong result = new VectorLong(vector.size);

            for (int i = 0; i < vector.size; i++)
            {
                result.IntArray[i] = vector[i] + scalar;
            }
            return result;
        }
        public static VectorLong operator ++(VectorLong vector)
        {
            for (int i = 0; i < vector.size; i++)
            {
                vector.IntArray[i]++;
            }
            return vector;
        }

        public static VectorLong operator --(VectorLong vector)
        {
            for (int i = 0; i < vector.size; i++)
            {
                vector.IntArray[i]--;
            }
            return vector;
        }
        public static VectorLong operator -(VectorLong vector1, VectorLong vector2)
        {
            int size = Math.Max((int)vector1.size, (int)vector2.size);
            VectorLong result = new VectorLong((uint)size);

            for (int i = 0; i < size; i++)
            {
                result.IntArray[i] = vector1[i] - vector2[i];
            }
            return result;
        }

        public static VectorLong operator -(VectorLong vector, long scalar)
        {
            VectorLong result = new VectorLong(vector.size);

            for (int i = 0; i < vector.size; i++)
            {
                result.IntArray[i] = vector[i] - scalar;
            }
            return result;
        }

        public static VectorLong operator *(VectorLong vector1, VectorLong vector2)
        {
            int size = Math.Max((int)vector1.size, (int)vector2.size);
            VectorLong result = new VectorLong((uint)size);

            for (int i = 0; i < size; i++)
            {
                result.IntArray[i] = vector1[i] * vector2[i];
            }
            return result;
        }

        public static VectorLong operator *(VectorLong vector, long scalar)
        {
            VectorLong result = new VectorLong(vector.size);

            for (int i = 0; i < vector.size; i++)
            {
                result.IntArray[i] = vector[i] * scalar;
            }
            return result;
        }

        public static VectorLong operator /(VectorLong vector1, VectorLong vector2)
        {
            int size = Math.Max((int)vector1.size, (int)vector2.size);
            VectorLong result = new VectorLong((uint)size);

            for (int i = 0; i < size; i++)
            {
                if (vector2[i] != 0)
                {
                    result.IntArray[i] = vector1[i] / vector2[i];
                }
                else
                {
                    // Handle division by zero
                    result.IntArray[i] = 0;
                }
            }
            return result;
        }

        public static VectorLong operator /(VectorLong vector, long scalar)
        {
            if (scalar != 0)
            {
                VectorLong result = new VectorLong(vector.size);

                for (int i = 0; i < vector.size; i++)
                {
                    result.IntArray[i] = vector[i] / scalar;
                }
                return result;
            }
            else
            {
                // Handle division by zero
                return new VectorLong(vector.size);
            }
        }

        public static VectorLong operator %(VectorLong vector1, VectorLong vector2)
        {
            int size = Math.Max((int)vector1.size, (int)vector2.size);
            VectorLong result = new VectorLong((uint)size);

            for (int i = 0; i < size; i++)
            {
                if (vector2[i] != 0)
                {
                    result.IntArray[i] = vector1[i] % vector2[i];
                }
                else
                {
                    // Handle division by zero
                    result.IntArray[i] = 0;
                }
            }
            return result;
        }

        public static VectorLong operator %(VectorLong vector, long scalar)
        {
            if (scalar != 0)
            {
                VectorLong result = new VectorLong(vector.size);

                for (int i = 0; i < vector.size; i++)
                {
                    result.IntArray[i] = vector[i] % scalar;
                }
                return result;
            }
            else
            {
                // Handle division by zero
                return new VectorLong(vector.size);
            }
        }

        public static VectorLong operator |(VectorLong vector1, VectorLong vector2)
        {
            int size = Math.Max((int)vector1.size, (int)vector2.size);
            VectorLong result = new VectorLong((uint)size);

            for (int i = 0; i < size; i++)
            {
                result.IntArray[i] = vector1[i] | vector2[i];
            }
            return result;
        }

        public static VectorLong operator |(VectorLong vector, long scalar)
        {
            VectorLong result = new VectorLong(vector.size);

            for (int i = 0; i < vector.size; i++)
            {
                result.IntArray[i] = vector[i] | scalar;
            }
            return result;
        }

        public static VectorLong operator ^(VectorLong vector1, VectorLong vector2)
        {
            int size = Math.Max((int)vector1.size, (int)vector2.size);
            VectorLong result = new VectorLong((uint)size);

            for (int i = 0; i < size; i++)
            {
                result.IntArray[i] = vector1[i] ^ vector2[i];
            }
            return result;
        }

        public static VectorLong operator ^(VectorLong vector, long scalar)
        {
            VectorLong result = new VectorLong(vector.size);

            for (int i = 0; i < vector.size; i++)
            {
                result.IntArray[i] = vector[i] ^ scalar;
            }
            return result;
        }

        public static VectorLong operator &(VectorLong vector1, VectorLong vector2)
        {
            int size = Math.Max((int)vector1.size, (int)vector2.size);
            VectorLong result = new VectorLong((uint)size);

            for (int i = 0; i < size; i++)
            {
                result.IntArray[i] = vector1[i] & vector2[i];
            }
            return result;
        }

        public static VectorLong operator &(VectorLong vector, int scalar)
        {
            VectorLong result = new VectorLong(vector.size);

            for (int i = 0; i < vector.size; i++)
            {
                result.IntArray[i] = vector[i] & scalar;
            }
            return result;
        }
/*
        public static VectorLong operator >>(VectorLong vector1, VectorLong vector2)
        {
            int size = Math.Max((int)vector1.size, (int)vector2.size);
            VectorLong result = new VectorLong((uint)size);

            for (int i = 0; i < size; i++)
            {
                result.IntArray[i] = vector1[i] >> (int)vector2[i];
            }
            return result;
        }

        public static VectorLong operator >>(VectorLong vector, long scalar)
        {
            VectorLong result = new VectorLong(vector.size);

            for (int i = 0; i < vector.size; i++)
            {
                result.IntArray[i] = vector[i] >> (int)scalar;
            }
            return result;
        }

        public static VectorLong operator <<(VectorLong vector1, VectorLong vector2)
        {
            int size = Math.Max((int)vector1.size, (int)vector2.size);
            VectorLong result = new VectorLong((uint)size);

            for (int i = 0; i < size; i++)
            {
                result.IntArray[i] = vector1[i] << (int)vector2[i];
            }
            return result;
        }

        public static VectorLong operator <<(VectorLong vector, long scalar)
        {
            VectorLong result = new VectorLong(vector.size);

            for (int i = 0; i < vector.size; i++)
            {
                result.IntArray[i] = vector[i] << (int)scalar;
            }
            return result;
        }
       */

        public static bool operator ==(VectorLong vector1, VectorLong vector2)
        {
            if (ReferenceEquals(vector1, vector2))
            {
                return true;
            }

            if (vector1.size != vector2.size)
            {
                return false;
            }

            for (int i = 0; i < vector1.size; i++)
            {
                if (vector1[i] != vector2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(VectorLong vector1, VectorLong vector2)
        {
            return !(vector1 == vector2);
        }

        public override bool Equals(object obj)
        {
            if (obj is VectorLong other)
            {
                return this == other;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode(); // Implement a proper GetHashCode if needed
        }
        // ... Попередній код ...

        public static bool operator >(VectorLong vector1, VectorLong vector2)
        {
            if (vector1.size != vector2.size)
            {
                // Throw an exception or handle the case when vectors have different sizes
                throw new ArgumentException("Vectors must have the same size for comparison.");
            }

            for (int i = 0; i < vector1.size; i++)
            {
                if (vector1[i] <= vector2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator >=(VectorLong vector1, VectorLong vector2)
        {
            if (vector1.size != vector2.size)
            {
                // Throw an exception or handle the case when vectors have different sizes
                throw new ArgumentException("Vectors must have the same size for comparison.");
            }

            for (int i = 0; i < vector1.size; i++)
            {
                if (vector1[i] < vector2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator <(VectorLong vector1, VectorLong vector2)
        {
            if (vector1.size != vector2.size)
            {
                // Throw an exception or handle the case when vectors have different sizes
                throw new ArgumentException("Vectors must have the same size for comparison.");
            }

            for (int i = 0; i < vector1.size; i++)
            {
                if (vector1[i] >= vector2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator <=(VectorLong vector1, VectorLong vector2)
        {
            if (vector1.size != vector2.size)
            {
                // Throw an exception or handle the case when vectors have different sizes
                throw new ArgumentException("Vectors must have the same size for comparison.");
            }

            for (int i = 0; i < vector1.size; i++)
            {
                if (vector1[i] > vector2[i])
                {
                    return false;
                }
            }

            return true;
        }

        // ... Інші оператори та функції ...

        // Додайте оновлені перевантаження інших операторів та функцій за потреби.

        // ... Закінчення коду ...

        // ... Інші оператори та функції ...

        // Додайте оновлені перевантаження інших операторів та функцій за потреби.

        // ... Закінчення коду ...


        // ... Інші оператори та функції ...

        // Додайте оновлені перевантаження інших операторів та функцій за потреби.

        // ... Закінчення коду ...


        // Implement other binary operators as needed...

        // Implement comparison operators...

        // Implement other required methods and operators...
    }



    internal class Modul1
    {
    }
}
