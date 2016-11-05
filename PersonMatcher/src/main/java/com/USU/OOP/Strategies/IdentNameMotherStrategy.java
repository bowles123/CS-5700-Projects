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

public class IdentNameMotherStrategy implements MatchingStrategy {
    public IdentNameMotherStrategy() { super(); }

    @Override
    public String match(Person person1, Person person2) {
        if (person1.getClass().getSimpleName().equals("Adult") || person2.getClass().getSimpleName().equals("Adult")) {
            return null;
        }
        
        Child child = (Child) person1;
        Child c = (Child) person2;

        if (child.get_newBornScreeningNumber().equals("null") || c.get_newBornScreeningNumber().equals("null") ||
                person1.get_firstName().equals("null") || person2.get_firstName().equals("null") ||
                person1.get_middleName().equals("null") || person2.get_firstName().equals("null") ||
                person1.get_lastName().equals("null") || person2.get_lastName().equals("null") ||
                child.get_motherFirstName().equals("null") || c.get_motherFirstName().equals("null") ||
                child.get_motherMiddleName().equals("null") || c.get_motherMiddleName().equals("null") ||
                child.get_motherLastName().equals("null") || c.get_motherLastName().equals("null")) {
            return null;
        }

        if (child.get_newBornScreeningNumber().equals(c.get_newBornScreeningNumber())) {
            if (person1.get_firstName().equals(person2.get_firstName()) &&
                    person1.get_middleName().equals(person2.get_middleName()) &&
                    person1.get_lastName().equals(person2.get_lastName())) {
                if(child.get_motherFirstName().equals(c.get_motherFirstName()) &&
                        child.get_motherMiddleName().equals(c.get_motherMiddleName()) &&
                        child.get_motherLastName().equals(c.get_motherLastName())) {
                    return "TRUE";
                }
            }
        }

        return "FALSE";
    }
}
