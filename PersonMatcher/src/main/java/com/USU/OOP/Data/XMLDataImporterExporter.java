package com.USU.OOP.Data;

import com.USU.OOP.Person.Person;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import java.io.File;
import java.util.List;
import java.util.Map;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/6/16
 * Time: 2:37 PM
 * To change this template use File | Settings | File Templates.
 */

public class XMLDataImporterExporter extends DataImporterExporter {
    public XMLDataImporterExporter(String path) {
        filePath = path;
    }

    @Override
    public void parseFile(String fileName) {
        String file = filePath + fileName;
        try {
            File inputFile = new File(file);
            DocumentBuilderFactory documentBuilderFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder documentBuilder = documentBuilderFactory.newDocumentBuilder();
            Document document = documentBuilder.parse(inputFile);
            createObjects(document);
        } catch(Exception e) {
            e.printStackTrace();
        }
    }

    private void createObjects(Document doc) {
        NodeList nodeList;
        Node node;
        Element element;

        doc.normalize();
        nodeList = doc.getElementsByTagName("Person");

        for (int i = 0; i < nodeList.getLength(); i++) {
            node = nodeList.item(i);

            if(node.getNodeType() == Node.ELEMENT_NODE) {
                element = (Element) node;

                if (element.getAttributes().item(0).getNodeValue().equals("Adult")) {
                    people.add(factory.Create("Adult", "XML", element));
                } else {
                    people.add(factory.Create("Child", "XML", element));
                }
            }
        }

    }

    @Override
    public void saveData(String fileName, Map<Person, List<Person>> matches) throws NotImplementedException {
        System.out.println("Saving data in XML format is not implemented.");
        throw new NotImplementedException();
    }
}
