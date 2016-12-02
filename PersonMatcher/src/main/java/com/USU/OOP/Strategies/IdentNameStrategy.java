package com.USU.OOP.Strategies;

import com.USU.OOP.Person.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/7/16
 * Time: 7:46 PM
 * To change this template use File | Settings | File Templates.
 */

public class IdentNameStrategy extends MatchingStrategy {
    public IdentNameStrategy() { super(); }

    @Override
    protected boolean Compare() {
        if (first.get_socialSecurityNumber().equals(second.get_socialSecurityNumber())) {
            if (first.get_firstName().equals(second.get_firstName()) &&
                    first.get_middleName().equals(second.get_middleName()) &&
                    first.get_lastName().equals(second.get_lastName())) {
                return true;
            }
        }

        return false;
    }

    @Override
    protected boolean IsNull() {
        return (first.get_socialSecurityNumber().equals("null") || second.get_socialSecurityNumber().equals("null") ||
                first.get_firstName().equals("null") || second.get_firstName().equals("null") ||
                first.get_middleName().equals("null") || second.get_middleName().equals("null") ||
                first.get_lastName().equals("null") || second.get_lastName().equals("null"));
    }
}
