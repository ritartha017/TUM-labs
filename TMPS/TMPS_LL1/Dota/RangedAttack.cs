namespace Dota;

using System;

class RangedAttack : Attack
{
    public override void Hit()
    {
        Console.WriteLine("Ranged attack.");
    }
}
