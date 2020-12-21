namespace Library.Characters
{
    public class Dragon : Villain
    {   
        /// <summary>
        /// Constructor de la clase Dragon.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="health"></param>
        /// <param name="defense"></param>
        /// <returns></returns>
        public Dragon(string name, int damage, int health, int defense) : base(name, damage, health, defense)
        {

        }
    }
}