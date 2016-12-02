package com.USU.OOP;

import com.USU.OOP.Person.Adult;
import com.USU.OOP.Person.Child;
import com.USU.OOP.Person.Person;
import junit.framework.Assert;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Test;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;


/**
 * Created by Brian Bowles (9/13/16, 11:13 PM).
 */

@Test
public class PersonMatcherTests {
    private List<Person> ppl;
    private PersonMatcher personMatcher;
    private Map<Person, List<Person>> matches;

    @BeforeTest
    public void setup() {
        personMatcher = new PersonMatcher();
    }
    
    @Test
    public void matchTest() {
        List<Person> person1Matches, person2Matches, person3Matches, person4Matches;
        Person person1, person3;
        Child person2, person4;
        ppl = new ArrayList<Person>();

        person1 = new Adult();
        person1.setGender("M");
        person1.setName("Brian", "null", "Bowles");
        person1.setBirthDate(13, 3, 1994);
        person1.set_socialSecurityNumber("123-45-6789");
        person1.set_objectId(1);

        person2 = new Child();
        person2.setGender("M");
        person2.set_socialSecurityNumber("123-45-6789");
        person2.setName("Brian", "Chalmer", "Bowles");
        person2.setBirthDate(13, 3, 1994);
        person2.set_newBornScreeningNumber("83736");
        person2.setMotherName("Jenifer", "Lyn", "Sanderson");
        person2.set_objectId(2);

        person3 = new Adult();
        person3.setGender("M");
        person3.setName("Brian", "Chalmer", "Bowles");
        person3.setBirthDate(13, 3, 1994);
        person3.set_socialSecurityNumber("null");
        person3.set_objectId(3);

        person4 = new Child();
        person4.set_newBornScreeningNumber("83736");
        person4.set_socialSecurityNumber("123-45-6789");
        person4.setGender("M");
        person4.setName("Brian", "Chalmer", "Bowles");
        person4.setBirthDate(13, 3, 1994);
        person4.setMotherName("Jenifer", "null", "Sanderson");
        person4.set_objectId(4);

        ppl.add(person1);
        ppl.add(person2);
        ppl.add(person3);
        ppl.add(person4);
        personMatcher.setPeople(ppl);
        personMatcher.match();
        matches = personMatcher.getMatches();

        Assert.assertNotNull(matches);
        Assert.assertTrue(matches.size() > 0);
        person1Matches = matches.get(person1);
        person2Matches = matches.get(person2);
        person3Matches = matches.get(person3);
        person4Matches = matches.get(person4);

        Assert.assertTrue(person1Matches.size() == 2);
        Assert.assertTrue(person2Matches.size() == 2);
        Assert.assertTrue(person3Matches.size() == 1);
        Assert.assertTrue(person4Matches.size() == 0);

        Assert.assertTrue(person1Matches.contains(person2));
        Assert.assertTrue(person1Matches.contains(person4));
        Assert.assertTrue(person2Matches.contains(person3));
        Assert.assertTrue(person2Matches.contains(person4));
        Assert.assertTrue(person3Matches.contains(person4));
    }

    @Test
    public void readInJSONDataTest() {
        Adult person;
        ppl = personMatcher.readInData(
                "JSON", "TestPerson.json", "src/test/java/resources/JSON/");

        Assert.assertNotNull(ppl);
        Assert.assertTrue(ppl.size() == 1);
        person = (Adult) ppl.get(0);
        Assert.assertNotNull(person);
        Assert.assertTrue(person.getClass().getSimpleName().equals("Adult"));

        Assert.assertEquals(27, person.get_birthDay());
        Assert.assertEquals(8, person.get_birthMonth());
        Assert.assertEquals(1997, person.get_birthYear());
        Assert.assertEquals(6, person.get_objectId());

        Assert.assertEquals("Lise", person.get_firstName());
        Assert.assertEquals("J", person.get_middleName());
        Assert.assertEquals("Peterson", person.get_lastName());
        Assert.assertEquals("F", person.get_gender());
        Assert.assertEquals("048517811", person.get_socialSecurityNumber());
        Assert.assertEquals("1997 51931", person.get_stateFileNumber());
        Assert.assertEquals("null", person.get_phoneOne());
        Assert.assertEquals("null", person.get_phoneTwo());
    }

    @Test
    public void readInXMLDataTest() {
        Adult person;
        ppl = personMatcher.readInData("XML", "TestPerson.xml",
                "src/test/java/resources/XML/");

        Assert.assertNotNull(ppl);
        Assert.assertTrue(ppl.size() == 1);
        person = (Adult) ppl.get(0);
        Assert.assertNotNull(person);
        Assert.assertTrue(person.getClass().getSimpleName().equals("Adult"));

        Assert.assertEquals(7, person.get_birthDay());
        Assert.assertEquals(3, person.get_birthMonth());
        Assert.assertEquals(1995, person.get_birthYear());
        Assert.assertEquals(124, person.get_objectId());

        Assert.assertEquals("Jane", person.get_firstName());
        Assert.assertEquals("Mary", person.get_middleName());
        Assert.assertEquals("Davis", person.get_lastName());
        Assert.assertEquals("F", person.get_gender());
        Assert.assertEquals("614485273", person.get_socialSecurityNumber());
        Assert.assertEquals("1995 01598", person.get_stateFileNumber());
        Assert.assertEquals("435-700-8142", person.get_phoneOne());
        Assert.assertEquals("828-1786", person.get_phoneTwo());
    }
}
