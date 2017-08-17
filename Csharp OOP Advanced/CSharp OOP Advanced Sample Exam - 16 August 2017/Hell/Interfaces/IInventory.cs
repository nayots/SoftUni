public interface IInventory
{
    long TotalAgilityBonus { get; }
    long TotalDamageBonus { get; }
    long TotalHitPointsBonus { get; }
    long TotalIntelligenceBonus { get; }
    long TotalStrengthBonus { get; }

    void AddCommonItem(IItem item);

    void AddRecipeItem(IRecipe recipe);
}