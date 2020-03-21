using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class TestInfo : IComparable<TestInfo>
    {
        public string TestName { get; set; }
        public int Mark { get; set; }

        public override string ToString()
        {
            return TestName + ":" + Mark.ToString();
        }
        public TestInfo() { }
        public TestInfo(string TestName, int Mark)
        {
            this.TestName = TestName;
            if (Mark >= 0)
                this.Mark = Mark;
            else
                throw new ArgumentException();
        }

        public int CompareTo(TestInfo other)
        {
            if (Mark == other.Mark && TestName == other.TestName)
            {
                return 0;
            }
            else if (Mark > other.Mark)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
