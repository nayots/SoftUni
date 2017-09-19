public class Easy : Mission
{
    private const double RequiredEndurance = 20;
    private const string MissionName = "Suppression of civil rebellion";

    public Easy(double scoreToComplete) : base(scoreToComplete)
    {
        this.EnduranceRequired = RequiredEndurance;
        this.Name = MissionName;
    }
}