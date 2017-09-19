using System;
using System.Collections.Generic;
using System.Text;

public class GameController
{
    private Army army;
    private IWareHouse wareHouse;
    private MissionController missionControllerField;
    private ISoldierController soldierController;
    private SoldierFactory soldiersFactory;
    private AmmunitionFactory ammunitionFactory;
    private IOutputGiver outputGiver;
    private MissionFactory missionFactory;

    public GameController(ISoldierController soldierController, SoldierFactory soldiersFactory, AmmunitionFactory ammunitionFactory, IOutputGiver outputGiver, Army army, IWareHouse wareHouse, MissionController missionControllerField, MissionFactory missionFactory)
    {
        this.soldierController = soldierController;
        this.soldiersFactory = soldiersFactory;
        this.ammunitionFactory = ammunitionFactory;
        this.missionFactory = missionFactory;
        this.outputGiver = outputGiver;
        Army = army;
        WareHouse = wareHouse;
        MissionControllerField = missionControllerField;
    }

    public Army Army
    {
        get { return army; }
        set { army = value; }
    }

    public IWareHouse WareHouse
    {
        get { return wareHouse; }
        set { wareHouse = value; }
    }

    public MissionController MissionControllerField
    {
        get { return missionControllerField; }
        set { missionControllerField = value; }
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            string type = string.Empty;
            string name = string.Empty;
            int age = 0;
            int experience = 0;
            double speed = 0d;
            double endurance = 0d;
            double motivation = 0;
            double maxWeight = 0d;

            if (data.Length == 3)
            {
                type = data[1];
                name = data[2];
            }
            else
            {
                type = data[1];
                name = data[2];
                age = int.Parse(data[3]);
                experience = int.Parse(data[4]);
                speed = double.Parse(data[5]);
                endurance = double.Parse(data[6]);
                motivation = double.Parse(data[7]);
                maxWeight = double.Parse(data[8]);
            }

            ISoldier soldier = this.soldiersFactory.CreateSoldier(type, name, age, experience, endurance);
            this.AddSoldierToArmy(soldier, type);
        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            IAmmunition ammunition = this.ammunitionFactory.CreateAmmunition(name);
            this.AddAmmunitions(ammunition, number);
        }
        else if (data[0].Equals("Mission"))
        {
            string name = data[1];
            double scoreToComplete = double.Parse(data[2]);

            IMission mission = this.missionFactory.CreateMission(name, scoreToComplete);

            this.MissionControllerField.PerformMission(mission);
        }
    }

    public void RequestResult(StringBuilder result)
    {
        //this.outputGiver.GiveOutput(result, army.Members, wareHouse.Weapons, this.MissionControllerField.SuccessMissionCounter);
    }

    private void AddAmmunitions(IAmmunition ammunition, int number)
    {
        if (!this.WareHouse.Weapons.ContainsKey(ammunition))
        {
            this.WareHouse.Weapons[ammunition] = number;
        }
        else
        {
            this.WareHouse.Weapons[ammunition] += number;
        }
    }

    private void AddSoldierToArmy(ISoldier soldier, string type)
    {
        if (!this.Army.Members.ContainsKey(type))
        {
            this.Army.Members[type] = new List<ISoldier>();
        }
        this.Army.Members[type].Add(soldier);
    }
}