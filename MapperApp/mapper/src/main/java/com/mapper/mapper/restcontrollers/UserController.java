package com.mapper.mapper.restcontrollers;

import com.mapper.mapper.entity.User;
import com.mapper.mapper.services.UserService;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/user")
public class UserController {

    private UserService _userService;

    @GetMapping(value = "/{idUser}", produces = "application/json")
    public User getUser(@PathVariable Integer idUser){
        return _userService.getUserById(idUser);
    }

    @PostMapping(value = "/register", produces = "application/json")
    public void Register(@RequestBody User user) {
        _userService.createUser(user);
    }

}
