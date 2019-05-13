package com.mapper.login.service;

import com.mapper.login.model.User;

public interface UserService {
    void save(User user);

    User findByUsername(String username);
}
