using System.Collections.Generic;

public interface IRecipe : IItem
{
    List<string> RequiredItems { get; }
}