using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Course { get; set; }

        private readonly BinaryTree<TestInfo> testInfos;

        public Student(string firstName, string secondName, int course, BinaryTree<TestInfo> testInfos)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Course = course;
            this.testInfos = testInfos;
        }

        public void AddTest(TestInfo test)
        {
            testInfos.Add(test);
        }

        public bool FindTest(TestInfo test)
        {
            return testInfos.FindNode(test);
        }

        public override string ToString()
        {
            return FirstName + " " + SecondName + " " + Course.ToString() + "\n" + OutputTestTree();
        }

        public string OutputTestTree()
        {
            if (testInfos == null)
                return "no tests";

            string str = String.Empty;

            foreach (var item in testInfos)
            {
                str += item + " ";
            }

            return str;
        }

        public void OutputTestTree2()
        {
            testInfos.PrintTree();
        }

    }
}
