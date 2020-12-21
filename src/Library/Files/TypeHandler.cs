// Se utiliza el patrón de diseño ChainOfResponsabilities para transferir la responsabilidad de manejar las entradas del archivo de texto a quien tenga la responsabilidad de trabajar con dicha entrada.
// Se cumple OCP porque los métodos son abstractos y su funcionamiento se pueden extender en las clases que hereden.
// Se usa Expert ya que tiene solo la información necesaria para cumplir con su responsabilidad.
// Se cumple SRP porque solo solo tiene la responsabilidad de manejar el HandlerRequest.

namespace Library.Files
{   
    /// <summary>
    /// Se encarga de realizar una operación o se la delega a otro si no es su responsabilidad realizarla.
    /// </summary>
    public abstract class TypeHandler
    {        
        protected TypeHandler nextHandler;

        public TypeHandler (TypeHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }
        public abstract HandlerRequest Handle(HandlerRequest handlerRequest);
        

    }
}