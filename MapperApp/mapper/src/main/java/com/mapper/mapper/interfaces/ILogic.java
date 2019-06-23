package com.mapper.mapper.interfaces;

import com.mapper.mapper.entity.User;

public interface ILogic {
    void enterGroup(Integer idGroup, User user);
    void exitGroup(Integer idGroup, User user);
}
