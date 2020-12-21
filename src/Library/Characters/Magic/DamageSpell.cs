// Cumple con SRP ya que su única responsabilidad es guardar el valor del daño del spell.
namespace Library.Characters.Magic
{   
    /// <summary>
    /// La clase DamageSpell representa los hechizos de ataque.
    /// </summary>
    public class DamageSpell : Spell
    {   
        /// <summary>
        /// Propiedad de daño del Spell (hechizo).
        /// </summary>
        /// <value></value>
        public int Damage { get; private set; }

        /// <summary>
        /// Constructor de la clase DamageSpell.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <returns></returns>
        public DamageSpell(string name, int damage) : base(name)
        {   
            this.Damage = damage;
        }
    }
}