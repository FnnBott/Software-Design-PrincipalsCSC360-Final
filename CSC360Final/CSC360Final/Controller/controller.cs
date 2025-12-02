using CSC360Final.Model;

namespace CSC360Final.Controller;

public class controller
{
    public void startProgram()
    {
        Console.WriteLine("Starting Factory...");

        new SpellFactory().GetSpell(SpellType.Fire);
        new SpellFactory().GetSpell(SpellType.Water);
        new SpellFactory().GetSpell(SpellType.Earth);
        new SpellFactory().GetSpell(SpellType.Ice);
        
        Console.WriteLine("Starting State...");
        MageLevel mageLevel = new MageLevel(new BeginnerLevel());
        
        mageLevel.Promote();
        mageLevel.Promote();
        mageLevel.Promote();
        mageLevel.Promote();
        mageLevel.Promote();
    }
}