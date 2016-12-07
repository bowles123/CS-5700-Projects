package com.USU.OOP.MatchingStrategyTest;

import com.USU.OOP.Person.Adult;
import com.USU.OOP.Person.Child;
import com.USU.OOP.Person.Person;
import com.USU.OOP.Strategies.*;
import org.testng.Assert;
import org.testng.annotations.Test;

/**
 * Created by Brian Bowles (9/12/16, 10:27 PM).
 */

@Test
public class MatchingStrategiesMismatchTests {
    private MatchingStrategy strategy;
    private String match;
    private Person person;
    private Person person1;

    @Test
    public void CompleteBirthNameGenderMismatchTest() {
        strategy = new CompleteBirthNameGenderStrategy();

        person = new Adult();
        person.setBirthDate(1970, 3, 1);
        person.setName("Brian", "Chalmer", "Bowles");
        person.setGender("M");
        person.set_objectId(1);

        person1 = new Child();
        person1.setBirthDate(2000, 5, 2);
        person1.setName("Wyatt", "Mason", "Bowles");
        person1.setGender("M");
        person1.set_objectId(2);

        match = strategy.Match(person, person1);
        Assert.assertNotNull(match);
        Assert.assertEquals(match, "FALSE");
    }

    @Test
    public void IdentBirthMotherStrategyMismatchTest() {
        strategy = new IdentBirthMotherStrategy();
        Child person, person1;

        person = new Child();
        person.set_newBornScreeningNumber("12345");
        person.setBirthDate(1970, 3, 1);
        person.setMotherName("Jenifer", "Lyn", "Sanderson");
        person.set_objectId(1);

        person1 = new Child();
        person1.set_newBornScreeningNumber("56789");
        person1.setBirthDate(2000, 5, 28);
        person1.setMotherName("Whitney", "Elizabeth", "Thompson");
        person1.setGender("M");
        person1.set_objectId(2);

        match = strategy.Match(person, person1);
        Assert.assertNotNull(match);
        Assert.assertEquals(match, "FALSE");
    }

    @Test
    public void IdentBirthStrategyMismatchTest() {
        strategy = new IdentBirthStrategy();

        person = new Adult();
        person.set_socialSecurityNumber("123-45-6789");
        person.setBirthDate(1970, 3, 1);
        person.set_objectId(1);

        person1 = new Child();
        person1.set_socialSecurityNumber("456-78-9123");
        person1.setBirthDate(200, 5, 28);
        person1.set_objectId(2);

        match = strategy.Match(person, person1);
        Assert.assertNotNull(match);
        Assert.assertEquals(match, "FALSE");
    }

    @Test
    public void IdentNameMotherStrategyMistmatchTest() {
        strategy = new IdentNameMotherStrategy();
        Child person, person1;

        person = new Child();
        person.set_newBornScreeningNumber("12345");
        person.setName("Brian", "Chalmer", "Bowles");
        person.setMotherName("Jenifer", "Lyn", "Sanderson");
        person.set_objectId(1);

        person1 = new Child();
        person1.set_newBornScreeningNumber("56789");
        person1.setName("Wyatt", "Mason", "Bowles");
        person1.setMotherName("Whitney", "Elizabeth", "Thompson");
        person1.setGender("M");
        person1.set_objectId(2);

        match = strategy.Match(person, person1);
        Assert.assertNotNull(match);
        Assert.assertEquals(match, "FALSE");
    }

    @Test
    public void IdentNameStrategyMismatchTest() {
        strategy = new IdentNameStrategy();

        person = new Adult();
        person.set_socialSecurityNumber("123-45-6789");
        person.setName("Brian", "Chalmer", "Bowles");
        person.set_objectId(1);

        person1 = new Child();
        person1.set_socialSecurityNumber("456-78-9123");
        person1.setName("Wyatt", "Mason", "Bowles");
        person1.set_objectId(2);

        match = strategy.Match(person, person1);
        Assert.assertNotNull(match);
        Assert.assertEquals(match, "FALSE");
    }
}
