// Es parte de la ChainOfResponsabilities.
// Se usa Expert ya que tiene solo la información necesaria para cumplir con su responsabilidad.
// Se cumple SRP porque solo solo tiene la responsabilidad de manejar el HandlerRequest.
// Se usa Creator ya que se crea una instancia de RodOfAsclepius.

using System;
using Library.Items;

namespace Library.Files.Handlers
{
    public class RodOfAsclepiusHandler : TypeHandler
    {
        public RodOfAsclepiusHandler(TypeHandler nextHandler) : base(nextHandler)
        {
        }

        public override HandlerRequest Handle(HandlerRequest handlerRequest)
        {   
            String cleanLine = handlerRequest.Line.Replace("\n","");
            String[] typeSplit = cleanLine.Split('-');
            if (handlerRequest.Line != "RodOfAsclepius")
            {
                return nextHandler?.Handle(handlerRequest); 
            }
            String[] values = typeSplit[1].Split(',');


            RodOfAsclepius rodOfAsclepius = new RodOfAsclepius(values[0],Convert.ToBoolean(values[1]));

            handlerRequest.LastCharacter.AddItem(rodOfAsclepius);
            
            return handlerRequest;
            
        }
    }
}