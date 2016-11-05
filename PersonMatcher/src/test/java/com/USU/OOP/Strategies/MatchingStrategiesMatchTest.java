package com.USU.OOP.Strategies;

import com.USU.OOP.Person.Adult;
import com.USU.OOP.Person.Child;
import com.USU.OOP.Person.Person;
import junit.framework.Assert;
import org.testng.annotations.Test;

/**
 * Created by Brian Bowles (9/8/16, 3:46 PM).
 */

@Test
public class MatchingStrategiesMatchTest {
    private MatchingStrategy strategy;
    private String match;
    private Person person;
    private Person person1;

    @Test
    public void CompleteBirthNameGenderStrategyMatchTest() {
        strategy = new CompleteBirthNameGenderStrategy();

        person = new Adult();
        person.setBirthDate(1990, 12, 13);
        person.setName("Brian", "Chalmer", "Bowles");
        person.setGender("M");
        person.set_objectId(1);

        person1 = new Child();
        person1.setBirthDate(1990, 12, 13);
        person1.setName("Brian", "Chalmer", "Bowles");
        person1.setGender("M");
        person1.set_objectId(2);

        match = strategy.match(person, person1);

        Assert.assertNotNull(match);
        Assert.assertEquals(match, "TRUE");
    }

    @Test
    public void IdentBirthMotherStrategyMatchTest() {
        strategy = new IdentBirthMotherStrategy();
        Child person, person1;

        person = new Child();
        person.set_newBornScreeningNumber("12345");
        person.setBirthDate(1990, 12, 13);
        person.setMotherName("Jenifer", "Lyn", "Sanderson");
        person.set_objectId(1);

        person1 = new Child();
        person1.set_newBornScreeningNumber("12345");
        person1.setBirthDate(1990, 12, 13);
        person1.setMotherName("Jenifer", "Lyn", "Sanderson");
        person1.setGender("M");
        person1.set_objectId(2);

        match = strategy.match(person, person1);

        Assert.assertNotNull(match);
        Assert.assertEquals(match, "TRUE");
    }

    @Test
    public void IdentBirthStrategyMatchTest() {
        strategy = new IdentBirthStrategy();

        person = new Adult();
        person.set_socialSecurityNumber("123-45-6789");
        person.setBirthDate(1990, 12, 13);
        person.set_objectId(1);

        person1 = new Child();
        person1.set_socialSecurityNumber("123-45-6789");
        person1.setBirthDate(1990, 12, 13);
        person1.set_objectId(2);

        match = strategy.match(person, person1);

        Assert.assertNotNull(match);
        Assert.assertEquals(match, "TRUE");
    }

    @Test
    public void IdentNameMotherStrategyMatchTest() {
        strategy = new IdentNameMotherStrategy();
        Child person, person1;

        person = new Child();
        person.set_newBornScreeningNumber("12345");
        person.setName("Brian", "Chalmer", "Bowles");
        person.setMotherName("Jenifer", "Lyn", "Sanderson");
        person.set_objectId(1);

        person1 = new Child();
        person1.set_newBornScreeningNumber("12345");
        person1.setName("Brian", "Chalmer", "Bowles");
        person1.setMotherName("Jenifer", "Lyn", "Sanderson");
        person1.setGender("M");
        person1.set_objectId(2);

        match = strategy.match(person, person1);

        Assert.assertNotNull(match);
        Assert.assertEquals(match, "TRUE");
    }

    @Test
    public void IdentNameStrategyMatchTest() {
        strategy = new IdentNameStrategy();

        person = new Adult();
        person.set_socialSecurityNumber("123-45-6789");
        person.setName("Brian", "Chalmer", "Bowles");
        person.set_objectId(1);

        person1 = new Child();
        person1.set_socialSecurityNumber("123-45-6789");
        person1.setName("Brian", "Chalmer", "Bowles");
        person1.set_objectId(2);

        match = strategy.match(person, person1);

        Assert.assertNotNull(match);
        Assert.assertEquals(match, "TRUE");
    }
}
