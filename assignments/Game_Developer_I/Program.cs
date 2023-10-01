class Game
{
    static void Main(string[] args)
    {
        
        var bandit = new Enemy("Bandit");


        var punch = new Attack("Punch", 5);
        var throwAttack = new Attack("Throw", 15);
        var fireball = new Attack("Fireball", 20);

        bandit.AttackList.Add(punch);
        bandit.AttackList.Add(throwAttack);
        bandit.AttackList.Add(fireball);

        for (int i = 0; i < 5; i++)
        {
            bandit.RandomAttack();
        }
    }
}