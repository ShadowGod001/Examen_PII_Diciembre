// Es parte de la ChainOfResponsabilities.
// Se usa Expert ya que tiene solo la información necesaria para cumplir con su responsabilidad.
// Se cumple SRP porque solo solo tiene la responsabilidad de manejar el HandlerRequest.
// Se usa Creator ya que se crea una instancia de BlackSword.

using System;
using Library.Items;

namespace Library.Files.Handlers
{
    public class BlackSwordHandler : TypeHandler
    {
        public BlackSwordHandler(TypeHandler nextHandler) : base(nextHandler)
        {
        }

        public override HandlerRequest Handle(HandlerRequest handlerRequest)
        {   
            String cleanLine = handlerRequest.Line.Replace("\n","");
            String[] typeSplit = cleanLine.Split('-');
            if (typeSplit[0] != "BlackSword")
            { 
                return nextHandler?.Handle(handlerRequest);
            }
            String[] values = typeSplit[1].Split(',');


            BlackSword blackSword = new BlackSword(values[0],Convert.ToInt32(values[1]),Convert.ToBoolean(values[2]));

            handlerRequest.LastCharacter.AddItem(blackSword);
            
            return handlerRequest;
            
        }
    }
}