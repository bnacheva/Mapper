package com.mapper.mapper.services;

import com.mapper.mapper.interfaces.ILogic;
import com.mapper.mapper.entity.User;
import com.mapper.mapper.repository.GroupRepository;
import com.mapper.mapper.repository.UserRepository;

public class LogicService implements ILogic {

    private UserRepository _userRepository;
    private GroupRepository _groupRepository;

    public void enterGroup(Integer idGroup, User user) {
        if(_groupRepository.findByIdGroup(idGroup) != null) {
            _userRepository.findByIdUser(user.getIdUser()).setIdGroup(idGroup);
            _userRepository.findByIdUser(user.getIdUser()).setIsInside(true);
        }
    }
    public void exitGroup(Integer idGroup, User user) {
        if(_groupRepository.findByIdGroup(idGroup) != null) {
            _userRepository.findByIdUser(user.getIdUser()).setIdGroup(-1);
            _userRepository.findByIdUser(user.getIdUser()).setIsInside(false);
        }
    }
}
