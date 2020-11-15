using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AXE_STARTING_ATTACK = 100;
    private const int UNBROKEN_AXE_STARTING_DURABILITY = 200;
    private const int BROKEN_AXE_STARTING_DURABILITY = 0;

    private const int DUMMY_STARTING_HEALTH = 100;
    private const int DUMMY_STARTING_EXP = 200;

    private const int DURABILITY_AFTER_WEAPON_ATTACK = 199;

    private const string WEAPON_FAIL_ATTACK_MESSAGE = "Weapon doen not lose any durability.";
    private const string ATTACK_WITH_BROKEN_WEAPON_MESSAGE = "You can not attack with broken weapon.";

    private Axe unbrokenAxe;
    private Axe brokenAxe;

    private Dummy dummy;

    [SetUp]
    public void SetUpWeapon()
    {
        this.unbrokenAxe = new Axe(AXE_STARTING_ATTACK, UNBROKEN_AXE_STARTING_DURABILITY);
        this.brokenAxe = new Axe(AXE_STARTING_ATTACK, BROKEN_AXE_STARTING_DURABILITY);
    }

    [SetUp]
    public void SetUpDummy()
    {
        this.dummy = new Dummy(DUMMY_STARTING_HEALTH, DUMMY_STARTING_EXP);
    }

    [Test]
    public void Weapon_Losing_Durability_After_Each_Attack()
    {
        // Act
        this.unbrokenAxe.Attack(this.dummy);

        // Assert
        Assert.That(this.unbrokenAxe.DurabilityPoints, Is.EqualTo(DURABILITY_AFTER_WEAPON_ATTACK),
            WEAPON_FAIL_ATTACK_MESSAGE);
    }

    [Test]
    public void Attacking_With_A_Broken_Weapon()
    {
        // Assert
        Assert.Throws<InvalidOperationException>
        (() => this.brokenAxe.Attack(this.dummy), // Act
            ATTACK_WITH_BROKEN_WEAPON_MESSAGE);
    }
}
