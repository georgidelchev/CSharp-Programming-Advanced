using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private const int EXP = 200;

    [Test]
    public void Hero_Should_Get_Exp_If_The_Target_Is_Dead()
    {
        // WITH FAKE CLASSES!

        // Arrange
        var weapon = new FakeWeapon();
        var target = new FakeTarget();
        var hero = new Hero("Stavri", weapon);

        // Act
        hero.Attack(target);

        // Assert
        Assert.That(hero.Experience, Is.EqualTo(FakeTarget.DEFAULT_EXP));
    }

    [Test]
    public void Second_Hero_Should_Get_Exp_If_The_Target_Is_Dead()
    {
        // WITH MOCKING!

        // Arrange
        var weapon = Mock.Of<IWeapon>();

        var target = new Mock<ITarget>();

        target
            .Setup(t => t.IsDead())
            .Returns(true);

        target
            .Setup(t => t.GiveExperience())
            .Returns(EXP);

        var hero = new Hero("Stavri", weapon);

        // Act
        hero.Attack(target.Object);

        // Assert
        Assert.That(hero.Experience, Is.EqualTo(EXP));
    }
}