package com.USU.OOP.Strategies;

import com.USU.OOP.Person.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/7/16
 * Time: 7:45 PM
 * To change this template use File | Settings | File Templates.
 */

public class IdentBirthStrategy implements MatchingStrategy {
    public IdentBirthStrategy() { super(); }

    @Override
    public String match(Person person1, Person person2) {
        if (person1.get_socialSecurityNumber().equals("null") || person2.get_socialSecurityNumber().equals("null") ||
                person1.get_birthDay() <= 0 || person2.get_birthDay() <= 0 ||
                person1.get_birthMonth() <= 0 || person2.get_birthMonth() <= 0 ||
                person1.get_birthYear() <= 0 || person2.get_birthYear() <= 0) {
            return null;
        }

        if (person1.get_socialSecurityNumber().equals(person2.get_socialSecurityNumber())) {
            if (person1.get_birthDay() == person2.get_birthDay() &&
                    person1.get_birthMonth() == person2.get_birthMonth() &&
                    person1.get_birthYear() == person2.get_birthYear()) {
                return "TRUE";
            }
        }

        return "FALSE";
    }
}
