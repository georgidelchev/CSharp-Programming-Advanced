public class FakeTarget : ITarget
{
    public const int DEFAULT_EXP = 100;

    public int Health { get; }

    public bool IsDead() => true;

    public int GiveExperience() => DEFAULT_EXP;

    public void TakeAttack(int attackPoints)
    {
    }
}