public class Hard : Mission
{
    private const double RequiredEndurance = 80;
    private const string MissionName = "Disposal of terrorists";

    public Hard(double scoreToComplete) : base(scoreToComplete)
    {
        this.EnduranceRequired = RequiredEndurance;
        this.Name = MissionName;
    }
}