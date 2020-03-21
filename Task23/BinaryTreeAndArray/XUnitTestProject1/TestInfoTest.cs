using BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BinaryTreeAndArrayTest
{
    public class TestInfoTest
    {
        [Fact]
        public void TestInfo_CreateInstance_InstanceIsNotNull()
        {
            //Arrange
            TestInfo testInfo = null;
            //Act
            testInfo = new TestInfo();
            //Assert
            Assert.NotNull(testInfo);
        }

        [Fact]
        public void TestInfo_CreateInstanceWithData_InstanceIncludesAllData()
        {
            //Arrange
            TestInfo testInfo = null;
            string testName = "Test1";
            int mark = 10;
            List<string> exp = new List<string>() { testName, mark.ToString() };
            //Act
            testInfo = new TestInfo(testName, mark);
            List<string> res = new List<string>() { testInfo.TestName, testInfo.Mark.ToString() };
            //Assert
            Assert.Equal(exp.ToString(), res.ToString());
        }

        [Fact]
        public void TestInfo_SetMarkToInstance_IfMarkIsNegativeCatchArgumentException()
        {

            //Arrange

            //act
            Action act = () => { _ = new TestInfo("Test", -1); };

            //assert is handled by ExpectedException
            Assert.Throws<ArgumentException>(act);

        }

        [Fact]
        public void ToString_ReturnStringForInstance_StringIsCorrect()
        {
            //Arrange
            TestInfo testInfo = new TestInfo
            {
                TestName = "TestName",
                Mark = 10
            };
            //Act
            var result = testInfo.ToString();
            //Assert
            Assert.Equal("TestName:10", result);
        }

        [Fact]
        public void CompareTo_CompareTwoTestInfos_FirstInfoIsSmallerThanSecond()
        {
            //Arrange
            TestInfo testInfo = new TestInfo();
            testInfo.TestName = "";
            testInfo.Mark = 1;
            TestInfo testInfo2 = new TestInfo();
            testInfo2.TestName = "";
            testInfo2.Mark = 2;
            //Act
            var result = testInfo.CompareTo(testInfo2);
            //Assert
            Assert.Equal(-1, result);
        }
    }
}
