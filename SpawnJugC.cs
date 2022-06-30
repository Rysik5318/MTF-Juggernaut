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
    class SpawnJugC : ParentCommand
    {
        public override string Command { get; } = "spawnjugc";

        public override string[] Aliases { get; } = { "spawnjuggernautcassie", "spawnjc" };

        public override string Description { get; } = "Spawns an MTF juggernaut with Cassie message.";

        public override void LoadGeneratedCommands()
        {

        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("mjugnc.spawn"))
            {
                response = "You don't have permission. Required permission: mjugnc.spawn. If you think you should get this permission, please write to the server admin.";
                return false;
            }

            if (arguments.Count == 0)
            {
                Player currentPlayer = Player.Get(sender);

                if (Plugin.plugin.MtfJuggernautPlayers.Contains(currentPlayer))
                {
                    response = $"Player {currentPlayer.Nickname} is already a n MTF Juggernaut!";
                    return false;
                }

                Plugin.plugin.SpawnPlayer(currentPlayer);

                ScpStateCassie(currentPlayer);

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
                ScpStateCassie(player);
                Log.Debug($"Player {Player.Get(sender).Nickname} with {Player.Get(sender).CustomUserId} ID spawned {player.Nickname} as an MTF Juggernaut.", Plugin.plugin.Config.DebugMode);
                response = $"Player {player.Nickname} became an MTF Juggernaut!";
                return true;
            }
        }

        public void ScpStateCassie(Player player){
            int scpPlayers = Player.List.Count(x => x.Role.Team == Team.SCP);
            if (scpPlayers > 0)
            {
                Timing.CallDelayed(3f, () => Cassie.Message(Plugin.plugin.Config.Cassie.Replace("$scpstate", $"AwaitingRecontainment {scpPlayers} ScpSubjects"), false, true, Plugin.plugin.Config.Subtitles));
            }
            else
            {
                Timing.CallDelayed(3f, () => Cassie.Message(Plugin.plugin.Config.Cassie.Replace("$scpstate", "NoSCPsLeft"), false, true, Plugin.plugin.Config.Subtitles));
            }
        }
    }
}
