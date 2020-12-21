

/// <summary>
/// Personaje nuevo (héroe) implementado como especificaba la letra.
/// </summary>

namespace Library.Characters
{
    public class Hobbit : Hero
    {   
        /// <summary>
        /// Constructor de la clase Hobbit
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="health"></param>
        /// <param name="defense"></param>
        /// <returns></returns>
        public Hobbit(string name, int damage, int health, int defense) : base(name, damage, health, defense)
        {
            
        }
    }
}