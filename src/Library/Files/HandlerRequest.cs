// Es parte de la ChainOfResponsabilities.
// Se usa agregación porque se guardan instancias de Characters.


using System.Collections.Generic;
using Library.Characters;
using Library.Encounters;

namespace Library.Files
{   
    /// <summary>
    /// Clase que almacena los datos utilizados por los TypeHandlers.
    /// </summary>
    public class HandlerRequest
    {        
        public string Line {get; set;}

        public Encounter Encounter {get; set;}

        public List<Character> ListOfCharacter {get; set;}

        public Character LastCharacter => ListOfCharacter[ListOfCharacter.Count - 1];

        public HandlerRequest ()
        {
            ListOfCharacter = new List<Character>();
        }
        
        

    }
}