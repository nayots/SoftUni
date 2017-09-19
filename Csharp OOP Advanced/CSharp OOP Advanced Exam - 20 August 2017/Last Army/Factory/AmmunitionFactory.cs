using System;

public class AmmunitionFactory
{
    public AmmunitionFactory()
    {
    }

    public IAmmunition CreateAmmunition(string name)
    {
        Type classType = Type.GetType(name);

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(classType, new object[] { name });

        return ammunition;
    }
}