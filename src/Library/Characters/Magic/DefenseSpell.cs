// Cumple con SRP ya que su única responsabilidad es guardar el valor de defensa del spell.
namespace Library.Characters.Magic
{
    public class DefenseSpell : Spell
    {   
        /// <summary>
        /// Propiedad de defensa del Spell (hechizo).
        /// </summary>
        /// <value></value>
        public int Defense { get; private set; }
        /// <summary>
        /// Constructor de la clase DefenseSpell.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defense"></param>
        /// <returns></returns>
        public DefenseSpell(string name, int defense) : base(name)
        {
            this.Defense = defense;
        }
    }
}