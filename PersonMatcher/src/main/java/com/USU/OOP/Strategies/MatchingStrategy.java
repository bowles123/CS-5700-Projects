package com.USU.OOP.Strategies;

import com.USU.OOP.Person.Person;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/5/16
 * Time: 9:58 PM
 * To change this template use File | Settings | File Templates.
 */

public interface MatchingStrategy {
    public abstract String match(Person person1, Person person2);
}
