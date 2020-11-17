using System;
using DatabaseExtended;
using NUnit.Framework;

public class ExtendedDatabaseTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Empty_Constructor_Should_Return_Count_Zero()
    {
        // Arrange
        var db = new ExtendedDatabase();

        // Act
        var actualResult = db.Count;
        var expectedResult = 0;

        //Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Add_One_Person_In_The_Constructor_And_Should_Return_Count_One()
    {
        // Arrange
        var person = new Person(1, "Stavri");
        var db = new ExtendedDatabase(person);

        // Act
        var actualResult = db.Count;
        var expectedResult = 1;

        //Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Constructor_Should_Throw_An_Exception_If_There_Are_More_Elements_Than_The_Collection_Size_Are_Added()
    {
        // Arrange
        var personArr = new Person[17];

        for (int i = 0; i < personArr.Length; i++)
        {
            personArr[i] = new Person(i + 1, $"Stavri {i + 1}");
        }

        // Assert
        Assert.Throws<ArgumentException>(
            () => new ExtendedDatabase(personArr), // Act
            "The collection is not full.");
    }

    [Test]
    public void Add_One_Person_To_The_Collection_Should_Be_Added_Correctly()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(5, "Dimitri"));

        // Act
        db.Add(new Person(9, "Hasan"));

        var actualResult = db.FindById(9);

        // Assert
        Assert.That(actualResult.Id, Is.EqualTo(9));
        Assert.That(actualResult.UserName, Is.EqualTo("Hasan"));
    }

    [Test]
    public void Throw_An_Exception_If_We_Try_To_Add_Person_In_Full_Collection()
    {
        // Arrange
        var personArr = new Person[16];

        for (int i = 0; i < personArr.Length; i++)
        {
            personArr[i] = new Person(i + 1, $"Ivcho {i + 1}");
        }

        var db = new ExtendedDatabase(personArr);

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Add(new Person(105, "Samuil")), // Act
            "The collection is not full.");
    }

    [Test]
    public void Adding_Person_With_Existing_Username_Should_Throw_And_Exception()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(4, "Dimitrichko"));

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Add(new Person(1, "Dimitrichko")), // Act
            "The person NAME is unique.");
    }

    [Test]
    public void Adding_Person_With_Existing_Id_Should_Throw_And_Exception()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(15, "Ivanka"));

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Add(new Person(15, "Dimitrichko")), // Act
            "The person ID is unique.");
    }

    [Test]
    public void Adding_Person_Should_Increment_Count()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(48, "Filip"));

        // Act
        db.Add(new Person(3, "Simba"));

        var actualResult = db.Count;
        var expectedResult = 2;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Adding_Two_Persons_Should_Increment_Count_With_Two()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(48, "Alfonso"));

        // Act
        db.Add(new Person(3, "Simba"));
        db.Add(new Person(1, "Gergana"));

        var actualResult = db.Count;
        var expectedResult = 3;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Removing_Person_Should_Decrement_Count()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(48, "Filip"));

        // Act
        db.Add(new Person(3, "Simba"));
        db.Add(new Person(13, "Ivan4o"));
        db.Add(new Person(23, "Petkan4o"));

        db.Remove();

        var actualResult = db.Count;
        var expectedResult = 3;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Removing_Two_Persons_Should_Decrement_Count_With_Two()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(48, "Alfonso"));

        // Act
        db.Add(new Person(3, "Simba"));
        db.Add(new Person(1, "Gergana"));

        db.Remove();
        db.Remove();

        var actualResult = db.Count;
        var expectedResult = 1;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Removing_Person_In_Empty_Collection_Should_Throw_An_Exception()
    {
        // Arrange
        var db = new ExtendedDatabase();

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Remove(), // Act
            "The collection is not empty.");
    }

    [TestCase(null)]
    [TestCase("")]
    public void FindByUsername_Should_Throw_An_Exception_In_Case_Of_Null_Or_Whitespace(string username)
    {
        // Arrange
        var db = new ExtendedDatabase();

        // Assert
        Assert.Throws<ArgumentNullException>(
            () => db.FindByUsername(username),
            "The username is not null or whitespace.");
    }

    [Test]
    public void FindByUsername_Should_Throw_An_Exception_In_Case_Of_Non_Existing_Username()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(5, "Simo"));

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.FindByUsername("Simo1"),
            "The username is already in the collection.");
    }

    [Test]
    public void FindByUsername_Should_Return_The_Person_Correctly()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(12, "Simo"));

        // Act
        var actualResult = db.FindByUsername("Simo");

        // Assert
        Assert.That(actualResult.Id, Is.EqualTo(12));

        Assert.That(actualResult.UserName, Is.EqualTo("Simo"));
    }

    [Test]
    public void FindById_Should_Throw_An_Exception_In_Case_Of_Negative_Id()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(5, "Simo"));

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => db.FindById(-1),
            "The id is not negative.");
    }

    [Test]
    public void FindById_Should_Throw_An_Exception_In_Case_Of_Non_Existing_Id()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(55, "Simo"));

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.FindById(45),
            "The id is already in the collection.");
    }

    [Test]
    public void FindById_Should_Return_The_Person_Correctly()
    {
        // Arrange
        var db = new ExtendedDatabase(new Person(12, "Simo"));

        // Act
        var actualResult = db.FindById(12);

        // Assert
        Assert.That(actualResult.Id, Is.EqualTo(12));

        Assert.That(actualResult.UserName, Is.EqualTo("Simo"));
    }
}

