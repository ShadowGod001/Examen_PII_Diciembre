// Se cumple ISP ya que los métodos AddSpell y RemoveSpell son los mínimos necesarios para poder cumplir con la responsabilidad de manejar los spells de un character.

namespace Library.Characters.Magic
{   
    /// <summary>
    /// Interfaz que implementarán todos aquellos personajes que puedan utilizar hechizos.
    /// </summary>
    public interface ISpellUser
    {   
        /// <summary>
        /// Método para agregar un hechizo.
        /// </summary>
        /// <param name="spell"></param>
        void AddSpell(Spell spell);

        /// <summary>
        /// Método para remover un hechizo.
        /// </summary>
        /// <param name="spell"></param>
        void RemoveSpell(Spell spell);
    }
}