using Array;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BinaryTreeAndArrayTest
{
    public class ArrayTest
    {
        [Fact]
        public void GetEnumerator_GetEnumeratorForArray_EnumeratorIsNotNull()
        {
            //Arrange
            Array<int> array = new Array<int>(0, 10);
            //Act
            var enumer = array.GetEnumerator();
            //Assert
            Assert.NotNull(enumer);
        }

        [Fact]
        public void Indexator_SetValueByIndex_SetCorrectValue()
        {
            //Arrange
            Array<int> array = new Array<int>(-10, 5);
            //Act
            array[-10] = 5;
            array[-6] = 1;
            //Assert
            Assert.Equal(5, array[-10]);
            Assert.Equal(1, array[-6]);
        }

        [Fact]
        public void Indexator_SetValueByIndex_IfIndexIncorrectThrowIndexOutOfRangeException()
        {
            //Arrange
            Array<int> array = new Array<int>(-10, 5);
            //act
            Action act = () => { array[-11] = 5; };
            //assert is handled by ExpectedException
            Assert.Throws<IndexOutOfRangeException>(act);
        }
        [Fact]
        public void Indexator_GetValueByIndex_IfIndexIncorrectThrowIndexOutOfRangeException()
        {
            //Arrange
            Array<int> array = new Array<int>(-10, 5);
            int res;
            //act
            Action act = () => { res = array[-3]; };
            //assert is handled by ExpectedException
            Assert.Throws<IndexOutOfRangeException>(act);
        }

        [Fact]
        public void CopyTo_CopyDataToAnotherArray_DataIsSame()
        {
            //Arrange
            Array<int> array = new Array<int>(new int[3] { 1, 2, 3 });
            Array<int> temp = new Array<int>(0, 3);
            //Act
            array.CopyTo(temp);
            //Assert
            Assert.Equal(array, temp);
        }
        [Fact]
        public void CopyTo_CopyDataToAnotherArray_IfAnotherCapacityLowerThanThisThrowArgumentException()
        {
            //Arrange
            Array<int> array = new Array<int>(new int[3] { 1, 2, 3 });
            Array<int> temp = new Array<int>(0, 2);
            //act
            Action act = () => { array.CopyTo(temp); };
            //assert is handled by ExpectedException
            Assert.Throws<ArgumentException>(act);

        }

        [Fact]
        public void CopyTo_CopyDataToArray_DataIsSame()
        {
            //Arrange
            Array<int> array = new Array<int>(new int[3] { 1, 2, 3 });
            int[] temp = new int[3];
            //Act
            array.CopyTo(temp);
            //Assert
            Assert.Equal(array, temp);
        }
        [Fact]
        public void CopyTo_CopyDataToArray_IfAnotherLengthLowerThanMyCapacityThrowArgumentException()
        {
            //Arrange
            Array<int> array = new Array<int>(new int[3] { 1, 2, 3 });
            int[] temp = new int[2];
            //act
            Action act = () => { array.CopyTo(temp); };
            //assert is handled by ExpectedException
            Assert.Throws<ArgumentException>(act);
        }


        [Fact]
        public void Array_CreateInstance_CreatedInstanceIsNotNullAndCapacityIsCorrect()
        {
            //Arrange
            Array<int> array;
            //Act
            array = new Array<int>(10, 5);
            //Assert
            Assert.NotNull(array);
            Assert.Equal(5, array.Capacity);
        }
        [Fact]
        public void Array_CreateInstanceFromArrayFromZeroIndex_CreatedInstanceHasSameData()
        {
            //Arrange
            Array<int> array;
            int[] temp = new int[5] { 1, 2, 3, 4, 5 };
            //Act
            array = new Array<int>(temp);
            //Assert
            Assert.Equal(temp, array.array);
        }

        [Fact]
        public void Array_CreateInstanceFromAnotherArray_CreatedInstanceHasSameDataStartingFromSameIndex()
        {
            //Arrange
            Array<int> array;
            Array<int> temp = new Array<int>(new int[5] { 1, 2, 3, 4, 5 }, -5);
            //Act
            array = new Array<int>(temp);
            //Assert
            Assert.Equal(temp, array);
            Assert.Equal(temp.LowerBound, array.LowerBound);
        }

        [Fact]
        public void Array_CreateInstanceWithIndexAndCapacity_IfCapacityLowerThan1ThrowArgumentException()
        {
            //Arrange
            Array<int> array;
            //act
            Action act = () => { array = new Array<int>(10, 0); };
            //assert is handled by ExpectedException
            Assert.Throws<ArgumentException>(act);

        }
        [Fact]
        public void Array_CreateInstanceFromArray_IfNullLengthOfArrayLowerThan1ThrowArgumentException()
        {
            //Arrange
            Array<int> array;
            int[] temp = new int[0];
            //act
            Action act = () => { array = new Array<int>(temp); };
            //assert is handled by ExpectedException
            Assert.Throws<ArgumentException>(act);

        }
        [Fact]
        public void Array_CreateInstanceFromArrayAndCustomIndex_IfNullLengthOfArrayLowerThan1ThrowNullReferenceException()
        {
            //Arrange
            int[] temp = null;
            //act
            Action act = () => { _ = new Array<int>(temp, -5); };
            //assert is handled by ExpectedException
            Assert.Throws<NullReferenceException>(act);
        }

        [Fact]
        public void Array_CreateInstanceFromAnotherArray_IfNullThrowNullReferenceException()
        {
            //Arrange
            Array<int> temp = null;
            //act
            Action act = () => { _ = new Array<int>(temp); };
            //assert is handled by ExpectedException
            Assert.Throws<NullReferenceException>(act);

        }
    }
}
