public class Enemy
{
    public string Name { get; }
    private int Health = 100;
    public int _Health
    {
        get {return Health;}
        set {Health = value;}
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

    public void PerformAttack(Enemy target, Attack chosenAttack)
    {
        if (this.Health > 0 && target.Health > 0)
        {
            target.Health -= chosenAttack.DamageAmount;
            if (target.Health < 0) target.Health = 0;
            Console.WriteLine($"{Name} attacks {target.Name}, dealing {chosenAttack.DamageAmount} damage and reducing {target.Name}'s health to {target.Health}!!");
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
        _Health = 100;
        AttackList.Add(new Attack("Punch", 20));
        AttackList.Add(new Attack("Kick", 15));
        AttackList.Add(new Attack("Throw", 25));
    }

    public void Rage()
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