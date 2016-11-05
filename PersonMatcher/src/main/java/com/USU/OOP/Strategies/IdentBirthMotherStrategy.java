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

public class IdentBirthMotherStrategy implements MatchingStrategy {
    public IdentBirthMotherStrategy() { super(); }

    @Override
    public String match(Person person1, Person person2) {
        if (person1.getClass().getSimpleName().equals("Adult") || person2.getClass().getSimpleName().equals("Adult")) {
            return null;
        }

        Child c, child = (Child) person1;
        c = (Child) person2;


        if (child.get_newBornScreeningNumber().equals("null") || c.get_newBornScreeningNumber().equals("null") ||
                person1.get_birthDay() <= 0 || person2.get_birthDay() <= 0 ||
                person1.get_birthMonth() <= 0 || person2.get_birthMonth() <= 0 ||
                person1.get_birthYear() <= 0 || person2.get_birthYear() <= 0 ||
                child.get_motherFirstName().equals("null") || c.get_motherFirstName().equals("null") ||
                child.get_motherMiddleName().equals("null") || c.get_motherMiddleName().equals("null") ||
                child.get_motherLastName().equals("null") || c.get_motherLastName().equals("null")) {
            return null;
        }


        if (child.get_newBornScreeningNumber().equals(c.get_newBornScreeningNumber())) {
            if (person1.get_birthDay() == person2.get_birthDay() &&
                    person1.get_birthMonth() == person2.get_birthMonth() &&
                    person1.get_birthYear() == person2.get_birthYear()) {
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
