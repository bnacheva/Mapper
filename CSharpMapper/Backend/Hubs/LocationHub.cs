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

        public LocationHub(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task SendLocationToAll(string name, string location)
        {
            await Clients.All.SendAsync(name, location);
            Console.WriteLine("Error");
        }

        public async Task SendLocationToOne(string name, string location)
        {
            await Clients.Caller.SendAsync(name, location);
        }

        public async Task SendLocationToOthers(string name, string location)
        {
            await Clients.Others.SendAsync(name, location);
        }

        public async Task SendLocationToGroup(string group, string name, string location) 
        {
            await Clients.Group(group).SendAsync(name, location);
        }

        public async Task AddGroup(string groupName)
        {
            Group newGroup = new Group(){ Name = groupName };

            await _groupService.AddGroupAsync(newGroup);
            await Clients.All.SendAsync(groupName, newGroup.Id);
        }

        public override async Task OnConnectedAsync()
        {
            UsersOnline++;
            //string group = "";
            await Groups.AddToGroupAsync(Context.ConnectionId, "");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            UsersOnline--;
            //string group = "";
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "");
            await base.OnDisconnectedAsync(exception);
        }
    }
}