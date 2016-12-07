package com.USU.OOP.PersonMatcherTests;

import com.USU.OOP.Person.Person;
import com.USU.OOP.PersonMatcher;
import org.testng.Assert;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Test;

import java.util.List;

/**
 * Created by Brian Bowles (12/6/16, 11:30 PM).
 */

@Test
public class PersonMatcherInvalidInputTests {
    private List<Person> ppl;
    private PersonMatcher personMatcher;

    @BeforeTest
    public void setup() {
        personMatcher = new PersonMatcher();
    }

    @Test
    public void readInDataBadInputTypeTest() {
        ppl = personMatcher.readInData(null,  "TestPerson.xml", "src/test/java/resources/XML/");
        Assert.assertNull(ppl);
    }

    @Test
    public void readInDataBadInFileTest() {
        ppl = personMatcher.readInData("XML", null, "src/test/java/resources/XML/");
        Assert.assertNull(ppl);
    }

    @Test
    public void readInDataBadFilePathTest() {
        ppl = personMatcher.readInData("XML",  "TestPerson.xml", null);
        Assert.assertNull(ppl);
    }
}
