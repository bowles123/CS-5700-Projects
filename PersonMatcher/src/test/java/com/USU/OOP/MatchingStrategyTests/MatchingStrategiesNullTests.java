package com.USU.OOP.MatchingStrategyTests;

import com.USU.OOP.Person.Adult;
import com.USU.OOP.Person.Child;
import com.USU.OOP.Person.Person;
import com.USU.OOP.Strategies.*;
import org.testng.Assert;
import org.testng.annotations.Test;

/**
 * Created by Brian Bowles (9/13/16, 4:47 PM).
 */

@Test
public class MatchingStrategiesNullTests {
    private MatchingStrategy strategy;
    private String match;
    private Person person;
    private Person person1;

    @Test
    public void CompleteBirthNameGenderNullTest() {
        strategy = new CompleteBirthNameGenderStrategy();

        person = new Adult();
        person.setName("Brian", "Chalmer", "Bowles");
        person.setGender("M");
        person.set_objectId(1);

        person1 = new Child();
        person1.setBirthDate(2015, 5, 28);
        person1.setName("Wyatt", "Mason", "Bowles");
        person1.setGender("M");
        person1.set_objectId(2);

        match = strategy.Match(person, person1);
        Assert.assertNull(match);
    }

    @Test
    public void IdentBirthMotherStrategyNullTest() {
        strategy = new IdentBirthMotherStrategy();
        Child person, person1;

        person = new Child();
        person.set_newBornScreeningNumber("null");
        person.setBirthDate(1994, 3, 13);
        person.setMotherName("Jenifer", "Lyn", "Sanderson");
        person.setGender("M");
        person.set_objectId(1);

        person1 = new Child();
        person1.set_newBornScreeningNumber("56789");
        person1.setBirthDate(2015, 5, 28);
        person1.setMotherName("Whitney", "Elizabeth", "Thompson");
        person1.setGender("M");
        person1.set_objectId(2);

        match = strategy.Match(person, person1);
        Assert.assertNull(match);
    }

    @Test
    public void IdentBirthStrategyNullTest() {
        strategy = new IdentBirthStrategy();

        person = new Adult();
        person.set_socialSecurityNumber("645-47-8474");
        person.set_objectId(1);

        person1 = new Child();
        person1.set_socialSecurityNumber("456-78-9123");
        person1.setBirthDate(2015, 5, 28);
        person1.set_objectId(2);

        match = strategy.Match(person, person1);
        Assert.assertNull(match);
    }

    @Test
    public void IdentNameMotherStrategyMistmatchTest() {
        strategy = new IdentNameMotherStrategy();
        Child person, person1;

        person = new Child();
        person.set_newBornScreeningNumber("null");
        person.setName("Brian", "Chalmer", "Bowles");
        person.setMotherName("Jenifer", "Lyn", "Sanderson");
        person.setGender("M");
        person.set_objectId(1);

        person1 = new Child();
        person1.set_newBornScreeningNumber("56789");
        person1.setName("Wyatt", "Mason", "Bowles");
        person1.setMotherName("Whitney", "Elizabeth", "Thompson");
        person1.setGender("M");
        person1.set_objectId(2);

        match = strategy.Match(person, person1);
        Assert.assertNull(match);
    }

    @Test
    public void IdentNameStrategyNullTest() {
        strategy = new IdentNameStrategy();

        person = new Adult();
        person.set_socialSecurityNumber("736-38-2826");
        person.setName("Brian", "null", "Bowles");
        person.set_objectId(1);

        person1 = new Child();
        person1.set_socialSecurityNumber("456-78-9123");
        person1.setName("Wyatt", "Mason", "Bowles");
        person1.set_objectId(2);

        match = strategy.Match(person, person1);
        Assert.assertNull(match);
    }

    @Test
    public void OnePersonIsNullTest() {
        strategy = new IdentNameStrategy();

        person = new Adult();
        person.set_socialSecurityNumber("123-45-6789");
        person.setName("Mr.", "John", "Doe");
        person.set_objectId(1);

        match = strategy.Match(person, null);
        Assert.assertNull(match);
    }

    @Test
    public void TwoPeopleAreNullTest() {
        strategy = new IdentBirthMotherStrategy();
        match = strategy.Match(null, null);
        Assert.assertNull(match);
    }
}
