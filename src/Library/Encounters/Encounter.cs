// Se cumple OCP porque los métodos son virtuales y su funcionamiento se pueden extender en las clases que hereden.

using System.Collections.Generic;
using Library.Characters;

namespace Library.Encounters
{   
    /// <summary>
    /// La clase abstracta Encounter representa un encuentro.
    /// </summary>
    public abstract class Encounter
    {   
        /// <summary>
        /// Constructor de la clase Encounter.
        /// </summary>
        /// <param name="listOfCharacter"></param>
        protected Encounter(List<Character> listOfCharacter)
        {

        }

        /// <summary>
        /// Método que inicializa el encuentro (anteriormente llamado Fight).
        /// </summary>
        public abstract void Excecute();
        
    }

}
