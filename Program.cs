// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to the Dungeon Text Adventure Game!");
Console.WriteLine("");
Console.WriteLine("Command List:");
Console.WriteLine("!GetItem");
Console.WriteLine("!CheckRoom");

class Player
{
 public string Name;
 int health;
 public string Item;
 public Player(string name, int health, string item){
  Player character = new Player();
  character.Name = "Jim";
  character.health = 100;
  character.Item = "Hammer"; 
  Console.WriteLine(character.Name);
 }

 private Player()
 {
  throw new NotImplementedException();
 }
}

class Room
{
 private string Desc;
 private string Item;
}