using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Services;
using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public class LocationHub : Hub
    {
        private readonly IGroupService _groupService;
        public int UsersOnline;

        public void SendLocationToAll(string name, string location)
        {
            Clients.All.SendAsync("sendLocationToAll", name, location);
        }

        public void SendLocationToGroup(string location) 
        {
            Clients.Group("SignalR Users").SendAsync("ReceiveLocation", location);
        }

        public LocationHub(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task AddGroup(string groupName)
        {
            Group newGroup = new Group()
            {
                Name = groupName
            };

            await _groupService.AddGroupAsync(newGroup);
            await Clients.All.SendAsync("NewGroup", groupName, newGroup.Id);
        }

        public override async Task OnConnectedAsync()
        {
            UsersOnline++;
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            UsersOnline--;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
    }
}