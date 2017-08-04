using Exercises_Models.Models;
using NUnit.Framework;
using System;

namespace Exercises_Models.Tests
{
    [TestFixture]
    public class PeopleDBTests
    {
        private const string PersonExistsExc = "Person already exists!";
        private const string PersonDoesNotExistExc = "Person does not exists in the database!";

        private const string UsernameEmptyExc = "Username cannot be empty!";
        private const string IdNegativeExc = "Id cannot be a negative number!";

        private PeopleDB sut;

        [SetUp]
        public void TestInit()
        {
            this.sut = new PeopleDB(new Person(123456789, "Gosho"), new Person(987654321, "Pesho"));
        }

        [Test]
        public void AddingUser()
        {
            this.sut.Add(new Person(1, "Dummy"));

            Assert.AreEqual(3, this.sut.Count);
        }

        [Test]
        public void AddUserWithDuplicatingUsername()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => this.sut.Add(new Person(10, "Gosho")));

            Assert.AreEqual(PersonExistsExc, ex.Message);
        }

        [Test]
        public void AddUserWithDuplicatingId()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => this.sut.Add(new Person(123456789, "Ivan")));

            Assert.AreEqual(PersonExistsExc, ex.Message);
        }

        [Test]
        public void RemoveUser()
        {
            this.sut.Remove();

            Assert.AreEqual(1, sut.Count);
        }

        [Test]
        public void FindPersonByUsername()
        {
            Person person = sut.FindByUsername("Gosho");

            Assert.IsNotNull(person);
        }

        [Test]
        public void FindPersonWithNonExistingUsernameThrowsException()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => this.sut.FindByUsername("Ivancho"));

            Assert.AreEqual(PersonDoesNotExistExc, ex.Message);
        }

        [Test]
        public void FindPersonWithNullValueForUsername()
        {
            Exception ex = Assert.Throws<ArgumentNullException>(() => this.sut.FindByUsername(string.Empty));

            Assert.AreEqual(UsernameEmptyExc, ex.Message);
        }

        [Test]
        public void FindExistingPersonById()
        {
            Person person = this.sut.FindById(123456789);

            Assert.IsNotNull(person);
        }

        [Test]
        public void FindNonExsitingPersonById()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => this.sut.FindById(999));

            Assert.AreEqual(PersonDoesNotExistExc, ex.Message);
        }

        [Test]
        public void FindPersonWithNegativeId()
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => this.sut.FindById(-1));

            Assert.AreEqual(IdNegativeExc, ex.Message);
        }
    }
}