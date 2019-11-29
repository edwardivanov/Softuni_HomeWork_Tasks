using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        ExtendedDatabase database;
        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase
                (new Person(22, "Pesho"));
        }

        [Test]
        public void CheckCount()
        {
            Assert.That(database.Count == 1);
        }
        [Test]
        public void AddingPerson()
        {
            Assert.DoesNotThrow(() => database.Add(new Person(20, "Ivo")));
        }
        [Test]
        public void AddingPersonWithSameId()
        {
            Assert.Throws<InvalidOperationException>(() 
                => database.Add(new Person(22,"Niki")));
        }

        [Test]
        public void AddingPersonWithSameName()
        {
            Assert.Throws<InvalidOperationException>(()
                 => database.Add(new Person(28, "Pesho")));
        }

        [Test]
        public void AddingOverTheCapacityOfDatabase()
        {
            int maxCapacity = 16;
            int currentCount = database.Count;
            for (int i = 0; i < maxCapacity-currentCount; i++)
            {
                database.Add(new Person(25+i, "Ivo_"+i.ToString()));
            }
            Assert.Throws<InvalidOperationException>(()
                 => database.Add(new Person(28, "Pesho")));
        }

        [Test]
        public void RemovePersonFromDatabase()
        {
            database.Remove();
            Assert.That(database.Count == 0);
        }

        [Test]
        public void RemoveFromEmptyDatabase()
        {
            database.Remove();
            Assert.Throws<InvalidOperationException>(()
                 => database.Remove());
        }

        [Test]
        public void FindingPersonByName_Null()
        {
            Assert.Throws<ArgumentNullException>(()
                 => database.FindByUsername(null));
        }

        [Test]
        public void FindingPersonWithNotExistingName()
        {
            Assert.Throws<InvalidOperationException>(()
                 => database.FindByUsername("Niko"));
        }

        [Test]
        public void FindingPersonWithExistingName()
        {
            var person = database.FindByUsername("Pesho");
            Assert.That(person.UserName == "Pesho");
        }

        [Test]
        public void FindingPersonWithNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                 => database.FindById(-1));
        }

        [Test]
        public void FindingPersonWithNotExistingId()
        {
            Assert.Throws<InvalidOperationException>(()
                 => database.FindById(28));
        }

        [Test]
        public void FindingPersonWithExistingId()
        {
            var person = database.FindById(22);
            Assert.That(person.Id == 22);
        }

        [Test]
        public void AddingBiggerCollection()
        {
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(new Person[17]));
        }

        [Test]
        public void InstanceWithEmptyCtor()
        {
            Assert.DoesNotThrow(() => new ExtendedDatabase());
        }
    }
}