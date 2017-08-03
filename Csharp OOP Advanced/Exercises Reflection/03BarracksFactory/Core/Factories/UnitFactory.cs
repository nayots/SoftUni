namespace _03BarracksFactory.Core.Factories
{
    using Contracts;
    using System;
    using System.Reflection;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type classType = Type.GetType(" _03BarracksFactory.Models.Units." + unitType);

            ConstructorInfo ctorInfo = classType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, Type.EmptyTypes, null);

            IUnit unit = (IUnit)ctorInfo.Invoke(new object[] { });

            return unit;
        }
    }
}