using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtfJuggernaut
{
    public class Config : IConfig
    {
        [Description("↓Indicates whether the plugin is enabled or not")]
        public bool IsEnabled { get; set; } = true;
        [Description("↓Indicates whether the Juggernaut will receive damage from the stake")]
        public bool InvinsibleToColaDmg { get; set; } = true;
        [Description("↓Specifies which items to get Juggernaut when spawning")]
        public List<ItemType> SpawnItems { get; set; } = new List<ItemType>() { ItemType.ArmorHeavy, ItemType.GrenadeHE, ItemType.Adrenaline, ItemType.Medkit, ItemType.Radio, ItemType.GunE11SR, ItemType.KeycardNTFCommander };
        [Description("↓Specifies the name of the squad after the nickname")]
        public RoleType SpawnRole { get; set; } = RoleType.NtfCaptain;
        [Description("↓Specifies which broadcast will be written to the player when the juggernaut appears")]
        public string Broadcast { get; set; } = "<size=60>You are - <b><color=#008C21>MTF Juggernaut</color></b></size>\nClick on <b>[~]</b> for details!";
        [Description("↓Specifies which message will be output to the console to the player")]
        public string ConsoleMessage { get; set; } =
    "\n   <color=#FFFFFF>You -</color> <color=#008C21>MTF Juggernaut</color><color=#FFFFFF>!</color> <color=#FFFFF>Elite Fighter</color> <color=#356FFF>Foundation</color><color=#FFFFFF>, you were sent to the facility.</color>\n" +
    "<color=#FFFFFF>You are very slow.</color>\n" +
    "<color=#FFFFFF>You are playing on the MTF side.</color>\n" +
    "<color=#FFFFFF>You have an increased health reserve.</color>\n" +
    "<color=#FFFFFF>I wish you a pleasant game!</color>\n" +
    "    <color=#73C5FF>If you encounter any bugs, please report them to us in discord: Discord.GG/hGANQR5n3f :D</color>";
        [Description("↓Specifies the name of the squad after the nickname")]
        public string CustomInfo { get; set; } = "Juggernaut MTF";
        [Description("↓Indicates whether subtitles will be used when playing cassie")]
        public bool Subtitles { get; set; } = false;
        [Description("↓Specifies which cassie will be played when the juggernaut appears")]
        public string Cassie { get; set; } = "Heavy MtfUnit Epsilon 11 Designated NATO_F 7  HasEntered AllRemaining   . $scpstate";
        [Description("↓Indicates the hp of the juggernaut")]
        public float Health { get; set; } = 500;
        [Description("↓Indicates which cartridges the juggernaut will receive when spawning")]
        public Dictionary<AmmoType, ushort> SpawnAmmo { get; set; } = new Dictionary<AmmoType, ushort>() {
            { AmmoType.Nato556, 300 }, { AmmoType.Nato762, 300 }, { AmmoType.Nato9, 300 }, { AmmoType.Ammo44Cal, 300 }, { AmmoType.Ammo12Gauge, 300 } };
        public string UnitName { get; set; } = "Heavy Juggernaut";
        [Description("↓Indicates the time in seconds before the spawn of the juggernaut")]
        public float SpawnTime { get; set; } = 900f;
        [Description("↓Indicates whether Debug Mode will work in the plugin")]
        public bool DebugMode { get; set; } = false;
    }
}
