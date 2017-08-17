using System.Collections.Generic;

public class ItemCommand : Command
{
    public ItemCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        string heroName = this.Args[1];

        List<string> itemArgs = new List<string>(this.Args);

        IHero hero = (this.Manager as HeroManager).heroes[heroName];

        return this.Manager.AddItemToHero(itemArgs, hero);
    }
}