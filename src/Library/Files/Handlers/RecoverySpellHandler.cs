// Es parte de la ChainOfResponsabilities.
// Se usa Expert ya que tiene solo la información necesaria para cumplir con su responsabilidad.
// Se cumple SRP porque solo solo tiene la responsabilidad de manejar el HandlerRequest.
// Se usa Creator ya que se crea una instancia de RecoverySpell.

using System;
using Library.Characters.Magic;

namespace Library.Files.Handlers
{
    public class RecoverySpellHandler : TypeHandler
    {
        public RecoverySpellHandler(TypeHandler nextHandler) : base(nextHandler)
        {
        }

        public override HandlerRequest Handle(HandlerRequest handlerRequest)
        {   
            String cleanLine = handlerRequest.Line.Replace("\n","");
            String[] typeSplit = cleanLine.Split('-');
            if (handlerRequest.Line != "RecoverySpell")
            {
                return nextHandler?.Handle(handlerRequest);
            }
            String[] values = typeSplit[1].Split(',');


            RecoverySpell recoverySpell = new RecoverySpell(values[0],Convert.ToInt32(values[1]));

            try
            {
                ISpellUser spellUser = (ISpellUser)handlerRequest.ListOfCharacter[handlerRequest.ListOfCharacter.Count - 1];
                spellUser.AddSpell(recoverySpell);
            }
            catch (System.Exception)
            {
                
                throw new InvalidFileFormatException("Formato de archivo inválido: Se intentó agregar un spell a un character que no puede usarlos.");
            }
            
            return handlerRequest;
            
        }
    }
}