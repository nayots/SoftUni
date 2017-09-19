public class Medium : Mission
{
    private const double RequiredEndurance = 50;
    private const string MissionName = "Capturing dangerous criminals";

    public Medium(double scoreToComplete) : base(scoreToComplete)
    {
        this.EnduranceRequired = RequiredEndurance;
        this.Name = MissionName;
    }
}