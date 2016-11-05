package com.USU.OOP.Creators;

import com.USU.OOP.Person.Child;
import com.USU.OOP.Person.Person;
import org.w3c.dom.Element;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/8/16
 * Time: 12:57 PM
 * To change this template use File | Settings | File Templates.
 */

public class CreateChildFromXML implements CreatePerson {
    @Override
    public Person create(Object obj) {
        Child child = new Child();
        Element element = (Element) obj;

        child.set_objectId(Integer.parseInt(element.getElementsByTagName("ObjectId").item(0).getTextContent()));
        child.setBirthDate(Integer.parseInt(element.getElementsByTagName("BirthDay").item(0).getTextContent()),
                Integer.parseInt(element.getElementsByTagName("BirthMonth").item(0).getTextContent()),
                Integer.parseInt(element.getElementsByTagName("BirthYear").item(0).getTextContent()));

        child.set_socialSecurityNumber(element.getElementsByTagName("SocialSecurityNumber").item(0).getTextContent());
        child.set_stateFileNumber(element.getElementsByTagName("StateFileNumber").item(0).getTextContent());
        child.setGender(element.getElementsByTagName("Gender").item(0).getTextContent());
        child.setName(element.getElementsByTagName("FirstName").item(0).getTextContent(),
                element.getElementsByTagName("MiddleName").item(0).getTextContent(),
                element.getElementsByTagName("LastName").item(0).getTextContent());
        child.setMotherName(element.getElementsByTagName("MotherFirstName").item(0).getTextContent(),
                element.getElementsByTagName("MotherMiddleName").item(0).getTextContent(),
                element.getElementsByTagName("MotherLastName").item(0).getTextContent());
        child.set_birthCounty(element.getElementsByTagName("BirthCounty").item(0).getTextContent());
        child.set_birthOrder(Integer.parseInt(element.getElementsByTagName("BirthOrder").item(0).getTextContent()));
        child.set_isPartOfMultipleBirth(element.getElementsByTagName("IsPartOfMultipleBirth").item(0).getTextContent());
        child.set_newBornScreeningNumber(element.getElementsByTagName("NewbornScreeningNumber").item(0).getTextContent());

        return child;
    }
}
