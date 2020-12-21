namespace Library.Items
{
    public class GenericItem : Item
    {
        /// <summary>
        /// Constructor de la clase Item.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="defense"></param>
        /// <param name="recovery"></param>
        /// <param name="magic"></param>
        public GenericItem(string name, int damage, int defense, int recovery, bool magic) : base(name, magic)
        {
            this.Damage = damage;
            this.Defense = defense;
            this.Recovery = recovery;
            this.IsMagic = magic;
        }
        
    }
}
