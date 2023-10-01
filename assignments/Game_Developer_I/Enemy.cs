public class Enemy
{
    public string Name { get; }
    public int Health { get; private set; }
    public List<Attack> AttackList { get; }

    public Enemy(string name)
    {
        Name = name;
        Health = 100;
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