using NUnit.Framework;
using Library.Characters;
using Library.Items;
using Library.Encounters;
using System.Collections.Generic;

namespace Library.Test
{
    public class ExchangeEncounterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Se testea que el emisor pierda el item que cambió y el receptor lo gane.
        /// </summary>
        [Test]
        public void ExcecuteTest()
        {   
            Elf character = new Elf("TestCharacter", 50,10,40);
            Wizard Secondcharacter = new Wizard("TestCharacter", 50,10,40);
            GenericItem item = new GenericItem("TestItem",10,10,0,false);
            character.AddItem(item);
            List<Item> listOfItem = new List<Item>();
            listOfItem.Add(item);
            List<Character> listOfCharacter = new List<Character>();
            listOfCharacter.Add(character);
            listOfCharacter.Add(Secondcharacter);
            ExchangeEncounter exchangeEncounter = new ExchangeEncounter(listOfCharacter,listOfItem);
            exchangeEncounter.Excecute();
            Assert.AreEqual(character.GetItems().Count,0);
            Assert.AreEqual(Secondcharacter.GetItems()[0],item);

        }

        /// <summary>
        /// Se testea que el emisor pierda todos sus items y el emisor los gane.
        /// </summary>
         [Test]
        public void ExcecuteTestForMoreThanOneItem()
        {   
            Elf character = new Elf("TestCharacter", 50,10,40);
            Wizard Secondcharacter = new Wizard("TestCharacter", 50,10,40);
            GenericItem item = new GenericItem("TestItem",10,10,0,false);
            GenericItem Seconditem = new GenericItem("SeCONDTestItem",10,10,0,false);
            character.AddItem(item);
            character.AddItem(Seconditem);
            List<Item> listOfItem = new List<Item>();
            listOfItem.Add(item);
            listOfItem.Add(Seconditem);
            List<Character> listOfCharacter = new List<Character>();
            listOfCharacter.Add(character);
            listOfCharacter.Add(Secondcharacter);
            ExchangeEncounter exchangeEncounter = new ExchangeEncounter(listOfCharacter,listOfItem);
            exchangeEncounter.Excecute();
            Assert.AreEqual(character.GetItems().Count,0);
            Assert.AreEqual(Secondcharacter.GetItems()[0],item);
            Assert.AreEqual(Secondcharacter.GetItems()[1],Seconditem);

        }
    }
}