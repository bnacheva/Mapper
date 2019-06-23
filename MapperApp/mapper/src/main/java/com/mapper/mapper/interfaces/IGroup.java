package com.mapper.mapper.interfaces;

import com.mapper.mapper.entity.Group;

import java.util.List;

public interface IGroup {
    List<Group> getAllGroups();
    Group getGroupById(Integer idGroup);
    void createGroup(Group newGroup);
    void deleteGroup(Integer idGroup);
}
