using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class GroupService : IGroupService
    {
        private readonly DataContext _context;

        public GroupService(DataContext context) 
        {
            _context = context;
        }

        public async Task<List<Group>> GetGroupsAsync()
        {
            var groups = await _context.Groups.ToListAsync<Group>();

            return groups;
        }

        public async Task<bool> AddGroupAsync(Group newGroup)
        {
            if (string.IsNullOrWhiteSpace(newGroup.Name))
                throw new AppException("The group name is required!");

            if (_context.Groups.Any(x => x.Name == newGroup.Name))
                throw new AppException("Group name '" + newGroup.Name + "' is already taken");

            newGroup.Id = Guid.NewGuid();

            _context.Groups.Add(newGroup);

            var saveResults = await _context.SaveChangesAsync();

            return saveResults > 0;
        }
    }
}