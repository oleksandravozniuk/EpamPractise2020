using BinaryTree;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class BinaryTreeTests
    {
        [Fact]
        public void Add_AddedNodeIsNull_ArgumentNullException()
        {
            //arrange
            var bt = new BinaryTree<int>();
            //act
            Action act = () => { bt.Add(null); };

            //assert is handled by ExpectedException
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Add_AddIntFirstElementToTheTree_AddedElementIsARoot()
        {
            //arrange
            int i = 1;
            BinaryTree<int> bt = new BinaryTree<int>();
            //act
            bt.Add(1);
            //assert
            Assert.Equal(i, bt.RootNode.Data);
        }

        [Fact]
        public void Add_AddIntElementThatIsSmallerThanRoot_ElementGoesLeft()
        {
            //arrange
            var bt = new BinaryTree<int>();
            //act
            bt.Add(2);
            bt.Add(1);
            //assert
            Assert.Equal(1, bt.RootNode.LeftNode.Data);

        }

        [Fact]
        public void Add_AddIntElementThatIsBiggerThanRoot_ElementGoesRight()
        {
            //arange
            var bt = new BinaryTree<int>();
            //act
            bt.Add(2);
            bt.Add(3);
            //assert
            Assert.Equal(3, bt.RootNode.RightNode.Data);
        }

        [Fact]
        public void FindNode_FindingIntNodeThatDoesntExistsInTheTree_False()
        {
            //arrange
            var bt = new BinaryTree<int>();
            bt.Add(1);
            //act
            var result = bt.FindNode(2);
            //assert
            Assert.False(result);
        }

        [Fact]
        public void FindNode_FindingIntNodeThatExistsInTheTree_True()
        {
            //arrange
            var bt = new BinaryTree<int>
            {
                1
            };
            //act
            var result = bt.FindNode(1);
            //assert
            Assert.True(result);
        }


        [Fact]
        public void Inorder_Input3Elements213_Output123()
        {
            //arrange
            var bt = new BinaryTree<int>
            {
                2,
                1,
                3
            };

            var q = new Queue<int>();
            var q2 = new Queue<int>();
            q2.Enqueue(1);
            q2.Enqueue(2);
            q2.Enqueue(3);

            //act


            foreach (var item in bt)
            {
                q.Enqueue(item);
            }
            //assert
            Assert.Equal(q,q2);
        }


        [Fact]
        public void Inorder_InorderIfTreeIsEmpty_EmptyString()
        {
            //arrange
            var bt = new BinaryTree<int>();
            //act
            var q = new Queue<int>();
            foreach (var item in bt)
            {
               q.Enqueue(item);
            }
            //assert
            Assert.Empty(q);
        }



        [Fact]
        public void Insert_InsertedObjectCallEvent_ReturnValueOfObjectThatCallEvent()
        {
            // arrenge
            var tree = new BinaryTree<int>();
            var actual = new BinaryTreeEventArgs<int>(0);

            //act
            tree.OnInsert += (_, s) => { actual = s; };
            tree.Add(1);

            //assert
            Assert.Equal(1, actual.Value);


        }

        //---------------------------------

        [Fact]
        public void Add_AddTestInfoFirstElementToTheTree_AddedElementIsARoot()
        {
            //arrange
            BinaryTree<TestInfo> bt = new BinaryTree<TestInfo>();
            //act
            bt.Add(new TestInfo("Test0", 1));
            //assert
            Assert.Equal(new TestInfo("Test0", 1), bt.RootNode.Data);
        }

        [Fact]
        public void Add_AddTestInfoElementThatIsSmallerThanRoot_ElementGoesLeft()
        {
            //arrange
            BinaryTree<TestInfo> bt = new BinaryTree<TestInfo>();
            //act
            bt.Add(new TestInfo("Test0", 2));
            bt.Add(new TestInfo("Test0", 1));
            //assert
            Assert.Equal(new TestInfo("Test0", 1), bt.RootNode.LeftNode.Data);

        }

        [Fact]
        public void Add_AddTestInfoElementThatIsBiggerThanRoot_ElementGoesRight()
        {
            //arrange
            BinaryTree<TestInfo> bt = new BinaryTree<TestInfo>();
            //act
            bt.Add(new TestInfo("Test0", 2));
            bt.Add(new TestInfo("Test0", 3));
            //assert
            Assert.Equal(new TestInfo("Test0", 3), bt.RootNode.RightNode.Data);
        }

        [Fact]
        public void FindNode_FindingTestInfoNodeThatDoesntExistsInTheTree_False()
        {
            //arrange
            BinaryTree<TestInfo> bt = new BinaryTree<TestInfo>();
            bt.Add(new TestInfo("Test0", 1));
            //act
            var result = bt.FindNode(new TestInfo("Test1", 1));
            //assert
            Assert.False(result);
        }

        [Fact]
        public void FindNode_FindingInfoTestNodeThatExistsInTheTree_True()
        {
            //arrange
            BinaryTree<TestInfo> bt = new BinaryTree<TestInfo>();
            bt.Add(new TestInfo("Test0", 1));
            //act
            var result = bt.FindNode(new TestInfo("Test0", 1));
            //assert
            Assert.True(result);
        }


        //[Fact]
        //public void Inorder_Input3ElementsWithTestMarks213_Output123()
        //{
        //    //arrange
        //    BinaryTree<TestInfo> bt = new BinaryTree<TestInfo>();

        //    bt.Add(new TestInfo("Test0", 2));
        //    bt.Add(new TestInfo("Test0", 1));
        //    bt.Add(new TestInfo("Test0", 3));
        //    //act
        //    string inorderStr = String.Empty;
        //    foreach (var item in bt)
        //    {
        //        inorderStr += item.Mark + " ";
        //    }
        //    //assert
        //    Assert.Equal("1 2 3 ", inorderStr);
        //}
    }
}
