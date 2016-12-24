package com.USU.OOP.DataImporterExporterTests;

import com.USU.OOP.Data.XMLDataImporterExporter;
import com.sun.org.apache.xerces.internal.dom.DocumentImpl;
import org.testng.Assert;
import org.testng.annotations.BeforeTest;
import org.testng.annotations.Test;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;

/**
 * Created by Brian Bowles (12/6/16, 11:22 PM).
 */

@Test
public class XMLImporterExporterTests {
    private XMLDataImporterExporter importerExporter;
    private Element element;
    private Document document;
    private Node item;

    @BeforeTest
    public void setup() {
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
    public void CreateObjectsTest() {
        importerExporter = new XMLDataImporterExporter("src/test/java/resources/XML/");
        importerExporter.createObjects(document);
        Assert.assertNotNull(importerExporter.getPeople().isEmpty());
    }

    @Test
    public void ParseFileTest() {
        importerExporter = new XMLDataImporterExporter("src/test/java/resources/XML/");
        Assert.assertTrue(importerExporter.parseFile("TestPerson.xml"));
    }

    @Test
    public void CreateObjectsWithNullXMLDocumentTest() {
        importerExporter = new XMLDataImporterExporter("src/test/java/resources/XML/");
        importerExporter.createObjects(null);
        Assert.assertTrue(importerExporter.getPeople().isEmpty());
    }

    @Test
    public void ParseFileWithNullPathTest() {
        importerExporter = new XMLDataImporterExporter(null);
        Assert.assertFalse(importerExporter.parseFile("TestPerson.xml"));
        importerExporter = new XMLDataImporterExporter("");
        Assert.assertFalse(importerExporter.parseFile("TestPerson.xml"));
    }

    @Test
    public void ParseFileWithNullFileTest() {
        importerExporter = new XMLDataImporterExporter("src/test/java/resources/XML/");
        Assert.assertFalse(importerExporter.parseFile(null));
        Assert.assertFalse(importerExporter.parseFile(""));
    }
}
