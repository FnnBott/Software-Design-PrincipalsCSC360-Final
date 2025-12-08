namespace CSC360Final.Model;

public interface ISpellComposite
{
    public void listSpells();
    public string addSpell(string spellName);
    public string removeSpell(string spellName);
    public string getSpell(string spellName);
}

public class ProxySpellBook : ISpellComposite
{
    private List<string> spells;

    public ProxySpellBook()
    {
        spells = new List<string>();
        
        spells.Add("Fireball");
        spells.Add("Ice Spike");
        spells.Add("Water Sprite");
    }

    public void listSpells()
    {
        Console.WriteLine("~~~ Spell Book Contents ~~~");
        if (spells.Count == 0)
        {
            Console.WriteLine("No spells in the book.");
        }
        else
        {
            foreach (var spell in spells)
            {
                Console.WriteLine($"- {spell}");
            }
        }
        Console.WriteLine($"Total spells: {spells.Count}");
    }

    public string addSpell(string spellName)
    {
        if (spells.Contains(spellName))
        {
            return $"Spell '{spellName}' already exists.";
        }
        
        spells.Add(spellName);
        return $"Spell '{spellName}' added successfully.";
    }

    public string removeSpell(string spellName)
    {
        if (spells.Remove(spellName))
        {
            return $"Spell '{spellName}' removed successfully.";
        }
        return $"Spell '{spellName}' not found.";
    }

    public string getSpell(string spellName)
    {
        if (spells.Contains(spellName))
        {
            return $"Found spell: {spellName}";
        }
        return $"Spell '{spellName}' not found.";
    }
}

public class SpellProxy : ISpellComposite
{
    private ProxySpellBook? _realSpellBook;
    private bool _hasAccess;
    private string _userRole;

    public SpellProxy(string userRole = "student")
    {
        _userRole = userRole;
        _hasAccess = CheckAccess(userRole);
    }

    private bool CheckAccess(string role)
    {
        // Only wizards and teachers have full access
        return role.ToLower() == "wizard" || role.ToLower() == "teacher";
    }

    private void LazyInitialize()
    {
        if (_realSpellBook == null)
        {
            Console.WriteLine("[Proxy] Initializing spell book for the first time...");
            _realSpellBook = new ProxySpellBook();
        }
    }

    private void LogAccess(string operation)
    {
        Console.WriteLine($"[Proxy] User ({_userRole}) attempting: {operation}");
    }

    public void listSpells()
    {
        LogAccess("listSpells");
        LazyInitialize();
        _realSpellBook!.listSpells();
    }

    public string addSpell(string spellName)
    {
        LogAccess($"addSpell({spellName})");
        
        if (!_hasAccess)
        {
            return $"Access Denied: {_userRole} cannot add spells.";
        }

        LazyInitialize();
        return _realSpellBook!.addSpell(spellName);
    }

    public string removeSpell(string spellName)
    {
        LogAccess($"removeSpell({spellName})");
        
        if (!_hasAccess)
        {
            return $"Access Denied: {_userRole} cannot remove spells.";
        }

        LazyInitialize();
        return _realSpellBook!.removeSpell(spellName);
    }

    public string getSpell(string spellName)
    {
        LogAccess($"getSpell({spellName})");
        LazyInitialize();
        return _realSpellBook!.getSpell(spellName);
    }
}