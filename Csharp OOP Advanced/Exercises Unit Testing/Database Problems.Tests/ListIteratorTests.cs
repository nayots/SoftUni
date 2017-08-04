using Exercises_Models.Models;
using NUnit.Framework;
using System;

namespace Exercises_Models.Tests
{
    [TestFixture]
    public class ListIteratorTests
    {
        private ListIterator<string> sut;

        [SetUp]
        public void TestInit()
        {
            this.sut = new ListIterator<string>(new string[] { "Some", "Random", "Message" });
        }

        [Test]
        public void CreateWithNullParameter()
        {
            Assert.Throws<ArgumentNullException>(() => this.sut = new ListIterator<string>(null));
        }

        [Test]
        public void MoveIsPossible()
        {
            for (int i = 0; i < 2; i++)
            {
                bool result = this.sut.Move();

                Assert.IsTrue(result);
            }
        }

        [Test]
        public void MoveIsNotPossible()
        {
            this.sut.Move();
            this.sut.Move();
            bool result = this.sut.Move();

            Assert.IsFalse(result);
        }

        [Test]
        public void MoveIsNotPossibleWithEmptyList()
        {
            this.sut = new ListIterator<string>(new string[0]);

            bool result = this.sut.Move();

            Assert.IsFalse(result);
        }

        [Test]
        public void PrintLastElement()
        {
            this.sut.Move();
            this.sut.Move();

            string result = this.sut.Print();

            Assert.AreEqual("Message", result);
        }

        [Test]
        public void PrintFirstElement()
        {
            string result = this.sut.Print();

            Assert.AreEqual("Some", result);
        }

        [Test]
        public void PrintWithEmptyListThrowsException()
        {
            this.sut = new ListIterator<string>(new string[0]);

            Assert.Throws<InvalidOperationException>(() => this.sut.Print());
        }

        [Test]
        public void ListHasNextElement()
        {
            Assert.IsTrue(this.sut.HasNext());
        }

        [Test]
        public void ListDoesNotHaveNextElement()
        {
            this.sut.Move();
            this.sut.Move();

            Assert.IsFalse(this.sut.HasNext());
        }

        [Test]
        public void EmptyListDoesNotHaveNextElement()
        {
            this.sut = new ListIterator<string>(new string[0]);

            Assert.False(this.sut.HasNext());
        }
    }
}