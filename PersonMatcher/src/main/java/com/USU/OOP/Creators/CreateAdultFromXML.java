package com.USU.OOP.Creators;

import com.USU.OOP.Person.Adult;
import com.USU.OOP.Person.Person;
import org.w3c.dom.Element;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/8/16
 * Time: 12:57 PM
 * To change this template use File | Settings | File Templates.
 */

public class CreateAdultFromXML implements CreatePerson {
    @Override
    public Person create(Object obj) {
        Adult adult = new Adult();
        Element element = (Element) obj;

        adult.set_objectId(Integer.parseInt(element.getElementsByTagName("ObjectId").item(0).getTextContent()));
        adult.setBirthDate(Integer.parseInt(element.getElementsByTagName("BirthDay").item(0).getTextContent()),
                Integer.parseInt(element.getElementsByTagName("BirthMonth").item(0).getTextContent()),
                Integer.parseInt(element.getElementsByTagName("BirthYear").item(0).getTextContent()));

        adult.set_socialSecurityNumber(element.getElementsByTagName("SocialSecurityNumber").item(0).getTextContent());
        adult.set_stateFileNumber(element.getElementsByTagName("StateFileNumber").item(0).getTextContent());
        adult.setGender(element.getElementsByTagName("Gender").item(0).getTextContent());
        adult.setPhoneNumbers(element.getElementsByTagName("Phone1").item(0).getTextContent(),
                element.getElementsByTagName("Phone2").item(0).getTextContent());
        adult.setName(element.getElementsByTagName("FirstName").item(0).getTextContent(),
                element.getElementsByTagName("MiddleName").item(0).getTextContent(),
                element.getElementsByTagName("LastName").item(0).getTextContent());

        return adult;
    }
}
