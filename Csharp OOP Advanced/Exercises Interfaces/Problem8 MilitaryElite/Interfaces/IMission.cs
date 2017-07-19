using Problem8_MilitaryElite.Enums;

namespace Problem8_MilitaryElite
{
    public interface IMission
    {
        string CodeName { get; }
        MissionState State { get; }

        void CompleteMission();
    }
}