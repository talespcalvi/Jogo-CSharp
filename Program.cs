using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Warrior warrior1 = new Warrior("Epaminondas", 20, 5, 100);
        Warrior warrior2 = new Warrior("Skib", 15, 10, 120);

        warrior1 = new SwordDecorator(warrior1);
        warrior1 = new ArmorDecorator(warrior1);
        warrior1 = new RingDecorator(warrior1);

        warrior2 = new SwordDecorator(warrior2);
        warrior2 = new RingDecorator(warrior2);

        List<Warrior> warriors = new List<Warrior> { warrior1, warrior2 };
        int round = 0;

        while (warrior1.BeAlive() && warrior2.BeAlive())
        {
            Warrior attacker = warriors[round % 2];
            Warrior defender = warriors[(round + 1) % 2];

            attacker.ToAttack(defender);

            if (!defender.BeAlive())
            {
                Console.WriteLine($"{defender.Name} foi derrotado!");
                break; 
            }

            if (attacker is RingDecorator AttackerRing && defender.DamageTook > 0)
            {
                AttackerRing.CollectPowerEsphere();
            }

            round++;
            Console.WriteLine();
        }

        Console.WriteLine(warrior1.BeAlive() ? $"{warrior1.Name} venceu!" : $"{warrior2.Name} venceu!");
    }
}
