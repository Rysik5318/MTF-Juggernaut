using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtfJuggernaut
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool InvinsibleToColaDmg { get; set; } = true;
        public List<ItemType> SpawnItems { get; set; } = new List<ItemType>() { ItemType.ArmorHeavy, ItemType.GrenadeHE, ItemType.Adrenaline, ItemType.Medkit, ItemType.Radio, ItemType.GunE11SR, ItemType.KeycardNTFCommander };
        public RoleType SpawnRole { get; set; } = RoleType.NtfCaptain;
        public string Broadcast { get; set; } = "<size=60>You are - <b><color=#008C21>MTF Juggernaut</color></b></size>\nClick on <b>[~]</b> for details!";
        public string ConsoleMessage { get; set; } =
    "\n" +
    "    <color=#FFFFFF>You -</color> <color=#008C21>MTF Juggernaut</color><color=#FFFFFF>!</color> <color=#FFFFF>Elite Fighter</color> <color=#356FFF>Foundation</color><color=#FFFFFF>, you were sent to the facility.</color>\n" +
    "<color=#FFFFFF>You are very slow.</color>\n" +
    "<color=#FFFFFF>You are playing on the MTF side.</color>\n" +
    "<color=#FFFFFF>You have an increased health reserve.</color>\n" +
    "<color=#FFFFFF>I wish you a pleasant game!</color>\n" +
    "    <color=#73C5FF>If you encounter any bugs, please report them to us in discord: Discord.GG/hGANQR5n3f :D</color>";
        public string CustomInfo { get; set; } = "Juggernaut MTF";
        public bool Subtitles { get; set; } = false;
        public string Cassie { get; set; } = "Heavy MtfUnit Designated NATO_F 7  HasEntered AllRemaining   . $scpstate";
        public float Health { get; set; } = 500;
        public Dictionary<AmmoType, ushort> SpawnAmmo { get; set; } = new Dictionary<AmmoType, ushort>() {
            { AmmoType.Nato556, 300 }, { AmmoType.Nato762, 300 }, { AmmoType.Nato9, 300 }, { AmmoType.Ammo44Cal, 300 }, { AmmoType.Ammo12Gauge, 300 } };
        public string UnitName { get; set; } = "Heavy Juggernaut";
        public float SpawnTime { get; set; } = 900f;
        public bool DebugMode { get; set; } = false;
        public bool ShoulDoBlackouts { get; set; } = false;
    }
}
