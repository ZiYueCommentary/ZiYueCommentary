using SCP.Command;
using SCP.Items;
using SCP.Rooms;
using ZiYue;

namespace SCP.Core
{
    public sealed class Game
    {
        public static readonly Game Instance;

        static Game() { 
            Instance = new Game();
        }

        public static void Main()
        {
            Console.WriteLine("======= CONSOLE =======");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Player player = new Player() { Permission = Permission.OWNER };
            for (; ; )
                Commander.ParseCommand(player, Console.ReadLine());
        }

        private Game() { }

        ~Game()
        {
            Console.WriteLine("Game Instance Terminated.");
        }
    }

    public sealed class Client
    {
        public static void SendPlayerMessage(Player player, string message)
        {

        }
    }

    public sealed class Player
    {
        public readonly string Name;
        public bool Moveable, Terminated, IsCrouching, Invisible;
        public float Health, Injuries, Bloodloss;
        public Zones CurrentZone;
        public Item[] Inventory;
        public Item[] QuickInventory = new Item[3];
        public Permission Permission;
        public IWearable Head = null, Body = null, Leg = null, Feet = null;

        public Player() : this("Player", 10) 
        {
        }

        public Player(string name) : this(name, 10) 
        { 
        }

        public Player(string name, byte inventorySlots)
        {
            Name = name;
            Inventory = new Item[inventorySlots];
            Lists.AddPlayer(this);
        }
    }

    public enum Permission
    {
        GUEST, NORMAL, ADMIN, OWNER
    }

    public sealed class Lists
    {
        private Lists() { }

        private static readonly Dictionary<string, Player> Players = new();
        private static readonly Dictionary<string, Item> Items = new();
        private static readonly Dictionary<string, Room> Rooms = new();

        public static void AddPlayer(Player Player)
        {
            Players.Add(Player.Name, Player);
        }

        public static void AddItem(Item Item)
        {
            Items.Add(Item.ID.ToLower(), Item);
        }

        public static void AddRoom(Room Room)
        {
            Rooms.Add(Room.ID.ToLower(), Room);
        }

        public static Player GetPlayer(string PlayerName)
        {
            return Players[PlayerName];
        }

        public static Item GetItem(string ItemID)
        {
            return Items[ItemID.ToLower()];
        }

        public static Room GetRoom(string RoomID)
        {
            return Rooms[RoomID.ToLower()];
        }

        public static void RemovePlayer(Player Player)
        {
            Players.Remove(Player.Name);
        }
    }

    public enum Zones
    {
        LIGHT_CONTAINMENT_ZONE,
        HEAVY_CONTAINMENT_ZONE,
        ENTRANCE_ZONE,
        POCKET_DIMENSION,
        SCP1499_DIMENSION
    }
}

public class PlaceHolder { }