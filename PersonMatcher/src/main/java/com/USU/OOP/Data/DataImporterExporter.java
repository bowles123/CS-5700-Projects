package com.USU.OOP.Data;

import com.USU.OOP.Creators.CreatePerson;
import com.USU.OOP.Person.Person;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/5/16
 * Time: 9:54 PM
 * To change this template use File | Settings | File Templates.
 */

public abstract class DataImporterExporter {
    protected List<Person> people;
    protected String filePath;

    public abstract void parseFile(String fileName);
    public abstract void saveData(String fileName, Map<Person, List<Person>> matches);
    public List<Person> getPeople() { return people; }

    public DataImporterExporter() {
        people = new ArrayList<Person>();
    }

    protected Person createPerson(Object object, CreatePerson creator) {
        return creator.create(object);
    }
}
