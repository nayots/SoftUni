using System.Collections.Generic;

public abstract class Mission : IMission
{
    public Mission(double scoreToComplete)
    {
        ScoreToComplete = scoreToComplete;
    }

    public string Name { get; protected set; }

    public double EnduranceRequired { get; protected set; }

    public double ScoreToComplete { get; protected set; }

    public double WearLevelDecrement { get; protected set; }
    //public IList<IAmmunition> MissionWeapons { get; protected set; }
}