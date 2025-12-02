namespace CSC360Final.Model;

public interface ISpell
{
    string GetSpell();
}

public class FireSpell : ISpell
{
    public string GetSpell()
    {
        Console.WriteLine("Fireball");
        return "Fireball";
    }
}

public class WaterSpell : ISpell
{
    public string GetSpell()
    {
        Console.WriteLine("Water Sprite");
        return "Water Sprite";
    }
}

public class EarthSpell : ISpell
{
    public string GetSpell()
    {
        Console.WriteLine("Summon Boulder");
        return "Summon Boulder";
    }
}

public class IceSpell : ISpell
{
    public string GetSpell()
    {
        Console.WriteLine("Ice Spike");
        return "Ice Spike";
    }
}

public enum SpellType
{
    Fire,
    Water,
    Earth,
    Ice
}

public class SpellFactory
{
    public ISpell GetSpell(SpellType spellType)
    {
        switch (spellType)
        {
            case SpellType.Fire:
                return new FireSpell();
            case SpellType.Water:
                return new WaterSpell();
            case SpellType.Earth:
                return new EarthSpell();
            case SpellType.Ice:
                return new IceSpell();
            default:
                throw new NotSupportedException();
        }
    }
}