package com.USU.OOP.Strategies;

import com.USU.OOP.Person.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/7/16
 * Time: 7:46 PM
 * To change this template use File | Settings | File Templates.
 */

public class IdentNameStrategy implements MatchingStrategy {
    public IdentNameStrategy() { super(); }

    @Override
    public String match(Person person1, Person person2) {
        if (person1.get_socialSecurityNumber().equals("null") || person2.get_socialSecurityNumber().equals("null") ||
                person1.get_firstName().equals("null") || person2.get_firstName().equals("null") ||
                person1.get_middleName().equals("null") || person2.get_middleName().equals("null") ||
                person1.get_lastName().equals("null") || person2.get_lastName().equals("null")) {
            return null;
        }

        if (person1.get_socialSecurityNumber().equals(person2.get_socialSecurityNumber())) {
            if (person1.get_firstName().equals(person2.get_firstName()) &&
                    person1.get_middleName().equals(person2.get_middleName()) &&
                    person1.get_lastName().equals(person2.get_lastName())) {
                return "TRUE";
            }
        }

        return "FALSE";
    }
}
