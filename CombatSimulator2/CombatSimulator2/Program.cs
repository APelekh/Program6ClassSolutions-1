using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game myGame = new Game();
            myGame.Play();
            //keep it open
            Console.ReadKey();
        }

    }

    /// <summary>
    /// Base class for an actor in our game. This actor can either be user controlled (player) or computer controlled (enemy).
    /// </summary>
    class Actor
    {
        public int HP { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get { return this.HP > 0; } }
        public Random RNG { get; set; }
        public Actor(int hp, string name)
        {
            this.HP = hp; this.Name = name; this.RNG = new Random();
        }
        public virtual void Attack(Actor actor) { }
    }

    /// <summary>
    /// Computer controlled actor
    /// </summary>
    class Enemy : Actor
    {

        public int DamageMultiplier { get; set; }
        //Constructor
        public Enemy(string name, int startingHP, int damageMultiplier)
            : base(startingHP, name)
        {
            //constructor is empty, because the base class contructor handles all the work
            this.DamageMultiplier = damageMultiplier;
        }

        //Do our attack method
        public override void Attack(Actor actor)
        {
            //80% to hit
            if (RNG.Next(0, 11) > 2)
            {
                //hit!, damage roll for 5-15 hp
                int damage = RNG.Next(5, 16) * this.DamageMultiplier;
                //we will hit the player
                actor.HP -= damage;
                //write the output to the console
                Console.WriteLine("{0} hit {1} for {2} damage!", this.Name, actor.Name, damage);
            }
            else
            {
                //miss
                Console.WriteLine("{0} missed {1}.", this.Name, actor.Name);
            }

        }

    }

    //enum for attack types
    public enum AttackType { Sword = 1, Magic, Heal }
    
    class Player : Actor
    {
        //Constructor
        public Player(string name, int startingHP)
            : base(startingHP, name)
        {
            //the base class Actor does all the work.
        }

        //create new function to choose attack
        private AttackType ChooseAttack()
        {
            //validated for your pleasure.
            bool validInput = false;
            int input = 0;
            do
            {
                Console.WriteLine(@"
Choose Attack:
1. Sword
2. Magic
3. Heal");
                //get input from user
                validInput = int.TryParse(Console.ReadLine(), out input) && (input > 0 && input < 4);
                if (validInput == false)
                {
                    Console.WriteLine("Invalid input");
                }
                //return the correct AttackType using a CAST
            } while (validInput == false);

            return (AttackType)input;
        }

        public override void Attack(Actor actor)
        {
            //use a switch statement to perform
            // the attack
            int damage; //variable to hold damage dealt

            switch (ChooseAttack())
            {
                case AttackType.Sword:
                    //70% chance to hit.
                    if (this.RNG.Next(0, 11) > 3)
                    {
                        //Hit! Deal 15-30 damage
                        damage = this.RNG.Next(15, 31);
                        //deal the damage to the enemy
                        actor.HP -= damage;
                        //write output to the user
                        Console.WriteLine("{0} deals {1} damage to {2}", this.Name, damage, actor.Name);
                    }
                    else
                    {
                        //missed
                        Console.WriteLine("{0} missed {1} with the sword!", this.Name, actor.Name);
                    }
                    break;
                case AttackType.Magic:
                    //magic always deal 5-15 damage
                    damage = this.RNG.Next(5, 16);
                    //deal damage to enemy
                    actor.HP -= damage;
                    //write to the console
                    Console.WriteLine("{0} did {1} damage to {2}", this.Name, damage, actor.Name);
                    break;
                case AttackType.Heal:
                    //always heals for 10-20
                    int amountToHealPlayer = this.RNG.Next(10, 21);
                    //heal the player
                    this.HP += amountToHealPlayer;
                    //write the results to the user
                    Console.WriteLine("{0} was healed for {1} HP!", this.Name, amountToHealPlayer);
                    break;
                default:
                    break;
            }
        }
    }

    class Game
    {
        //define properties
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }

        //Constructor
        public Game()
        {
            this.Player = new Player("The mighty Dustin", 100);
            this.Enemy = new Enemy("The mightier Pat", 200, 40);
        }

        //Methods!
        private void DisplayInfo()
        {
            //displays current hp totals for player and enemy
            Console.WriteLine("{0} {1} HP vs {2} {3} HP", Player.Name, Player.HP, Enemy.Name, Enemy.HP);

        }

        public void Play()
        {
            //playing while both are alive
            while (Player.IsAlive && Enemy.IsAlive)
            {
                DisplayInfo(); //show current HP
                Player.Attack(Enemy); //player attack enemy
                Enemy.Attack(Player); //enemy attack player
            }
            //someone died
            if (!Player.IsAlive)
            {
                Console.WriteLine("{0} hath been slain", this.Player.Name);
            }
            else
            {
                Console.WriteLine("{0} hath been defeated! There was much rejoicing.", this.Enemy.Name);
            }
        }
    }
}