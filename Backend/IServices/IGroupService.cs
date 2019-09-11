using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Services
{
    public interface IGroupService
    {
        Task<List<Group>> GetGroupsAsync();
        Task<bool> AddGroupAsync(Group newGroup);
    }
}