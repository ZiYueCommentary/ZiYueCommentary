using SCP.Core;

namespace SCP.Rooms
{
    public class Room
    {
        public static readonly Dictionary<string, Room> Rooms = new();
        public static readonly List<Zones> ApplyZones = new();

        public readonly string Name, ID;

        public Room(string id, params Zones[] zones) : this(null, id)
        {
            ApplyZones.AddRange(zones);
        }

        public Room(string name, string id)
        {
            Name = name;
            ID = id;
            Lists.AddRoom(this);
        }
    }
}