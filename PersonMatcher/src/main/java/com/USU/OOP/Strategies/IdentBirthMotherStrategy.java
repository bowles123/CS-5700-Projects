package com.USU.OOP.Strategies;

import com.USU.OOP.Person.Child;
import com.USU.OOP.Person.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/7/16
 * Time: 7:46 PM
 * To change this template use File | Settings | File Templates.
 */

public class IdentBirthMotherStrategy extends MatchingStrategy {
    private Child c;
    private Child child;
    public IdentBirthMotherStrategy() { super(); }

    @Override
    protected boolean Compare() {
        if (child.get_newBornScreeningNumber().equals(c.get_newBornScreeningNumber())) {
            if (first.get_birthDay() == second.get_birthDay() &&
                    first.get_birthMonth() == second.get_birthMonth() &&
                    first.get_birthYear() == second.get_birthYear()) {
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
                first.get_birthDay() <= 0 || second.get_birthDay() <= 0 ||
                first.get_birthMonth() <= 0 || second.get_birthMonth() <= 0 ||
                first.get_birthYear() <= 0 || second.get_birthYear() <= 0 ||
                child.get_motherFirstName().equals("null") || c.get_motherFirstName().equals("null") ||
                child.get_motherMiddleName().equals("null") || c.get_motherMiddleName().equals("null") ||
                child.get_motherLastName().equals("null") || c.get_motherLastName().equals("null"));
    }
}
