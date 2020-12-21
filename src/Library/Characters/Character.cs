// Se usa composición, ya que se contiene una instancia de Inventory, para poder usar sus funcionalidades.
// Se usa polimorfismo en el método DoDamage que utiliza el ReceiveDamage del Character pasado por parámetro y funciona correctamente ya que todos los Characters tienen ese método. También se usa polimorfismo en los métodos AddItem y RemoveItem ya que funciona correctamente para cualquier subtipo de item.
// Se usa Creator ya que contiene una instancia de Inventory.
// Se cumple OCP porque los métodos son virtuales y su funcionamiento se pueden extender en las clases que hereden.
// Se usa delegación en los métodos AddItem y RemoveItem ya que se delega la responsabilidad a los métodos AddItem y RemoveItem de la clase Inventory.
// Se usa demeter ya que el método GetItems protege a la lista de items de ser accedida desde otras clases a través de la instancia de Inventory.

using System;
using Library.Items;
using System.Collections.ObjectModel;

namespace Library.Characters
{   
    /// <summary>
    /// La clase Character representa un personaje y las acciones que puede ejecutar.
    /// </summary>
    public abstract class Character
    {   
        /// <summary>
        /// Propiedad de daño del character.
        /// </summary>
        /// <value></value>
        public int Damage { get; protected set; }

        /// <summary>
        /// Propiedad de salud del character.
        /// </summary>
        /// <value></value>
        public int Health { get; protected set; }

        /// <summary>
        /// Propiedad de defensa del character.
        /// </summary>
        /// <value></value>
        public int Defense { get; protected set; }

        /// <summary>
        /// Puntos de victoria del character.
        /// </summary>
        /// <value></value>
        public int VictoryPoint { get; protected set; }

        /// <summary>
        /// Propiedad de nombre del character.
        /// </summary>
        /// <value></value>
        public string Name { get; protected set; }

        /// <summary>
        /// Booleano para saber si la vida llegó a cero o no.
        /// </summary>
        /// <value></value>
        public bool IsDead { get; protected set; }

        /// <summary>
        /// Instancia de la clase Inventory (Inventario) donde se manejan los items del character.
        /// </summary>
        /// <value></value>
        protected Inventory Inventory { get; set; }

        /// <summary>
        /// Propiedad de salud inicial del character.
        /// </summary>
        /// <value></value>
        public int InitialHealth { get; protected set; }

        /// <summary>
        /// Constructor de la clase Character.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="health"></param>
        /// <param name="defense"></param>
        public Character (string name, int damage, int health, int defense)
        {   
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.Defense = defense;

            Inventory = new Inventory();

            InitialHealth = health;
        }

        /// <summary>
        /// Método para curar al Character.
        /// </summary>
        /// <param name="value"></param>
        public virtual void Cure (int value)
        {
            this.Health = this.Health + value;
        }

        /// <summary>
        /// Método para atacar a otro Character. Este a su vez llama al método ReceiveDamage.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="character"></param>
        public virtual void DoDamage (int value, Character character)
        {   
            if (character == null)
            {
                throw new ArgumentNullException();
            }
            character.ReceiveDamage(value);
        }

        /// <summary>
        /// Método para que el Character reciba daño.
        /// </summary>
        /// <param name="value"></param>
        public virtual void ReceiveDamage (int value)
        {   
            if (this.Defense > value)
            {
                return;
            }
            this.Defense = this.Defense - value;
            if (this.Defense <= 0)
            {
                this.Health = this.Health - (Math.Abs(0-this.Defense));
                this.Defense = 0;
            }
            if (this.Health <= 0)
            {   
                this.Health = 0;
                this.IsDead = true;
            }
        }

        /// <summary>
        /// Método para sumar puntos de victoria al Character.
        /// </summary>
        /// <param name="value"></param>
        public virtual void AddVictoryPoint (int value)
        {
            this.VictoryPoint = this.VictoryPoint + value;
        }

        /// <summary>
        /// Método para agregar item al inventario del Character.
        /// </summary>
        /// <param name="item"></param>
        public virtual void AddItem(Item item) 
        {   
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            if (item.IsMagic == false)
            {
                Inventory.AddItem(item);
            }
            
            this.Damage += item.Damage;
            this.Defense += item.Defense;

            if (item.Recovery > 0) //Si equipa un objeto de recuperacion se va a curar toda la vida y luego el objeto desaparece. Hay que equiparlos sabiamente!
            {
                int lifeToRecover = this.InitialHealth-this.Health;
                this.Cure(lifeToRecover);
                Inventory.RemoveItem(item);
            }
        }

        /// <summary>
        /// Método para remover item del inventario del Character.
        /// </summary>
        /// <param name="item"></param>
        public virtual void RemoveItem(Item item)
        {   
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            
            if(Inventory.RemoveItem(item) == false)
            {
                throw new RemoveItemException("El item seleccionado no esta en el inventario");
            }else
            {
                Inventory.RemoveItem(item);
                this.Damage -= item.Damage;
                this.Defense -= item.Defense;
            }
            
            
        }

        public virtual ReadOnlyCollection<Item> GetItems()
        {
            return Inventory.Item;
        }


    }

    
}
