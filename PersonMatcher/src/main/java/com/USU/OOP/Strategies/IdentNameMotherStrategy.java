package com.USU.OOP.Strategies;

import com.USU.OOP.Person.Child;
import com.USU.OOP.Person.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/7/16
 * Time: 7:47 PM
 * To change this template use File | Settings | File Templates.
 */

public class IdentNameMotherStrategy extends MatchingStrategy {
    private Child child;
    private Child c;
    public IdentNameMotherStrategy() { super(); }

    @Override
    protected boolean Compare() {
        if (child.get_newBornScreeningNumber().equals(c.get_newBornScreeningNumber())) {
            if (first.get_firstName().equals(second.get_firstName()) &&
                    first.get_middleName().equals(second.get_middleName()) &&
                    first.get_lastName().equals(second.get_lastName())) {
                if(child.get_motherFirstName().equals(c.get_motherFirstName()) &&
                        child.get_motherMiddleName().equals(c.get_motherMiddleName()) &&
                        child.get_motherLastName().equals(c.get_motherLastName())) {
                    return true;
                }
            }
        }
        return false;
    }

    @Override
    protected boolean HasNull() {
        if (first.getClass().getSimpleName().equals("Adult") || second.getClass().getSimpleName().equals("Adult")) {
            return true;
        }
        
        child = (Child) first;
        c = (Child) second;

        return (child.get_newBornScreeningNumber().equals("null") || c.get_newBornScreeningNumber().equals("null") ||
                first.get_firstName().equals("null") || second.get_firstName().equals("null") ||
                first.get_middleName().equals("null") || second.get_firstName().equals("null") ||
                first.get_lastName().equals("null") || second.get_lastName().equals("null") ||
                child.get_motherFirstName().equals("null") || c.get_motherFirstName().equals("null") ||
                child.get_motherMiddleName().equals("null") || c.get_motherMiddleName().equals("null") ||
                child.get_motherLastName().equals("null") || c.get_motherLastName().equals("null"));
    }
}
