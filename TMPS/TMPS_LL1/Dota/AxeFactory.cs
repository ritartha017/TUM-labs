namespace Dota;

class AxeFactory : HeroFactory
{
    public override Attack CreateAttack()
    {
        return new MeleeAttack();
    }
}
