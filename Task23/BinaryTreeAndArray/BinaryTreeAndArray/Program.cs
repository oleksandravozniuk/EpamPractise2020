using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;
using Array;

namespace BinaryTreeAndArray
{
    class Program
    {
        static void Main(string[] args)
        {
            TestInfo testInfo0 = new TestInfo("Test0", 7);
            TestInfo testInfo1 = new TestInfo("Test1",8);
            TestInfo testInfo2 = new TestInfo("Test2", 9);
            TestInfo testInfo3 = new TestInfo("Test3", 5);
            TestInfo testInfo4 = new TestInfo("Test4", 7);
            TestInfo testInfo5 = new TestInfo("Test5", 6);
            TestInfo testInfo6 = new TestInfo("Test6", 10);
            TestInfo testInfo7 = new TestInfo("Test7", 4);
            TestInfo testInfo8 = new TestInfo("Test8", 1);

            BinaryTree<TestInfo> binaryTree = new BinaryTree<TestInfo>();

            binaryTree.OnInsert += OnTreeInsert;

            binaryTree.Add(testInfo0);
            binaryTree.Add(testInfo1);
            binaryTree.Add(testInfo2);
            binaryTree.Add(testInfo3);
            binaryTree.Add(testInfo4);
            binaryTree.Add(testInfo5);
            binaryTree.Add(testInfo6);
            binaryTree.Add(testInfo7);
            binaryTree.Add(testInfo8);


            Student student = new Student("Mark", "Mark", 2, binaryTree);

            Console.WriteLine(student);
            student.OutputTestTree2();

            Console.WriteLine(student.FindTest(testInfo3));

            Console.WriteLine();

            Array<int> myArray = new Array<int>(-5, 14);
            myArray[-5] = -5;
            myArray[-4] = -4;
            myArray[0] = 1000;
            myArray[8] = 8;

            foreach (var i in myArray)
            {
                Console.WriteLine($"{i}");
            }

            Array<string> m1 = new Array<string>(new string[5] { "a", "b", "c", "d", "e" });
            Array<string> m2 = new Array<string>(30, 6);
            m1.CopyTo(m2);
            foreach (var item in m2)
            {
                Console.WriteLine(item);
            }

            Array<string> m3 = new Array<string>(m1);
            foreach (var item in m3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Array<Student> s1 = new Array<Student>(-2,5);
            s1[-2] = new Student("N", "n", 2, null);
            s1[0] = student;

            foreach(var item in s1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            


            Console.ReadKey();
        }

        public static void OnTreeInsert<T>(object sender, BinaryTreeEventArgs<T> e)
        {
            Console.WriteLine("Element added to tree: " + e.Value.ToString());
        }

    }
}
