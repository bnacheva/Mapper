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
            if (_context.Groups.Any(x => x.Name == newGroup.Name))
                throw new AppException("Group name '" + newGroup.Name + "' is already taken.");

            newGroup.Id = Guid.NewGuid();

            _context.Groups.Add(newGroup);

            var saveResults = await _context.SaveChangesAsync();

            return saveResults > 0;
        }

        public void RemoveGroup(Guid id)
        {
            var group = _context.Groups.Find(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                _context.SaveChanges();
            }
        }
    }
}