using Exercises_Models.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace Exercises_Models.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const string DBFullMsg = "Database is full!";
        private const string DBEmptyMsg = "Database is empty!";

        [Test]
        public void DatabaseRegistersElements()
        {
            Database<int> sut = new Database<int>(1, 2, 3, 4, 5);

            Assert.AreEqual(5, sut.Count, "Registered items count does not match!");
        }

        [Test]
        public void EmptyDatabaseHasZeroCount()
        {
            Database<int> sut = new Database<int>();

            Assert.AreEqual(0, sut.Count, "Database count is not zero when it should be!");
        }

        [Test]
        public void FullDatabaseThrowsExceptionWhenAddingMoreItems()
        {
            Database<int> sut = new Database<int>(Enumerable.Range(0, 16).ToArray());

            Exception ex = Assert.Throws<InvalidOperationException>(() => sut.Add(100));

            Assert.AreEqual(DBFullMsg, ex.Message);
        }

        [Test]
        public void InitializingDBOverCapacityThrowsException()
        {
            try
            {
                Database<int> sut = new Database<int>(Enumerable.Range(0, 17).ToArray());
            }
            catch (Exception ex)
            {
                Assert.AreEqual(DBFullMsg, ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void RemoveLastItemFromDatabase()
        {
            Database<int> sut = new Database<int>(1, 2, 3);

            Assert.That(() => sut.Remove() == 3, "Removing last item from Database fails.");
        }

        [Test]
        public void RemovingItemChangesCount()
        {
            Database<int> sut = new Database<int>(1);

            sut.Remove();

            Assert.AreEqual(0, sut.Count);
        }

        [Test]
        public void RemovingItemFromEmptyDatabaseThrowsException()
        {
            Database<int> sut = new Database<int>();

            Exception ex = Assert.Throws<InvalidOperationException>(() => sut.Remove());

            Assert.AreEqual(DBEmptyMsg, ex.Message);
        }

        [Test]
        public void FetchingDatabaseReturnsCorrectCollection()
        {
            Database<int> sut = new Database<int>(Enumerable.Range(0, 16).ToArray());
            int[] numbers = Enumerable.Range(0, 16).ToArray();

            int[] returnedCollection = sut.Fetch();

            Assert.IsTrue(numbers.SequenceEqual(returnedCollection));
        }

        [Test]
        public void FetchEmptyDatabaseReturnsEmptyCollection()
        {
            Database<int> sut = new Database<int>();
            int[] numbers = new int[0];

            int[] returnedCollection = sut.Fetch();

            Assert.IsTrue(numbers.SequenceEqual(returnedCollection));
        }
    }
}