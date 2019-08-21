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
        int playerMaxedHealth = 100;
        int playerHealth = 100;
        int playerDamage = 50;
        int MonsterHealth = 100;
        int playerHealing = 10;

        public void Start()
        {

            Welcome();

            int monsterRemaining = 5;
            bool alive = true;

           //fight until you lose
            while (alive && monsterRemaining > 0)
            {
                Console.WriteLine("There are " + monsterRemaining + " monsters remaining. Kill them all");
                alive = Encounter(20, 20);
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

        bool Encounter(int monsterHealth,int monsterDamage)
        {
           //Monster encounter!
            
           Console.WriteLine("");
           Console.WriteLine("There is a monster in front of you");

           string action = "";
           bool survived = true;
            while (playerHealth > 0 && monsterHealth > 0)
            {
                Console.Write("What will you do?(Fight/Flee or Heal) :o ");
                action = Console.ReadLine();
                if (action == "fight" || action == "Fight")
                {
                    survived = Fight(ref monsterHealth, ref monsterDamage);
                    if (!survived)
                    {
                        return false;
                    }
                }
                else if (action == "flee" || action == "Flee")
                {

                    //escape
                    survived = flee();
                    if (!survived)
                    {
                        return true;
                    }


                }
                else if (action == "heal" || action == "Heal") 
                {
                    //heal
                    survived = heal(ref playerHealing, ref monsterDamage, ref monsterHealth, ref playerMaxedHealth);
                    if (!survived)
                    {
                        return true;
                    }
                }
            }
            return survived;   
        }

        bool Fight(ref int monsterHealth,ref int monsterDamage)
        {
            //monster attack
            Console.WriteLine("The monster attacks!" + playerName + " takes " + monsterDamage + " damage!");
            playerHealth = playerHealth - monsterDamage;
            Console.WriteLine(playerName + " has " + playerHealth + " HP remaining.");
            if (playerHealth <= 0)
            {
                //player defeat!
                Console.WriteLine(playerName + " was defeated");
                return false;
            }
            //player attack
            Console.WriteLine(playerName + " attack! The monster takes " + playerDamage + " damage");
            monsterHealth -= playerDamage;
            Console.WriteLine("The monster has " + monsterHealth + " health remaining.");
            if (monsterHealth <= 0)
            {
                //monster defeat
                Console.WriteLine("Monster was defeated");
                return true;

            }  return true;
        } 

        bool flee()
        {
            Console.WriteLine("You got away coward! :(");
            return true;
            
        }

        bool heal(ref int playerHealing, ref int monsterDamage, ref int monsterHealth, ref int playerMaxedHealth)
        {
            
            //player heal
            Console.WriteLine(playerName + "  uses badages. " + playerHealing + " Healing");
            playerHealth += playerHealing;
            if (playerHealth > playerMaxedHealth)
            {
                playerHealth = playerMaxedHealth;
            }
            Console.WriteLine("You have  " + playerHealth + " health remaining.");
            return true;
           
            }
            
           
    }    
}
