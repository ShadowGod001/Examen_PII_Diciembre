// Es parte de la ChainOfResponsabilities.
// Se usa Expert ya que tiene solo la información necesaria para cumplir con su responsabilidad.
// Se cumple SRP porque solo solo tiene la responsabilidad de manejar el HandlerRequest.
// Se usa Creator ya que se crea una instancia de BattleEncounter.

using Library.Encounters;

namespace Library.Files.Handlers
{   
    public class BattleEncounterHandler : TypeHandler
    {
        public BattleEncounterHandler(TypeHandler nextHandler) : base(nextHandler)
        {
        }

        public override HandlerRequest Handle(HandlerRequest handlerRequest)
        {
            if (handlerRequest.Line != "BattleEncounter")
            {
                return nextHandler?.Handle(handlerRequest);
            }

            handlerRequest.Encounter = new BattleEncounter(handlerRequest.ListOfCharacter);

            return handlerRequest;
            
        }
    }
}