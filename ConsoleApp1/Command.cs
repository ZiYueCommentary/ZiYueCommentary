using SCP.Core;

namespace SCP.Command
{
    public class Commander
    {
        public static void ParseCommand(Player player, string command)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (command == "") return;
            try
            {
                List<string> strings = new(ZiYue.CommandParser.Parse(command));
                Command command1 = CommandList.Commands[strings[0]];
                strings.RemoveAt(0);
                try
                {
                    if (command1.requirePermission > player.Permission) throw new NotEnoughPermissionException();
                    if ((strings.Count != command1.argumentNumber) && (command1.argumentNumber != null)) throw new IndexOutOfRangeException();
                    command1.execute(strings.ToArray());
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Error.WriteLine("Require {0} arguments, current is {1}.", command1.argumentNumber, strings.Count);
                }
                catch (NotEnoughPermissionException)
                {
                    Console.Error.WriteLine("Require {0} permission, current is {1}.", command1.requirePermission, player.Permission);
                }
            }
            catch (KeyNotFoundException)
            {
                Console.Error.WriteLine("Command not found.");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }

    public class NotEnoughPermissionException : Exception
    {
        public NotEnoughPermissionException() { }
        public NotEnoughPermissionException(string message) : base(message) { }
        public NotEnoughPermissionException(string message, Exception inner) : base(message, inner) { }
        protected NotEnoughPermissionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public sealed class CommandList
    {
        private CommandList() { }

        public static readonly Dictionary<string, Command> Commands = new();

        public static readonly Command HELP = new("help", 1, Permission.GUEST, args => { switch (args[0])
            {
                case "quit":
                    Console.WriteLine("Exit the game.");
                    break;
                case "permission":
                    Console.WriteLine("Set player's permission.");
                    break;
                case "kick":
                    Console.WriteLine("Kick a player, require ADMIN permission.");
                    break;
                default:
                    Commands.ToList().ForEach(command => Console.WriteLine(command.Key));
                    break;
            }
        });
        public static readonly Command QUIT = new("quit", 0, Permission.GUEST, args => Environment.Exit(0));
        public static readonly Command PERMISSION = new("permission", 2, Permission.OWNER, args => Lists.GetPlayer(args[0]).Permission = (Permission)int.Parse(args[1]));
        public static readonly Command KICK = new("kick", 2, Permission.ADMIN, args =>
        {
            try
            {
                Lists.RemovePlayer(Lists.GetPlayer(args[0]));
                Console.WriteLine("Kicked player: {0}, reason: {1}.", args[0], args[1]);
            }
            catch (KeyNotFoundException)
            {
                Console.Error.WriteLine("Player not found: {0}", args[0]);
            }
        });
        public static readonly Command PLAYERSTATES = new("playerstates", 1, Permission.GUEST, args =>
        {
            try
            {
                Player player = Lists.GetPlayer(args[0]);
                Console.WriteLine("===== Player States =====");
                Console.WriteLine("Name: {0}", player.Name);
                Console.WriteLine("Permission: {0}", player.Permission);
                Console.WriteLine("Current Zone: {0}", player.CurrentZone);
            }
            catch (KeyNotFoundException)
            {
                Console.Error.WriteLine("Player not found: {0}", args[0]);
            }
        });
        public static readonly Command SETPERMISSION = new("setpermission", 2, Permission.OWNER, args => { 
            Command command = Commands[args[0]];
            Command newCommand = new(command.name, command.argumentNumber, (Permission)int.Parse(args[1]), command.execute);
            Commands[args[0]] = newCommand;
        });
        public static readonly Command reflection = new("reflection", null, Permission.ADMIN, args => Commands[args[0]].execute(args[1..]));
    }

    public sealed class Command
    {
        public delegate void Run(params string[] args);

        public readonly string name;
        public readonly byte? argumentNumber;
        public readonly Permission requirePermission;
        public readonly Run execute;

        public Command(string name, byte? argumentNumber, Permission requirePermission, Run runnable)
        {
            this.name = name;
            this.argumentNumber = argumentNumber;
            this.requirePermission = requirePermission;
            execute = runnable;

            CommandList.Commands[name] = this;
        }
    }
}
