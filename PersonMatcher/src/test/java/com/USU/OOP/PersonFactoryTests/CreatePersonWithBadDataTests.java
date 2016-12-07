package com.USU.OOP.PersonFactoryTests;

import com.USU.OOP.Person.Person;
import com.USU.OOP.Person.PersonFactory;
import com.sun.org.apache.xerces.internal.dom.DocumentImpl;
import junit.framework.Assert;
import org.json.JSONObject;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Test;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

/**
 * Created by Brian Bowles (12/1/16, 4:57 PM).
 */
@Test
public class CreatePersonWithBadDataTests {
    private JSONObject JSON;
    private Element XML;
    private Person person;
    private Document document;
    private PersonFactory factory;

    @BeforeTest
    public void setup() {
        JSON = new JSONObject();
        document = new DocumentImpl();
        XML = document.createElement("Person");
        factory = new PersonFactory();
    }

    @Test
    public void CreatePersonWithUnknownTypeTest() {
        person = factory.Create("Alien", "JSON", JSON);
        Assert.assertNull(person);

        person = factory.Create("Alien", "XML", XML);
        Assert.assertNull(person);
    }

    @Test
    public void CreatePersonWithUnknownFromTest() {
        person = factory.Create("Child", "Text", JSON);
        Assert.assertNull(person);

        person = factory.Create("Adult", "Text", JSON);
        Assert.assertNull(person);
    }

    @Test
    public void CreatePersonWithNullObjectTest() {
        person = factory.Create("Child", "JSON", null);
        Assert.assertNull(person);

        person = factory.Create("Adult", "JSON", null);
        Assert.assertNull(person);
    }
}
