package com.mapper.mapper.interfaces;

import com.mapper.mapper.entity.User;

import java.util.List;

public interface IUser {

    List<User> getAllUsers();
    User getUserById(Integer idUser);
    void createUser(User newUser);
    void deleteUser(Integer idUser);
}
