package com.USU.OOP.Data;

import com.USU.OOP.Person.Person;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.USU.OOP.Person.PersonFactory;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/6/16
 * Time: 12:58 PM
 * To change this template use File | Settings | File Templates.
 */

public class JSONDataImporterExporter extends DataImporterExporter {
    private String jsonString;

    private  void createObjects() {
        try {
            JSONArray objects = new JSONArray(jsonString);

            for(int i = 0; i < objects.length(); i++) {
                JSONObject object = objects.getJSONObject(i);

                if (object.getString("__type").contains("Adult")) {
                    people.add(factory.Create("Adult", "JSON", object));
                } else {
                    people.add(factory.Create("Child", "XML", object));
                }
            }

        } catch(JSONException exception) {
            exception.printStackTrace();
        }
    }

    public JSONDataImporterExporter(String string, String path) {
        super();
        jsonString = string;
        filePath = path;
    }

    @Override
    public void saveData(String fileName, Map<Person, List<Person>> matches) throws NotImplementedException {
        System.out.println("Saving data in JSON format is not implemented.");
        throw new NotImplementedException();
    }

    @Override
    public void parseFile(String fileName) {
        String file = filePath + fileName;

        try {
            jsonString = new String(Files.readAllBytes(Paths.get(file)));
            createObjects();
        }
        catch(FileNotFoundException exception) {
            System.out.println("Unable to locate file: " + fileName);
            exception.printStackTrace();
        }
        catch(IOException exception) {
            System.out.println("Unable to parse file: " + fileName);
            exception.printStackTrace();
        }
    }
}
