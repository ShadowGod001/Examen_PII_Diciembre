using Library.Characters;

namespace Library.Items
{
    public class BlackSword : Item
    {        
        /// <summary>
        /// Constructor de la clase BlackSword. El item black sword es una clase aparte.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        
        /// <returns></returns>
        public BlackSword(string name, int damage, bool magic) : base(name, magic)
        {
            this.Damage = damage;
        }

        /// <summary>
        /// Método que agrega gemas elementales a la black sword y le suma ataque. Se rompe demeter y polimorfismo (inventar buena justificacion).
        /// </summary>
        /// <param name="amountOfGems"></param>
        public void UpdateElementalGem(Character character, int DamageMultiplier) 
        {   
            int gemCount = 0;
            foreach (Item item in character.GetItems())
            {
                if (item.GetType() == typeof(ElementalGem))
                {   
                    gemCount += 1;

                }
            }
            this.Damage = gemCount * DamageMultiplier;
            
        }
    }
}