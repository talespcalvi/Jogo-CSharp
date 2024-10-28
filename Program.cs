using System;
using System.Collections.Generic;
using System.Threading;
// Classe cliente para rodar o jogo.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Escolha seu guerreiro:");
        Console.WriteLine("1. Epaminondas: (Ataque: 17, Defesa: 5, Vida: 100)");
        Console.WriteLine("2. Skib: (Ataque: 13, Defesa: 8, Vida: 120)");

        Warrior playerWarrior = null;
        int warriorChoice = int.Parse(Console.ReadLine());

        if (warriorChoice == 1)
        {
            playerWarrior = new Warrior("Epaminondas", 17, 5, 100);
        } 
        else if (warriorChoice == 2)
        {
            playerWarrior = new Warrior("Skib", 13, 8, 120);
        }
        else
        {
            Console.WriteLine("ERRO: ESCOLHA INVÁLIDA.");
            return;
        }

        int points = 10; // Pontos para comprar equipamentos.
        Console.WriteLine($"\nVocê tem {points} pontos para gastar em equipamentos");

        while(points > 0)
        {
            Console.WriteLine("\nEscolha um equipamento para comprar:");
            Console.WriteLine("1. Espada (3 pontos)");
            Console.WriteLine("2. Espada Flamejante (5 pontos)");
            Console.WriteLine("3. Armadura (3 pontos)");
            Console.WriteLine("4. Armadura Encantada (5 pontos)");
            Console.WriteLine("5. Anel (4 pontos)");
            Console.WriteLine("6. Anel Sagrado (6 pontos)");
            Console.WriteLine("7. Iniciar Batalha");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1 && points >= 3)
            {
                playerWarrior = new SwordDecorator(playerWarrior);
                points -= 3;
                Console.WriteLine("Espada comprada.");
            }
            else if (choice == 2 && points >= 5)
            {
                playerWarrior = new FlammingSwordDecorator(playerWarrior);
                points -= 5;
                Console.WriteLine("Espada flamejante comprada.");
            }
            else if (choice == 3 && points >= 3)
            {
                playerWarrior = new ArmorDecorator(playerWarrior);
                points -= 3;
                Console.WriteLine("Armadura comprada.");
            }
            else if (choice == 4 && points >= 5)
            {
                playerWarrior = new EnchantedArmorDecorator(playerWarrior);
                points -= 5;
                Console.WriteLine("Armadura Encantada comprada.");
            }
            else if (choice == 5 && points >= 4)
            {
                playerWarrior = new RingDecorator(playerWarrior);
                points -= 4;
                Console.WriteLine("Anel comprado.");
            }
            else if (choice == 6 && points >= 6)
            {
                playerWarrior = new SacredRingDecorator(playerWarrior);
                points -= 6;
                Console.WriteLine("Anel Sagrado comprado.");
            }
            else if (choice == 7)
            {
                break;
            }
            else
            {
                Console.WriteLine("Pontos insuficientes ou escolha inválida.");
            }
            Console.WriteLine($"Pontos restantes: {points}");
        }

        Console.WriteLine("\nPreparando o adversário...");
        Warrior enemyWarrior = new Warrior("Inimigo", 18, 8, 110);
        enemyWarrior = new SwordDecorator(enemyWarrior);
        enemyWarrior = new ArmorDecorator(enemyWarrior);
        enemyWarrior = new RingDecorator(enemyWarrior);

        List<Warrior> warriors = new List<Warrior> { playerWarrior, enemyWarrior };
        int round = 0;

        int delay = 1000; // Intervao de 1 segundo entre as rodadas.

        while (playerWarrior.BeAlive() && enemyWarrior.BeAlive())
        {
            Warrior attacker = warriors[round % 2];
            Warrior defender = warriors[(round + 1) % 2];

            attacker.ToAttack(defender);

            Thread.Sleep(delay);

            if (!defender.BeAlive())
            {
                Console.WriteLine($"{defender.Name} foi derrotado!");
                break;
            }

            if(attacker is RingDecorator AttackerRing && defender.DamageTook > 0)
            {
                AttackerRing.CollectPowerEsphere();
                Thread.Sleep(delay);
            }

            round++;
            Console.WriteLine();
        }

        Console.WriteLine(playerWarrior.BeAlive() ? $"{playerWarrior.Name} venceu!" : $"{enemyWarrior.Name} venceu!");
    }
}
