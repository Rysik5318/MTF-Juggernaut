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
        public override string Command { get; } = "spawnjug";

        public override string[] Aliases { get; } = { "spawnjuggernaut", "spawnj" };

        public override string Description { get; } = "Spawns an MTF juggernaut";

        public override void LoadGeneratedCommands()
        {

        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("mjugnc.spawn"))
            {
                response = "У вас нет разрешения. Нужное разрешение: mjugnc.spawn. Если вы считаете, что должны иметь это разрешение, пожалуйста, напишите Rysik5318#7967";
                return false;
            }

            if (arguments.Count == 0)
            {
                Player sender1 = Player.Get(sender);

                if (Plugin.plugin.Jplayers.Contains(sender1))
                {
                    response = $"Игрок {sender1.Nickname} уже Джагернаут!";
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
                response = $"Игрок {sender1.Nickname} стал Джаггернаутом!";
                return true;
            }

            Player player = Player.Get(arguments.At(0));
            if (player == null)
            {
                response = "Данного игрока не существует. Требуется ID игрока либо его никнейм!";
                return false;
            }

            if (Plugin.plugin.Jplayers.Contains(player))
            {
                response = $"Игрок {player.Nickname} уже Джагернаут!";
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

                response = $"Игрок {player.Nickname} стал Джаггернаутом!";
                return true;
            }
            response = "amogus";
            return true;
        }
    }
}
