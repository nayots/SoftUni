using Exercises_Models.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Exercises_Models.Tests
{
    [TestFixture]
    public class BubbleTests
    {
        [Test]
        public void CreateBubbleList()
        {
            Bubble<int> bubble = new Bubble<int>(7, 8, 1, 6);
            IList<int> numbers = new List<int>() { 1, 6, 7, 8 };

            Assert.IsTrue(numbers.SequenceEqual(bubble));
        }

        [Test]
        public void SortOneItemList()
        {
            Bubble<int> bubble = new Bubble<int>(10);
            IList<int> numbers = new List<int>() { 10 };

            Assert.IsTrue(numbers.SequenceEqual(bubble));
        }
    }
}