package com.USU.OOP.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/5/16
 * Time: 6:37 PM
 * To change this template use File | Settings | File Templates.
 */

public abstract class Person {
    protected int _objectId;
    protected String _stateFileNumber;
    protected String _socialSecurityNumber;
    protected String _firstName;
    protected String _middleName;
    protected String _lastName;
    protected int _birthYear;
    protected int _birthMonth;
    protected int _birthDay;
    protected String _gender;

    public int get_objectId() { return _objectId; }
    public String get_stateFileNumber() { return _stateFileNumber; }
    public String get_socialSecurityNumber() { return _socialSecurityNumber; }
    public String get_firstName() { return _firstName; }
    public String get_middleName() { return _middleName; }
    public String get_lastName() { return _lastName; }
    public int get_birthDay() { return _birthDay; }
    public int get_birthMonth() { return _birthMonth; }
    public int get_birthYear() { return _birthYear; }
    public String get_gender() { return _gender; }

    public void set_objectId(int id) {
        if (id > 0) {
            _objectId = id;
        } else {
            _objectId = 0;
        }
    }

    public void set_stateFileNumber(String sfn) {
        _stateFileNumber = sfn;
    }

    public void set_socialSecurityNumber(String ssn) {
        if((ssn.contains("-") && ssn.length() == 11) || (!ssn.contains("-") && ssn.length() == 9)) {
            _socialSecurityNumber = ssn;
        } else {
            _socialSecurityNumber = "";
        }
    }

    public void setName(String first, String middle, String last) {
        _firstName = first;
        _middleName = middle;
        _lastName = last;
    }

    public void setBirthDate(int day, int month, int year) {
        _birthDay = day;
        _birthMonth = month;
        _birthYear = year;
    }

    public void setGender(String gender) {
        _gender = gender;
    }
}
