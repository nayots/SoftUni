using System.Text;

public abstract class Item : IItem
{
    public Item(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus)
    {
        Name = name;
        StrengthBonus = strengthBonus;
        AgilityBonus = agilityBonus;
        IntelligenceBonus = intelligenceBonus;
        HitPointsBonus = hitPointsBonus;
        DamageBonus = damageBonus;
    }

    public string Name { get; private set; }
    public int StrengthBonus { get; private set; }
    public int AgilityBonus { get; private set; }
    public int IntelligenceBonus { get; private set; }
    public int HitPointsBonus { get; private set; }
    public int DamageBonus { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"###Item: {this.Name}");
        sb.AppendLine($"###+{this.StrengthBonus} Strength");
        sb.AppendLine($"###+{this.AgilityBonus} Agility");
        sb.AppendLine($"###+{this.IntelligenceBonus} Intelligence");
        sb.AppendLine($"###+{this.HitPointsBonus} HitPoints");
        sb.AppendLine($"###+{this.DamageBonus} Damage");

        return sb.ToString().Trim();
    }
}