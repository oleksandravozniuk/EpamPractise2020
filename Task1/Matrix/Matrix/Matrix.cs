using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix
    {
        private double[,] data;

        private int m;
        public int M { get => this.m; }

        private int n;
        public int N { get => this.n; }

        public Matrix(int m, int n)//constructor
        {
            this.m = m;
            this.n = n;
            this.data = new double[m, n];
        }

        public Matrix(int m, int n, double[,] matrix)//constructor
        {
            this.m = m;
            this.n = n;
            this.data = Copy(matrix);
        }

        //indexators
        public double this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= data.GetLength(0) || y < 0 || y >= data.GetLength(1))
                    throw new IndexOutOfRangeException();
                else
                return this.data[x, y];
            }
            set
            {
                if (x < 0 || x >= data.GetLength(0) || y < 0 || y >= data.GetLength(1))
                    throw new IndexOutOfRangeException();
                else
                    this.data[x, y] = value;
            }
        }
        //--------------------------------------------------------------


        public void OutputMatrix()
        {
            for (var i = 0; i < this.M; i++)
            {
                for (var j = 0; j < this.N; j++)
                {
                    Console.Write(this.data[i, j]);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
        }

        public static Matrix operator *(Matrix matrix, double value)//multiply by value
        {
            if(matrix==null)
            {
                throw new NullReferenceException();
            }
            var result = new Matrix(matrix.M, matrix.N);
            for (var i = 0; i < matrix.M; i++)
            {
                for (var j = 0; j < matrix.N; j++)
                {
                    result.data[i, j] = matrix[i,j]*value;
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix matrix, Matrix matrix2)//multiply matrix and matrix
        {
            if (matrix == null || matrix2==null)
            {
                throw new NullReferenceException();
            }
            if (matrix.N != matrix2.M)
            {
                throw new ArgumentException("matrixes can not be multiplied");
            }
            var result = new Matrix(matrix.M, matrix2.N);
            for (var i = 0; i < matrix.M; i++)
            {
                for (var j = 0; j < matrix2.N; j++)
                {
                    result[i, j] = 0;

                    for (var k = 0; k < matrix.N; k++)
                    {
                        result[i, j] += matrix[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }

        public static Matrix operator +(Matrix matrix, Matrix matrix2)// adding matrixes
        {
            if (matrix == null || matrix2 == null)
            {
                throw new NullReferenceException();
            }

            if (matrix.M != matrix2.M || matrix.N != matrix2.N)
            {
                throw new ArgumentException("matrixes dimensions should be equal");
            }
            var result = new Matrix(matrix.M, matrix.N);
            for (var i = 0; i < matrix.M; i++)
            {
                for (var j = 0; j < matrix.N; j++)
                {
                    result[i, j] = matrix[i, j] + matrix2[i, j];
                }

            }

            return result;
        }

        public static Matrix operator -(Matrix matrix, Matrix matrix2)
        {
            return matrix + (matrix2 * -1);
        }

        public Matrix CreateTransposeMatrix()
        {
            var result = new Matrix(this.N, this.M);
            for (var i = 0; i < this.N; i++)
            {
                for (var j = 0; j < this.M; j++)
                {
                    result[i, j] = this[j, i];
                }

            }
            return result;
        }

        public static bool operator ==(Matrix matrix, Matrix matrix2)
        {
            if ((ReferenceEquals(matrix,null) && !ReferenceEquals(matrix2,null))||(!ReferenceEquals(matrix,null) && ReferenceEquals(matrix2,null)) )
                return false;
            else
            if (matrix is null && matrix2 is null)
                return true;

            if (matrix.m != matrix2.m || matrix.n != matrix2.n)
            {
                return false;
            }

            for (int i = 0; i < matrix.m; i++)
            {
                for (int j = 0; j < matrix.n; j++)
                {
                    if (matrix[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator !=(Matrix matrix, Matrix matrix2)
        {
            if ((ReferenceEquals(matrix, null) && !ReferenceEquals(matrix2, null)) || (!ReferenceEquals(matrix, null) && ReferenceEquals(matrix2, null)))
                return true;
            else
            if (matrix is null && matrix2 is null)
                return false;

            if (matrix.m != matrix2.m || matrix.n != matrix2.n)
            {
                return true;
            }
            for (int i = 0; i < matrix.m; i++)
            {
                for (int j = 0; j < matrix.n; j++)
                {
                    if (matrix[i, j] != matrix2[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            var matrix = obj as Matrix;
            return matrix != null &&
                   EqualityComparer<double[,]>.Default.Equals(this.data, matrix.data) &&
                   m == matrix.m &&
                   n == matrix.n;
        }

        public override int GetHashCode()
        {
            var hashCode = 1313493824;
            hashCode = hashCode * -1521134295 + EqualityComparer<double[,]>.Default.GetHashCode(data);
            hashCode = hashCode * -1521134295 + m.GetHashCode();
            hashCode = hashCode * -1521134295 + n.GetHashCode();
            return hashCode;
        }

        public static double[,] Copy(double[,] matrix)
        {
            double[,] m = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    m[i, j] = matrix[i, j];
                }
            }
            return m;
        }


    }
}
