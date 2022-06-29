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
    class SpawnJugNC : ParentCommand
    {
        public override string Command { get; } = "spawnjugbc";

        public override string[] Aliases { get; } = { "spawnjuggernautnopecassie", "spawnjnc" };

        public override string Description { get; } = "Spawns an MTF juggernaut, but cassie doesn't play.";

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
                Player sender1 = Player.Get(sender);

                if (Plugin.plugin.Jplayers.Contains(sender1))
                {
                    response = $"Player {sender1.Nickname} already a juggernaut!";
                    return false;
                }

                Plugin.plugin.SpawnPlayer(sender1);
                if (Player.List.Where(x => x.Role.Team == Team.SCP).Count() > 0)
                {
                    Timing.CallDelayed(3f, () => Cassie.Message(Plugin.plugin.Config.Cassie.Replace("$scpstate", $"AwaitingRecontainment {Player.List.Where(x => x.Role.Team == Team.SCP).Count()} ScpSubjects"), false, true, Plugin.plugin.Config.Subtitles));
                }
                else
                {
                    Timing.CallDelayed(3f, () => Cassie.Message(Plugin.plugin.Config.Cassie.Replace("$scpstate", "NoSCPsLeft"), false, true, Plugin.plugin.Config.Subtitles));
                }
                Log.Debug($"Игрок {Player.Get(sender).Nickname} под ID {Player.Get(sender).CustomUserId} заспавнил самого себя за Джагернаута.", Plugin.plugin.Config.DebugMode);
                response = $"Player {sender1.Nickname} became a Juggernaut!";
                return true;
            }

            Player player = Player.Get(arguments.At(0));
            if (player == null)
            {
                response = "This player does not exist. The player's ID or nickname is required!";
                return false;
            }

            if (Plugin.plugin.Jplayers.Contains(player))
            {
                response = $"Player {player.Nickname} already a juggernaut!";
                return false;
            }
            else
            {
                Plugin.plugin.SpawnPlayer(player);
                Log.Debug($"Игрок {Player.Get(sender).Nickname} под ID {Player.Get(sender).CustomUserId} заспавнил игрока {player.Nickname} за Джагернаута.", Plugin.plugin.Config.DebugMode);
                if (Player.List.Where(x => x.Role.Team == Team.SCP).Count() > 0)
                {
                    Timing.CallDelayed(3f, () => Cassie.Message(Plugin.plugin.Config.Cassie.Replace("$scpstate", $"AwaitingRecontainment {Player.List.Where(x => x.Role.Team == Team.SCP).Count()} ScpSubjects"), false, true, Plugin.plugin.Config.Subtitles));
                }
                else
                {
                    Timing.CallDelayed(3f, () => Cassie.Message(Plugin.plugin.Config.Cassie.Replace("$scpstate", "NoSCPsLeft"), false, true, Plugin.plugin.Config.Subtitles));
                }

                response = $"Player {player.Nickname} became a Juggernaut!";
                return true;
            }
            response = "amogus";
            return true;
        }
    }
}
