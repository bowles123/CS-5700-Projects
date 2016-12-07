package com.USU.OOP.DataImporterExporterTests;

import com.USU.OOP.Data.JSONDataImporterExporter;
import org.json.JSONObject;
import org.testng.Assert;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Test;

/**
 * Created by Brian Bowles (12/6/16, 11:23 PM).
 */

@Test
public class JSONImporterExporterTests {
    private JSONDataImporterExporter importerExporter;
    private String string;

    @BeforeTest
    public void setup() {
        string = "[{\"__type\":\"Adult:#PersonMatcher.DataObjects\",\"BirthDay\":27,\"BirthMonth\":8,\"BirthYear\":1997," +
                "\"FirstName\":\"Lise\",\"Gender\":\"F\",\"LastName\":\"Peterson\",\"MiddleName\":\"J\",\"ObjectId\":6," +
                "\"SocialSecurityNumber\":\"048517811\",\"StateFileNumber\":\"1997 51931\",\"Phone1\":null,\"Phone2\":null}]";
    }

    @Test
    public void CreateObjectsTest() {
        importerExporter = new JSONDataImporterExporter(string, "src/test/java/resources/JSON/");
        importerExporter.createObjects();
        Assert.assertFalse(importerExporter.getPeople().isEmpty());
    }

    @Test
    public void ParseFileTest() {
        importerExporter = new JSONDataImporterExporter(string, "src/test/java/resources/JSON/");
        Assert.assertTrue(importerExporter.parseFile("TestPerson.json"));
    }

    @Test
    public void CreateObjectsWithBadJSONStringTest() {
        importerExporter = new JSONDataImporterExporter("", "src/test/java/resources/JSON/");
        importerExporter.createObjects();
        Assert.assertTrue(importerExporter.getPeople().isEmpty());
    }

    @Test
    public void ParseFileWithNullPathTest() {
        importerExporter = new JSONDataImporterExporter(string, null);
        Assert.assertFalse(importerExporter.parseFile("TestPerson.json"));
        importerExporter = new JSONDataImporterExporter(string, "");
        Assert.assertFalse(importerExporter.parseFile("TestPerson.json"));
    }

    @Test
    public void ParseFileWithNullFileTest() {
        importerExporter = new JSONDataImporterExporter(string.toString(), "src/test/java/resources/JSON/");
        Assert.assertFalse(importerExporter.parseFile(null));
        Assert.assertFalse(importerExporter.parseFile(""));
    }
}
