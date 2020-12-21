using System;

namespace Library.Characters.Magic
{
    public abstract class Spell
    {   
        /// <summary>
        /// Propiedad de nombre del Spell (hechizo).
        /// </summary>
        /// <value></value>
        public string Name { get; private set; }
        
        /// <summary>
        /// Cosntructor de la clase Spell.
        /// </summary>
        /// <param name="name"></param>
        public Spell (string name) //Un hechizo solo puede ser de ataque, defense o recuperación
        {   
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }
            this.Name = name;
            
            
        }

        
    }
}