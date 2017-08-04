using Exercises_Models.Interface;
using Moq;
using NUnit.Framework;
using System;

namespace Exercises_Models.Tests
{
    [TestFixture]
    public class DateTimeTests
    {
        private Mock<IClock> time;

        [SetUp]
        public void TestInit()
        {
            time = new Mock<IClock>();
        }

        [Test]
        public void GetCurrentTime()
        {
            this.time.SetupGet(x => x.Now).Returns(DateTime.Now);

            Assert.AreEqual(DateTime.Now.ToShortTimeString(), time.Object.Now.ToShortTimeString());
        }

        [Test]
        public void AddADayInTheMiddleOfTHeMonth()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(2000, 10, 15));

            DateTime dummyCLock = this.time.Object.Now.AddDays(1);

            Assert.AreEqual(16, dummyCLock.Day);
        }

        [Test]
        public void AddDayThatJumpsToNextMonth()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(2017, 08, 31));

            DateTime dummyCLock = this.time.Object.Now.AddDays(1);

            Assert.IsTrue(dummyCLock.Month == 9 && dummyCLock.Day == 1);
        }

        [Test]
        public void AddNegativeDays()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(2017, 08, 31));

            DateTime dummyCLock = this.time.Object.Now.AddDays(-10);

            Assert.IsTrue(dummyCLock.Month == 8 && dummyCLock.Day == 21);
        }

        [Test]
        public void AddNegativeDaysThatJumpBackAMonth()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(2017, 08, 31));

            DateTime dummyCLock = this.time.Object.Now.AddDays(-31);

            Assert.IsTrue(dummyCLock.Month == 7 && dummyCLock.Day == 31);
        }

        [Test]
        public void AddDayToLeapYearMonth()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(2008, 02, 28));

            DateTime dummyCLock = this.time.Object.Now.AddDays(1);

            Assert.IsTrue(dummyCLock.Month == 2 && dummyCLock.Day == 29);
        }

        [Test]
        public void AddDayToNonLeapYearMonth()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(1900, 02, 28));

            DateTime dummyCLock = this.time.Object.Now.AddDays(1);

            Assert.IsTrue(dummyCLock.Month == 3 && dummyCLock.Day == 1);
        }

        [Test]
        public void AddDayToDateTimeMinValue()
        {
            this.time.SetupProperty(x => x.Now, DateTime.MinValue);

            Assert.DoesNotThrow(() => this.time.Object.Now.AddDays(1));
        }

        [Test]
        public void SubtractDayToDateTimeMinValue()
        {
            this.time.SetupProperty(x => x.Now, DateTime.MinValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => this.time.Object.Now.AddDays(-1));
        }

        [Test]
        public void AddDayToDateTimeMaxValue()
        {
            this.time.SetupProperty(x => x.Now, DateTime.MaxValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => this.time.Object.Now.AddDays(1));
        }

        [Test]
        public void SubtractDayToDateTimeMaxValue()
        {
            this.time.SetupProperty(x => x.Now, DateTime.MaxValue);

            Assert.DoesNotThrow(() => this.time.Object.Now.AddDays(-1));
        }
    }
}