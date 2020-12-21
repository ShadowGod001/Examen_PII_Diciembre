namespace Library.Characters
{
    public class Demon : Villain
    {   
        /// <summary>
        /// Constructor de la clase Demon.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="health"></param>
        /// <param name="defense"></param>
        /// <returns></returns>
        public Demon(string name, int damage, int health, int defense) : base(name, damage, health, defense)
        {

        }
    }
}