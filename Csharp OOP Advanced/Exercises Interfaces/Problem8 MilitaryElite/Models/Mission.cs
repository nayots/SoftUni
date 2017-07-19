using Problem8_MilitaryElite.Enums;

namespace Problem8_MilitaryElite
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionState state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; protected set; }
        public MissionState State { get; protected set; }

        public void CompleteMission()
        {
            this.State = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }
    }
}