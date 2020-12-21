// Se usa agregación, ya que se guardan instancias de Hero y Villain en listas.
// Se usa polimorfismo en el método WinElementalGem ya que utiliza el método AddItem de Character y funciona correctamente para cualquier subtipo de Character. Sin embargo tambien se viola polimorfismo en el método BattleEncounter porque se pregunta por el tipo del Character para separarlos en listas distintas.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Characters;
using Library.Items;

namespace Library.Encounters
{   
    /// <summary>
    /// La clase BattleEncounter representa un encuentro de batalla.
    /// </summary>
    public class BattleEncounter : Encounter
    {   
        /// <summary>
        /// Lista de heroes.
        /// </summary>
        private List<Hero> listOfHero;

        public ReadOnlyCollection<Hero> ListOfHero => listOfHero.AsReadOnly();


        /// <summary>
        /// Lista de villanos.
        /// </summary>
        private List<Villain> listOfVillain;

        public ReadOnlyCollection<Villain> ListOfVillain => listOfVillain.AsReadOnly();

        /// <summary>
        /// Constructor de la clase BatlleEncounter.
        /// </summary>
        public BattleEncounter(List<Character> listOfCharacter) : base(listOfCharacter)
        {   
            listOfHero = new List<Hero>();
            listOfVillain = new List<Villain>();
            foreach (Character character in listOfCharacter)
            {
                switch (character)
                {
                    case Hero hero:
                        listOfHero.Add(hero);
                        break;
                    case Villain villain:
                        listOfVillain.Add(villain);
                        break;
                }
            }
            
        }

        /// <summary>
        /// Método de batalla. Se repetirá hasta que todos los héroes o todos los villanos hayan muerto.
        /// </summary>
        public override void Excecute() //Antes llamado fight
        {            
            while (listOfHero.Count >= 1  && listOfVillain.Count >= 1)
            {
                VillainTurn();
                CheckIfDead();
                HeroTurn();
                CheckVP();
            }
        }

        /// <summary>
        /// Método que representa el turno de los villanos para atacar a los héroes.
        /// </summary>
        public void VillainTurn()
        {   
            if (listOfHero.Count == 1)
            {
                foreach (Villain villain in listOfVillain)
                {
                    villain.DoDamage(villain.Damage,listOfHero[0]);
                    
                    if (listOfHero[0].IsDead == true)
                    {
                        return;
                    }
                }
            }
            else if (listOfHero.Count >= 1  && listOfVillain.Count == listOfHero.Count)
            {
                for (int i = 0; i < listOfVillain.Count; i++)
                {
                    listOfVillain[i].DoDamage(listOfVillain[i].Damage,listOfHero[i]);
                    
                }
            }
            else if (listOfHero.Count < listOfVillain.Count || listOfHero.Count > listOfVillain.Count)
            {   
                int heroIndex = 0;

                foreach (Villain villain in listOfVillain)
                {
                    villain.DoDamage(villain.Damage,listOfHero[heroIndex]);

                    CheckIfDead();
                   
                    if (heroIndex == listOfHero.Count)
                    {
                        heroIndex = 0;
                    }
                    else
                    {
                        heroIndex += 1;
                    }
                }
            }
            
        }

        /// <summary>
        /// Método que representa el turno de los héroes para atacar a los villanos.
        /// </summary>
        public void HeroTurn()
        {
            foreach (Hero hero in listOfHero)
            {
                foreach (Villain villain in listOfVillain)
                {
                    hero.DoDamage(hero.Damage,villain);

                    if (villain.IsDead == true)
                    {
                        hero.AddVictoryPoint(villain.VictoryPoint);
                        listOfVillain.Remove(villain);
                    }
                }
            }
        }

        /// <summary>
        /// Método que verifica si todos los héroes o todos los villanos murieron.
        /// </summary>
        public void CheckIfDead ()
        {
            foreach (Villain villain in listOfVillain)
            {
                if (villain.IsDead == true)
                {
                    listOfVillain.Remove(villain);
                }
            }

            foreach (Hero hero in listOfHero)
            {
                if (hero.IsDead == true)
                {
                    listOfHero.Remove(hero);
                }
            }
        }

        /// <summary>
        /// Método que verifica si el héroe consiguió 5 vp y lo cura.
        /// </summary>
        public void CheckVP ()
        {
            foreach (Hero hero in listOfHero)
            {
                if (hero.VictoryPoint >= 5)
                {
                    int lifeToRecover = hero.InitialHealth-hero.Health;
                    hero.Cure(lifeToRecover);

                }
            }
        }

        /// <summary>
        /// Método que agrega una gema elemental al personaje de forma aleatoria.
        /// </summary>
        /// <param name="character"></param>
        public void WinElementalGem (Character character)
        {
            Random random = new Random();
            int number = random.Next(0,100);
            if (number <= 10)
            {   
                ElementalGem gem = new ElementalGem("Gema elemental",false);
                character.AddItem(gem);
            }
        }
    }
}