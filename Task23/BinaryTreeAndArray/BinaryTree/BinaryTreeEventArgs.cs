using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTreeEventArgs<T> : EventArgs
    {
        public T Value { get; set; }

        public BinaryTreeEventArgs(T Value)
        {
            this.Value = Value;
        }
    }
}
