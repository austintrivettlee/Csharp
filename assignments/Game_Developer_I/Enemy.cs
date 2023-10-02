public class Enemy
{
    public string Name { get; }
    private int Health = 100;
    public int MaxHealth { get; set; } = 100;
    public int _Health
    {
        get { return Health; }
        set { Health = value; }
    }

    public List<Attack> AttackList { get; }

    public Enemy(string name)
    {
        Name = name;
        AttackList = new List<Attack>();
    }

    public void RandomAttack()
    {
        var random = new Random();
        var randomAttack = random.Next(AttackList.Count);
        var selectedAttack = AttackList[randomAttack];
        Console.WriteLine($"{Name} performs a {selectedAttack.Name} attack for {selectedAttack.DamageAmount} damage!");
    }

    public virtual void PerformAttack(Enemy target, Attack chosenAttack)
    {
        if (this.Health > 0 && target.Health > 0)
        {
            target.Health -= chosenAttack.DamageAmount;
            if (target.Health < 0) target.Health = 0;
            Console.WriteLine($"{Name} attacks {target.Name} with {chosenAttack.Name}, dealing {chosenAttack.DamageAmount} damage and reducing {target.Name}'s health to {target.Health}!!");
        }
        else
        {
            Console.WriteLine($"The {target.Name} has no health left!");
        }
    }
}
public class Melee : Enemy
{
    public Melee(string name) : base(name)
    {
        _Health = 120;
        MaxHealth = _Health;
        AttackList.Add(new Attack("Punch", 20));
        AttackList.Add(new Attack("Kick", 15));
        AttackList.Add(new Attack("Throw", 25));
    }

    public void Rage(Enemy target)
    {
        if (_Health > 0)
        {
            var random = new Random();
            var randomIndex = random.Next(AttackList.Count);
            var selectedAttack = AttackList[randomIndex];
            var enhancedDamage = selectedAttack.DamageAmount + 10;
            Console.WriteLine($"{Name} enters rage, performing {selectedAttack.Name} for {enhancedDamage} damage!");
        }
        else
        {
            Console.WriteLine($"{Name} has no health left to perform a rage attack!");
        }
    }
}
public class Ranged : Enemy
{
    public int Distance { get; private set; } = 5;

    public Ranged(string name) : base(name)
    {
        AttackList.Add(new Attack("Shoot an Arrow", 20));
        AttackList.Add(new Attack("Throw a Knife", 15));
        MaxHealth = _Health;
    }

    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"{Name} dashes, setting distance to {Distance}.");
    }

    public override void PerformAttack(Enemy target, Attack chosenAttack)
    {
        if (Distance >= 10)
        {
            base.PerformAttack(target, chosenAttack);
        }
        else
        {
            Console.WriteLine($"{Name} is too close to perform a ranged attack!");
        }
    }
}

public class Magic : Enemy
{
    public Magic(string name) : base(name)
    {
        _Health = MaxHealth = 80;
        AttackList.Add(new Attack("Fireball", 25));
        AttackList.Add(new Attack("Lightning Bolt", 20));
        AttackList.Add(new Attack("Staff Strike", 10));
    }

    public void Heal(Enemy target)
    {
        if (_Health > 0)
        {
            var healingAmount = 40;
            if ((target._Health + healingAmount) > MaxHealth && target._Health != MaxHealth)
            {
                target._Health = MaxHealth;
                Console.WriteLine($"{target.Name} is healed to {MaxHealth}.");
            }
            else if ((target._Health + healingAmount) > MaxHealth && target._Health == MaxHealth) {

                Console.WriteLine($"Cannot heal {target.Name} past {MaxHealth}.");
            }
            Console.WriteLine($"{Name} heals {target.Name} for {healingAmount} health, {target.Name}'s health is now {target._Health}.");
        }
        else
        {
            Console.WriteLine($"{Name} has no health left to perform a healing!");
        }
    }
}