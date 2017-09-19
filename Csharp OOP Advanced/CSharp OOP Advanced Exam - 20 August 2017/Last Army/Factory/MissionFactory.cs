using System;

public class MissionFactory
{
    public IMission CreateMission(string type, double scoreToComplete)
    {
        Type classType = Type.GetType(type);

        IMission mission = (IMission)Activator.CreateInstance(classType, new object[] { scoreToComplete });

        return mission;
    }
}