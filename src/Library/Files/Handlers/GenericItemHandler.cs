// Es parte de la ChainOfResponsabilities.
// Se usa Expert ya que tiene solo la información necesaria para cumplir con su responsabilidad.
// Se cumple SRP porque solo solo tiene la responsabilidad de manejar el HandlerRequest.
// Se usa Creator ya que se crea una instancia de GenericItem.

using System;
using Library.Items;

namespace Library.Files.Handlers
{
    public class GenericItemHandler : TypeHandler
    {
        public GenericItemHandler(TypeHandler nextHandler) : base(nextHandler)
        {
        }

        public override HandlerRequest Handle(HandlerRequest handlerRequest)
        {   
            String cleanLine = handlerRequest.Line.Replace("\n","");
            String[] typeSplit = cleanLine.Split('-');
            if (typeSplit[0] != "GenericItem")
            {
                return nextHandler?.Handle(handlerRequest);
            }
            String[] values = typeSplit[1].Split(',');


            GenericItem genericItem = new GenericItem(values[0],Convert.ToInt32(values[1]),Convert.ToInt32(values[2]),Convert.ToInt32(values[3]),Convert.ToBoolean(values[4]));

            handlerRequest.ListOfCharacter[handlerRequest.ListOfCharacter.Count - 1].AddItem(genericItem);
            return handlerRequest;
            
        }
    }
}