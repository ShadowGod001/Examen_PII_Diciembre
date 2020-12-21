using NUnit.Framework;
using System.IO;
using Library.Characters;
using Library.Encounters;
using Library.Files;
using Library.Files.Handlers;
using Library.Items;
using Library.Scenarios;

namespace Library.Test.Files
{
    public class FileReaderTest
    {
        private string validFormat1 = "[Character]\n" +
                                    "Elf-elf1,50,50,50\n" +
                                    "[Items]\n" +
                                    "GenericItem-espada,50,0,0,false\n" +
                                    "[Encounter]\n" +
                                    "BattleEncounter";
        
        private string validFormat2 = "Elf-elf1,50,50,50\n" +
                                    "GenericItem-espada,50,0,0,false\n" +
                                    "BattleEncounter";

        private string twoEncounters = "BattleEncounter\n[NewGroup]\nBattleEncounter";

        [SetUp]
        public void Setup()
        {
            File.WriteAllText("validFormat1.txt", validFormat1);
            File.WriteAllText("validFormat2.txt", validFormat2);
            File.WriteAllText("twoEncounters.txt", twoEncounters);
        }

        private void validFormatAssert(string file)
        {
            TypeHandler firstHandler = new BattleEncounterHandler(new GenericItemHandler(new ElfHandler(null)));

            FileReader fileReader = new FileReader(firstHandler);
            Scenario scenario = fileReader.Read(file);

            Assert.AreEqual(scenario.ListOfEncounter.Count, 1);
            Assert.IsInstanceOf<BattleEncounter>(scenario.ListOfEncounter[0]);

            BattleEncounter battleEncounter = scenario.ListOfEncounter[0] as BattleEncounter;
            Character elf = battleEncounter.ListOfHero[0];
            Assert.IsInstanceOf<Elf>(elf);
            Assert.AreEqual(elf.Name, "elf1");

            Assert.AreEqual(elf.GetItems().Count, 1);
            Item item = elf.GetItems()[0];
            Assert.IsInstanceOf<GenericItem>(item);
            Assert.AreEqual(item.Name, "espada");
        }
        
        [Test]
        public void ValidFormat1Test()
        {
            validFormatAssert("validFormat1.txt");
        }

        [Test]
        public void ValidFormat2Test()
        {
            validFormatAssert("validFormat2.txt");
        }

        [Test]
        public void TwoEncountersTest()
        {
            TypeHandler firstHandler = new BattleEncounterHandler(null);
            FileReader fileReader = new FileReader(firstHandler);
            Scenario scenario = fileReader.Read("twoEncounters.txt");
            
            Assert.AreEqual(scenario.ListOfEncounter.Count, 2);
        }
        
    }
}