using System;

public abstract class WarriorDecorator : Warrior
{
    protected Warrior warrior;

    public WarriorDecorator(Warrior warrior) : base(warrior.Name, warrior.Attack, warrior.Defense, warrior.Health)
    {
        this.warrior = warrior;
    }

    public override void ToAttack(Warrior target)
    {
        warrior.ToAttack(target);
    }

    public override void TakeDamage(int damage)
    {
        warrior.TakeDamage(damage);
    }
}
