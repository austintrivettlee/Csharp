class Game
{
    static void Main(string[] args)
    {
        Melee Barbarian = new Melee("Barbarian");
        Ranged Ranger = new Ranged("Ranger");
        Magic Wizard = new Magic("Wizard");

        Attack? kick = Barbarian.AttackList.Find(attack => attack.Name == "Kick");
        Barbarian.PerformAttack(Ranger, kick);

        Barbarian.Rage(Wizard);

        Attack? shootArrow = Ranger.AttackList.Find(attack => attack.Name == "Shoot an Arrow");
        Ranger.PerformAttack(Barbarian, shootArrow);

        Ranger.Dash();

        Ranger.PerformAttack(Barbarian, shootArrow);

        Attack? fireball = Wizard.AttackList.Find(attack => attack.Name == "Fireball");
        Wizard.PerformAttack(Barbarian, fireball);

        Wizard.Heal(Ranger);

        Wizard.Heal(Wizard);
    }
}