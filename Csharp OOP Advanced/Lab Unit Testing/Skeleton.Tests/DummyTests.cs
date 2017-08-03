using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int AxeAttack = 10;
        private const int AxeDurability = 10;
        private const int DummyHp = 10;
        private const int DummyExp = 100;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Testinit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHp, DummyExp);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            this.axe.Attack(dummy);

            Assert.AreEqual(0, this.dummy.Health, "Dummy is not loosing health when attacked!");
        }

        [Test]
        public void DeadDummyThrowsException()
        {
            this.dummy = new Dummy(0, 100);

            var ex = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy));

            Assert.AreEqual("Dummy is dead.", ex.Message);
        }

        [Test]
        public void DeadDummyCanGiveExp()
        {
            this.dummy = new Dummy(0, 100);

            int exp = dummy.GiveExperience();

            Assert.AreEqual(100, exp, "Dead dummy does not give exp!");
        }

        [Test]
        public void AliveDummyCantGiveExp()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
            Assert.AreEqual("Target is not dead.", ex.Message);
        }
    }
}