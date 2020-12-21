using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Encounters;

namespace Library.Scenarios
{

    public class Scenario
    {   
        /// <summary>
        /// Lista de encuentros.
        /// </summary>
        private List<Encounter> listOfEncounter;

        public ReadOnlyCollection<Encounter> ListOfEncounter => listOfEncounter.AsReadOnly();

        /// <summary>
        /// Constructor de la clase Scenario.
        /// </summary>
        /// <param name="listOfEncounter"></param>
        public Scenario (List<Encounter> listOfEncounter)
        {
            this.listOfEncounter = listOfEncounter;
        }

        /// <summary>
        /// Método que ejecuta el método excecute que inicializa el encuentro.
        /// </summary>
       public void Start()
       {
           foreach (Encounter encounter in listOfEncounter)
           {
               encounter.Excecute();
           }
       }
        
        
    }
}
