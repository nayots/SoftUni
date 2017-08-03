using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
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
        public void AxeLosesDurabilityAfterAttack()
        {
            this.axe.Attack(dummy);

            Assert.AreEqual(9, this.axe.DurabilityPoints, "Axe Durability doesn't change after attack");
        }

        [Test]
        public void AttackWithBrokenWeapon()
        {
            this.axe = new Axe(10, 0);

            var ex = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy));
            Assert.AreEqual("Axe is broken.", ex.Message);
        }
    }
}