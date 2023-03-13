namespace Dota;
class Hero
{
    private Attack attack;
    public Hero(HeroFactory factory)
    {
        attack = factory.CreateAttack();
    }

    public void Hit()
    {
        attack.Hit();
    }
}
