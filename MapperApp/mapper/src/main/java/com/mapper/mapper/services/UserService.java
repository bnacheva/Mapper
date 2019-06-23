package com.mapper.mapper.services;

import com.mapper.mapper.interfaces.IUser;
import com.mapper.mapper.entity.User;
import com.mapper.mapper.repository.UserRepository;

import java.util.List;

public class UserService implements IUser {

    private UserRepository _userRepository;

    public  UserService(UserRepository userRepository) {
        _userRepository = userRepository;
    }

    public List<User> getAllUsers() {

        return _userRepository.findAll();
    }

    public User getUserById(Integer idUser) {
        return _userRepository.findByIdUser(idUser);
    }

    public void createUser(User newUser) {
        User user = new User(
                newUser.getUserName(),
                newUser.getUserEmail(),
                newUser.getUserPassword()
        );
        this._userRepository.saveAndFlush(user);
    }

    public void deleteUser(Integer idUser) {
        User user = _userRepository.findByIdUser(idUser);
        if (user != null) {
            _userRepository.deleteById(idUser);
        }
    }
}
