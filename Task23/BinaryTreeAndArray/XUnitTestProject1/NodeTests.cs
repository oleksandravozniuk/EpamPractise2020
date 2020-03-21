using BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BinaryTreeAndArrayTest
{
    public class NodeTests
    {

        [Fact]
        public void Node_CreateObject_ObjectIsNotNull()
        {
            //Arrange
            //Act
            Node<int> node = new Node<int>();
            //Assert
            Assert.NotNull(node);
        }

        [Fact]
        public void Node_CreateObjectWithValue_ObjectWithCorrectValue()
        {
            //Arrange
            Node<int> node = null;
            int value = 5;
            //Act
            node = new Node<int>(value);
            //Assert
            Assert.Equal(value, node.Data);
        }
    }
}
