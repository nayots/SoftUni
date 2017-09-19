using System.Collections.Generic;
using System.Text;

public interface IOutputGiver
{
    void GiveOutput(StringBuilder result, Dictionary<string, List<ISoldier>> army, Dictionary<string, List<Ammunition>> wearHouse, int missionQueueCount);
}