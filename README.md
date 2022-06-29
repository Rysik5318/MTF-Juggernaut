# MTF-Juggernaut
MTF Juggernaut plugin for SCP SL

# Description:
After a specified amount of time, the elite fighter spawns in.
It has slow speed, lots of HP, heavy armor and heavy guns.

# Default config:
```yaml
mjug:
  is_enabled: true
  invinsible_to_cola_dmg: true
  spawn_items:
  - ArmorHeavy
  - GrenadeHE
  - Adrenaline
  - Medkit
  - Radio
  - GunE11SR
  - KeycardNTFCommander
  spawn_role: NtfCaptain
  broadcast: >-
    <size=60>You are - <b><color=#008C21>MTF Juggernaut</color></b></size>

    Click on <b>[~]</b> for details!
  console_message: >2-

    <color=#FFFFFF>You -</color> <color=#008C21>MTF Juggernaut</color><color=#FFFFFF>!</color> <color=#FFFFF>Elite Fighter</color> <color=#356FFF>Foundation</color><color=#FFFFFF>, you were sent to the facility.</color>

    <color=#FFFFFF>You are very slow.</color>

    <color=#FFFFFF>You are playing on the MTF side.</color>

    <color=#FFFFFF>You have an increased health reserve.</color>

    <color=#FFFFFF>I wish you a pleasant game!</color>

    <color=#73C5FF>If you encounter any bugs, please report them to us in discord: Discord.GG/hGANQR5n3f :D</color>
  custom_info: MTF Juggernaut
  subtitles: false
  cassie: Heavy MtfUnit Designated NATO_F 7  HasEntered AllRemaining   . $scpstate
  health: 500
  spawn_ammo:
    Nato556: 300
    Nato762: 300
    Nato9: 300
    Ammo44Cal: 300
    Ammo12Gauge: 300
  unit_name: Heavy Juggernaut
  spawn_time: 900
  debug_mode: false
  shoul_do_blackouts: false
