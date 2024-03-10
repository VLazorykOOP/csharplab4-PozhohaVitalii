using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    class Money
    {
        // Захищені поля
        private int _first;
        private int _second;
        private int _nominal;
        private int _num;
        public static int _count;
        // Конструктор
        public Money(int nominal, int num)
        {
            _first = 0;
            _second = 0;
            _nominal = nominal;
            _num = num;
            _count = nominal * num;
        }
        public static int Count
        {
            get { return _count; }
        }
        // Метод для виведення інформації
        public void DisplayInfo()
        {
            Console.WriteLine($"Nominal: {_nominal}, Count: {_num}");
        }

        // Метод для перевірки, чи вистачить грошей на покупку товару
        public static bool IsEnoughMoney(int amount)
        {
            return _count >= amount;
        }
        public bool IsEnoughMoneyThis(int amount)
        {
            return _nominal * _num >= amount;
        }

        public int this[int index]
        {
            get
            {
                if (index == 1) { return _second; }
                else if (index == 0) { return _first; }
                else { throw new IndexOutOfRangeException(); }
            }

           
            set {
                if (index == 1) { _second = value; }
                else if (index == 0) { _first = value; }
                else { throw new IndexOutOfRangeException(); }
            }
        }

        public static Money operator ++(Money obj)
        {
            obj._first++;
            obj._second++;
            return obj;
        }
        public static Money operator --(Money obj)
        {
            obj._first--;   
            obj._second--;
            return obj;
        }
        public static bool operator !(Money obj) {
            if (obj._second != 0) { return true; }
            else
            {
                return false;
            }
        }
        public static Money operator +(Money A, double a) {
            Money B = new Money(A.Nominal,A.Num);
            A._second += (int)a;
            B._first=A._first;
            B._second+=A._second;
            return B;
        }
        // Метод для розрахунку кількості товару, яку можна купити на гроші
        public static int CalculateItemsToBuy(int amount)
        {
            if (IsEnoughMoney(amount))
            {
                return _count / amount;
            }
            else
            {
                return 0;
            }
        }

        // Властивості для отримання і встановлення значень полів
        public int Nominal
        {
            get { return _nominal; }
            set
            {
                _count -= _nominal * _num;
                _count += value * _num;
                _nominal = value;
            }
        }

        public int Num
        {
            get { return _num; }
            set
            {
                _count -= _nominal * _num;
                _count += value * _nominal;
                _num = value;
            }
        }

        // Властивість для отримання суми грошей
        public int TotalAmount
        {
            get { return _nominal * _num; }
        }
    }
    internal class UserClass
    {
        public string Name { get; set; }
    }
}
