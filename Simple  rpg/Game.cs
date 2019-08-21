using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple__rpg
{
    class Game
    {
        string playerName = "";
        int playerHealth = 100;
        public void Start()
        {

            Welcome();

            int monsterRemaining = 5;
            bool alive = true;

           //fight until you lose
            while (alive && monsterRemaining > 0)
            {
                Console.WriteLine("There are " + monsterRemaining + " monsters remaining.");
                alive = Encounter(20);
                monsterRemaining--;
            }
           
            
            //wait for user input before closing
            Console.ReadKey();
        }
        void Welcome()
        {
            //Welcome the player
            Console.Write("What is your name? ");
            playerName = Console.ReadLine();
            Console.WriteLine("Welcome, " + playerName + ".");

        }

        bool Encounter(int monsterDamage)
        {
            //Monster encounter!
            
            Console.WriteLine("");
            Console.WriteLine("There is a monster in front of you");

            string action = "";
            Console.Write("What will you do?(fight/flee) :o ");
            action = Console.ReadLine();
            if (action == "fight" || action == "Fight")
            {
                //monster attack
                Console.WriteLine("The monster attacks!" + playerName + " takes " + monsterDamage + " damage!");
                playerHealth = playerHealth - monsterDamage;
                Console.WriteLine(playerName + " has " + playerHealth + " health remaining.");
                if (playerHealth <= 0)
                {
                    //player defeat!
                    Console.WriteLine(playerName + " was defeated");
                    return false;
                }
                //player attack
                Console.WriteLine(playerName + " attack! The monster is defeated!");

            }
            else if (action == "flee" || action == "Flee")
            {

                //escape
                Console.WriteLine("You got away coward! ;(");

            }
            return true;
        }
    }
}
