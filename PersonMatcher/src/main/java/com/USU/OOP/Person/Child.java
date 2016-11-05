package com.USU.OOP.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/5/16
 * Time: 6:37 PM
 * To change this template use File | Settings | File Templates.
 */

public class Child extends Person {
    private String _newBornScreeningNumber;
    private String _isPartOfMultipleBirth;
    private int _birthOrder;
    private String _birthCounty;
    private String _motherFirstName;
    private String _motherMiddleName;
    private String _motherLastName;

    public String get_newBornScreeningNumber() { return _newBornScreeningNumber; }
    public String get_isPartOfMultipleBirth() { return _isPartOfMultipleBirth; }
    public int get_birthOrder() { return _birthOrder; }
    public String get_birthCounty() { return _birthCounty; }
    public String get_motherFirstName() { return _motherFirstName; }
    public String get_motherMiddleName() { return _motherMiddleName; }
    public String get_motherLastName() { return _motherLastName; }

    public void set_newBornScreeningNumber(String nsn){
        _newBornScreeningNumber = nsn;
    }

    public void set_isPartOfMultipleBirth(String isPartOfMultipleBirth) {
        _isPartOfMultipleBirth = isPartOfMultipleBirth;
    }

    public void set_birthOrder(int birthOrder) {
        _birthOrder = birthOrder;
    }

    public void set_birthCounty(String birthCounty) {
        _birthCounty = birthCounty;
    }

    public void setMotherName(String first, String middle, String last) {
        _motherFirstName = first;
        _motherMiddleName = middle;
        _motherLastName = last;
    }
}
