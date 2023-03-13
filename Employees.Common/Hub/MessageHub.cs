using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Common.Hub
{
    public class MessageHub : Hub<IMessageHubClient>
    {
        public async Task SendOffersToUsers(List<string> message)
        {
            await Clients.All.SendOffersToUser(message);
        }
    }
}
