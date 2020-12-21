using System;
using System.Collections.Generic;
using Library.Files;
using Library.Files.Handlers;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            TypeHandler firstHandler = ChainedHandler();

            FileReader fileReader = new FileReader(firstHandler);

            string location = System.Reflection.Assembly.GetEntryAssembly().Location;

            fileReader.Read("..\\..\\..\\scenario1.txt");
        }

        static TypeHandler ChainedHandler()
        {
            List<TypeHandler> handlers = new List<TypeHandler>();

            handlers.Add(new WizardHandler(null));
            handlers.Add(new RodOfAsclepiusHandler(handlers.Last()));
            handlers.Add(new RecoverySpellHandler(handlers.Last()));
            handlers.Add(new OrcHandler(handlers.Last()));
            handlers.Add(new NazgulHandler(handlers.Last()));
            handlers.Add(new HobbitHandler(handlers.Last()));
            handlers.Add(new GenericItemHandler(handlers.Last()));
            handlers.Add(new ExchangeEncounterHandler(handlers.Last()));
            handlers.Add(new ElfHandler(handlers.Last()));
            handlers.Add(new ElementalGemHandler(handlers.Last()));
            handlers.Add(new DwarfHandler(handlers.Last()));
            handlers.Add(new DragonHandler(handlers.Last()));
            handlers.Add(new DemonHandler(handlers.Last()));
            handlers.Add(new DefenseSpellHandler(handlers.Last()));
            handlers.Add(new DamageSpellHandler(handlers.Last()));
            handlers.Add(new BlackSwordHandler(handlers.Last()));
            handlers.Add(new BattleEncounterHandler(handlers.Last()));

            return handlers.Last();
        }
    }
}
