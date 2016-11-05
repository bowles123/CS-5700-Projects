package com.USU.OOP.Creators;

import com.USU.OOP.Person.Child;
import com.USU.OOP.Person.Person;
import org.json.JSONObject;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/5/16
 * Time: 9:44 PM
 * To change this template use File | Settings | File Templates.
 */

public class CreateChildFromJSON implements CreatePerson{
    @Override
    public Person create(Object object) {
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
}
