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
        
        Console.WriteLine("Starting Proxy: User = Student...");
        
        SpellProxy studentSpellProxy = new SpellProxy("student");
        studentSpellProxy.listSpells();
        Console.WriteLine(studentSpellProxy.addSpell("Summon Boulder"));
        Console.WriteLine(studentSpellProxy.removeSpell("Ice Spike"));
        
        
        Console.WriteLine("Starting Proxy: User = Wizard...");
        
        SpellProxy wizardSpellProxy = new SpellProxy("wizard");
        wizardSpellProxy.listSpells();
        Console.WriteLine(wizardSpellProxy.addSpell("Meteor"));
        Console.WriteLine(wizardSpellProxy.removeSpell("Water Sprite"));
        
        
    }
}