using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero, IComparable<AbstractHero>
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero()
    {
        this.inventory = new HeroInventory();
    }

    public string Name { get; protected set; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            FieldInfo[] inventoryFieldsInfo = this.inventory.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo fi in inventoryFieldsInfo)
            {
                ItemAttribute itemAttribute = (ItemAttribute)fi.GetCustomAttributes(typeof(ItemAttribute), true).FirstOrDefault();

                if (itemAttribute != null)
                {
                    Dictionary<string, IItem> itemsRaw = (Dictionary<string, IItem>)fi.GetValue(this.inventory);

                    return itemsRaw.Select(x => x.Value).ToList();
                }
            }

            throw new InvalidOperationException("Hero has no items");
        }
    }

    public void AddRecipe(RecipeItem recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public void AddCommonItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        int primary = other.PrimaryStats.CompareTo(this.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }
        return other.SecondaryStats.CompareTo(this.SecondaryStats);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}");
        sb.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        sb.AppendLine($"Strength: {this.Strength}");
        sb.AppendLine($"Agility: {this.Agility}");
        sb.AppendLine($"Intelligence: {this.Intelligence}");
        if (this.Items.Count == 0)
        {
            sb.AppendLine($"Items: None");
        }
        else
        {
            sb.AppendLine($"Items:");
        }
        foreach (var cItem in this.Items)
        {
            sb.AppendLine(cItem.ToString());
        }

        return sb.ToString().Trim();
    }
}