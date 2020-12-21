// Se usa polimorfismo en el método DoDamage que utiliza el ReceiveDamage del Character pasado por parámetro y funciona correctamente ya que todos los Characters tienen ese método. 
// Se cumple OCP porque los métodos son virtuales y su funcionamiento se pueden extender en las clases que hereden.


using System;

namespace Library.Characters
{   
    /// <summary>
    /// La clase hero representa a los héroes.
    /// </summary>
    public abstract class Hero : Character
    {   
        /// <summary>
        /// Propiedad que representa cuantos Characters derrotó el héroe.
        /// </summary>
        protected static int LaPiedraEterna;

        /// <summary>
        /// Constructor de la clase Hero.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damage"></param>
        /// <param name="health"></param>
        /// <param name="defense"></param>
        /// <returns></returns>
        protected Hero(string name, int damage, int health, int defense) : base(name, damage, health, defense)
        {

        }

        /// <summary>
        /// Override del método para atacar a otro Character. Se le agrega sumar 1 a LaPiedraEterna cada vez que derrota a otro Character.
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
                LaPiedraEterna += 1;
                
            }
        }

    
    }
}