// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

using System;
using System.Linq;
using FestivalManager.Entities;
using NUnit.Framework;

namespace FestivalManager.Tests
{
    [TestFixture]
    public class StageTests
    {
        [Test]
        public void Constructor_Should_Set_Correctly()
        {
            var stage = new Stage();

            Assert.IsNotNull(stage.Performers);
            Assert.That(stage.Performers.Count, Is.EqualTo(0));
        }

        [Test]
        public void Add_Performer_Should_Add_Correctly()
        {
            var stage = new Stage();

            stage.AddPerformer(new Performer("Ivan", "Ivanov", 20));
            stage.AddPerformer(new Performer("Ivan1", "Ivanov2", 20));

            Assert.That(stage.Performers.Count, Is.EqualTo(2));
            Assert.That(stage.Performers.Any(p => p.FullName == "Ivan Ivanov"), Is.EqualTo(true));
        }

        [Test]
        public void Add_Performer_Should_Throw_An_Exception_If_The_Performer_Is_Null()
        {
            var stage = new Stage();

            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }

        [Test]
        public void Add_Performer_Should_Throw_An_Exception_If_The_Performer_Is_Under_18()
        {
            var stage = new Stage();

            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Ivan", "Ivanov", 12)));
        }

        [Test]
        public void Add_Song_Should_Throw_An_Exception_If_The_Song_Is_Null()
        {
            var stage = new Stage();

            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
        }

        [Test]
        public void Add_Song_Should_Throw_An_Exception_If_The_Song_Duration_Is_Under_1_Minute()
        {
            var stage = new Stage();

            var song = new Song("Smth", new TimeSpan(0, 0, 30));

            Assert.Throws<ArgumentException>(() => stage.AddSong(song));
        }

        [Test]
        public void Add_Song_Should_Be_Add_Successfully()
        {
            var stage = new Stage();

            var song = new Song("Smth", new TimeSpan(0, 3, 25));

            stage.AddSong(song);
        }

        [Test]
        public void Add_Song_To_Performer_Should_Throw_An_Exception_If_The_Song_Is_Null()
        {
            var stage = new Stage();

            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "a"));
        }

        [Test]
        public void Add_Song_To_Performer_Should_Throw_An_Exception_If_The_Performer_Is_Null()
        {
            var stage = new Stage();

            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("a", null));
        }

        [Test]
        public void Add_Song_To_Performer_Should_Throw_An_Exception_If_The_Performer_Is_Not_Existing()
        {
            var stage = new Stage();

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("a", "Ivan4o"));
        }

        [Test]
        public void Add_Song_To_Performer_Should_Throw_An_Exception_If_The_Song_Is_Not_Existing()
        {
            var stage = new Stage();

            stage.AddPerformer(new Performer("Ri", "a", 20));

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Frog", "Ri a"));
        }

        [Test]
        public void Add_Song_To_Performer_Should_Be_Add_Successfully()
        {
            var stage = new Stage();

            stage.AddSong(new Song("A", new TimeSpan(0, 3, 21)));
            stage.AddPerformer(new Performer("Ivan", "Ivanov", 30));

            stage.AddSongToPerformer("A", "Ivan Ivanov");


        }

        [Test]
        public void Play_Should_Return_Correct_Result()
        {
            var stage = new Stage();

            stage.AddSong(new Song("A", new TimeSpan(0, 3, 24)));
            stage.AddPerformer(new Performer("Ivan", "Ivanov", 30));
            stage.AddSongToPerformer("A", "Ivan Ivanov");

            var result = stage.Play();

            Assert.That(result, Is.EqualTo($"1 performers played 1 songs"));
        }
    }
}