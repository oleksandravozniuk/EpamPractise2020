using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public Node<T> RootNode { get; private set; }

        public delegate void EventHandler(object sender, BinaryTreeEventArgs<T> e);
        public event EventHandler OnInsert;


        public BinaryTree()
        {
            RootNode = null;
        }

        public void Add(T data)
        {

            OnInsert?.Invoke(this, new BinaryTreeEventArgs<T>(data));
            Add(new Node<T>(data));
        }

        public Node<T> Add(Node<T> node, Node<T> currentNode = null)//add a node to the binary tree
        {

            if (node == null)
                throw new ArgumentNullException("argument null exception");

            if (RootNode == null)
            {
                node.ParentNode = null;
                
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;


            //if((result=node.Data.CompareTo(currentNode.Data))==0)
            //{
            //    return currentNode;
            //}
            //else
            //{
            //    if(result<0)
            //    {
            //        if (currentNode.LeftNode == null)
            //        {
            //            currentNode.LeftNode = node;

            //        }

            //            Add(node, currentNode.LeftNode);
            //    }
            //    else
            //    if(result>0)
            //    {
            //        if (currentNode.RightNode == null)
            //        {
            //            currentNode.RightNode = node;

            //        }

            //            Add(node, currentNode.RightNode);
            //    }
            //    return currentNode;
            //}


            return (result = node.Data.CompareTo(currentNode.Data)) == 0
                ? Add(node, currentNode.RightNode)
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);

            
        }
        public void PrintTree()
        {
            PrintTree(RootNode);
        }

        private void PrintTree(Node<T> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {

                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data.ToString()}");
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }

        public bool FindNode(T data)
        {
           
            if (FindNode(data, RootNode) == null)
                return false;
            else
                return true;
        }

        public Node<T> FindNode(T data, Node<T> startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result;
            return (result = data.CompareTo(startWithNode.Data)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(data, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(data, startWithNode.RightNode);
        }

        public IEnumerator<T> GetEnumerator() => new NodeEnumerator<T>(this);
        IEnumerator IEnumerable.GetEnumerator() => new NodeEnumerator<T>(this);

    }
}
