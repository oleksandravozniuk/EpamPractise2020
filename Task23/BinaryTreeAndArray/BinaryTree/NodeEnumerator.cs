using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class NodeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private BinaryTree<T> myTree;
        private Queue<T> queue;
        public NodeEnumerator(BinaryTree<T> myTree)
        {
            this.myTree = myTree;
            queue = new Queue<T>();
            Traverse(this.myTree.RootNode);
        }

        public T Current => queue.Dequeue();
        object IEnumerator.Current { get { return Current; } }

        public void Dispose() { }
        public void Traverse(Node<T> Root)
        {
            if (Root == null)
                return;
            Traverse(Root.LeftNode);
            queue.Enqueue(Root.Data);
            Traverse(Root.RightNode);
        }
        public bool MoveNext()
        {
            if (queue.Count > 0)
                return true;
            return false;
        }
        public void Reset() { }
    }
}
