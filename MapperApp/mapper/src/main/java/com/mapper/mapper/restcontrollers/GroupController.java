package com.mapper.mapper.restcontrollers;

import com.mapper.mapper.entity.Group;
import com.mapper.mapper.services.GroupService;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/groups")
public class GroupController {
    private GroupService _groupService;

    @GetMapping(value = "/{idGroup}", produces = "application/json")
    public Group getUser(@PathVariable Integer idGroup){
        return _groupService.getGroupById(idGroup);
    }

    @PostMapping(value = "/create", produces = "application/json")
    public void CreateGroup(@RequestBody Group group) {
        _groupService.createGroup(group);
    }
}
