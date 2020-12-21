using NUnit.Framework;
using Library.Characters;
using Library.Items;
using System.Collections.Generic;

namespace Library.Test
{
    public class CharacterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento del método ReceiveDamage que permite evaluar si la propiedad isDead funciona correctamente. En este caso se prueba que de true.
        /// </summary>

        [Test]
        public void ReceiveDamage_Value_UpdateHealthOrBooleanTrue()
        {   
           CharacterTestDummy character = new CharacterTestDummy("TestCharacter", 50,10,40);
           character.ReceiveDamage(50);
           Assert.AreEqual(character.Health,0);
           Assert.AreEqual(character.IsDead,true);
        
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento del método ReceiveDamage que permite evaluar si la propiedad isDead funciona correctamente. En este caso se prueba que de false.
        /// </summary>

        [Test]
        public void ReceiveDamage_Value_UpdateHealthOrBooleanFalse()
        {   
           CharacterTestDummy character = new CharacterTestDummy("TestCharacter", 50,10,40);
           character.ReceiveDamage(5);
           Assert.AreEqual(character.IsDead,false);
        
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento del método AddItem.
        /// </summary>

        [Test]
        public void AddItem_Item_UpdatedStats()
        {   
           CharacterTestDummy character = new CharacterTestDummy("TestCharacter",10,10,10);
           GenericItem item = new GenericItem("TestItem",10,10,0,false);
           character.AddItem(item);
           Assert.AreEqual(character.Damage,20);
           Assert.AreEqual(character.Defense,20);
        
        }

         /// <summary>
        /// Test que evalúa el correcto funcionamiento del método RemoveItem.
        /// </summary>

        [Test]
        public void RemoveItem_Item_UpdatedStats()
        {   
           CharacterTestDummy character = new CharacterTestDummy("TestCharacter",10,10,10);
           GenericItem item = new GenericItem("TestItem",10,10,0,false);
           character.AddItem(item);
           Assert.AreEqual(character.Damage,20);
           Assert.AreEqual(character.Defense,20);
           character.RemoveItem(item);
           Assert.AreEqual(character.Damage,10);
           Assert.AreEqual(character.Defense,10);
        }

        /// <summary>
        /// Test que evalúa el correcto funcionamiento del método AddItem para dos items.
        /// </summary>

        [Test]
        public void AddItem_TwoItems_UpdatedStats()
        {   
           CharacterTestDummy character = new CharacterTestDummy("TestCharacter",10,10,10);
           GenericItem item = new GenericItem("TestItem",10,10,0,false);
           GenericItem SecondItem = new GenericItem("SecondTestItem",10,10,0,false);
           character.AddItem(item);
           character.AddItem(SecondItem);
           Assert.AreEqual(character.Damage,30);
           Assert.AreEqual(character.Defense,30);
           
        }

        /// <summary>
        /// Test que evalúa que la vida no sea negativa
        /// </summary>

        [Test]
        public void ReceiveDamage_Value_NotNegativeLife()
        {   
           CharacterTestDummy character = new CharacterTestDummy("TestCharacter", 50,10,40);
           character.ReceiveDamage(60);
           Assert.AreEqual(character.Health,0);
           Assert.AreEqual(character.IsDead,true);
        
        }

        /// <summary>
        /// Test que evalúa que la defensea no se modifique si esta es mayor al ataque recibido.
        /// </summary>

        [Test]
        public void ReceiveDamage_Value_NotDefenseValuesUpdated()
        {   
           CharacterTestDummy character = new CharacterTestDummy("TestCharacter", 50,10,40);
           character.ReceiveDamage(10);
           Assert.AreEqual(character.Defense,40);
        
        }

        
      

    }

    /// <summary>
    /// Clase dummy que al heredar de Character se usa para crear una instancia de esta clase y poder llamar al método ReceiveDamage 
    /// que es el que se va a probar en el test ReceiveDamage_Value_UpdateHealthOrBoolean().
    /// </summary>
    internal class CharacterTestDummy : Character
    {
         public CharacterTestDummy(string name, int damage, int health, int defense) : base(name,damage,health,defense)
        {

        }
       
    }
}