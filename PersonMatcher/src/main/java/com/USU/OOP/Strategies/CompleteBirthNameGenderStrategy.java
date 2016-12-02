package com.USU.OOP.Strategies;

import com.USU.OOP.Person.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/7/16
 * Time: 7:48 PM
 * To change this template use File | Settings | File Templates.
 */

public class CompleteBirthNameGenderStrategy extends MatchingStrategy {
    public CompleteBirthNameGenderStrategy() { super(); }

    @Override
    protected boolean Compare() {
        if (first.get_gender().equals(second.get_gender())) {
            if (first.get_firstName().equals(second.get_firstName()) &&
                    first.get_middleName().equals(second.get_middleName()) &&
                    first.get_lastName().equals(second.get_lastName())) {
                if (first.get_birthDay() == second.get_birthDay() &&
                        first.get_birthMonth() == second.get_birthMonth() &&
                        first.get_birthYear() == second.get_birthYear()) {
                    return true;
                }
            }
        }
        return false;
    }

    @Override
    protected boolean IsNull() {
        return (first.get_gender().equals("null") || second.get_gender().equals("null") ||
                first.get_firstName().equals("null") || second.get_firstName().equals("null") ||
                first.get_middleName().equals("null") || second.get_middleName().equals("null") ||
                first.get_lastName().equals("null") || second.get_lastName().equals("null") ||
                first.get_birthDay() <= 0 || second.get_birthDay() <= 0 ||
                first.get_birthMonth() <= 0 || second.get_birthMonth() <= 0 ||
                first.get_birthYear() <= 0 || second.get_birthYear() <= 0);
    }
}
