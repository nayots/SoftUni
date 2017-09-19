using System.Collections.Generic;

public interface ISoldierController
{
    bool CanEverySoldierCarryOnTheNeededWeapons(Dictionary<string, List<Soldier>> army, List<Ammunition> missionWeapons, string soldierGroup);

    bool CheckSoldiersMotivationAndEndurance(Mission mission, Dictionary<string, List<Soldier>> army, string s);

    bool DoWeHaveAllNeededWeaponsForTheMission(Dictionary<string, List<Ammunition>> wearHouse, Dictionary<string, List<Soldier>> army, string soldireType, Mission mission);

    bool IsTheTeamOnVacation(Dictionary<string, List<Soldier>> army, string soldierGroup);

    void SoldierChangesAfterFailedMission(Dictionary<string, List<Soldier>> army, Mission mission, string rankerType);

    void SoldierChangesAfterSuccessfulMission(Dictionary<string, List<Soldier>> army, Mission mission, string rankerType);

    void TeamComesBackFromVacation(Dictionary<string, List<Soldier>> army, string rankerType);

    void TeamGetBonus(Dictionary<string, List<Soldier>> army, string rankerType);

    void TeamGoesOnVacation(Dictionary<string, List<Soldier>> army, string rankerType);

    void TeamRegenerate(Dictionary<string, List<Soldier>> army, string rankerType);
}