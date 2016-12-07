package com.USU.OOP.Strategies;

import com.USU.OOP.Person.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/7/16
 * Time: 7:45 PM
 * To change this template use File | Settings | File Templates.
 */

public class IdentBirthStrategy extends MatchingStrategy {
    public IdentBirthStrategy() { super(); }

    @Override
    protected boolean Compare() {
        if (first.get_socialSecurityNumber().equals(second.get_socialSecurityNumber())) {
            if (first.get_birthDay() == second.get_birthDay() &&
                    first.get_birthMonth() == second.get_birthMonth() &&
                    first.get_birthYear() == second.get_birthYear()) {
                return true;
            }
        }
        return false;
    }

    @Override
    protected boolean HasNull() {
        return (first.get_socialSecurityNumber().equals("null") || second.get_socialSecurityNumber().equals("null") ||
                first.get_birthDay() <= 0 || second.get_birthDay() <= 0 ||
                first.get_birthMonth() <= 0 || second.get_birthMonth() <= 0 ||
                first.get_birthYear() <= 0 || second.get_birthYear() <= 0);
    }
}
