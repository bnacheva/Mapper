package com.mapper.mapper.entity;

import javax.persistence.*;

@Entity
@Table(name = "groups")
public class Group {

    private Integer idGroup;
    private String nameGroup;

    Group() {}

    public Group(String _nameGroup) {
        this.nameGroup = _nameGroup;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getIdGroup() {
        return idGroup;
    }

    public void setIdGroup(Integer _idGroup) {
        this.idGroup = _idGroup;
    }

    @Column(name = "name", unique = true, nullable = false)
    public String getNameGroup() {
        return nameGroup;
    }

    public  void setNameGroup(String _nameGroup) {
        this.nameGroup = _nameGroup;
    }
}
