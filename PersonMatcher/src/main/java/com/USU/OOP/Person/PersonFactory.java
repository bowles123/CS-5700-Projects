package com.USU.OOP.Person;

import org.json.JSONObject;
import org.w3c.dom.Element;

/**
 * Created by Brian Bowles (12/1/16, 12:12 PM).
 */
public class PersonFactory {
    public Person Create(String type, String from, Object obj) {
        if (obj == null) return null;

        if (type == "Adult") {
            if (from == "XML") {
                return CreateAdultFromXML(obj);
            } else if (from == "JSON") {
                return CreateAdultFromJSON(obj);
            } else {
                return null;
            }
        } else if (type == "Child") {
            if (from == "XML") {
                return CreateChildFromXML(obj);
            } else if (from == "JSON") {
                return CreateChildFromJSON(obj);
            } else {
                return null;
            }
        } else {
            return null;
        }
    }

    private Person CreateAdultFromJSON(Object object) {
        Adult person = new Adult();
        JSONObject obj = (JSONObject) object;

        person.setBirthDate(obj.getInt("BirthDay"), obj.getInt("BirthMonth"), obj.getInt("BirthYear"));
        person.setName(obj.get("FirstName").toString(), obj.get("MiddleName").toString(), obj.get("LastName").toString());
        person.setGender(obj.get("Gender").toString());
        person.set_objectId(obj.getInt("ObjectId"));
        person.set_socialSecurityNumber(obj.get("SocialSecurityNumber").toString());
        person.set_stateFileNumber(obj.get("StateFileNumber").toString());
        person.setPhoneNumbers(obj.get("Phone1").toString(), obj.get("Phone2").toString());

        return person;
    }

    private Person CreateAdultFromXML(Object object) {
        Adult adult = new Adult();
        Element element = (Element) object;

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

    private Person CreateChildFromJSON(Object object) {
        Child person = new Child();
        JSONObject obj = (JSONObject) object;

        person.setBirthDate(obj.getInt("BirthDay"), obj.getInt("BirthMonth"), obj.getInt("BirthYear"));
        person.setName(obj.get("FirstName").toString(), obj.get("MiddleName").toString(), obj.get("LastName").toString());
        person.setGender(obj.get("Gender").toString());
        person.set_objectId(obj.getInt("ObjectId"));
        person.set_socialSecurityNumber(obj.get("SocialSecurityNumber").toString());
        person.set_stateFileNumber(obj.get("StateFileNumber").toString());
        person.set_birthCounty(obj.get("BirthCounty").toString());
        person.set_birthOrder(obj.getInt("BirthOrder"));
        person.set_isPartOfMultipleBirth(obj.get("IsPartOfMultipleBirth").toString());
        person.setMotherName(obj.get("MotherFirstName").toString(), obj.get("MotherMiddleName").toString(),
                obj.get("MotherLastName").toString());
        person.set_newBornScreeningNumber(obj.get("NewbornScreeningNumber").toString());

        return person;
    }

    private Person CreateChildFromXML(Object object) {
        Child child = new Child();
        Element element = (Element) object;

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
