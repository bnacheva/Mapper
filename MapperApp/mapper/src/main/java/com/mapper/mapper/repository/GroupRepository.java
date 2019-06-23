package com.mapper.mapper.repository;

import com.mapper.mapper.entity.Group;
import org.springframework.data.jpa.repository.JpaRepository;

public interface GroupRepository extends JpaRepository<Group, Integer> {
    Group findByIdGroup(Integer idGroup);
}
