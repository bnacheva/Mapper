package com.mapper.mapper.repository;

import com.mapper.mapper.entity.User;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserRepository extends JpaRepository<User, Integer> {
    User findByIdUser(Integer idUser);
}
