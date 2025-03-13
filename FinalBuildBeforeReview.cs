using System;
using System.Runtime.InteropServices;

namespace DungeonGame
{
    //Initializes the Player Class
    class Player
    {
        public string name;
        public int health = 100;
        public string item = "cloth garments";
        public static string itemDef = "cloth garments";
    }
}
   //Initializes the Room Class
namespace DungeonGame
{
    class Room
    {
        public string Desc;
        public string roomItem;
    }
}
//Main Body Of Code
namespace DungeonGame
{
    class Game
    {
        static void  Main(string[] args)
        {
            //Opening user prompt
            Console.WriteLine("Welcome to the TEXT DUNGEON GAME");
            Console.WriteLine("PLEASE ENTER YOUR NAME");
            //Room 1 Attributes
            Room room1 = new Room();
            room1.Desc = "You are in a small room, the walls are covered in jagged cobblestone and the air is moist";
            room1.roomItem = "WoodenSword ";
            //Player name input and backstory
            Player player1 = new Player();
            string name = Console.ReadLine();
            Console.WriteLine("Your Name is " + name + " You are an Adventurer from a far off land known as the Baklands");
            Console.WriteLine("You have came to a secret Dungeon to the east in search of unimaginable riches ");

            //Player Command List
            bool play = true;
            while (play)
            {

                Console.WriteLine("Enter a Command");
                Console.WriteLine("!roomDesc");
                Console.WriteLine("!roomItem");
                Console.WriteLine("!playerDesc");
                Console.WriteLine("!exitGame");
                Console.WriteLine("!DefaultItem");
                string command = Console.ReadLine();

                if (command == "!roomDesc")
                {
                    Console.WriteLine(room1.Desc);
                }
                else if (command == "!roomItem")
                {
                    Console.WriteLine("in this room you found" + room1.roomItem);
                    player1.item = room1.roomItem + player1.item;
                }
                else if (command == "!playerDesc")
                {
                    Console.WriteLine("your hp is " + player1.health + " and you have " + player1.item + " Equipped");
                }
                else if (command == "!exitGame")
                {
                    play = false;
                    Console.WriteLine("Thanks for playing");
                }
                else if (command == "!DefaultItem")
                {
                    def();
                }
                else
                {
                    Console.WriteLine("Invalid Command");
                }
                //Console.WriteLine(name);
            }
        }

        private static void def()
        {
            Console.WriteLine("Your starting gear was "+Player.itemDef);    
        }
    }
}
