// Es parte de la ChainOfResponsabilities.
// Se usa Expert ya que tiene solo la información necesaria para cumplir con su responsabilidad.
// Se cumple SRP porque solo solo tiene la responsabilidad de manejar el HandlerRequest.
// Se usa Creator ya que se crea una instancia de Nazgul.

using System;
using Library.Characters;

namespace Library.Files.Handlers
{
    public class NazgulHandler : TypeHandler
    {
        public NazgulHandler(TypeHandler nextHandler) : base(nextHandler)
        {
        }

        public override HandlerRequest Handle(HandlerRequest handlerRequest)
        {   
            String cleanLine = handlerRequest.Line.Replace("\n","");
            String[] typeSplit = cleanLine.Split('-');
            if (typeSplit[0] != "Nazgul")
            {
                return nextHandler?.Handle(handlerRequest);
            }
            String[] values = typeSplit[1].Split(',');


            Nazgul nazgul = new Nazgul(values[0],Convert.ToInt32(values[1]),Convert.ToInt32(values[2]),Convert.ToInt32(values[3]));

            handlerRequest.ListOfCharacter.Add(nazgul);
            
            return handlerRequest;
            
        }
    }
}