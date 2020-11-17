using System;
using NUnit.Framework;

public class DatabaseTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Constructor_Empty_Collection_Should_Return_Count_Zero()
    {
        // Arrange
        var db = new Database();

        // Act
        var actualResult = db.Count;
        var expectedResult = 0;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Constructor_Collection_With_Six_Elements_Should_Return_Count_Six()
    {
        // Arrange
        var db = new Database(1, 2, 3, 4, 5, 6);

        // Act
        var actualResult = db.Count;
        var expectedResult = 6;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Constructor_Collection_With_Ten_Elements_Should_Return_Count_Ten()
    {
        // Arrange
        var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

        // Act
        var actualResult = db.Count;
        var expectedResult = 10;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Constructor_With_Two_Elements_Should_Be_Added_Correctly()
    {
        // Arrange
        var db = new Database(1, 2);

        // Act
        var actualResult = db.Fetch();

        var expectedResult = new int[]
        {
            1, 2
        };

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Constructor_With_Ten_Elements_Should_Be_Added_Correctly()
    {
        // Arrange
        var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

        // Act
        var actualResult = db.Fetch();

        var expectedResult = new int[]
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Constructor_With_Zero_Elements_Should_Return_Empty_Collection()
    {
        // Arrange
        var db = new Database();

        // Act
        var actualResult = db.Fetch();

        var expectedResult = new int[]
        {
        };

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Constructor_With_More_Elements_Than_The_Collection_Capacity_Should_Throw_An_Exception()
    {
        // Arrange
        var arr = new int[20];

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => new Database(arr), // Act
            "Collection capacity is not full.");
    }

    [Test]
    public void Throw_An_Exception_If_We_Try_To_Add_Element_But_The_Collection_Is_Full()
    {
        // Arrange
        var arr = new int[16];

        var db = new Database(arr);

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Add(1), // Act
            "The collection is not full.");
    }

    [Test]
    public void Throw_An_Exception_If_We_Try_To_Remove_Element_But_The_Collection_Is_Empty()
    {
        // Arrange
        var db = new Database();

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Remove(), // Act
            "The collection is not empty.");
    }

    [Test]
    public void Adding_Element_To_Empty_Collection_Should_Be_Added_Correctly()
    {
        // Arrange
        var db = new Database();

        // Act
        db.Add(1);

        var actualResult = db.Fetch();

        var expectedResult = new int[]
        {
            1
        };

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Adding_Three_Element_To_Empty_Collection_Should_Be_Added_Correctly()
    {
        // Arrange
        var db = new Database();

        // Act
        db.Add(1);
        db.Add(2);
        db.Add(3);

        var actualResult = db.Fetch();

        var expectedResult = new int[]
        {
            1, 2, 3
        };

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Removing_Three_Element_From_Collection_Should_Be_Removed_Correctly()
    {
        // Arrange
        var db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

        // Act
        db.Remove();
        db.Remove();
        db.Remove();

        var actualResult = db.Fetch();

        var expectedResult = new int[]
        {
            1, 2, 3, 4, 5, 6, 7
        };

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Removing_Element_From_Collection_Should_Be_Removed_Correctly()
    {
        // Arrange
        var db = new Database(1);

        // Act
        db.Remove();

        var actualResult = db.Fetch();

        var expectedResult = new int[]
        {
        };

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Collection_Count_Should_Increment_After_Add_Element()
    {
        // Arrange
        var db = new Database();

        // Act
        db.Add(1);

        var actualResult = db.Count;
        var expectedResult = 1;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Collection_Count_Should_Increment_Twice_After_Add_Two_Element()
    {
        // Arrange
        var db = new Database(1, 2);

        // Act
        db.Add(3);
        db.Add(4);

        var actualResult = db.Count;
        var expectedResult = 4;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Collection_Count_Should_Decrement_After_Remove_Element()
    {
        // Arrange
        var db = new Database(1, 2, 3, 4);

        // Act
        db.Remove();

        var actualResult = db.Count;
        var expectedResult = 3;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Collection_Count_Should_Decrement_Twice_After_Remove_Two_Element()
    {
        // Arrange
        var db = new Database(1, 2, 3);

        // Act
        db.Remove();
        db.Remove();

        var actualResult = db.Count;
        var expectedResult = 1;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Collection_Count_Should_Not_Change_After_Add_And_Remove_Element()
    {
        // Arrange
        var db = new Database(1, 2);

        // Act
        db.Add(3);
        db.Remove();

        var actualResult = db.Count;
        var expectedResult = 2;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}