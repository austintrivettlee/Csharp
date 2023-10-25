public class Enemy
{
    public string Name { get; }
    private int Health = 100;
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
}
