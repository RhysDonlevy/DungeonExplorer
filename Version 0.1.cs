// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to the Dungeon Text Adventure Game!");
Console.WriteLine("");
Console.WriteLine("Command List:");
Console.WriteLine("!GetItem");
Console.WriteLine("!CheckRoom");

class Player
{
 private string Name;
 int health;
 private string Item;
}

class Room
{
 private string Desc;
 private string Item;
}