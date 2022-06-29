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
        public string Broadcast { get; set; } = "<size=60>Вы - <b><color=#008C21>МОГ Джаггернаут</color></b></size>\nНажмите на <b>[~]</b> для подробностей!";
        public string ConsoleMessage { get; set; } =
    "\n" +
    "<color=#FFFFFF>Вы -</color> <color=#008C21>МОГ Джаггернаут</color><color=#FFFFFF>!</color> <color=#FFFFF>Элитный боец</color> <color=#356FFF>Фонда</color><color=#FFFFFF>, вас отправили в комплекс.</color>\n" +
    "<color=#FFFFFF>Вы очень замедлены.</color>\n" +
    "<color=#FFFFFF>Вы играете за сторону MTF.</color>\n" +
    "<color=#FFFFFF>У вас повышенный запас здоровья.</color>\n" +
    "<color=#FFFFFF>Желаю приятной игры!</color>\n" +
    "<color=#73C5FF>Если возникнут баги, пожалуйста, отпишитесь о них к нам в дискорд: Discord.GG/hGANQR5n3f :D </color>";
        public string CustomInfo { get; set; } = "Джаггернаут МОГ";
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
