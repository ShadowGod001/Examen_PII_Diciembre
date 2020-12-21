namespace Library.Characters
{
    public class Orc : Villain
    {   
        /// <summary>
        /// Constructor de la clase Orc.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="health"></param>
        /// <param name="defense"></param>
        /// <returns></returns>
        public Orc(string name, int damage, int health, int defense) : base(name, damage, health, defense)
        {

        }
    }
}