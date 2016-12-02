package com.USU.OOP.Strategies;

import com.USU.OOP.Person.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/5/16
 * Time: 9:58 PM
 * To change this template use File | Settings | File Templates.
 */

public abstract class MatchingStrategy {
    protected Person first;
    protected Person second;
    protected abstract boolean IsNull();
    protected abstract boolean Compare();

    public String Match(Person person1, Person person2) {
        first = person1;
        second = person2;

        if (IsNull()) {
            return null;
        } else if (Compare()) {
            return "TRUE";
        }
        return "FALSE";
    }
}
