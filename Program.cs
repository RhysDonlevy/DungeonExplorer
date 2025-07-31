using System;
using System.Runtime.InteropServices;
using DungeonGame;

namespace DungeonGame
//Creature Class Created 
{
    abstract class Creature
    {
        public string name;
        public double health;
        public int attack;

        
        public virtual void SetDifficulty(string diff)
        {
            Console.WriteLine("Choose a difficulty");
            Console.WriteLine("1: Easy");
            Console.WriteLine("2: Normal");
            Console.WriteLine("3: Hard");
        }
    }

    // Player class inherits from Creature
    class Player : Creature
    {
        public string item = "clothGarments";
        public static string itemDef = "clothGarments";

        // Override to scale players health based on difficulty
        public override void SetDifficulty(string diff)
        {
            switch (diff)
            {
                case "Easy":
                case "1":
                    health *= 1.5;
                    break;
                case "Normal":
                case "2":
                    health *= 1.0;
                    break;
                case "Hard":
                case "3":
                    health *= 0.5;
                    break;
                default:
                    Console.WriteLine("Invalid difficulty. Using Normal.");
                    health *= 1.0;
                    break;
            }
        }
    }

    // Monster class also inherits from Creature
    class Monster : Creature
    {
        public string info;

        // Override to scale monsters health based on difficulty
        public override void SetDifficulty(string diff)
        {
            switch (diff)
            {
                case "Easy":
                case "1":
                    health *= 0.5;
                    break;
                case "Normal":
                case "2":
                    health *= 1.0;
                    break;
                case "Hard":
                case "3":
                    health *= 1.5;
                    break;
                default:
                    Console.WriteLine("Invalid difficulty. Using Normal.");
                    health *= 1.0;
                    break;
            }
        }
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

//Initializes Item class and children classes
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

//Main Body Of Code
class Game
{
    public static void StartGame(bool skipNameInput = false, string testName = "Player")
    {
        //Opening user prompt
        Console.WriteLine("Welcome to the TEXT DUNGEON GAME");
        //For Testing class
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

        //Player setup
        Player player1 = new Player();
        player1.health = 100;
        player1.attack = 2;
        //Monster Setup
        Monster goblin = new Monster();
        goblin.health = 8;
        goblin.attack = 2;
        goblin.name = "goblin";
        goblin.info = goblin.name + ": a stout green creature with a wide grin has " + goblin.health +
                      " health and " +
                      goblin.attack + " attack ";

        // Difficulty setup
        Console.WriteLine("Choose a difficulty:");
        Console.WriteLine("1: Easy");
        Console.WriteLine("2: Normal");
        Console.WriteLine("3: Hard");
        string diff = Console.ReadLine();
        player1.SetDifficulty(diff);
        goblin.SetDifficulty(diff);
        //Room 1 Attributes
        Room room1 = new Room();
        room1.Desc =
            "You are in a small room, the walls are covered in jagged cobblestone and the air is moist";
        room1.roomItem = "WoodenSword ";
        room1.objective = "Find an item to start your adventure";

        //Room 2 Attributes
        Room room2 = new Room();
        room2.Desc = "you enter a larger room to the north encased in uniform stone";
        room2.roomItem = "nothing";
        room2.objective = "Fight your first enemy";

        //Room 3 Attributes
        Room room3 = new Room();
        room3.Desc = "You found a small treasure room small glistening rubys fill the walls";
        room3.roomItem = "potion";
        room3.objective = "gain a powerful item";

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

        //Player Command List
        int monster = 0;
        int RoomId = 1;
        bool play = true;

        while (play)
        {
            Console.WriteLine("Enter a Command");
            Console.WriteLine("!checkInv/0");
            Console.WriteLine("!roomDesc/1");
            Console.WriteLine("!roomItem/2");
            Console.WriteLine("!newRoom/3");
            Console.WriteLine("!playerDesc/4");
            Console.WriteLine("!playerObjective/5");
            Console.WriteLine("!defaultItem/6");
            Console.WriteLine("!monsterCheck/7");
            Console.WriteLine("!exitGame/8");

            string command = Console.ReadLine();
            //States what room player is in
            if (RoomId == 1)
            {
                if (command == "!roomDesc" || command == "1")
                {
                    Console.WriteLine(room1.Desc);
                }
                else if (command == "!roomItem" || command == "2")
                {
                    Console.WriteLine("in this room you found a " + WoodSword.Desc);
                    player1.attack = WoodSword.attack;
                    player1.item = " WoodSword " + player1.item;
                }
            }
            else if (RoomId == 2)
            {
                monster = 1;
                if (command == "!roomDesc" || command == "1")
                {
                    Console.WriteLine(room2.Desc);
                }
                else if (command == "!roomItem" || command == "2")
                {
                    Console.WriteLine("in this room you found no item");
                }
            }
            else if (RoomId == 0)
            {
                monster = 0;
                if (command == "!roomDesc" || command == "1")
                {
                    Console.WriteLine(room3.Desc);
                }
                else if (command == "!roomItem" || command == "2")
                {
                    Console.WriteLine("in this room you found a " + HealingPotion.Desc +
                                      " it can increase your health over max");
                    player1.health = player1.health + HealingPotion.healthInc;
                }

            }

            //States if a monsters in a room
            if (monster == 1)
            {
                if (command == "!monsterCheck" || command == "7")
                {
                    Console.WriteLine("there is a monster here");
                    Console.WriteLine("what do you want to do now?");
                    Console.WriteLine("!monInfo/9");
                    Console.WriteLine("!AttackMon/10");
                }
                else if (command == "!monInfo" || command == "9")
                {
                    Console.WriteLine(goblin.info);
                }
                else if (command == "!AttackMon" || command == "10")
                {
                    if (goblin.health <= 0)
                    {
                        Console.WriteLine("The goblin is already defeated.");
                        continue;
                    }

                    goblin.health -= player1.attack;
                    Console.WriteLine("The goblin now has " + goblin.health + " health");
                    player1.health -= goblin.attack;
                    Console.WriteLine(
                        "The goblin also attacked you. You now have " + player1.health + " health");

                    if (goblin.health <= 0)
                    {
                        monster = 0;
                        Console.WriteLine("The goblin is defeated");
                    }
                }
            }
            //States what happens if no monster in room
            if (monster == 0)
            {
                if (command == "!monsterCheck" || command == "7")
                {
                    Console.WriteLine("there is no monster here");
                }
            }
            //Player based commands and exit command
            if (command == "!checkInv" || command == "0")
            {
                Inventory(player1);
            }
            else if (command == "!newRoom" || command == "3")
            {
                Console.WriteLine("Choose a path north or south (n/s):");
                string direction = Console.ReadLine().ToLower();
                RoomId = direction switch
                {
                    "n" => RoomId + 1,
                    "s" => RoomId - 1,
                    _ => RoomId
                };
            }
            else if (command == "!playerDesc" || command == "4")
            {
                Console.WriteLine(
                    "your hp is " + player1.health + " and you have " + player1.item + " Equipped");
            }
            else if (command == "!playerObjective" || command == "5")
            {
                Objective(RoomId, room1, room2, room3);
            }
            else if (command == "!defaultItem" || command == "6")
            {
                Def();
            }
            else if (command == "!exitGame" || command == "8")
            {
                play = false;
                Console.WriteLine("Thanks for playing");
            }
            else if (command != "!roomDesc" && command != "!roomItem" && command != "!monsterCheck" &&
                     command != "!monInfo" && command != "!AttackMon" && command != "1" && command != "2" &&
                     command != "7" && command != "9" && command != "10" && command != "n" && command != "s")
            {
                Console.WriteLine("Invalid Command");
            }

            Console.WriteLine("press any key to proceed");
            Console.ReadKey(true);
            //Stops user from going out of bounds
            if (RoomId < 0)
            {
                Console.WriteLine("you cant go any more south");
                RoomId = 0;
            }
            else if (RoomId > 3)
            {
                Console.WriteLine("you cant go any more north");
                RoomId = 2;
            }
        }
    }

    // Misc Methods
    private static void Def()
    {
        Console.WriteLine("Your starting gear was " + Player.itemDef);
    }

    private static void Inventory(Player player1)
    {
        Console.WriteLine(" Your items are, " + player1.item);
    }

    private static void Objective(int roomId, Room room1, Room room2, Room room3)
    {
        string obj = roomId switch
        {
            1 => room1.objective,
            2 => room2.objective,
            0 => room3.objective,
            _ => "Explore the dungeon."
        };
        Console.WriteLine("Your current Objective is:");
        Console.WriteLine(obj);
    }
    //remove this method if wish to use test class
    static void Main(string[] args)
    {
    StartGame();
    }
}


//Test class to skip user input and start the game directly remove comments if wish to use 
    //class TestGame
    //{
        //static void Main(string[] args)
        //{
            //Game.StartGame(skipNameInput: true, testName: "Tester");
        //}
    //}
//}

