// Es parte de la ChainOfResponsabilities.
// Se usa Expert ya que tiene solo la información necesaria para cumplir con su responsabilidad.
// Se cumple SRP porque solo solo tiene la responsabilidad de manejar el HandlerRequest.
// Se usa Creator ya que se crea una instancia de Demon.

using System;
using Library.Characters;

namespace Library.Files.Handlers
{
    public class DemonHandler : TypeHandler
    {
        public DemonHandler(TypeHandler nextHandler) : base(nextHandler)
        {
        }

        public override HandlerRequest Handle(HandlerRequest handlerRequest)
        {   
            String cleanLine = handlerRequest.Line.Replace("\n","");
            String[] typeSplit = cleanLine.Split('-');
            if (typeSplit[0] != "Demon")
            {
                return nextHandler?.Handle(handlerRequest);
            }
            String[] values = typeSplit[1].Split(',');


            Demon demon = new Demon(values[0],Convert.ToInt32(values[1]),Convert.ToInt32(values[2]),Convert.ToInt32(values[3]));

            handlerRequest.ListOfCharacter.Add(demon);
            
            return handlerRequest;
            
        }
    }
}