using System;
using System.Collections;
using System.Collections.Generic;
using ClassLibrary_LabWork2;
using NUnit.Framework;

namespace LabWork2.Tests
{
    [TestFixture]
    public class LabWork2Tests
    {
        [TestCase(1, 2, 3, 4, 5, 6)]
        [TestCase(0)]
        public void ConstructorCount_Get_ShouldReturnCorrectValue(params int[] elements)
        {
            //arrange
            CustomLL<int> list = new CustomLL<int>(elements);

            //act
            var expected = elements.Length;
            var actual = list.Count;

            //assert
            Assert.AreEqual(expected, actual, message: "Count works incorrectly");
            Assert.AreEqual(elements[0], list[0], message: "Get index works incorrectly");
        }

        [Test]
        public void Count_Return0()
        {
            //arrange
            int actual = 0;

            //act
            CustomLL<int> list = new CustomLL<int>();

            //assert
            Assert.AreEqual(list.Count, actual, message: "Count works incorrectly");
        }

        [Test]
        public void Clear_ReturnCount0()
        {
            //arrange
            CustomLL<int> list = new CustomLL<int>(1, 2, 3);
            Item<int> expectedHead = null;

            //act
            list.Clear();
            int count = list.Count;
            var actualHead = list.Head;

            //arrange
            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, count, message: "Clear method works incorrectly ");
                Assert.AreEqual(expectedHead, actualHead, message: "Clear method works incorrectly ");
            });
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, 4, true)]
        [TestCase(10, new int[] { 1, 2, 3, 4, 5 }, 5, false)]
        [TestCase(15, new int[] { 11, 4, 5 }, 3, false)]
        [TestCase(-1, new int[] { -1, 2, -1, 4, 5 }, 4, true)]
        [TestCase(99, new int[] { -1, 2, -1, 4, 100 }, 5, false)]
        [TestCase(1, new int[] { 1 }, 0, true)]
        public void Remove_Element_ReturnedExpectedCount(int elementToRemove, int[] elements, int expectedCount, bool expectedBool)
        {
            //arrange
            CustomLL<int> list = new CustomLL<int>(elements);

            //act
            var actualBool = list.Remove(elementToRemove);

            //arrange
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCount, list.Count, message: "Remove method works incorrectly");
                Assert.AreEqual(expectedBool, actualBool, message: "Remove method works incorrectly");
            });
        }


    }
}
