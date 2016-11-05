package com.USU.OOP.Strategies;

import com.USU.OOP.Person.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/7/16
 * Time: 7:48 PM
 * To change this template use File | Settings | File Templates.
 */

public class CompleteBirthNameGenderStrategy implements MatchingStrategy {
    public CompleteBirthNameGenderStrategy() { super(); }

    @Override
    public String match(Person person1, Person person2) {
        if(person1.get_gender().equals("null") || person2.get_gender().equals("null") ||
                person1.get_firstName().equals("null") || person2.get_firstName().equals("null") ||
                person1.get_middleName().equals("null") || person2.get_middleName().equals("null") ||
                person1.get_lastName().equals("null") || person2.get_lastName().equals("null") ||
                person1.get_birthDay() <= 0 || person2.get_birthDay() <= 0 ||
                person1.get_birthMonth() <= 0 || person2.get_birthMonth() <= 0 ||
                person1.get_birthYear() <= 0 || person2.get_birthYear() <= 0) {
            return null;
        }
        
        if (person1.get_gender().equals(person2.get_gender())) {
            if (person1.get_firstName().equals(person2.get_firstName()) &&
                    person1.get_middleName().equals(person2.get_middleName()) &&
                    person1.get_lastName().equals(person2.get_lastName())) {
                if (person1.get_birthDay() == person2.get_birthDay() &&
                        person1.get_birthMonth() == person2.get_birthMonth() &&
                        person1.get_birthYear() == person2.get_birthYear()) {
                    return "TRUE";
                }
            }
        }

        return "FALSE";
    }
}
