

/// <summary>
/// Personaje nuevo (villano) implementado como especificaba la letra.
/// </summary>

namespace Library.Characters
{
    public class Nazgul : Villain
    {   
        /// <summary>
        /// Constructor de la clase Nazgul.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="health"></param>
        /// <param name="defense"></param>
        /// <returns></returns>
        public Nazgul(string name, int damage, int health, int defense) : base(name, damage, health, defense)
        {

        }
    }
}