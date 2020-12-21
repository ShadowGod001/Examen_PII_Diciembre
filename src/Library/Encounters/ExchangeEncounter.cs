// Se usa agregación, ya que se guardan instancias de Character.
// Cumple con SRP ya que su única responsabilidad es ejecutar el método Excecute que realiza el intercambio de items.

using System;
using System.Collections.Generic;
using Library.Characters;
using Library.Items;

namespace Library.Encounters
{   
    /// <summary>
    /// La clase ExchangeEncounter representa un encuentro de intercambio de items.
    /// </summary>
    public class ExchangeEncounter : Encounter
    {   
        /// <summary>
        /// Instancia de Character pasada por parámetro.
        /// </summary>
        private Character sender;

        /// <summary>
        /// Instancia de Character pasada por parámetro.
        /// </summary>
        private Character receiver;

        /// <summary>
        /// Lista de instancias de Item pasada por parámetro.
        /// </summary>
        private List<Item> listOfItem;
        
        /// <summary>
        /// Constructor de la clase ExchangeEncounter.
        /// </summary>
        /// <param name="listOfCharacter"></param>
        /// <param name="listOfItem"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ExchangeEncounter(List<Character> listOfCharacter, List<Item> listOfItem) : base(listOfCharacter) 
        {   
            Character sender = listOfCharacter[0];
            Character receiver = listOfCharacter[1];
            if (sender == null || receiver == null)
            {
                throw new ArgumentNullException();
            }
            this.sender = sender;
            this.receiver = receiver;
            this.listOfItem = listOfItem;
        }

        /// <summary>
        /// Método para hacer trade de items (antes llamado Exchagne item)
        /// </summary>
        public override void Excecute()
        {
            foreach (Item item in listOfItem)
            {   
                sender.RemoveItem(item);
                receiver.AddItem(item);
                
            }
        }
    }
}