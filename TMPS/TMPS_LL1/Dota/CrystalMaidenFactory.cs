namespace Dota;

class CrystalMaidenFactory : HeroFactory
{
    public override Attack CreateAttack()
    {
        return new RangedAttack();
    }
}
