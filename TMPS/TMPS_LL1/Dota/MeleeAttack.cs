namespace Dota;

using System;

class MeleeAttack : Attack
{
    public override void Hit()
    {
        Console.WriteLine("Melee attack.");
    }
}
