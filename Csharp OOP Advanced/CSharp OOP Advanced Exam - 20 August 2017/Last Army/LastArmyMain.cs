using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class LastArmyMain
{
    private static void Main()
    {
        SoldierFactory fac = new SoldierFactory();
        AmmunitionFactory afac = new AmmunitionFactory();
        MissionFactory mfac = new MissionFactory();

        var sold = fac.CreateSoldier("Ranker", "Ivan", 10, 10, 10);

        var ammo = afac.CreateAmmunition("Gun");

        var m = mfac.CreateMission("Easy", 100);

        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IEngine engine = new Engine(reader, writer);
        engine.Run();

        //TryToGetSomePointsFromJudge();
    }

    private static void TryToGetSomePointsFromJudge()
    {
        IWareHouse wh = new WareHouse();
        IDictionary<string, List<ISoldier>> soldiers = new Dictionary<string, List<ISoldier>>();
    }
}