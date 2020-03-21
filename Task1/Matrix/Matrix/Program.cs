using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Matrix 1");
            double[,] data1 = { 
                { 1, 2, 3 }, { 3, 4, 5 }, { 5, 6, 7 },
                   {1,3,4 },{4,7,8 },{1,3,5 },
                    {4,2,5 },{2,4,7 },{4,3,2 }
            }; 
            Matrix matrix = new Matrix(3,3, data1);
            matrix.OutputMatrix();
            Console.WriteLine();


            Console.WriteLine("Matrix2");
            double[,] data2 = {
                { 1, 2, 3 }, { 4, 4, 5 }, { 5, 6, 7 },
                   {1,4,4 },{4,7,8 },{1,3,9 },
                    {4,2,2},{2,4,7 },{4,3,2 }
            };
            Matrix matrix2 = new Matrix(3, 3, data2);
            matrix2.OutputMatrix();
            Console.WriteLine();

            Console.WriteLine("Multiply matrix1 and matrix2");

            try
            {
                var matrix3 = matrix * matrix2;
                matrix3.OutputMatrix();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            Console.WriteLine("Adding matrix1 and matrix2");
            try
            {
                var matrix4 = matrix + matrix2;
                matrix4.OutputMatrix();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            Console.WriteLine();

            Console.WriteLine("Multiply matrix1 on value 2");
            try
            {
                var matrix5 = matrix * 2;
                matrix5.OutputMatrix();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine();

            Console.WriteLine("matrix1 - matrix2");
            try
            {
                var matrix6 = matrix - matrix2;
                matrix6.OutputMatrix();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            Console.WriteLine();

            Console.WriteLine("Get value [0,0] from matrix1 with an indexator");
            try
            {
                Console.WriteLine(matrix[0, 0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine();

            Console.WriteLine("Transposed matrix1");
            try
            {
                var matrix7 = matrix.CreateTransposeMatrix();
                matrix7.OutputMatrix();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine();

            Console.WriteLine("Matrix A");
            double[,] dataA = {
                { 1, 2, 3 }, { 3, 4, 5 }, { 5, 6, 7 },
                   {1,3,4 },{4,7,8 },{1,3,5 },
                    {4,2,5 },{2,4,7 },{4,3,2 }
            };
            Matrix matrixA = new Matrix(3, 3, dataA);
            matrixA.OutputMatrix();
            Console.WriteLine();

            Console.WriteLine("Matrix B");
            double[,] dataB = {
                { 1, 2, 3 }, { 4, 4, 5 }, { 5, 6, 7 },
                   {1,4,4 },{4,7,8 },{1,3,9 },
                    {4,2,2},{2,4,7 },{4,3,2 }
            };
            Matrix matrixB = new Matrix(3, 3, dataB);
            matrixB.OutputMatrix();
            Console.WriteLine();

            if (matrixA == matrixB)
            {
                Console.WriteLine("matrixA and matrixB are equal!");
            }
            else
            {
                Console.WriteLine("matrixA and matrixB are not equal!");
            }

            Console.ReadKey();
        }
    }
}
