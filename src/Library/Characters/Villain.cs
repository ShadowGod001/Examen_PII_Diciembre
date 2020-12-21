// Se usa polimorfismo en el método DoDamage que utiliza el ReceiveDamage del Character pasado por parámetro y funciona correctamente ya que todos los Characters tienen ese método. 
// Se cumple OCP porque los métodos son virtuales y su funcionamiento se pueden extender en las clases que hereden.
// Se usa agregación, ya que se guardan instancias de hero en una lista.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library.Characters
{   
    /// <summary>
    /// La clase Villain representa a los villanos.
    /// </summary>
    public abstract class Villain : Character
    {   
        /// <summary>
        /// Lista de héroes derrotados por el villano.
        /// </summary>
        /// <typeparam name="Hero"></typeparam>
        /// <returns></returns>
        private static List<Hero> arbolDeLosMilDias = new List<Hero>();

        public static ReadOnlyCollection<Hero> ArbolDeLosMilDias => arbolDeLosMilDias.AsReadOnly();

        /// <summary>
        /// Cosntructor de la clase Villain.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="health"></param>
        /// <param name="defense"></param>
        /// <returns></returns>
        protected Villain(string name, int damage, int health, int defense) : base(name, damage, health, defense)
        {

        }

        /// <summary>
        /// Override del método para atacar a otro Character. Se le agrega, agregar el héroe derrotado a la lista del Aarbol de los mil dias.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="character"></param>
        public override void DoDamage (int value, Character character)
        {   
            if (character == null)
            {
                throw new ArgumentNullException();
            }
            character.ReceiveDamage(value);

            if (character.IsDead == true)
            {
                arbolDeLosMilDias.Add((Hero) character); 
            }
        }
    }
}