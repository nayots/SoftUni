using System;
using System.Text;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        var input = reader.ReadLine();

        ISoldierController soldierController = new SoldierController();
        AmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        IOutputGiver outputGiver = new Output();
        Army army = new Army();
        IWareHouse wareHouse = new WareHouse();
        SoldierFactory soldiersFactory = new SoldierFactory();
        MissionFactory missionFactory = new MissionFactory();
        MissionController missionController = new MissionController(army, wareHouse);

        var gameController = new GameController(soldierController, soldiersFactory, ammunitionFactory, outputGiver, army, wareHouse, missionController, missionFactory);
        var result = new StringBuilder();

        while (!input.Equals("Enough! Pull back!"))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                result.AppendLine(arg.Message);
            }
            input = reader.ReadLine();
        }

        gameController.RequestResult(result);
        writer.WriteLine(result.ToString());
    }
}