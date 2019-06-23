package com.mapper.mapper.services;

import com.mapper.mapper.interfaces.IGroup;
import com.mapper.mapper.entity.Group;
import com.mapper.mapper.repository.GroupRepository;

import java.util.List;

public class GroupService implements IGroup {

    private GroupRepository _groupRepository;

    public GroupService(GroupRepository groupRepository) {
        _groupRepository = groupRepository;
    }

    public List<Group> getAllGroups() {
        return _groupRepository.findAll();
    }

    public Group getGroupById(Integer idGroup) {
        return _groupRepository.findByIdGroup(idGroup);
    }

    public void createGroup(Group newGroup) {
        Group group = new Group(
                newGroup.getNameGroup()
        );
        this._groupRepository.saveAndFlush(group);
    }

    public void deleteGroup(Integer idGroup) {
        Group group = _groupRepository.findByIdGroup(idGroup);
        if (group != null) {
            _groupRepository.deleteById(idGroup);
        }
    }
}
