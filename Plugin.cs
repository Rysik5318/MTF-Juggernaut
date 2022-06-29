using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtfJuggernaut
{
    class Plugin : Plugin<Config>
    {
        public override string Prefix => "mjug";
        public override string Name => "Mtf Juggernaut";
        public override string Author => "moseechev and Rysik5318";
        public static Plugin plugin;
        public bool Known = false;
        public List<Player> Jplayers = new List<Player>();
        public override Version Version { get; } = new Version(1, 1, 7);
        bool going = false;
        public override void OnEnabled()
        {
            plugin = this;
            base.OnEnabled();
            Exiled.Events.Handlers.Server.RestartingRound += OnRoundEnding;
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStart;
            Exiled.Events.Handlers.Player.Died += OnPlayerDie;
            Exiled.Events.Handlers.Player.ChangingRole += OnPlayerForceclass;
            Exiled.Events.Handlers.Player.Left += OnPlayerLeave;
        }

        private void OnPlayerDie(DiedEventArgs ev)
        {
            if (Jplayers.Contains(ev.Target))
            {
                Jplayers.Remove(ev.Target);
                ev.Target.CustomInfo = "";
                ev.Target.MaxHealth = 100;
            }
        }

        private void OnPlayerForceclass(ChangingRoleEventArgs ev)
        {
            if (Jplayers.Contains(ev.Player))
            {
                Jplayers.Remove(ev.Player);
                ev.Player.CustomInfo = "";
                ev.Player.MaxHealth = 100;
            }
        }

        private void OnPlayerLeave(LeftEventArgs ev)
        {
            if (Jplayers.Contains(ev.Player))
            {
                Jplayers.Remove(ev.Player);
            }
        }

        private void OnRoundEnding()
        {
            going = false;
            Jplayers.Clear();
        }

        /*private void OnDecontamination(DecontaminatingEventArgs ev)
        {
            List<Player> spectators = (List<Player>)Player.List.Where(x => x.Role == RoleType.Spectator);
            if (spectators.Count > 0)
            {
                Timing.CallDelayed(15f, () =>
                {
                    SpawnPlayer(spectators.RandomItem());
                });
            }
            else
            {
                Timing.CallDelayed(15f, () => repeating());
                Log.Debug($"В наблюдателях нет игроков, повторяем процедуру через 15 секунд!", Config.DebugMode);
            }
        }*/

        public override void OnDisabled()
        {
            plugin = null;
            Exiled.Events.Handlers.Server.RestartingRound -= OnRoundEnding;
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStart;
            Exiled.Events.Handlers.Player.Died -= OnPlayerDie;
            Exiled.Events.Handlers.Player.ChangingRole -= OnPlayerForceclass;
            Exiled.Events.Handlers.Player.Left -= OnPlayerLeave;
            base.OnDisabled();
        }

        private void OnRoundStart()
        {
            Random rnd = new Random();
            going = true;
            repeating();
            sus();
        }
        private void sus()
        {
            if (going)
            {
                foreach (Player player in Jplayers)
                {
                    player.EnableEffect<CustomPlayerEffects.Disabled>(10f, false);
                }
                Timing.CallDelayed(9f, () => sus());
            }
        }

        void repeating()
        {
            if (Round.ElapsedTime.TotalSeconds >= Config.SpawnTime)
            {
                List<Player> spectators = new List<Player>();
                foreach (Player player in Player.List)
                    if (player.Role.Team == Team.RIP)
                        spectators.Add(player);
                if (spectators.Count > 0)
                {
                    Log.Debug($"Найден спектатор!", Config.DebugMode);
                    SpawnPlayer(spectators.RandomItem());
                    if (Player.List.Where(x => x.Role.Team == Team.SCP).Count() > 0)
                    {
                        Timing.CallDelayed(3f, () => Cassie.Message(Config.Cassie.Replace("$scpstate", $"AwaitingRecontainment {Player.List.Where(x => x.Role.Team == Team.SCP).Count()} ScpSubjects"), false, true, Config.Subtitles));
                    }
                    else
                    {
                        Timing.CallDelayed(3f, () => Cassie.Message(Config.Cassie.Replace("$scpstate", "NoSCPsLeft"), false, true, Config.Subtitles));
                    }
                }
                else
                {
                    Timing.CallDelayed(10f, () => repeating());
                    Log.Debug($"В наблюдателях нет игроков, повторяем процедуру через 10 секунд!", Config.DebugMode);
                }
            }
            else
            {
                Timing.CallDelayed(10f, () => repeating());
                Log.Debug($"Время ещё не прошло, повторяем процедуру через 10 секунд!", Config.DebugMode);
            }
        }
        public void SpawnPlayer(Player player)
        {
            player.SetRole(Config.SpawnRole);
            player.ClearInventory();
            Timing.CallDelayed(1f, () => {
                foreach (ItemType item in Config.SpawnItems)
                {
                    player.AddItem(item);
                }
            });
            Timing.CallDelayed(2f, () => {
                foreach (KeyValuePair<AmmoType, ushort> entry in Config.SpawnAmmo)
                {
                    Timing.CallDelayed(0.1f, () => player.SetAmmo(entry.Key, entry.Value));
                }
            });
            player.UnitName = Config.UnitName;
            player.UnitName = Config.UnitName;
            player.Health = Config.Health;
            player.MaxHealth = (int)Config.Health;
            player.CustomInfo = Config.CustomInfo;
            player.Broadcast(10, Config.Broadcast, Broadcast.BroadcastFlags.Normal);
            player.SendConsoleMessage(Config.ConsoleMessage, "aqua");
            Jplayers.Add(player);
            Log.Debug($"Игрок {player.Nickname} стал Джаггернаутом!", Config.DebugMode);
            Timing.CallDelayed(8f, () => player.Health = Config.Health);
            Timing.CallDelayed(8f, () => player.MaxHealth = (int)Config.Health);
        }
    }
}
