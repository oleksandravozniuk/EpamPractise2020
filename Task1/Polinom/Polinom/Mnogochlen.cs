using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    class Mnogochlen
    {
        private int[] koef; //массив коэф-ов

        public Mnogochlen(int[] k)
        {
            this.koef = k;
            k.CopyTo(this.koef,0);
        }

        //indexators
        public int this[int x]
        {
            get
            {
                if (x < 0 || x >= koef.Length)
                    throw new IndexOutOfRangeException();
                else
                return this.koef[x];
            }
            set
            {
                if (x < 0 || x >= koef.Length)
                    throw new IndexOutOfRangeException();
                else
                    this.koef[x] = value;
            }
        }

        //сложение полиномов
        public static Mnogochlen operator +(Mnogochlen A, Mnogochlen B)
        {
            if(A==null || B==null)
            {
                throw new NullReferenceException();
            }

            int resultSize;
            if (A.koef.Length >= B.koef.Length)
                resultSize = A.koef.Length;
            else
                resultSize = B.koef.Length;

            int[] newKoef = new int[resultSize];

            Mnogochlen C = new Mnogochlen(newKoef);

            for (int i = 0; i < C.koef.Length; i++)
            {
                int a;
                if (A.koef.Length<=i)
                    a = 0;
                else a = A.koef[i];

                int b;
                if (B.koef.Length<=i)
                    b = 0;
                else b = B.koef[i];
                    
                C.koef[i] = a + b;
            }
            return C;
        }


        //вычитание полиномов
        public static Mnogochlen operator -(Mnogochlen A, Mnogochlen B)
        {
            if (A == null || B == null)
            {
                throw new NullReferenceException();
            }

            int resultSize;
            if (A.koef.Length >= B.koef.Length)
                resultSize = A.koef.Length;
            else
                resultSize = B.koef.Length;

            int[] newKoef = new int[resultSize];

            Mnogochlen C = new Mnogochlen(newKoef);

            for (int i = 0; i < C.koef.Length; i++)
            {
                int a;
                if (A.koef.Length<=i)
                    a = 0;
                else a = A.koef[i];

                int b;
                if (B.koef.Length<=i)
                    b = 0;
                else b = B.koef[i];

                C.koef[i] = a - b;
            }
            return C;
        }


        public static Mnogochlen operator *(Mnogochlen A, Mnogochlen B)
        {
            if (A == null || B == null)
            {
                throw new NullReferenceException();
            }


            int size = A.koef.Length + B.koef.Length - 1;
            int[] koef = new int[size];
            Mnogochlen result = new Mnogochlen(koef);
            for (int i = 0; i < A.koef.Length; ++i)
            {
                for (int j = 0; j < B.koef.Length; ++j)
                {
                    koef[i + j] += A.koef[i] * B.koef[j];
                }
            }
            return result;
        
    }



        //вывод полинома
        public void show()
        {
            for (int i = 0; i < koef.Length; i++)
            {
                Console.Write("  " + koef[i] + "x^" + i);
            }
    
        }
    }
}
