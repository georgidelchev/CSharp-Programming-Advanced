using System;
using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int ALIVE_DUMMY_HEALTH = 100;
    private const int DEAD_DUMMY_HEALTH = 0;
    private const int DUMMY_EXP = 200;

    private const int DUMMY_HEALTH_AFTER_LOST = 99;
    private const int DUMMY_ATTACK_POINTS = 1;

    private const string DUMMY_ATTACK_MESSAGE = "Dummy got no damage.";
    private const string DUMMY_ATTACK_TAKEN_MESSAGE = "Dead dummy can not take attacks";
    private const string DEAD_DUMMY_EXP_MESSAGE = "Only dead dummies can give exp.";
    private const string ALIVE_DUMMY_EXP_MESSAGE = "Alive dummies can not give exp.";

    private Dummy aliveDummy;
    private Dummy deadDummy;

    [SetUp]
    public void SetDummies()
    {
        this.aliveDummy = new Dummy(ALIVE_DUMMY_HEALTH, DUMMY_EXP);
        this.deadDummy = new Dummy(DEAD_DUMMY_HEALTH, DUMMY_EXP);
    }

    [Test]
    public void Dummy_Loses_Health_If_He_Is_Attacked()
    {
        // Act
        this.aliveDummy.TakeAttack(DUMMY_ATTACK_POINTS);

        // Assert
        Assert.That(this.aliveDummy.Health, Is.EqualTo(DUMMY_HEALTH_AFTER_LOST),
            DUMMY_ATTACK_MESSAGE);
    }

    [Test]
    public void Dead_Dummy_Throws_Exception_If_He_Is_Attacked()
    {
        //Assert
        Assert.Throws<InvalidOperationException>
        (() => this.deadDummy.TakeAttack(DUMMY_ATTACK_POINTS), // Act
            DUMMY_ATTACK_TAKEN_MESSAGE);
    }

    [Test]
    public void Dead_Dummy_Can_Give_Exp()
    {
        // Assert
        var exp = this.deadDummy.GiveExperience();
        Assert.That(exp, Is.EqualTo(DUMMY_EXP), // Act
            DEAD_DUMMY_EXP_MESSAGE);
    }

    [Test]
    public void Alive_Dummy_Can_Not_Give_Exp()
    {
        // Assert
        Assert.Throws<InvalidOperationException>
        (() => this.aliveDummy.GiveExperience(),
            ALIVE_DUMMY_EXP_MESSAGE);
    }
}
