namespace Library.Items
{
    public class RodOfAsclepius : Item
    {   
        /// <summary>
        /// Cosntructor de la clase RodOfAsclepius.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="defense"></param>
        /// <param name="recovery"></param>
        /// <param name="magic"></param>
        /// <returns></returns>
        public RodOfAsclepius(string name, bool magic = false) : base(name, magic)
        {
            
        }
    }
}