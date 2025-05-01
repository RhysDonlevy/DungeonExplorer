using System;
using System.Runtime.InteropServices;

namespace DungeonGame
{
    //Initializes the Player Class
    class Player : Creature
    {
        public string item = "clothGarments";
        public static string itemDef = "clothGarments";
    }
}

//Initializes the Room Class
namespace DungeonGame
{
    class Room
    {
        public string Desc;
        public string roomItem;
        public string objective;
    }
}

class Item
{
    public string Desc;
}

class Weapon : Item
{
    public int attack;
}

class Potion : Item
{
    public int healthInc;
}

namespace DungeonGame
{
    abstract class Creature
    {
        public string name;
        public int health;
        public int attack;
    }
}

namespace DungeonGame
{
    class Monster : Creature
    {
        public int attack;
        public string info;
    }
}

//Main Body Of Code
namespace DungeonGame
{
    class Game
    {
        public static void StartGame(bool skipNameInput = false, string testName = "Player")
        {
            //Opening user prompt
            Console.WriteLine("Welcome to the TEXT DUNGEON GAME");

            string name;
            if (!skipNameInput)
            {
                Console.WriteLine("PLEASE ENTER YOUR NAME");
                name = Console.ReadLine();
            }
            else
            {
                name = testName;
                Console.WriteLine($"Test Mode: Player name is {name}");
            }

            //Room 1 Attributes
            Room room1 = new Room();
            room1.Desc = "You are in a small room, the walls are covered in jagged cobblestone and the air is moist";
            room1.roomItem = "WoodenSword ";
            room1.objective = "Find an item to start your adventure";

            //Room 2 Attributes
            Room room2 = new Room();
            room2.Desc = "you enter a larger room to the north encased in uniform stone";
            room2.roomItem = "Whip ";
            room2.objective = "Fight your first enemy";

            //Player setup
            Player player1 = new Player();
            player1.health = 100;
            player1.attack = 2;

            Console.WriteLine("Your Name is " + name +
                              " You are an Adventurer from a far off land known as the Baklands");
            Console.WriteLine("You have came to a secret Dungeon to the east in search of unimaginable riches ");

            //First Item
            Weapon WoodSword = new Weapon();
            WoodSword.Desc = "Wood Sword";
            WoodSword.attack = player1.attack * 2;

            //Second Item
            Potion HealingPotion = new Potion();
            HealingPotion.Desc = "Healing potion";
            HealingPotion.healthInc = 5;

            //First enemy attributes
            Monster goblin = new Monster();
            goblin.health = 4;
            goblin.attack = 2;
            goblin.name = "goblin";
            goblin.info = "a stout green creature with a wide grin has " + goblin.health + " health and " +
                          goblin.attack + " attack ";

            //Player Command List
            int monster = 0;
            int RoomId = 0;
            bool play = true;

            while (play)
            {
                Console.WriteLine("Enter a Command");
                Console.WriteLine("!roomDesc");
                Console.WriteLine("!roomItem");
                Console.WriteLine("!newRoom");
                Console.WriteLine("!playerDesc");
                Console.WriteLine("!playerObjective");
                Console.WriteLine("!defaultItem");
                Console.WriteLine("!exitGame");
                Console.WriteLine("!monsterCheck");

                string command = Console.ReadLine();
                //States what room player is in
                if (RoomId == 0)
                {
                    if (command == "!roomDesc")
                    {
                        Console.WriteLine(room1.Desc);
                    }
                    else if (command == "!roomItem")
                    {
                        Console.WriteLine("in this room you found a" + WoodSword.Desc);
                        player1.attack = WoodSword.attack;
                    }
                }
                else if (RoomId == 1)
                {
                    monster = 1;
                    if (command == "!roomDesc")
                    {
                        Console.WriteLine(room2.Desc);
                    }
                    else if (command == "!roomItem")
                    {
                        Console.WriteLine("in this room you found a" + HealingPotion.Desc);
                        player1.health = player1.health + HealingPotion.healthInc;
                    }
                }
                //States if a monsters in a room
                if (monster == 0)
                {
                    if (command == "!monsterCheck")
                    {
                        Console.WriteLine("there is no monster here");
                    }
                }
                else if (monster == 1)
                {
                    if (command == "!monsterCheck")
                    {
                        Console.WriteLine("there is a monster here");
                        Console.WriteLine("what do you want to do now?");
                        Console.WriteLine("!AttackMon");
                        Console.WriteLine("!monInfo");
                    }
                    else if (command == "!monInfo")
                    {
                        Console.WriteLine(goblin.info);
                    }
                    else if (command == "!AttackMon")
                    {
                        goblin.health = goblin.health - player1.attack;
                        Console.WriteLine(" the goblin now has " + goblin.health + " health ");
                        player1.health = player1.health - goblin.attack;
                        Console.WriteLine("The goblin also attacked you now have " + player1.health + " health ");

                        if (goblin.health == 0)
                        {
                            monster = 0;
                            Console.WriteLine("the goblin is defeated");
                        }
                    }
                }

                if (command == "!newRoom")
                {
                    RoomId = 1;
                    Console.WriteLine("You have entered a new room to the north");
                }
                else if (command == "!playerDesc")
                {
                    Console.WriteLine("your hp is " + player1.health + " and you have " + player1.item + " Equipped");
                }
                else if (command == "!playerObjective")
                {
                    Objective();
                }
                else if (command == "!defaultItem")
                {
                    Def();
                }
                else if (command == "!exitGame")
                {
                    play = false;
                    Console.WriteLine("Thanks for playing");
                }
                else if (command != "!roomDesc" && command != "!roomItem" && command != "!monsterCheck" &&
                         command != "!monInfo" && command != "!AttackMon")
                {
                    Console.WriteLine("Invalid Command");
                }
            }
        }
        // Misc Methods
        private static void Def()
        {
            Console.WriteLine("Your starting gear was " + Player.itemDef);
        }

        private static void Objective()
        {
            Console.WriteLine("Your current Objective is");
            Console.WriteLine("Find an Item in the room");
        }

        static void Main(string[] args)
        {
            StartGame();
        }
    }
}

// Test class to skip user input and start the game directly
    //class TestGame
    //{
        //static void Main(string[] args)
        //{
            //Game.StartGame(skipNameInput: true, testName: "Tester");
        //}
    //}
//}
