using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // GET: api/values
        [HttpGet]
        [Route("~/api/group")]  
        public async Task<IActionResult> Get()
        {
            var groups = await _groupService.GetGroupsAsync();

            return Ok(groups);
        }

        // POST api/values
        [HttpPost]
        [Route("~/api/group")]  
        public async void Post([FromBody]Group newGroup)
        {
            await _groupService.AddGroupAsync(newGroup);
        }
    }
}