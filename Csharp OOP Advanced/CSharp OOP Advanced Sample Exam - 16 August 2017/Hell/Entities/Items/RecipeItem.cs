using System.Collections.Generic;

public class RecipeItem : Item, IRecipe
{
    public RecipeItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus, params string[] items) : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.RequiredItems = new List<string>();
        foreach (var item in items)
        {
            this.RequiredItems.Add(item);
        }
    }

    public List<string> RequiredItems { get; private set; }
}