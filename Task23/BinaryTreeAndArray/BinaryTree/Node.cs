using System;

namespace BinaryTree
{

    public enum Side
    {
        Left,
        Right
    }
    public class Node<T>
    {
       
        public T Data { get; set; }
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
        public Node<T> ParentNode { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node()
        {
        }

        public Side? NodeSide =>
        ParentNode == null
        ? (Side?)null
        : ParentNode.LeftNode == this
            ? Side.Left
            : Side.Right;

        public override string ToString() => Data.ToString();
    }
}
