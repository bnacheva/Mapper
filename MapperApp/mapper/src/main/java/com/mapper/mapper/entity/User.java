package com.mapper.mapper.entity;

import javax.persistence.*;

@Entity
@Table(name = "users")
public class User {

    private Integer idUser;

    private String userName;

    private String userEmail;

    private String userPassword;

    private boolean isInside;

    private Integer idGroup;

    User() {}

    public User(String _userName, String _userEmail, String _userPassword) {
        this.userName = _userName;
        this.userEmail = _userEmail;
        this.userPassword = _userPassword;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getIdUser() {
        return idUser;
    }

    public void setIdUser(Integer _idUser) {
        this.idUser = _idUser;
    }

    @Column(name = "username", unique = true, nullable = false)
    public String getUserName() {
        return userName;
    }

    public void setUserName(String _userName) {
        this.userName = _userName;
    }

    @Column(name = "email", unique = true, nullable = false)
    public String getUserEmail() {
        return userEmail;
    }

    public void setUserEmail(String _userEmail) {
        this.userEmail = _userEmail;
    }

    @Column(name = "password", length = 60, nullable = false)
    public String getUserPassword() {
        return userPassword;
    }

    public void setUserPassword(String _userPassword) {
        this.userPassword = _userPassword;
    }

    @Column(name = "flag", columnDefinition = "boolean default false")
    public boolean getIsInside() {
        return isInside;
    }

    public void setIsInside(boolean _isInside) {
        this.isInside = _isInside;
    }

    @Column(name = "idGroup", columnDefinition = "default -1")
    public Integer getIdGroup() { return idGroup; }

    public void setIdGroup(Integer _idGroup) { this.idGroup = _idGroup; }
}