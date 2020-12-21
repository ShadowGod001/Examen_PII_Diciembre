// Se usa agregación, ya que se guardan instancias de Spell en una lista.
// También se usa polimorfismo en el método AddItem ya que funciona correctamente para cualquier subtipo de item y en los métodos AddSpell y RemoveSpell, ya que funciona correctamente para cualquier subtipo de spell.
// Se usa delegación en el método AddItem ya que se delega la responsabilidad al método AddItem de la clase Inventory.


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Characters.Magic;
using Library.Items;

namespace Library.Characters
{   
    /// <summary>
    /// La clase Wizard representa a los magos.
    /// </summary>
    public class Wizard : Hero, ISpellUser
    {   
        /// <summary>
        /// Lista de instancias de la clase Spell (hechizos).
        /// </summary>
        /// <typeparam name="Spell"></typeparam>
        /// <returns></returns>
        private List<Spell> spellBook = new List<Spell>();
        
        /// <summary>
        /// Lista de solo lectura de instancias de la clase Spell (hechizos).
        /// </summary>
        /// <value></value>
        public ReadOnlyCollection<Spell> SpellBook => spellBook.AsReadOnly();

        /// <summary>
        /// Constructor de la clase Wizard.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="health"></param>
        /// <param name="defense"></param>
        /// <returns></returns>
        public Wizard(string name, int damage, int health, int defense) : base(name, damage, health, defense)
        {

        }

        /// <summary>
        /// Override del método AddItem de Character para poder agregar cualquier item sea mágico o no.
        /// </summary>
        /// <param name="item"></param>
        public override void AddItem(Item item)
        {   
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            Inventory.AddItem(item);
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
        /// Método para agregar spell a la lista de spell.
        /// </summary>
        /// <param name="spell"></param>
        public void AddSpell(Spell spell)
        {   
            if (spell == null)
            {
                throw new ArgumentNullException();
            }
            this.spellBook.Add(spell);
            
        }

        /// <summary>
        /// Método para remover spell de la lista de spell.
        /// </summary>
        /// <param name="spell"></param>
        public void RemoveSpell(Spell spell)
        {   
            if (spell == null)
            {
                throw new ArgumentNullException();
            }
            this.spellBook.Remove(spell);
        }
    }
}