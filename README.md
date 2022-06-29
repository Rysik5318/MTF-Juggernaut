# MTF-Juggernaut
MTF Juggernaut plugin for SCP SL

# Description:
After a specified amount of time, the elite fighter spawns in.
It has slow speed, lots of HP, heavy armor and heavy guns.

# Default config:
```yaml
mjug:
# ↓Indicates whether the plugin is enabled or not
  is_enabled: true
  # ↓Indicates whether the Juggernaut will receive damage from the stake
  invinsible_to_cola_dmg: true
  # ↓Specifies which items to get Juggernaut when spawning
  spawn_items:
  - ArmorHeavy
  - GrenadeHE
  - Adrenaline
  - Medkit
  - Radio
  - GunE11SR
  - KeycardNTFCommander
  # ↓Specifies the name of the squad after the nickname
  spawn_role: NtfCaptain
  # ↓Specifies which broadcast will be written to the player when the juggernaut appears
  broadcast: >-
    <size=60>You are - <b><color=#008C21>MTF Juggernaut</color></b></size>

    Click on <b>[~]</b> for details!
  # ↓Specifies which message will be output to the console to the player
  console_message: >2-

        <color=#FFFFFF>You -</color> <color=#008C21>MTF Juggernaut</color><color=#FFFFFF>!</color> <color=#FFFFF>Elite Fighter</color> <color=#356FFF>Foundation</color><color=#FFFFFF>, you were sent to the facility.</color>
    <color=#FFFFFF>You are very slow.</color>

    <color=#FFFFFF>You are playing on the MTF side.</color>

    <color=#FFFFFF>You have an increased health reserve.</color>

    <color=#FFFFFF>I wish you a pleasant game!</color>
        <color=#73C5FF>If you encounter any bugs, please report them to us in discord: Discord.GG/hGANQR5n3f :D</color>
  # ↓Specifies the name of the squad after the nickname
  custom_info: Juggernaut MTF
  # ↓Indicates whether subtitles will be used when playing cassie
  subtitles: false
  # ↓Specifies which cassie will be played when the juggernaut appears
  cassie: Heavy MtfUnit Designated NATO_F 7  HasEntered AllRemaining   . $scpstate
  # ↓Indicates the hp of the juggernaut
  health: 500
  # ↓Indicates which cartridges the juggernaut will receive when spawning
  spawn_ammo:
    Nato556: 300
    Nato762: 300
    Nato9: 300
    Ammo44Cal: 300
    Ammo12Gauge: 300
  unit_name: Heavy Juggernaut
  # ↓Indicates the time in seconds before the spawn of the juggernaut
  spawn_time: 900
  # ↓Indicates whether Debug Mode will work in the plugin
  debug_mode: false
```
