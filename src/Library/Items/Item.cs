namespace Library.Items
{
    public abstract class Item
    {   
        /// <summary>
        /// Propiedad de nombre del item.
        /// </summary>
        /// <value></value>
        public string Name { get; protected set; }

        /// <summary>
        /// /// Propiedad de daño del item.
        /// </summary>
        /// <value></value>
        public int Damage { get; protected set; }

        /// <summary>
        /// Propiedad de defensa del item.
        /// </summary>
        /// <value></value>
        public int Defense { get; protected set; }

        /// <summary>
        /// Propiedad de recuperación del item.
        /// </summary>
        /// <value></value>
        public int Recovery { get; protected set; }

        /// <summary>
        /// Booleano para saber si el ítem es mágico o no.
        /// </summary>
        /// <value></value>
        public bool IsMagic { get; protected set; }

        /// <summary>
        /// Constructor de la clase Item.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="defense"></param>
        /// <param name="recovery"></param>
        /// <param name="magic"></param>
        public Item (string name, bool magic)
        {
            this.Name = name;
            this.IsMagic = magic;
        }

        
    }
}
