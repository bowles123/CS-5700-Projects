package com.USU.OOP.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/5/16
 * Time: 6:37 PM
 * To change this template use File | Settings | File Templates.
 */

public class Adult extends Person {
    private String _phoneOne;
    private String _phoneTwo;

    public String get_phoneOne() { return _phoneOne; }
    public String get_phoneTwo() { return _phoneTwo; }

    public void setPhoneNumbers(String one, String two) {
        _phoneOne = one;
        _phoneTwo = two;
    }
}
