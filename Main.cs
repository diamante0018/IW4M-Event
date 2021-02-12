using SharedLibraryCore;
using SharedLibraryCore.Database.Models;
using SharedLibraryCore.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IW4M_Event
{
    public class Main : IPlugin
    {
        public string Name => "Anti AFK";

        public float Version => 1.0f;

        public string Author => "Diavolo#6969";

        private readonly IEntityService<EFClient> _clientEntityService;

        public Main(IEntityService<EFClient> clientEntityService)
        {
            _clientEntityService = clientEntityService;
        }

        public async Task OnEventAsync(GameEvent E, Server S)
        {
            if (E.Type == GameEvent.EventType.Other && E.Subtype == "AFK")
            {
                long playerGUID = E.Origin.NetworkId;
                string playerName = E.Origin.Name;

                var AFKUpdate = AFKEvent.Parse(playerName, playerGUID);
                var client = S.Manager.GetActiveClients().FirstOrDefault(_client => _client.NetworkId == AFKUpdate.Guid);
                var sender = Utilities.IW4MAdminClient(E.Owner);

                if (client != null)
                {
                    client.TempBan("You broke the rules of our Infected Server", new TimeSpan(2, 0, 0), sender);
                }

                else
                {
                    var existingClient = await _clientEntityService.GetUnique(AFKUpdate.Guid);
                    if (existingClient != null)
                    {
                        var dbClient = await _clientEntityService.Get(existingClient.ClientId);
                        dbClient.TempBan("You broke the rules of our Infected Server", new TimeSpan(2, 0, 0), sender);
                    } 
                }
            }
        }

        public Task OnLoadAsync(IManager manager) => Task.CompletedTask;

        public Task OnTickAsync(Server S) => Task.CompletedTask;

        public Task OnUnloadAsync() => Task.CompletedTask;
    }
}