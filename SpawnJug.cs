using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtfJuggernaut
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class SpawnJug : ParentCommand
    {
        public override string Command { get; } = "spawnjug";

        public override string[] Aliases { get; } = { "spawnjuggernaut", "spawnj" };

        public override string Description { get; } = "Spawns an MTF juggernaut";

        public override void LoadGeneratedCommands()
        {
            
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("mjug.spawn"))
            {
                response = "You don't have permission. Required permission: mjug.spawn. Please reffer to the server admin if you think you should have this permission,";
                return false;
            }

            if (arguments.Count == 0)
            {
                Player currentPlayer = Player.Get(sender);

                if (Plugin.plugin.MtfJuggernautPlayers.Contains(currentPlayer))
                {
                    response = $"Player {currentPlayer.Nickname} is already an MTF Juggernaut!";
                    return false;
                }

                Plugin.plugin.SpawnPlayer(currentPlayer);
                Log.Debug($"Player {Player.Get(sender).Nickname} with {Player.Get(sender).CustomUserId} ID spawned themselves as an MTF Juggernaut.", Plugin.plugin.Config.DebugMode);
                response = $"Player {currentPlayer.Nickname} has became a Juggernaut!";
                return true;
            }

            Player player = Player.Get(arguments.At(0));
            if (player == null)
            {
                response = "This player does not exist. The player's ID or nickname is required!";
                return false;
            }

            if (Plugin.plugin.MtfJuggernautPlayers.Contains(player))
            {
                response = $"Player {player.Nickname} is already an MTF Juggernaut!";
                return false;
            }
            else
            {
                Plugin.plugin.SpawnPlayer(player);
                Log.Debug($"Игрок {Player.Get(sender).Nickname} with {Player.Get(sender).CustomUserId} ID spawned {player.Nickname} as an MTF Juggernaut.", Plugin.plugin.Config.DebugMode);

                response = $"Player {player.Nickname} became an MTF Juggernaut!";
                return true;
            }
        }
    }
}
