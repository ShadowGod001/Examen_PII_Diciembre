// Se usa agregación, ya que se guardan instancias de items en una lista.
// Se usa polimorfismo en los métodos AddItem y RemoveItem ya que funciona correctamente para cualquier subtipo de item.
// Se usa Creator ya que conoce como crear instancias de GenericItem.
// Se usa composición con Character. Inventory es la clase componente.


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Items;

namespace Library.Characters
{   
    /// <summary>
    /// Clase que representa un inventario de items.
    /// </summary>
    public class Inventory
    {   
        /// <summary>
        /// Lista de instancias de la clase Item.
        /// </summary>
        /// <typeparam name="Item"></typeparam>
        /// <returns></returns>
        protected List<Item> item = new List<Item>();

        /// <summary>
        /// Lista de solo lectura de instancias de la clase Item
        /// </summary>
        /// <value></value>
        public ReadOnlyCollection<Item> Item => item.AsReadOnly();

        /// <summary>
        /// Constructor de la clase Inventory.
        /// </summary>
        public Inventory()
        {

        }

        /// <summary>
        /// Método para agregar Item a la lista de items.
        /// </summary>
        /// <param name="item"></param>
        public virtual void AddItem(Item item)
        {   
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            this.item.Add(item);
      
        }

        /// <summary>
        /// Método para remover items de la lista de items.
        /// </summary>
        /// <param name="item"></param>
        public virtual bool RemoveItem(Item item)
        {   
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return this.item.Remove(item);
        }

        /// <summary>
        /// Método para combinar items. Se rompe polimorfismo al preguntar por el tipo de item.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="combinedItemName"></param>
        public virtual void CombineItem (IEnumerable<Item> items, string combinedItemName)
        {   
            if (items == null || combinedItemName == null)
            {
                throw new ArgumentNullException();
            }
            int countDamage = 0;
            int countDefense = 0;
            int countRecovery = 0;
            bool CombinedItemIsMagic = false;

            foreach (Item item in items)
            {
                countDamage = countDamage + item.Damage;
                countDefense = countDefense + item.Defense;
                countRecovery = countRecovery + item.Recovery;

                RemoveItem(item);
                if (item.GetType() == typeof(RodOfAsclepius))
                {   
                    CombinedItemIsMagic = false;

                }
                else
                {
                   CombinedItemIsMagic = true; 
                }
                

            }

            GenericItem newItem = new GenericItem(combinedItemName,countDamage,countDefense,countRecovery,CombinedItemIsMagic);

            
        }
        
    }
}
