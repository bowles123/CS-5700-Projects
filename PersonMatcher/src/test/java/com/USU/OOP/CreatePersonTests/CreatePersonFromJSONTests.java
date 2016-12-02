package com.USU.OOP.CreatePersonTests;

import com.USU.OOP.Person.Adult;
import com.USU.OOP.Person.Child;
import com.USU.OOP.Person.Person;
import com.USU.OOP.Person.PersonFactory;
import junit.framework.Assert;
import org.json.JSONObject;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Test;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/8/16
 * Time: 12:19 PM
 * To change this template use File | Settings | File Templates.
 */

@Test
public class CreatePersonFromJSONTests {
    private JSONObject object;
    private Person person;
    private PersonFactory factory;

    @BeforeTest
    public void setUp() {
        object = new JSONObject();
        factory = new PersonFactory();

        object.put("ObjectId", 1);
        object.put("FirstName", "Brian");
        object.put("MiddleName", "C");
        object.put("LastName", "Bowles");
        object.put("BirthDay", 10);
        object.put("BirthMonth", 3);
        object.put("BirthYear", 1990);
        object.put("SocialSecurityNumber", "123-45-6789");
        object.put("StateFileNumber", "9876");
        object.put("Gender", "M");
    }

    @Test
    public void createAdultTest() {
        Adult adult;

        object.put("__type", "Adult");
        object.put("Phone1", "435-567-8910");
        object.put("Phone2", "");

        person = factory.Create("Adult", "JSON", object);
        Assert.assertNotNull(person);
        Assert.assertTrue(person.getClass().getSimpleName().equals("Adult"));
        adult = (Adult) person;

        Assert.assertNotNull(person.get_firstName());
        Assert.assertNotNull(person.get_lastName());
        Assert.assertNotNull(person.get_socialSecurityNumber());
        Assert.assertNotNull(adult.get_phoneOne());

        Assert.assertEquals(1, person.get_objectId());
        Assert.assertEquals("Brian", person.get_firstName());
        Assert.assertEquals("Bowles", person.get_lastName());
        Assert.assertEquals(10, person.get_birthDay());
        Assert.assertEquals(3, person.get_birthMonth());
        Assert.assertEquals(1990, person.get_birthYear());
        Assert.assertEquals("123-45-6789", person.get_socialSecurityNumber());
        Assert.assertEquals("435-567-8910", adult.get_phoneOne());
    }

    @Test
    public void createChildTest() {
        Child child;

        object.put("__type", "Child");
        object.put("BirthCounty", "Iron");
        object.put("IsPartOfMultipleBirth", "F");
        object.put("BirthOrder", 0);
        object.put("NewbornScreeningNumber", "12345");
        object.put("MotherFirstName", "Jenifer");
        object.put("MotherMiddleName", "L");
        object.put("MotherLastName", "Sanderson");

        person = factory.Create("Child", "JSON", object);
        Assert.assertNotNull(person);
        Assert.assertTrue(person.getClass().getSimpleName().equals("Child"));
        child = (Child) person;

        Assert.assertNotNull(person.get_firstName());
        Assert.assertNotNull(person.get_lastName());
        Assert.assertNotNull(child.get_newBornScreeningNumber());
        Assert.assertNotNull(child.get_motherFirstName());
        Assert.assertNotNull(child.get_motherLastName());

        Assert.assertEquals(1, person.get_objectId());
        Assert.assertEquals("Brian", person.get_firstName());
        Assert.assertEquals("Bowles", person.get_lastName());
        Assert.assertEquals(10, person.get_birthDay());
        Assert.assertEquals(3, person.get_birthMonth());
        Assert.assertEquals(1990, person.get_birthYear());
        Assert.assertEquals("12345", child.get_newBornScreeningNumber());
        Assert.assertEquals("Jenifer", child.get_motherFirstName());
        Assert.assertEquals("Sanderson", child.get_motherLastName());
    }
}
