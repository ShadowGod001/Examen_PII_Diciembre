// Cumple con SRP ya que su única responsabilidad es guardar el valor de recuperación del spell.
namespace Library.Characters.Magic
{
    public class RecoverySpell : Spell
    {   
        /// <summary>
        /// Propiedad de recuperación del Spell (hechizo).
        /// </summary>
        /// <value></value>
        public int Recovery { get; private set; }

        /// <summary>
        /// Cosntructor de la clase RecoverySpell.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="recovery"></param>
        /// <returns></returns>
        public RecoverySpell(string name, int recovery) : base(name)
        {
            this.Recovery = recovery;
        }
    }
}