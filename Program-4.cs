using System;
using System.Runtime.InteropServices;

namespace MyNamespace
{
    class Player
    {
        public string name;
        public int health = 100;
        public string item = "cloth garments";
    }
}

namespace MyNamespace
{
    class Room
    {
    public string Desc;
    public string roomItem;
    }
}

namespace MyNamespace
{
    class Game
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the TEXT DUNGEON GAME");
            Console.WriteLine("PLEASE ENTER YOUR NAME");
            
            Room room1 = new Room();
            room1.Desc = "You are in a small room";
            room1.roomItem = "WoodenSword";
            
            Player player1 = new Player();
            string name = Console.ReadLine();
            Console.WriteLine("Enter a Command");
            Console.WriteLine("!roomDesc");
            Console.WriteLine("!roomItem");
            Console.WriteLine("!playerDesc");
            
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
                Console.WriteLine("your hp is " + player1.health + " and you have " + player1.item);
            }
            else
            {
                Console.WriteLine("Invalid Command");
            }
            //Console.WriteLine(name);
        }
    }
}