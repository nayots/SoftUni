using Exercises_Models.Models;
using NUnit.Framework;
using System;

namespace Exercises_Models.Tests
{
    [TestFixture]
    public class DynamicListTests
    {
        private DynamicList<int> sut;

        [SetUp]
        public void TestInit()
        {
            this.sut = new DynamicList<int>();
            this.sut.Add(10);
            this.sut.Add(20);
            this.sut.Add(30);
        }

        [Test]
        public void NewEmptyListCountIsZero()
        {
            DynamicList<int> list = new DynamicList<int>();

            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void AddElementToList()
        {
            this.sut.Add(100);

            Assert.AreEqual(4, this.sut.Count);
        }

        [Test]
        public void GetElementAtIndex()
        {
            Assert.AreEqual(20, this.sut[1]);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void RemoveElementAtIndex(int index)
        {
            int valueExpected = this.sut[index];

            int returnedValue = this.sut.RemoveAt(index);

            Assert.AreEqual(valueExpected, returnedValue);
        }

        [Test]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void RemoveAtInvalidIndexThrowsExc(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.sut.RemoveAt(index));
        }

        [Test]
        public void RemoveExistingElementByValue()
        {
            Assert.AreEqual(1, this.sut.Remove(20));
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void RemoveNonExistantElementByValue(int value)
        {
            Assert.AreEqual(-1, this.sut.Remove(value));
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void ReturnCorrectIndexOfElement(int value)
        {
            int expectedIndex = value / 10 - 1;

            Assert.AreEqual(expectedIndex, this.sut.IndexOf(value));
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void ReturnNegativeIndexOfElementWhenValueDoesNotExists(int value)
        {
            Assert.AreEqual(-1, this.sut.IndexOf(value));
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void ReturnTrueForExistingElementsWhenSearchedByValue(int value)
        {
            Assert.IsTrue(this.sut.Contains(value));
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void ReturnFalseForExistingElementsWhenSearchedByValue(int value)
        {
            Assert.IsFalse(this.sut.Contains(value));
        }
    }
}