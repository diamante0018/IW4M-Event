# IW4M-Event
Anti AFK script for infected servers. Needs a game script to ban AFK players or ragequitters.
You need this InfinityScript (TeknoMW3) [AntiAFK](https://github.com/diamante0018/AntiAFK) for this IW4M plugin to work.
This plugin, once the game script identifies AFK players or ragequitters, will automatically temp ban them for 2 hours.

If you don't have TeknoMW3, or you want to write your game script implementation, you need to print the following string in the game logs for the IW4M plugin to take action.
It will work with any game as long as it follows this format:
AFK;GUID;EntityReference;PlayerName

TODO:
Add configurations so the ban time can be changed without recompilation.

Special thanks to [RaidMax](https://github.com/RaidMax)
