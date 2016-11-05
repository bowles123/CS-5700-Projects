package com.USU.OOP.Creators;

import com.USU.OOP.Person.Adult;
import com.USU.OOP.Person.Child;
import com.USU.OOP.Person.Person;
import com.sun.org.apache.xerces.internal.dom.DocumentImpl;
import junit.framework.Assert;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Test;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/8/16
 * Time: 12:22 PM
 * To change this template use File | Settings | File Templates.
 */

@Test
public class CreatePersonFromXMLTest {
    private Element element;
    private CreatePerson creator;
    private Document document;
    Person person;
    private Node item;

    @BeforeTest
    private void setUp() {
        item = null;
        document = new DocumentImpl();
        element = document.createElement("Person");

        item = document.createElement("SocialSecurityNumber");
        item.appendChild(document.createTextNode("123-45-6789"));
        element.appendChild(item);
        item = document.createElement("StateFileNumber");
        item.appendChild(document.createTextNode("7464637"));
        element.appendChild(item);
        item = document.createElement("FirstName");
        item.appendChild(document.createTextNode("John"));
        element.appendChild(item);
        item = document.createElement("MiddleName");
        item.appendChild(document.createTextNode("null"));
        element.appendChild(item);
        item = document.createElement("LastName");
        item.appendChild(document.createTextNode("Doe"));
        element.appendChild(item);
        item = document.createElement("Gender");
        item.appendChild(document.createTextNode("M"));
        element.appendChild(item);

        item = document.createElement("ObjectId");
        item.appendChild(document.createTextNode("1"));
        element.appendChild(item);
        item = document.createElement("BirthDay");
        item.appendChild(document.createTextNode("1"));
        element.appendChild(item);
        item = document.createElement("BirthMonth");
        item.appendChild(document.createTextNode("1"));
        element.appendChild(item);
        item = document.createElement("BirthYear");
        item.appendChild(document.createTextNode("1996"));
        element.appendChild(item);
    }

    @Test
    public void createAdultTest() {
        creator = new CreateAdultFromXML();
        Adult adult;

        item = document.createElement("Phone1");
        item.appendChild(document.createTextNode("null"));
        element.appendChild(item);
        item = document.createElement("Phone2");
        item.appendChild(document.createTextNode("null"));
        element.appendChild(item);

        person = creator.create(element);
        Assert.assertNotNull(person);
        Assert.assertTrue(person.getClass().getSimpleName().equals("Adult"));
        adult = (Adult) person;

        Assert.assertNotNull(person.get_firstName());
        Assert.assertNotNull(person.get_lastName());
        Assert.assertNotNull(person.get_socialSecurityNumber());
        Assert.assertNotNull(adult.get_phoneOne());
        Assert.assertNotNull(adult.get_phoneTwo());

        Assert.assertEquals(1, person.get_objectId());
        Assert.assertEquals("John", person.get_firstName());
        Assert.assertEquals("Doe", person.get_lastName());
        Assert.assertEquals(1, person.get_birthDay());
        Assert.assertEquals(1, person.get_birthMonth());
        Assert.assertEquals(1996, person.get_birthYear());
        Assert.assertEquals("123-45-6789", person.get_socialSecurityNumber());
    }

    @Test
    public void createChildTest() {
        creator = new CreateChildFromXML();
        Child child;

        item = document.createElement("NewbornScreeningNumber");
        item.appendChild(document.createTextNode("746353"));
        element.appendChild(item);
        item = document.createElement("BirthCounty");
        item.appendChild(document.createTextNode("Utah"));
        element.appendChild(item);
        item = document.createElement("BirthOrder");
        item.appendChild(document.createTextNode("0"));
        element.appendChild(item);
        item = document.createElement("IsPartOfMultipleBirth");
        item.appendChild(document.createTextNode("F"));
        element.appendChild(item);

        item = document.createElement("MotherFirstName");
        item.appendChild(document.createTextNode("Jane"));
        element.appendChild(item);
        item = document.createElement("MotherMiddleName");
        item.appendChild(document.createTextNode("null"));
        element.appendChild(item);
        item = document.createElement("MotherLastName");
        item.appendChild(document.createTextNode("null"));
        element.appendChild(item);

        person = creator.create(element);
        Assert.assertNotNull(person);
        Assert.assertTrue(person.getClass().getSimpleName().equals("Child"));
        child = (Child) person;

        Assert.assertNotNull(person.get_firstName());
        Assert.assertNotNull(person.get_lastName());
        Assert.assertNotNull(child.get_newBornScreeningNumber());
        Assert.assertNotNull(child.get_motherFirstName());
        Assert.assertNotNull(child.get_motherLastName());

        Assert.assertEquals(1, person.get_objectId());
        Assert.assertEquals("John", person.get_firstName());
        Assert.assertEquals("Doe", person.get_lastName());
        Assert.assertEquals(1, person.get_birthDay());
        Assert.assertEquals(1, person.get_birthMonth());
        Assert.assertEquals(1996, person.get_birthYear());
        Assert.assertEquals("746353", child.get_newBornScreeningNumber());
        Assert.assertEquals("Jane", child.get_motherFirstName());
    }
}
