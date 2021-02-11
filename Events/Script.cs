using SharedLibraryCore;
using SharedLibraryCore.Database.Models;
using SharedLibraryCore.Interfaces;
using System.Collections.Generic;
using EventGeneratorCallback = System.ValueTuple<string, string,
    System.Func<string, SharedLibraryCore.Interfaces.IEventParserConfiguration,
    SharedLibraryCore.GameEvent,
    SharedLibraryCore.GameEvent>>;

namespace IW4M_Event.Events
{
    public class Script : IRegisterEvent
    {
        private const string EVENT_AFK = "AFK";
        private EventGeneratorCallback AfkTB()
        {
            return (EVENT_AFK, EVENT_AFK, (string eventLine, IEventParserConfiguration config, GameEvent autoEvent) =>
            {
                string[] lineSplit = eventLine.Split(";");
                long originId = lineSplit[1].ConvertGuidToLong(config.GuidNumberStyle, 1);
                string playerName = lineSplit[3];

                autoEvent.Type = GameEvent.EventType.Other;
                autoEvent.Subtype = EVENT_AFK;
                autoEvent.Origin = new EFClient() { Name = playerName, NetworkId = originId };
                //autoEvent.RequiredEntity = GameEvent.EventRequiredEntity.Origin;
                autoEvent.GameTime = autoEvent.GameTime;

                return autoEvent;
            }
            );
        }

        public IEnumerable<EventGeneratorCallback> Events => new[] { AfkTB() };
    }
}