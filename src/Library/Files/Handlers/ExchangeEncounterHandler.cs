// Es parte de la ChainOfResponsabilities.
// Se usa Expert ya que tiene solo la información necesaria para cumplir con su responsabilidad.
// Se cumple SRP porque solo solo tiene la responsabilidad de manejar el HandlerRequest.
// Se usa Creator ya que se crea una instancia de ExchangeEncounter.

using System;
using System.Collections.Generic;
using Library.Encounters;
using Library.Items;

namespace Library.Files.Handlers
{
    public class ExchangeEncounterHandler : TypeHandler
    {
        public ExchangeEncounterHandler(TypeHandler nextHandler) : base(nextHandler)
        {
        }

        public override HandlerRequest Handle(HandlerRequest handlerRequest)
        {   
            String cleanLine = handlerRequest.Line.Replace("\n","");
            String[] typeSplit = cleanLine.Split('-');
            if (typeSplit[0] != "ExchangeEncounter")
            {
                return nextHandler?.Handle(handlerRequest);
            }
            String[] values = typeSplit[1].Split(',');

            List<Item> listOfItem = new List<Item>();
            foreach (var value in values)
            {
                int index = Convert.ToInt32(value);
                listOfItem.Add(handlerRequest.ListOfCharacter[0].GetItems()[index]);
            }
            handlerRequest.Encounter = new ExchangeEncounter(handlerRequest.ListOfCharacter,listOfItem);

            return handlerRequest;
            
        }
    }
}