namespace CSC360Final.Model;

public abstract class Level
{
   public abstract void Handle(MageLevel mageLevel); 
}

public class MageLevel
{
    Level level;

    public MageLevel(Level level)
    {
        this.level = level;
    }

    public Level Level
    {
        get { return level; }
        set
        {
            level = value;
            Console.WriteLine("Level: " + level.GetType().Name);
        }
    }
    
    public void Promote()
    {
        Level.Handle(this);
    }
}

public class BeginnerLevel : Level
{
    public override void Handle(MageLevel mageLevel)
    {
        mageLevel.Level = new IntermediateLevel();
    }
}

public class IntermediateLevel : Level
{
    public override void Handle(MageLevel mageLevel)
    {
        mageLevel.Level = new AdvancedLevel();
    }
}

public class AdvancedLevel : Level
{
    public override void Handle(MageLevel mageLevel)
    {
        mageLevel.Level = new Archmage();
    }
}

public class Archmage : Level
{
    public override void Handle(MageLevel mageLevel)
    {
        mageLevel.Level = new GrandMage();
    }
}

public class GrandMage : Level
{
    public override void Handle(MageLevel mageLevel)
    {
        mageLevel.Level = new BeginnerLevel(); 
        // makes it loop through the different states again
    }
}